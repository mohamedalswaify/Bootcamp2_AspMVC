using Bootcamp2_AspMVC.Data;
using Bootcamp2_AspMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp2_AspMVC.Controllers
{
    public class EmployeesController : Controller
    {


        private readonly ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var  employees = _context.Employees.ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Employee employee)
        {

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var cate = _context.Employees.Find(Id);

            return View(cate);
        }


        [HttpPost]
        public IActionResult Edit(Employee emp)
        {

            _context.Employees.Update(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var cate = _context.Employees.Find(Id);

            return View(cate);
        }


        [HttpPost]
        public IActionResult Delete(Employee emp)
        {

            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }





    }
}
