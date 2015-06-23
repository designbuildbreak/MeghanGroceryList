using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeghanGroceryList.Models;

namespace MeghanGroceryList.Controllers
{
    public class GroceryItemsController : Controller
    {
        private GroceryItemDBContext db = new GroceryItemDBContext();

        // GET: GroceryItems
        public ActionResult Index()
        {
            return View(db.GroceryItems.ToList());
        }

        // GET: GroceryItems/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    GroceryItem groceryItem = db.GroceryItems.Find(id);
        //    if (groceryItem == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View();
        //}

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult GotIt(int id)
        {
            //Move it to the bottom of the db table. Update List.
            GroceryItem groceryItem = db.GroceryItems.Find(id);
            db.GroceryItems.Remove(groceryItem);
            db.SaveChanges();
            db.GroceryItems.Add(groceryItem);
            db.SaveChanges();
            groceryItem.GotIt = !groceryItem.GotIt;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: GroceryItems/Create
        public ActionResult Create()
        {
            //return RedirectToAction("Index");
            return View();
        }

        // POST: GroceryItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Item")] GroceryItem groceryItem)
        {
            if(groceryItem.Item == null)
            {
                return RedirectToAction("Index");
            }
  
            if ((ModelState.IsValid) && (groceryItem.Item != null))
            {
                db.GroceryItems.Add(groceryItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groceryItem);
        }

        // GET: GroceryItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroceryItem groceryItem = db.GroceryItems.Find(id);
            if (groceryItem == null)
            {
                return HttpNotFound();
            }
            return View(groceryItem);
        }

        // POST: GroceryItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Item")] GroceryItem groceryItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groceryItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groceryItem);
        }

        // GET: GroceryItems/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    GroceryItem groceryItem = db.GroceryItems.Find(id);
        //    if (groceryItem == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(groceryItem);
        //}

        // POST: GroceryItems/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        public ActionResult Delete(int id)
        {
            //if (groceryItem == null)
            //{
            //    return RedirectToAction("Index");
            //}
            GroceryItem groceryItem = db.GroceryItems.Find(id);
            db.GroceryItems.Remove(groceryItem);
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
