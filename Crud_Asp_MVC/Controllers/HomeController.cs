using Crud_Asp_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_Asp_MVC.Controllers
{
    public class HomeController : Controller
    {
        StudentDBDataContext db = new StudentDBDataContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.students.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Create(student s)
        {
            db.students.InsertOnSubmit(s);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var std = db.students.Single(x => x.ID == id);
            return View(std);
        }
        [HttpPost]
        public ActionResult Edit(int id,student s)
        {
            student std = db.students.Single(x => x.ID == id);
            std.NAME = s.NAME;
            std.GENDER = s.GENDER;
            std.AGE = s.AGE;
            std.STANDARD = s.STANDARD;
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var std = db.students.Single(x => x.ID == id);
            return View(std);
        }
        [HttpPost]
        public ActionResult Delete(int id,student s)
        {
            student std = db.students.Single(x => x.ID == id);
            db.students.DeleteOnSubmit(std);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var std = db.students.Single(x => x.ID == id);
            return View(std);
        }
    }
}