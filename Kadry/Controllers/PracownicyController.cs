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
    public class PracownicyController : Controller
    {
        private PracownicyContext db = new PracownicyContext();

        // GET: Pracownicy
        public ActionResult Index()
        {
            var pracownicy = db.Pracownicy.Include(p => p.Działy).Include(p => p.Umowy);
            return View(pracownicy.ToList());
        }

        // GET: Pracownicy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownik pracownik = db.Pracownicy.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // GET: Pracownicy/Create
        public ActionResult Create()
        {
            ViewBag.DziałId = new SelectList(db.Działy, "Id", "NazwaDziału");
            ViewBag.UmowaId = new SelectList(db.Umowy, "Id", "RodzajUmowy");
            return View();
        }

        // POST: Pracownicy/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DziałId,UmowaId,Imie,Nazwisko,Stanowisko,OpisStanowiska")] Pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                db.Pracownicy.Add(pracownik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DziałId = new SelectList(db.Działy, "Id", "NazwaDziału", pracownik.DziałId);
            ViewBag.UmowaId = new SelectList(db.Umowy, "Id", "RodzajUmowy", pracownik.UmowaId);
            return View(pracownik);
        }

        // GET: Pracownicy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownik pracownik = db.Pracownicy.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            ViewBag.DziałId = new SelectList(db.Działy, "Id", "NazwaDziału", pracownik.DziałId);
            ViewBag.UmowaId = new SelectList(db.Umowy, "Id", "RodzajUmowy", pracownik.UmowaId);
            return View(pracownik);
        }

        // POST: Pracownicy/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DziałId,UmowaId,Imie,Nazwisko,Stanowisko,OpisStanowiska")] Pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pracownik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DziałId = new SelectList(db.Działy, "Id", "NazwaDziału", pracownik.DziałId);
            ViewBag.UmowaId = new SelectList(db.Umowy, "Id", "RodzajUmowy", pracownik.UmowaId);
            return View(pracownik);
        }

        // GET: Pracownicy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownik pracownik = db.Pracownicy.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // POST: Pracownicy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pracownik pracownik = db.Pracownicy.Find(id);
            db.Pracownicy.Remove(pracownik);
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
