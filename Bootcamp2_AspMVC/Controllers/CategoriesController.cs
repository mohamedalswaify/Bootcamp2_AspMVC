using Bootcamp2_AspMVC.Data;
using Bootcamp2_AspMVC.Dtos;
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
        public  ActionResult<IEnumerable<CategoryDto>> GetAll()
        {
            var categories =  _context.Categories
                .Include(c => c.Products).Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Count = c.Products.Count()
                })
                .ToList();

            return Ok(categories); // يرجّع JSON
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Category> category = _context.Categories.ToList();


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



            try
            {
                if (category.Name == "100")
                {
                    ModelState.AddModelError("CustomError", "Name Van not be Equal 100");
                }


                if (ModelState.IsValid)
                {
                    category.Name = null;
                    _context.Categories.Add(category);
                    _context.SaveChanges();
                    TempData["Add"] = "تم اضافة البيانات بنجاح";
                    return RedirectToAction("Index");

                }
                else
                {
                    return View(category);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "حدث خطأ أثناء إضافة البيانات: " + ex.Message);
                return View(category);
            }


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
            TempData["Update"] = "تم تحديث البيانات بنجاح";
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
            TempData["Remove"] = "تم حذف البيانات بنجاح";
            return RedirectToAction("Index");


        }




    }
}
