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

        [HttpGet]
        public IList<Product> Products()
        {
            var products = _dbContext.Products.ToList();
            return products;
        }

        //Get
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            if (product is null || product.Id == 0)
            {
                return NotFound();
            }

            var productDb = _dbContext.Products.Find(product.Id);

            if (productDb is null)
            {
                return NotFound();
            }

            try
            {
                _dbContext.Products.Remove(productDb);
                _dbContext.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }

        //Post
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            DateTime utcDateTime = product.Date.ToUniversalTime();
            product.Date = utcDateTime;
            try
            {
                _dbContext.Products.Update(product);
                _dbContext.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, Message = ex.Message });
            }
        }
    }
}
