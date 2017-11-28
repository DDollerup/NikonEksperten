using NikonEksperten.Models;
using NikonEksperten.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NikonEksperten.Controllers
{
    public class HomeController : Controller
    {
        DBContext context = new DBContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            List<Category> allCategories = context.CategoryFactory.GetAll();
            return View(allCategories);
        }

        // id = CategoryID
        public ActionResult ProductList(int id = 0)
        {
            List<Product> productsByCategoryID = context.ProductFactory.GetAllBy("CategoryID", id);

            return View(productsByCategoryID);
        }
    }
}