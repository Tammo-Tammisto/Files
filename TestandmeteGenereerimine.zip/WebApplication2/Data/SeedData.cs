using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

namespace WebApplication2.Data
{
    public static class SeedData
    {
        public static void Generate(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            AddUsers(userManager);
            AddProducts(context);
        }

        private static void AddUsers(UserManager<IdentityUser> userManager)
        {
            var user = new IdentityUser();
            user.UserName = "mina@example.com";
            user.EmailConfirmed = true;
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, "Polükas2013*");

            userManager.CreateAsync(user).Wait();
        }

        private static void AddProducts(ApplicationDbContext context) 
        { 
            if(context.Products.Count() > 0) 
            {
                return;
            }

            var product = new Product();
            product.Name = "Coca-Cola";

            context.Add(product);
            context.SaveChanges();
        }
    }
}