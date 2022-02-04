using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace api.Helpers {
    public static class HelperExtensions
    {
        public static string Base64Decode(this StringValues base64EncodedData) {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static bool IsAuthenticated(this ClientPrincipal principal) {            
            return principal.UserRoles.Contains("authenticated");
        }

        public static ClientPrincipal GetPrincipal(this HttpRequest req) {
            var header = req.Headers["x-ms-client-principal"];
            var responseMessage = header.Base64Decode();
            return JsonConvert.DeserializeObject<ClientPrincipal>(responseMessage);
        }
    }
}