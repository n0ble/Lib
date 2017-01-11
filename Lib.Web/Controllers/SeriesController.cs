using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Lib.Web.Models;

namespace Lib.Web.Controllers
{
	public class SeriesController : Controller
    {
        private Entities db = new Entities();

        // GET: Series
        public ActionResult Index()
        {
            return View(db.Series.ToList());
        }

        // GET: Series/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Series series = db.Series.Find(id);
            if (series == null)
            {
                return HttpNotFound();
            }
            return View(series);
        }

        // GET: Series/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Series/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Series series)
        {
            if (ModelState.IsValid)
            {
                series.Id = Guid.NewGuid();
                db.Series.Add(series);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(series);
        }

        // GET: Series/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Series series = db.Series.Find(id);
            if (series == null)
            {
                return HttpNotFound();
            }
            return View(series);
        }

        // POST: Series/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Series series)
        {
            if (ModelState.IsValid)
            {
                db.Entry(series).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(series);
        }

        // GET: Series/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Series series = db.Series.Find(id);
            if (series == null)
            {
                return HttpNotFound();
            }
            return View(series);
        }

        // POST: Series/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Series series = db.Series.Find(id);
            db.Series.Remove(series);
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
