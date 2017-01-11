﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Lib.Web.Filters;
using Lib.Web.Models;

namespace Lib.Web.Controllers
{
	[Culture]
	public class TagsController : Controller
	{
		private Entities db = new Entities();

		// GET: Tags
		[HandleError(ExceptionType = typeof(ArgumentNullException), View = "Error")]
		public ActionResult Index()
		{
			//throw new ArgumentNullException();
			return View(db.Tags.ToList());
		}

		// GET: Tags/Details/5
		public ActionResult Details(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Tag tag = db.Tags.Find(id);
			if (tag == null)
			{
				return HttpNotFound();
			}
			return View(tag);
		}

		// GET: Tags/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Tags/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Name")] Tag tag)
		{
			if (ModelState.IsValid)
			{
				tag.Id = Guid.NewGuid();
				db.Tags.Add(tag);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(tag);
		}

		// GET: Tags/Edit/5
		public ActionResult Edit(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Tag tag = db.Tags.Find(id);
			if (tag == null)
			{
				return HttpNotFound();
			}
			return View(tag);
		}

		// POST: Tags/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Name")] Tag tag)
		{
			if (ModelState.IsValid)
			{
				db.Entry(tag).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(tag);
		}

		// GET: Tags/Delete/5
		public ActionResult Delete(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Tag tag = db.Tags.Find(id);
			if (tag == null)
			{
				return HttpNotFound();
			}
			return View(tag);
		}

		// POST: Tags/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(Guid id)
		{
			Tag tag = db.Tags.Find(id);
			db.Tags.Remove(tag);
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
