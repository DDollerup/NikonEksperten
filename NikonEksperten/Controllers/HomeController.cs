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
            List<Product> products = null;
            // Hvis TempData IKKE er INGENTING
            if (TempData["searchResult"] != null)
            {
                ViewBag.SearchQuery = TempData["searchQuery"];
                products = TempData["searchResult"] as List<Product>;
            }
            else
            {
                products = context.ProductFactory.GetAllBy("CategoryID", id);
            }


            //List<Product> productsByCategoryID = context.ProductFactory.GetAllBy("CategoryID", id);

            List<ProductVM> pvmList = new List<ProductVM>();

            foreach (Product product in products)
            {
                ProductVM pvm = new ProductVM();
                pvm.Product = product;
                pvm.Category = context.CategoryFactory.Get(product.CategoryID);
                pvm.Manufacture = context.ManufactureFactory.Get(product.ManufactureID);

                pvmList.Add(pvm);
            }

            ViewBag.CategoryName = context.CategoryFactory.Get(id).Name;

            return View(pvmList);
        }

        // id = ProductID
        public ActionResult ShowProduct(int id = 0)
        {
            Product productByID = context.ProductFactory.Get(id);

            ProductVM pvm = new ProductVM();
            pvm.Product = productByID;
            pvm.Category = context.CategoryFactory.Get(productByID.CategoryID);
            pvm.Manufacture = context.ManufactureFactory.Get(productByID.ManufactureID);

            return View(pvm);
        }

        public ActionResult Search()
        {
            ViewBag.Categories = context.CategoryFactory.GetAll();
            return PartialView();
        }
        [HttpPost]
        public ActionResult SearchSubmit(string searchQuery, int categoryID, string maxPrice)
        {
            //List<Product> searchResult = context.ProductFactory.SearchBy(searchQuery, "Name", "Description", "Price");
            List<Product> searchResult = context.ProductFactory.SearchByFilter(searchQuery, new string[] {
                (categoryID > 0 ? "CategoryID = " + categoryID : "CategoryID > 0"),
                "Price <= " + maxPrice
            }, "Name", "Description");
            TempData["searchResult"] = searchResult;
            TempData["searchQuery"] = searchQuery;
            return RedirectToAction("ProductList");
        }
    }
}