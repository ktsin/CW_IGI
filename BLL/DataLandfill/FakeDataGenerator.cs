using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using Bogus;

namespace BLL.DataLandfill
{
    public static class FakeDataGenerator
    {
        public static List<DataItem> Images = new();

        public static void Init(int cont)
        {
            var ImageFaker = new Faker<DataItem>()
                .RuleFor(e => e.Id, f => f.Random.Uuid().ToString())
                .RuleFor(e => e.Base64String, f => f.Image.LoremFlickrUrl(320, 320));
            Images.AddRange(ImageFaker.Generate(cont));
        }
    }
}