using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using api.Helpers;
using System.Linq;

namespace api
{
  public class AddAddress: BaseFunction
    {
        public AddAddress(PostcardExchangeContext context) : base(context) { }

        [FunctionName("AddAddress")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req, ILogger log)
        {            
            var clientPrincipal = req.GetPrincipal();
            log.LogInformation($"Call from {clientPrincipal.UserDetails}");

            var user = Context.Users.FirstOrDefault(u => u.UniqueId == clientPrincipal.UserId);
            if(user==null) 
            {
                user = new Models.User 
                    {
                        UniqueId = clientPrincipal.UserId,
                        Name = req.Form["preferredName"],
                        Address = req.Form["address"]
                    };
                Context.Users.Add(user);
                log.LogInformation($"{clientPrincipal.UserDetails} is new user. Creating entity");
            } else {
                user.Name = req.Form["preferredName"];
                user.Address = req.Form["address"];
                log.LogInformation($"{clientPrincipal.UserDetails} is returning user. Updating entity");
            }
            
            Context.SaveChanges();
                
            return new RedirectResult("/thankyou");
        }
    }
}
