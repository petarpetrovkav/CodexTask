using CodexMVCProject.DataLayer;
using CodexMVCProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodexMVCProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        // POST: 
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            DateTime utcDateTime = product.Date.ToUniversalTime(); 
            product.Date = utcDateTime;

            try
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }
    }
}
