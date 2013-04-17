using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JavaScriptSerializer_MVC4.Models;
using JavaScriptSerialization.Models;
using System.Web.Script.Serialization;

namespace JavaScriptSerialization.Controllers
{
    public class DogController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Dog/

        public ActionResult Index()
        {
            var dgs = from de in db.Dogs
                      select new
                      {
                          id=de.DogID,
                          age = de.age,
                          name = de.name
                      };
            //MemoryStream stream1 = new MemoryStream();
            //DataContractJsonSerializer ser = new DataContractJsonSerializer(dgs.GetType());

            // ser.WriteObject(stream1, dgs.ToList());
            //stream1.Position = 0;
            //StreamReader sr = new StreamReader(stream1);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var output = serializer.Serialize(dgs.ToList());
            ViewBag.Dog = output;


            return View(db.Dogs.ToList());
        }

        //
        // GET: /Dog/Details/5

        public ActionResult Details(int id = 0)
        {
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            return View(dog);
        }

        //
        // GET: /Dog/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Dog/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dog dog)
        {
            if (ModelState.IsValid)
            {
                db.Dogs.Add(dog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dog);
        }

        //
        // GET: /Dog/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            return View(dog);
        }

        //
        // POST: /Dog/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Dog dog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dog);
        }

        //
        // GET: /Dog/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            return View(dog);
        }

        //
        // POST: /Dog/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dog dog = db.Dogs.Find(id);
            db.Dogs.Remove(dog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}