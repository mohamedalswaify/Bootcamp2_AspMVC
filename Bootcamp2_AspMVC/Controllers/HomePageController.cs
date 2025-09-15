using Bootcamp2_AspMVC.Data;
using Bootcamp2_AspMVC.Models;
using Bootcamp2_AspMVC.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp2_AspMVC.Controllers
{
    public class HomePageController : Controller
    {



        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;

        public HomePageController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }



        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Products.FindAllproducts();
            return View(products);
        }





        public IActionResult Details(int Id)
        {
           var products = _unitOfWork.Products.FindByIdproduct(Id);
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(int id, int qty = 1)
        {
            var p = _unitOfWork.Products.FindById(id);
            if (p == null) return NotFound();

            var item = new CartItem
            {
                ProductId = p.Id,
                Quantity = qty,
           
            };


            _context.CartItems.Add(item);
            _context.SaveChanges();


            return RedirectToAction("Index", "Cart");
        }

    }
}
