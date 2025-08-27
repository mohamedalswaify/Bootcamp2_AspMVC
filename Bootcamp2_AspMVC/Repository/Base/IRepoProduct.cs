﻿using Bootcamp2_AspMVC.Models;

namespace Bootcamp2_AspMVC.Repository.Base
{
    public interface IRepoProduct : IRepository<Product>
    {

        IEnumerable<Product> FindAllproducts();

    }
}
