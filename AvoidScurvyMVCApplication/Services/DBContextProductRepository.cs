using AvoidScurvyMVCApplication.Models;

namespace AvoidScurvyMVCApplication.Services
{
    public class DBContextProductRepository : IProductRepository
    {
        private AvoidScurvyContext _dbContext;
        public DBContextProductRepository(AvoidScurvyContext context)
        {
            _dbContext = context;
        }
        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }
        public void AddProduct(Product p)
        {
            _dbContext.Products.Add(p);
            _dbContext.SaveChanges();
        }
        public void EditProduct(Product p)
        {
            var ProductToEdit = _dbContext.Products.FirstOrDefault(prod => prod.ProductID == p.ProductID);
            if (ProductToEdit == null)
            {
                throw new Exception("Product not found!");
            }
            ProductToEdit.StarRating = p.StarRating;
            ProductToEdit.Name = p.Name;
            ProductToEdit.UPC = p.UPC;
            ProductToEdit.Calories = p.Calories;
            ProductToEdit.VitCDailyAmount = p.VitCDailyAmount;
            _dbContext.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.FirstOrDefault(p => p.ProductID == id);
        }

        public IEnumerable<Product> AutoCompleteProductByName(string name)
        {
            return _dbContext.Products.Where(p => p.Name.StartsWith(name)).ToList();
        }
    }
}
