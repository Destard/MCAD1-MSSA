using AvoidScurvyMVCApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvoidScurvyMVCApplication.ViewComponents
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        private readonly AvoidScurvyContext _dbContext;
        public ProductSummaryViewComponent(AvoidScurvyContext context)
        {
            _dbContext = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(
            int productId)
        {
            var viewings = _dbContext.ProductViewings.Where(v => v.ProductId == productId).ToList();
            ProductSummaryViewModel model = new ProductSummaryViewModel();
            if (viewings.Count > 0)
            {
                model.AveragePrice = Math.Round(viewings.Average(v => v.PricePerServing),2);
                model.TotalSightings = viewings.Count;
            }
            return View(model);
        }
    }
}
