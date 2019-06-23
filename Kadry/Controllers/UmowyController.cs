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
    public class UmowyController : Controller
    {
        private PracownicyContext db = new PracownicyContext();

        // GET: Umowy
        public ActionResult Index()
        {
            return View(db.Umowy.ToList());
        }

        // GET: Umowy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Umowa umowa = db.Umowy.Find(id);
            if (umowa == null)
            {
                return HttpNotFound();
            }
            return View(umowa);
        }

        // GET: Umowy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Umowy/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RodzajUmowy")] Umowa umowa)
        {
            if (ModelState.IsValid)
            {
                db.Umowy.Add(umowa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(umowa);
        }

        // GET: Umowy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Umowa umowa = db.Umowy.Find(id);
            if (umowa == null)
            {
                return HttpNotFound();
            }
            return View(umowa);
        }

        // POST: Umowy/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RodzajUmowy")] Umowa umowa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(umowa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(umowa);
        }

        // GET: Umowy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Umowa umowa = db.Umowy.Find(id);
            if (umowa == null)
            {
                return HttpNotFound();
            }
            return View(umowa);
        }

        // POST: Umowy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Umowa umowa = db.Umowy.Find(id);
            db.Umowy.Remove(umowa);
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
