using Microsoft.AspNetCore.Identity;

namespace WUI.Auth
{
    public class WebUser : IdentityUser
    {
        public int UnderlyingUserId {get; set;}
    }
}