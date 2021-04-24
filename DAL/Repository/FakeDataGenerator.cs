using System;
using System.Collections.Generic;
using System.Globalization;
using DAL.Entities;
using Bogus;

namespace DAL.Repository
{
    public static class FakeDataGenerator
    {
        public static List<Category> Categories = new();
        public static List<Good> Goods = new();
        public static List<Managers> Managers = new();
        public static List<Message> Messages = new();
        public static List<Order> Orders = new();
        public static List<Store> Stores = new();
        public static List<User> Users = new();
        public static List<UserBasket> Baskets = new();

        public static void Init(int cont)
        {
            Faker.GlobalUniqueIndex = 1212;
            var userFaker = new Faker<User>()
                .RuleFor(e => e.Id, f => f.IndexGlobal)
                .RuleFor(e => e.Address, f => f.Address.FullAddress())
                .RuleFor(e => e.Birtday,
                    f => f.Date.Between(new DateTime(1980, 1, 1), new DateTime(2000, 11, 11))
                        .ToString(CultureInfo.InvariantCulture))
                .RuleFor(e => e.Name, f => f.Name.FullName())
                .RuleFor(e => e.RegistrationDay,
                    f => f.Date.Between(new DateTime(2021, 1, 1), new DateTime(2021, 11, 11))
                        .ToString(CultureInfo.InvariantCulture));
            FakeDataGenerator.Users.AddRange(userFaker.Generate(cont * 10));
            int storeId = 120;
            var storeFaker = new Faker<Store>()
                .RuleFor(e => e.Id, () => (++storeId))
                .RuleFor(e => e.Address, f => f.Address.FullAddress())
                .RuleFor(e => e.Description, f => f.Lorem.Text())
                .RuleFor(e => e.Name, f => f.Lorem.Word())
                .RuleFor(e => e.OwnerId, (f, k) => f.Random.ListItem(FakeDataGenerator.Users).Id);
            FakeDataGenerator.Stores.AddRange(storeFaker.Generate(cont));
            var managerFaker = new Faker<Managers>()
                .RuleFor(e => e.Id, f => f.IndexGlobal)
                .RuleFor(e => e.UserId, f => f.Random.ListItem(Users).Id)
                .RuleFor(e => e.StoreId, (f => f.Random.ListItem(Stores).Id));
            FakeDataGenerator.Managers.AddRange(managerFaker.Generate(cont));
            var messageFaker = new Faker<Message>()
                .RuleFor(e => e.Id, f => f.IndexGlobal)
                .RuleFor(e => e.SenderId, f => f.Random.ListItem(Users).Id)
                .RuleFor(e => e.RecipientId, f => f.Random.ListItem(Users).Id)
                .RuleFor(e => e.MessageBody, f => f.Lorem.Sentences(3));
            FakeDataGenerator.Messages.AddRange(messageFaker.Generate(30*cont));
            
        }
    }
}