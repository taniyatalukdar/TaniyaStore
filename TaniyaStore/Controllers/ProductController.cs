using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaniyaStore.DAL;
using TaniyaStore.Models;

namespace TaniyaStore.Controllers
{
    public class ProductController : Controller
    {
        IProductDAL dal;
        public ProductController(IProductDAL dal)
        {
            this.dal = dal;
        }
        // GET: Product
        public ActionResult Index()
        {
            var product = dal.GetProducts();
            return View("Index", product);
        }


        public ActionResult ProductDetail(int id)
        {
            var product = dal.GetProduct(id);
            return View("ProductDetail", product);
        }

        public ActionResult CategoryDetail(int id)
        {
            var products = dal.GetAllFromCategoryId(id);
            return View("CategoryDetail", products);
        }

        [HttpPost]
        public ActionResult AddtoCart(int id, int quantity)
        {
            var product = dal.GetProduct(id);

            ShoppingCart cart = GetActiveShoppingCart();
            cart.AddToCart(product, quantity);
            return RedirectToAction("ViewCart", cart);
        }

        private ShoppingCart GetActiveShoppingCart()
        {
            ShoppingCart cart = null;
            if(Session["Shopping_Cart"] == null)
            {
                cart = new ShoppingCart();
                Session["Shopping_Cart"] = cart;
            }
            else
            {
                cart = Session["Shopping_Cart"] as ShoppingCart;
            }

            return cart;
        }

        public ActionResult ViewCart()
        {
            ShoppingCart cart = GetActiveShoppingCart();
            return View("ViewCart", cart);
        }
    }
}