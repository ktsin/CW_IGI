using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace WUI.Auth
{
    public class WebUser : IdentityUser
    {
        [DisplayName("User ID")] public override string Id { get; set; }

        public override string Email { get; set; }

        [DisplayName("Email Confirmation")] public override bool EmailConfirmed { get; set; }

        public override string PasswordHash { get; set; }

        [DisplayName("Underlying User ID")] public int UnderlyingUserId { get; set; }
    }
}