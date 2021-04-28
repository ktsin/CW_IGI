using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WUI.Auth
{
    public class WebUserContext : IdentityDbContext<WebUser>
    {
        public WebUserContext(DbContextOptions<WebUserContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}