using Microsoft.AspNetCore.Identity;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;

namespace WUI.Auth
{
    public class WebUserRole : IdentityRole
    {
        public override string Id { get; set; }

        public override string Name { get; set; }
    }
}