using Bootcamp2_AspMVC.Models;
using Bootcamp2_AspMVC.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp2_AspMVC.Controllers
{
    public class HomePageController : Controller
    {



        private readonly IUnitOfWork _unitOfWork;
    
        public HomePageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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



    }
}
