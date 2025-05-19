using Microsoft.AspNetCore.Mvc;
using Lab_3.Models;

namespace Lab_3.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Details()
        {
            Product product = new Product
            {
                Id = 1,
                Name = "Sample Product",
                Price = 19.99m
            };
            return View(product);
        }
    }
}
