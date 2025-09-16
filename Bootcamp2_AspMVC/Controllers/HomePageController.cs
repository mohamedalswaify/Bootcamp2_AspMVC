using Bootcamp2_AspMVC.Data;
using Bootcamp2_AspMVC.Models;
using Bootcamp2_AspMVC.Repository.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


            return RedirectToAction("Cart");

        }
        public IActionResult Cart()
        {
            var cartItems = _context.CartItems
                .Include(c => c.Product)
                .ToList();

            return View(cartItems); // بيرجع View اسمه Cart.cshtml
        }
        [HttpPost]
        public IActionResult UpdateQuantity(int id, int qty)
        {
            var item = _context.CartItems.Find(id);
            if (item != null && qty > 0)
            {
                item.Quantity = qty;
               // _context.CartItems.Update(item);
                _context.SaveChanges();
            }
            return RedirectToAction("Cart");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var item = _context.CartItems.Find(id);
            if (item != null)
            {
                _context.CartItems.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction("Cart");
        }

    }

}

