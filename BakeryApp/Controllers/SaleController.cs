using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryApp.Models;

namespace BakeryApp.Controllers
{
    public class SaleController : Controller
    {
        BakeryEntities1 db = new BakeryEntities1();

        Message message = new Message();

        public ActionResult Index()
        {
            ViewBag.ProductKey = new SelectList(db.Products, "ProductKey", "ProductName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ProductKey")]Product formProduct)
        {
            decimal costFromProductTableQuery = (from query in db.Products
                                                 where query.ProductKey == formProduct.ProductKey
                                                 select query.ProductPrice).FirstOrDefault();

            message.MessageText = costFromProductTableQuery.ToString();

            return View("Sale", message);
        }

        public ActionResult Sale(Message m)
        {
            return View(m);
        }
    }
}