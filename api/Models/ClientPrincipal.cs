using System.Collections.Generic;

namespace api {
    public class ClientPrincipal 
    {
        public string IdentityProvider {get;set;}
        public string UserId {get;set;}    
        public string UserDetails {get;set;}
        public List<string> UserRoles {get;set;}
    }
}