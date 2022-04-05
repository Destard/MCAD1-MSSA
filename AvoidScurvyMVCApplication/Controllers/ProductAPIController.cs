using AvoidScurvyMVCApplication.Models;
using AvoidScurvyMVCApplication.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AvoidScurvyMVCApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private IProductRepository _repository;
        public ProductAPIController(IProductRepository repository)
        {
            _repository = repository;
        }

        // GET api/<ProductAPIController>/Search/Ora
        [HttpGet("Search/{name}")]
        public IEnumerable<Product> Get(string name)
        {
            return _repository.AutoCompleteProductByName(name);
        }

        // POST api/<ProductAPIController>
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            _repository.AddProduct(product);
        }
    }
}
