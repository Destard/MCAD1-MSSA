namespace AvoidScurvyMVCApplication.Models
{
    public static class DbInitializer
    {
        public static void Initialize(AvoidScurvyContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Products.Add(new Product()
            {
                //ProductID = 2,
                Name = "Orange",
                Calories = 130,
                VitCDailyAmount = 130,
                StarRating = 5,
                UPC = "OrangeUPC"
            });
            context.Products.Add(new Product()
            {
                //ProductID = 2,
                Name = "Bananas",
                Calories = 130,
                VitCDailyAmount = 130,
                StarRating = 5,
                UPC = "BananasUPC"
            });
            context.Products.Add(new Product()
            {
                //ProductID = 2,
                Name = "Tomatoes",
                Calories = 130,
                VitCDailyAmount = 130,
                StarRating = 5,
                UPC = "TomatoUPC"
            });
            context.SaveChanges();
        }
    }
}
