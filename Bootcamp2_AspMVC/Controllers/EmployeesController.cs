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
    }
}
