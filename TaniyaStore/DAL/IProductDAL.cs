using TaniyaStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniyaStore.DAL
{
    public interface IProductDAL
    {
        List<Product> GetProducts();
        Product GetProduct(int id);
        List<Product> GetAllFromCategoryId(int id);

    }
}