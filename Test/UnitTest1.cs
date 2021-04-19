using System;
using DAL.Entities;
using DAL.Repository.EFCore;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            ContextFactory f = new ContextFactory();
            var k = f.CreateDbContext(null);
            k.Users.Add(new User() {Name = "Nadsdssd", Address = "dsdsefw "});
            k.SaveChanges();
        }
    }
}