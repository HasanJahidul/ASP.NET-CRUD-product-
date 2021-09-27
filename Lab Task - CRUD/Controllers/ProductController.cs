using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Lab_Task___CRUD.Models;
using Lab_Task___CRUD.Models.Entity;

namespace Lab_Task___CRUD.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            Database db = new Database();
            var products = db.Products.GetAll();
            return View(products);
        }
        [HttpGet]
        
        public ActionResult Create()
        {
            Product p = new Product();
            return View(p);
        }
        [HttpPost]
        public ActionResult Create( Product p)
        {

            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Create(p);
                return RedirectToAction("List");
            }
            return View(p);
        }
        public ActionResult Edit(int id)
        {
            Database db = new Database();
            var s = db.Products.Get(id);
            return View(s);
        }
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }



    }
}