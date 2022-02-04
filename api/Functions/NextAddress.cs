using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using api.Helpers;
using System.Linq;
using System;

namespace api
{
    public class NextAddress : BaseFunction
    {
        public NextAddress(PostcardExchangeContext context) : base(context) { }

        [FunctionName("NextAddress")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
        {
            var clientPrincipal = req.GetPrincipal();
            log.LogInformation($"Call from {clientPrincipal.UserDetails}");

            var user = Context.Users.FirstOrDefault(u => u.UniqueId == clientPrincipal.UserId);
            if (user == null)
            {
                log.LogInformation($"{clientPrincipal.UserDetails} is new user. Need to submit address first");
                return new RedirectResult("/submit");
            }
            else
            {
                // check if user has requested a penpal today
                var currentPostcard = Context.Postcards.Where(p => p.Sender == user && p.Date == DateTime.Today).ToList();

                var recipient = Context.Users.Where(u => u.Id != user.Id).OrderBy(r => Guid.NewGuid()).FirstOrDefault();
                if (recipient == null)
                {
                    log.LogInformation($"No one to send to. Wait till more users register");
                    return new RedirectResult("/index");
                }
                else
                {
                    log.LogInformation($"{clientPrincipal.UserDetails} is returning user. Picking a random address from the DB");
                    // save the transaction to DB, so we can track it
                    Context.Postcards.Add(new Models.Postcard
                    {
                        Date = DateTime.Today,
                        Sender = user,
                        Recipient = recipient
                    });
                    Context.SaveChanges();

                    return new JsonResult(new { recipient.Name, recipient.Address });
                }

            }
        }
    }
}
