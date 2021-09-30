using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Lab_Task___CRUD.Models;
using Lab_Task___CRUD.Models.Entity;
using System.Windows;

namespace Lab_Task___CRUD.Controllers
{
    public class ProductController : Controller
    {
        // GET
        // : Product
        Database db = new Database();
        public ActionResult Cart()
        {
           
            return View();
        }
        public ActionResult List()
        {
            
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
        public ActionResult Create(Product p)
        {

            if (ModelState.IsValid)
            {
                
                db.Products.Create(p);

                Response.Write("<script>alert('Data inserted successfully')</script>");
                return RedirectToAction("List");
            }
            return View(p);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            var p=db.Products.GetProduct(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(Product p) { 

            if (ModelState.IsValid)
                {
           
            db.Products.Create(p);
            return RedirectToAction("List");
            }
            return View(p);
        }
        public ActionResult Delete(int id)
        {

            db.Products.Delete(id);
            return RedirectToAction("List");
        }



    }
}