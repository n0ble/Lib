using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lib.Web.Models;

namespace Lib.Web.Controllers
{
    public class InterpretersController : Controller
    {
        private Entities db = new Entities();

        // GET: Interpreters
        public ActionResult Index()
        {
            return View(db.Interpreters.ToList());
        }

        // GET: Interpreters/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interpreter interpreter = db.Interpreters.Find(id);
            if (interpreter == null)
            {
                return HttpNotFound();
            }
            return View(interpreter);
        }

        // GET: Interpreters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Interpreters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,MiddleName,LastName")] Interpreter interpreter)
        {
            if (ModelState.IsValid)
            {
                interpreter.Id = Guid.NewGuid();
                db.Interpreters.Add(interpreter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(interpreter);
        }

        // GET: Interpreters/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interpreter interpreter = db.Interpreters.Find(id);
            if (interpreter == null)
            {
                return HttpNotFound();
            }
            return View(interpreter);
        }

        // POST: Interpreters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,MiddleName,LastName")] Interpreter interpreter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interpreter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(interpreter);
        }

        // GET: Interpreters/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interpreter interpreter = db.Interpreters.Find(id);
            if (interpreter == null)
            {
                return HttpNotFound();
            }
            return View(interpreter);
        }

        // POST: Interpreters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Interpreter interpreter = db.Interpreters.Find(id);
            db.Interpreters.Remove(interpreter);
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
