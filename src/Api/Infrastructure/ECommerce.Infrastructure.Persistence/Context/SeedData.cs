using Bogus;
using ECommerce.Api.Domain.Models;
using ECommerce.Common.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Persistence.Context
{
    public class SeedData
    {
        private static List<User> GetUsers()
        {

            var userFaker = new Faker<User>("tr")
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.CreatedDate, i =>
                         i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
                .RuleFor(i => i.FirstName, i => i.Person.FirstName)
                .RuleFor(i => i.LastName, i => i.Person.LastName)
                .RuleFor(i => i.PhoneNumer, i => i.Random.Int(100000000, 999999999))
                .RuleFor(i => i.IdentityNumber, i => i.Random.Int(100000000, 999999999))
                .RuleFor(u => u.EmailAddress, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                //.RuleFor(i => i.EmailAddress, i => i.Internet.Email())
                .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
                //.RuleFor(i => i.UserName, i => i.Internet.UserName())
                .RuleFor(i => i.Password, i => PasswordEncryptor.Encrypt(i.Internet.Password()))
                .RuleFor(i => i.EmailConfirmed, i => i.PickRandom(true, false))
                        .RuleFor(i => i.Address, i => i.Lorem.Sentence(13, 13))
                    .Generate(50);

            return userFaker;
        }

        public async Task SeedAsync(IConfiguration configuration)
        {
            var dbContextBuilder = new DbContextOptionsBuilder();
            dbContextBuilder.UseSqlServer(configuration.GetConnectionString("Default"));

            var context = new ECommerceDbContext(dbContextBuilder.Options);

            if (context.Users.Any())
            {
                await Task.CompletedTask;
                return;
            }

            var users = GetUsers();
            var userIds = users.Select(i => i.Id);

            await context.Users.AddRangeAsync(users);

            var guids = Enumerable.Range(0, 50).Select(i => Guid.NewGuid()).ToList();
            int counter = 0;

            var shoppingLists = new Faker<Category>("tr")
                        .RuleFor(i => i.Id, i => guids[counter++])
                        .RuleFor(i => i.CategoryName, i => i.Lorem.Word())
                        .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddHours(-10), DateTime.Now.AddHours(-9)))
                        .RuleFor(i => i.CreatedById, i => i.PickRandom(userIds))
                        .Generate(50);

            await context.Categories.AddRangeAsync(shoppingLists);

            var productBrandName = new[] { "Monster", "Casper", "Lenovo", "MSI", "HP", "Acer", "Apple", "Asus", "Dell" };

            var itemBrand = new Faker<ProductBrand>("tr")
                        .RuleFor(i => i.Id, i => Guid.NewGuid())
                        .RuleFor(i => i.CreatedDate, i =>
                                 i.Date.Between(DateTime.Now.AddHours(-9), DateTime.Now.AddHours(-8)))
                        .RuleFor(i => i.ProductBrandName, i => i.PickRandom(productBrandName))
                        .RuleFor(i => i.CategoryID, i => i.PickRandom(guids))
                        .Generate(500);

            await context.ProductBrands.AddRangeAsync(itemBrand);

            var productModelName = new[] { "Abra", "Tulpar", "A5", "A50", "HP", "Acer", "Apple", "Asus", "Dell" };

            var itemModel = new Faker<ProductModel>("tr")
                        .RuleFor(i => i.Id, i => Guid.NewGuid())
                        .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddHours(-9), DateTime.Now.AddHours(-8)))
                        .RuleFor(i => i.ProductModelName, i => i.PickRandom(productModelName))
                        .RuleFor(i => i.Description, i => i.Lorem.Sentence(3, 3))
                        .RuleFor(i => i.Count, i => i.Random.Number(1, 10))
                        .RuleFor(i => i.Price, i => i.Random.Number(1000, 100000))
                        .RuleFor(i => i.CategoryID, i => i.PickRandom(guids))
                        .Generate(500);


            await context.ProductModels.AddRangeAsync(itemModel);

            await context.SaveChangesAsync();
        }
    }
}
