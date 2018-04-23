using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaniyaStore.Models;
using TaniyaStore.DAL;

namespace TaniyaStore.Controllers
{
    public class HomeController : Controller
    {
        ICategoryDAL dal;
        public HomeController(ICategoryDAL dal)
        {
            this.dal = dal;
        }
        // GET: Home
        public ActionResult Index()
        {
            // Get all of the categories from the database
            // var model = dal.GetCategories();
            var categories = dal.GetAllCategories();
            return View("Index", categories);
        }
    }
}