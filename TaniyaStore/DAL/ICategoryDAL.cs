using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaniyaStore.Models;
using System.Threading.Tasks;

namespace TaniyaStore.DAL
{
    public interface ICategoryDAL
    {
        List<Category> GetAllCategories();
    }
}