using Bootcamp2_AspMVC.Models;

namespace Bootcamp2_AspMVC.Repository.Base
{
    public interface IUnitOfWork
    {
        IRepoProduct Products { get; }

        IRepoEmployee Employees { get; }

        IRepository<Category> Categories { get; }
        IRepository<Permission> Permissions { get; }

       // IRepository<Employee> Employees { get; }

        void Save();




    }
}
