using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using paddle.Models;

namespace paddle.Controllers
{
    public class RegistersController : Controller
    {
        private paddleEntities db = new paddleEntities();

        // GET: Registers
        public ActionResult Index()
        {
            //var users = db.users.Include(u => u.user1).Include(u => u.user2);
            return View(db.users.ToList());
        }

        // GET: Registers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Registers/Create
        public ActionResult Create()
        {
            //ViewBag.id = new SelectList(db.users, "id", "name");
            //ViewBag.id = new SelectList(db.users, "id", "name");
            return View();
        }

        // POST: Registers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,user_id,pwd")] user user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index","Login");
            }

            //ViewBag.id = new SelectList(db.users, "id", "name", user.id);
            //ViewBag.id = new SelectList(db.users, "id", "name", user.id);
            return View(user);
        }

        // GET: Registers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            //ViewBag.id = new SelectList(db.users, "id", "name", user.id);
            //ViewBag.id = new SelectList(db.users, "id", "name", user.id);
            return View(user);
        }

        // POST: Registers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,user_id,pwd")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.id = new SelectList(db.users, "id", "name", user.id);
            //ViewBag.id = new SelectList(db.users, "id", "name", user.id);
            return View(user);
        }

        // GET: Registers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
