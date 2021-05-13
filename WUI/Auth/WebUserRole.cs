using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WUI.Auth
{
    public class WebUserRole : IdentityRole
    {
        public WebUserRole()
        {
            var a =  Guid.NewGuid().ToString();
            base.Id = a;
            Id = a;
        }
        public WebUserRole(string id, string name) : base(id)
        {
            Id = id;
            name = name;
        }
        
        [Key]
        public override string Id { get; set; }

        public override string Name { get; set; }
    }
}