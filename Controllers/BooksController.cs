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
    public class BooksController : Controller
    {
        private paddleEntities db = new paddleEntities();

        // GET: Books
        public ActionResult Index()
        {
            //var books = db.books.Include(b => b.book1).Include(b => b.book2).Include(b => b.court);
            return View(db.books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            //ViewBag.id = new SelectList(db.books, "id", "name");
            //ViewBag.id = new SelectList(db.books, "id", "name");
            ViewBag.loc_id = new SelectList(db.courts, "id", "location");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,loc_id,date,courts,s_time,duration,amount")] book book)
        {
            if (ModelState.IsValid)
            {
                db.books.Add(book);
                db.SaveChanges();
                book.amount = book.duration * 100;
                return RedirectToAction("Index");
            }

            //ViewBag.id = new SelectList(db.books, "id", "name", book.id);
            //ViewBag.id = new SelectList(db.books, "id", "name", book.id);
            ViewBag.loc_id = new SelectList(db.courts, "id", "location", book.loc_id);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            //ViewBag.id = new SelectList(db.books, "id", "name", book.id);
            //ViewBag.id = new SelectList(db.books, "id", "name", book.id);
            ViewBag.loc_id = new SelectList(db.courts, "id", "location", book.loc_id);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,loc_id,date,courts,s_time,duration,amount")] book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.id = new SelectList(db.books, "id", "name", book.id);
            //ViewBag.id = new SelectList(db.books, "id", "name", book.id);
            ViewBag.loc_id = new SelectList(db.courts, "id", "location", book.loc_id);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            book book = db.books.Find(id);
            db.books.Remove(book);
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
