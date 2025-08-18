using Bootcamp2_AspMVC.Data;
using Bootcamp2_AspMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp2_AspMVC.Controllers
{
    public class CategoriesController : Controller
    {

        private readonly ApplicationDbContext _context;
        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        public  ActionResult<IEnumerable<Category>> GetAll()
        {
            var categories =  _context.Categories.ToList();

            return Ok(categories); // يرجّع JSON
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Category> category = _context.Categories.ToList().Where(e=>e.Id<50);


            if(category.Any())
            {
                TempData["Sucees"]= "تم جلب البيانات بنجاح";
            }
            else
            {
                TempData["Error"] = "لا توجد بيانات لعرضها";

            }

            return View(category);

        }

        [HttpGet]
        public IActionResult Create()
        {
          
            return View();
        }


        [HttpPost]
        public IActionResult Create(Category category)
        {

            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");

          
        }



        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var cate = _context.Categories.Find(Id);

            return View(cate);
        }


        [HttpPost]
        public IActionResult Edit(Category category)
        {

            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var cate = _context.Categories.Find(Id);

            return View(cate);
        }


        [HttpPost]
        public IActionResult Delete(Category category)
        {

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }




    }
}
