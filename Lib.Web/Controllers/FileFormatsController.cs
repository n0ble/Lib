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
    public class FileFormatsController : Controller
    {
        private Entities db = new Entities();

        // GET: FileFormats
        public ActionResult Index()
        {
            return View(db.FileFormats.ToList());
        }

        // GET: FileFormats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileFormat fileFormat = db.FileFormats.Find(id);
            if (fileFormat == null)
            {
                return HttpNotFound();
            }
            return View(fileFormat);
        }

        // GET: FileFormats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FileFormats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] FileFormat fileFormat)
        {
            if (ModelState.IsValid)
            {
                db.FileFormats.Add(fileFormat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fileFormat);
        }

        // GET: FileFormats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileFormat fileFormat = db.FileFormats.Find(id);
            if (fileFormat == null)
            {
                return HttpNotFound();
            }
            return View(fileFormat);
        }

        // POST: FileFormats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] FileFormat fileFormat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fileFormat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fileFormat);
        }

        // GET: FileFormats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileFormat fileFormat = db.FileFormats.Find(id);
            if (fileFormat == null)
            {
                return HttpNotFound();
            }
            return View(fileFormat);
        }

        // POST: FileFormats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FileFormat fileFormat = db.FileFormats.Find(id);
            db.FileFormats.Remove(fileFormat);
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
