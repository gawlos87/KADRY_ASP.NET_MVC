using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kadry.DAL;
using Kadry.Models;

namespace Kadry.Controllers
{
    public class DziałyController : Controller
    {
        private PracownicyContext db = new PracownicyContext();

        // GET: Działy
        public ActionResult Index()
        {
            return View(db.Działy.ToList());
        }

        // GET: Działy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dział dział = db.Działy.Find(id);
            if (dział == null)
            {
                return HttpNotFound();
            }
            return View(dział);
        }

        // GET: Działy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Działy/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NazwaDziału")] Dział dział)
        {
            if (ModelState.IsValid)
            {
                db.Działy.Add(dział);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dział);
        }

        // GET: Działy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dział dział = db.Działy.Find(id);
            if (dział == null)
            {
                return HttpNotFound();
            }
            return View(dział);
        }

        // POST: Działy/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NazwaDziału")] Dział dział)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dział).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dział);
        }

        // GET: Działy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dział dział = db.Działy.Find(id);
            if (dział == null)
            {
                return HttpNotFound();
            }
            return View(dział);
        }

        // POST: Działy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dział dział = db.Działy.Find(id);
            db.Działy.Remove(dział);
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
