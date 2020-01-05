using EmreSenturk.WebApiDemo.Entities;
using EmreSenturk.WebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmreSenturk.WebApiDemo.DataAccess
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductModel> GetProductWithDetails();
    }
}
