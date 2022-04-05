using AvoidScurvyMVCApplication.Models;
using AvoidScurvyMVCApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AvoidScurvyMVCApplication.Controllers
{
    public class ProductController : Controller
    {
        private AvoidScurvyContext _avoidScurvyContext;
        private IProductRepository _repository;
        private ILogger<ProductController> _logger;
        public ProductController(IProductRepository repository,
            AvoidScurvyContext context, ILogger<ProductController> logger)
        {
            _avoidScurvyContext = context;
            _repository = repository;
            _logger = logger;
        }

        public IActionResult RecreateDatabase()
        {
            DbInitializer.Initialize(_avoidScurvyContext);
            _logger.LogCritical("I just recreated my entire database!");
            return RedirectToAction("Index", "Home");
        }
        public IActionResult GetProducts()
        {
            
            _avoidScurvyContext.Products.ToList();
            //var listProducts = _avoidScurvyContext.Products.ToList();
            var listProducts = _repository.GetAllProducts();

            var ProductsOver100CaloriesSortedByVitCDescending =
                (from product in _avoidScurvyContext.Products
                 where product.Calories > 100
                 orderby product.VitCDailyAmount descending
                 select product).ToList(); //Forces execution.

            var SameQueryUsingExtensionMethods =
                _avoidScurvyContext.Products
                .Where(p => p.Calories > 100)
                .OrderByDescending(p => p.VitCDailyAmount).ToList();

            return View(listProducts); //.NET Core MVC looks for a view to retrieve.
            //The first place .NET looks is in the Views/{ControllerName}/{Actionname}.cshtml.
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            _logger.LogInformation("Add Product form was just retrieved.");
            //This is the GET version of Add Product, therefore it displays an HTML form to the user
            //expecting that they'll fill it out and POST it.
            return View();
        }
        //I have to have a second controller action for accepting the POST of my add Product page.
        //I know that when someone submits my form, they will be providing a Name and a VitCDailyAmount
        [HttpPost]
        [Route("{controller}/AddProduct")]
        public IActionResult AddProductPost(Product product)
        //These parameters are populated from the form.
        {
            _logger.LogInformation("Add Product form was just posted!");
            if (product.Name.Length < 3)
            {
                ViewBag.NameErrorMessage = "Product name to have 3 letters at least.";
            }
            else if (ModelState.IsValid)
            {
                _repository.AddProduct(product);
                //_avoidScurvyContext.Products.Add(product);
                //_avoidScurvyContext.SaveChanges();
                //This if statement is only entered if the Model class that is accepted as input to this method
                //meets its validation rules.
                //I would be storing the new Product Details within a database.
                //AddToDatabase(Name, VitCDailyAmount);
                return RedirectToAction("GetProducts");
            }
            return View("AddProduct", product);
        }
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            //This is the GET version of Add Product, therefore it displays an HTML form to the user
            //expecting that they'll fill it out and POST it.
            var model = _repository.GetProductById(id);
            return View(model);
        }
        //I have to have a second controller action for accepting the POST of my add Product page.
        //I know that when someone submits my form, they will be providing a Name and a VitCDailyAmount
        [HttpPost]
        public IActionResult EditProduct(Product product, int id)
        //These parameters are populated from the form.
        {
            if (ModelState.IsValid)
            {
                product.ProductID = id;
                //This if statement is only entered if the Model class that is accepted as input to this method
                //meets its validation rules.
                //I would be storing the new Product Details within a database.
                //AddToDatabase(Name, VitCDailyAmount);
                _repository.EditProduct(product);
                return RedirectToAction("GetProducts");
            }
            else
            {
                return View(product);
            }
        }
    }
}
