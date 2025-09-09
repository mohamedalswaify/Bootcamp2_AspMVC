using Bootcamp2_AspMVC.Data;
using Bootcamp2_AspMVC.Dtos;
using Bootcamp2_AspMVC.Models;
using Bootcamp2_AspMVC.Repository.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BootCamp2_AspAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IRepository<Category> _repository;
        public CategoriesController(IRepository<Category> repository)
        {

            _repository = repository;

        }


        [HttpGet("{id:int}")]
        public ActionResult<IEnumerable<CategoryDto>> GetAll(int  id=1)
        {
            var categories = _repository.FindAll()
               .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Count = c.Products.Count()
                }).Where(c => c.Id >= id)
                .ToList();

            return Ok(categories); // يرجّع JSON
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllCategories2()
        {
            IEnumerable<Category> category = _repository.FindAll();
            return Ok(category);

        }


        [HttpGet("GetById/{Id:int}")]
        public IActionResult GetById(int Id)
        {
            var cate = _repository.FindById(Id);
            if (cate == null)
            {
                return NotFound(new {Message ="لا توجد نتائج لهذا الرقم"});
            }

            return Ok(cate);
        }



    }
}
