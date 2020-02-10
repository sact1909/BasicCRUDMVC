using MyFirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly MyFirstDbEntities db = new MyFirstDbEntities();
        // GET: User
        public ActionResult Index()
        {

            var Usuarios = db.T_USER.ToList();
            
            return View(Usuarios);
        }

        public ActionResult Create() {

            return View();
        }

        [HttpPost]
        public ActionResult Create(T_USER Usuario)
        {
            if (ModelState.IsValid)
            {
                db.T_USER.Add(Usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else {
                return View();
            }
            
        }

        public ActionResult Details(int ID) {
            var Usuario = db.T_USER.Where(w => w.CODIGO == ID).FirstOrDefault();
            return View(Usuario);
        }

        
        public ActionResult Edit(int ID)
        {

            var Usuario = db.T_USER.Where(w => w.CODIGO == ID).FirstOrDefault();
            return View(Usuario);
        }

        [HttpPost]
        public ActionResult Edit(T_USER Usuario)
        {

            if (ModelState.IsValid) {

                db.Entry(Usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();

            }
            
            
        }

        public ActionResult Delete(int ID) {

            var usuarioDelete = db.T_USER.Where(w => w.CODIGO == ID).FirstOrDefault();
            db.T_USER.Remove(usuarioDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        





    }
}