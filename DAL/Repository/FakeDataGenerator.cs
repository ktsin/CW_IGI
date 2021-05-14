using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            Users.AddRange(userFaker.Generate(cont * 10));
            var storeId = 120;
            var storeFaker = new Faker<Store>()
                .RuleFor(e => e.Id, () => ++storeId)
                .RuleFor(e => e.Address, f => f.Address.FullAddress())
                .RuleFor(e => e.Description, f => f.Lorem.Text())
                .RuleFor(e => e.Name, f => f.Lorem.Word())
                .RuleFor(e => e.OwnerId, (f, k) => f.Random.ListItem(Users).Id);
            Stores.AddRange(storeFaker.Generate(cont));
            var managerFaker = new Faker<Managers>()
                .RuleFor(e => e.Id, f => f.IndexGlobal)
                .RuleFor(e => e.UserId, f => f.Random.ListItem(Users).Id)
                .RuleFor(e => e.StoreId, f => f.Random.ListItem(Stores).Id);
            Managers.AddRange(managerFaker.Generate(cont));
            var messageFaker = new Faker<Message>()
                .RuleFor(e => e.Id, f => f.IndexGlobal)
                .RuleFor(e => e.SenderId, f => f.Random.ListItem(Users).Id)
                .RuleFor(e => e.RecipientId, f => f.Random.ListItem(Users).Id)
                .RuleFor(e => e.MessageBody, f => f.Lorem.Sentences(3));
            Messages.AddRange(messageFaker.Generate(30 * cont));
            var categoryFaker = new Faker<Category>()
                .RuleFor(e => e.Id, f => f.IndexGlobal)
                .RuleFor(e => e.Name, f => f.Commerce.Categories(1)[0])
                .RuleFor(e => e.Description, f => f.Commerce.ProductDescription());
            Categories.AddRange(categoryFaker.Generate(cont));
            var goodFaker = new Faker<Good>()
                .RuleFor(e => e.Id, f => f.IndexGlobal)
                .RuleFor(e => e.Description, f => f.Commerce.ProductDescription())
                .RuleFor(e => e.Name, f => f.Commerce.ProductName())
                .RuleFor(e => e.StoreId, f => f.PickRandom(Stores).Id)
                .RuleFor(e => e.Price, f => f.Random.UInt(100, 10000))
                .RuleFor(e=>e.CategoryId, f=>f.Random.Int(Categories.First(e=>true).Id, Categories.Last(e=>true).Id));
            Goods.AddRange(goodFaker.Generate(cont));
            var orderFaker = new Faker<Order>()
                .RuleFor(e => e.Id, f => f.IndexGlobal)
                .RuleFor(e => e.UserId, f => f.Random.ListItem(Users).Id)
                .RuleFor(e => e.Goods, f => f.Random.ListItems(Goods));
            Orders.AddRange(orderFaker.Generate(cont * 5));
        }
    }
}