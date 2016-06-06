using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelCommunity.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace TravelCommunity.Controllers
{   
    [Authorize]
    public class PhonesController : Controller
    {      
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int id2 = 0)
        {
            var phones = db.Phones.Where(c => c.contactId == id2);
            ViewBag.id2 = id2;
            return View(phones.ToList());
        }

        public ActionResult Details(int? id, int id2 = 0)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            ViewBag.id2 = id2;
            return View(phone);
        }

        public ActionResult Create(int id2 = 0)
        {
            ViewBag.id2 = id2;
            ViewBag.contactName = db.Contacts.Find(id2).Name;
            ViewBag.ContactId = new SelectList(db.Contacts, "id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number")] Phone phone, int id2 = 0 )
        {
            if (ModelState.IsValid)
            {
                phone.contactId = id2;
                phone.Contact = db.Contacts.Find(id2);

                db.Phones.Add(phone);
                db.SaveChanges();
                return RedirectToAction("Index", new { id2 = id2 });
            }

            ViewBag.ContactId = new SelectList(db.Contacts, "id", "Name", phone.contactId);
            ViewBag.contactName = db.Contacts.Find(id2).Name;
            return View(phone);
        }

        public ActionResult Edit(int? id, int id2 = 0)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "id", "Name", phone.contactId);
            ViewBag.contactName = db.Contacts.Find(id2).Name;
            ViewBag.id2 = id2;
            return View(phone);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number")] Phone phone, int id2 = 0)
        {
            if (ModelState.IsValid)
            {
                phone.contactId = id2;
                db.Entry(phone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id2 = id2});
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "id", "Name", phone.contactId);
            return View(phone);
        }

        public ActionResult Delete(int? id, int id2 = 0)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            ViewBag.id2 = id2;
            return View(phone);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int id2 = 0)
        {
            Phone phone = db.Phones.Find(id);
            db.Phones.Remove(phone);
            db.SaveChanges();
            return RedirectToAction("Index", new { id2  = id2 });
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
