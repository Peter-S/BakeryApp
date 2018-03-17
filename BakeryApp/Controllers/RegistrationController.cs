using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryApp.Models;


namespace BakeryApp.Controllers
{
    public class RegistrationController : Controller
    {
        BakeryEntities1 db = new BakeryEntities1();
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include =
            "PersonLastName, " +
            "PersonFirstName, " +
            "PersonEmail," +
            "PersonPhone," +
            "PersonDateAdded")] Person per)
        {
            Person p = new Person();
            p.PersonLastName = per.PersonLastName;
            p.PersonFirstName = per.PersonFirstName;
            p.PersonEmail = per.PersonEmail;
            p.PersonPhone = per.PersonPhone;
            p.PersonDateAdded = DateTime.Now;

            db.People.Add(p);
            db.SaveChanges();

            Message m = new Message();
            m.MessageText = "Thank you for registaring at Pete's Bakery";
            return View("Result", m);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}