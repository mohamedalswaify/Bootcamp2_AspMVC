using Bootcamp2_AspMVC.Data;
using Bootcamp2_AspMVC.Models;
using Bootcamp2_AspMVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp2_AspMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IRepository<Employee> _repository;

        
        public EmployeesController(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var  employees = _repository.FindAll();
            if (employees.Any())
            {
                TempData["Sucees"] = "تم جلب البيانات بنجاح";
            }
            else
            {
                TempData["Error"] = "لا توجد بيانات لعرضها";
            }
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

            //_context.Employees.Add(employee);
            //_context.SaveChanges();
            _repository.Add(employee);
            TempData["Add"] = "تم اضافة البيانات بنجاح";
            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            //var cate = _context.Employees.Find(Id);
            var cate = _repository.FindById(Id);

            return View(cate);
        }


        [HttpPost]
        public IActionResult Edit(Employee emp)
        {

            //_context.Employees.Update(emp);
            //_context.SaveChanges();

            _repository.Update(emp);

            TempData["Update"] = "تم تعديل البيانات بنجاح";
            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            //var cate = _context.Employees.Find(Id);
            var cate =  _repository.FindById(Id);

            return View(cate);
        }


        [HttpPost]
        public IActionResult Delete(Employee emp)
        {

            //_context.Employees.Remove(emp);
            //_context.SaveChanges();
            _repository.Delete(emp);
            TempData["Remove"] = "تم حذف البيانات بنجاح";
            return RedirectToAction("Index");


        }





    }
}
