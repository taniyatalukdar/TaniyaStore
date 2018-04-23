using Ninject;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TaniyaStore.DAL;
using TaniyaStore.Models;

namespace TaniyaStore
{
    public class MvcApplication : NinjectHttpApplication
    {


        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

            // Map Interfaces to Classes
            //kernel.Bind<interface>().To<class>();
            kernel.Bind<IProductDAL>().To<ProductSqlDAL>();
            kernel.Bind<ICategoryDAL>().To<CategorySqlDAL>();

            return kernel;
        }
    }
}
