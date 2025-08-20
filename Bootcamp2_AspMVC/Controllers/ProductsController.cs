using Bootcamp2_AspMVC.Data;
using Bootcamp2_AspMVC.Dtos;
using Bootcamp2_AspMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp2_AspMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            IEnumerable<Product> products = _context.Products.Include(e => e.Category).ToList();
            return View(products);
        }


        public IActionResult GetAll2()
        {
            IEnumerable<Product> products = _context.Products.Include(e=>e.Category).AsNoTracking().ToList();
            return Ok(products);
        }



        public IActionResult GetAll()
        {
            IEnumerable<ProductDto> products = 
                _context.Products.
                Include(e => e.Category)
                .AsNoTracking()
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name
                })
                .ToList();
            return Ok(products);
        }





        private void CreateCategorySelectList()
        {
            // List<CategoryDto> categories = new List<CategoryDto> {

            //// new CategoryDto { Id = 0, Name = "Select Category" } ,
            //     new CategoryDto { Id = 1, Name = "Electronics" } ,
            //     new CategoryDto { Id = 2, Name = "Clothing" } ,
            //     new CategoryDto { Id = 3, Name = "Mobiles" } ,
            // };


            List<Category> categories = _context.Categories.ToList();

            SelectList selectListItems = new SelectList(categories, "Id", "Name", 0);
        ViewBag.Categories = selectListItems;

        }




    [HttpGet]
        public IActionResult Create()
        {

            CreateCategorySelectList();

            return View();
        }


        [HttpPost]
        public IActionResult Create(Product ptoducts)
        {
            if (ModelState.IsValid)
            {

                _context.Products.Add(ptoducts);
                _context.SaveChanges();
                TempData["Add"] = "تم اضافة البيانات بنجاح";
                return RedirectToAction("Index");

            }

            else
            {
                return View(ptoducts);
            }


        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var cate = _context.Products.Find(Id);
            CreateCategorySelectList();

            return View(cate);
        }


        [HttpPost]
        public IActionResult Edit(Product product)
        {

            _context.Products.Update(product);
            _context.SaveChanges();
            TempData["Update"] = "تم تحديث البيانات بنجاح";
            return RedirectToAction("Index");


        }




    }
}
