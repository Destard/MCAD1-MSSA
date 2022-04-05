using AvoidScurvyMVCApplication.Models;

namespace AvoidScurvyMVCApplication.Services
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        void AddProduct(Product p);
        void EditProduct(Product p);
        Product GetProductById(int id);
        IEnumerable<Product> AutoCompleteProductByName(string name);
        //void AddProductViewing(ProductViewing pv);
        //There are more actions that we need to expose.
    }
}
