using Bootcamp2_AspMVC.Models;

namespace Bootcamp2_AspMVC.Repository.Base
{
    public interface IRepoCategory : IRepository<Category>
    {
        Category FindByUIdcategory(string uid);

    }
}
