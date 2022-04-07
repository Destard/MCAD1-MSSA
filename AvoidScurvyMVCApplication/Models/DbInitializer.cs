using Microsoft.AspNetCore.Identity;

namespace AvoidScurvyMVCApplication.Models
{
    public static class DbInitializer
    {
        public async static Task Initialize(AvoidScurvyContext context, UserManager<AvoidScurvyIdentityUser> userManager)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var StartingUser = new AvoidScurvyIdentityUser()
            {
                Email = "Andrew.Smith@UnitedTraining.com",
                UserName ="Andrew.Smith@UnitedTraining.com"
            };
            await userManager.CreateAsync(StartingUser);
            await userManager.AddPasswordAsync(StartingUser, "DemoPassword1234");
            var userId = await userManager.GetUserIdAsync(StartingUser);
            context.Products.Add(new Product()
            {
                Name = "Orange",
                Calories = 130,
                VitCDailyAmount = 130,
                StarRating = 5,
                UPC = "OrangeUPC",
                ProductViewings = new List<ProductViewing>()
                {
                    new ProductViewing {StoreName = "Local",ViewingTime = DateTime.Now.AddDays(-3),PricePerServing = 5},
                    new ProductViewing {StoreName = "Local",ViewingTime = DateTime.Now,PricePerServing = 6},
                    new ProductViewing {StoreName = "Remote",ViewingTime = DateTime.Now.AddDays(-3),PricePerServing = 7},
                    new ProductViewing {StoreName = "Remote",ViewingTime = DateTime.Now,PricePerServing = 8},
                },
                UserId = userId
            });
            context.Products.Add(new Product()
            {
                Name = "Bananas",
                Calories = 130,
                VitCDailyAmount = 130,
                StarRating = 5,
                UPC = "BananasUPC",
                ProductViewings = new List<ProductViewing>()
                {
                    new ProductViewing {StoreName = "Local",ViewingTime = DateTime.Now.AddDays(-3),PricePerServing = 3},
                    new ProductViewing {StoreName = "Local",ViewingTime = DateTime.Now,PricePerServing = 4},
                    new ProductViewing {StoreName = "Remote",ViewingTime = DateTime.Now.AddDays(-3),PricePerServing = 5},
                    new ProductViewing {StoreName = "Remote",ViewingTime = DateTime.Now,PricePerServing = 6},
                },
                UserId = userId
            });
            context.Products.Add(new Product()
            {
                Name = "Tomatoes",
                Calories = 130,
                VitCDailyAmount = 130,
                StarRating = 5,
                UPC = "TomatoUPC",
                ProductViewings = new List<ProductViewing>()
                {
                    new ProductViewing {StoreName = "Local",ViewingTime = DateTime.Now.AddDays(-3),PricePerServing = 3},
                    new ProductViewing {StoreName = "Local",ViewingTime = DateTime.Now,PricePerServing = 5},
                    new ProductViewing {StoreName = "Remote",ViewingTime = DateTime.Now.AddDays(-3),PricePerServing = 8},
                    new ProductViewing {StoreName = "Remote",ViewingTime = DateTime.Now,PricePerServing = 7},
                },
                UserId = userId
            });
            context.SaveChanges();
        }
    }
}
