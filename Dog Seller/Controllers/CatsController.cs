using Dog_Seller.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dog_Seller.Controllers
{
   // [Authorize(Roles = "CanManage")]
    public class CatsController : Controller
    {
        private ApplicationDbContext _ApplicationDbContext;

        public CatsController()
        {
            _ApplicationDbContext = new ApplicationDbContext();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var cats = _ApplicationDbContext.Cats;
            if (User.IsInRole("CanManage"))
                return View("List", cats);

            return View("ReadOnlyList", cats);
        }
        public ActionResult Create()
        {
            var cat = new Cat();
            return View(cat);
        }

        public ActionResult Edit(int Id)
        {
            var catindb = _ApplicationDbContext.Cats.FirstOrDefault(c => c.Id == Id);
            if (catindb == null)
                return HttpNotFound();


            return View(catindb);
        }

        public ActionResult Save(Cat cat, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", cat);
            }

            if (cat.Id == 0)
            {
                if (file != null)
                {
                    Random rnd = new Random();
                    int i = rnd.Next();
                    cat.Image = i + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Images//") + cat.Image);
                }
                _ApplicationDbContext.Cats.Add(cat);

            }
            else
            {
                var catindb = _ApplicationDbContext.Cats.FirstOrDefault(c => c.Id == cat.Id);
                catindb.Age = cat.Age;
                catindb.Price = cat.Price;
                catindb.Type = cat.Type;
            }

            _ApplicationDbContext.SaveChanges();

            return RedirectToAction("Index", "Cats");
        }

        public ActionResult Delete(int id)
        {
            var catindb = _ApplicationDbContext.Cats.FirstOrDefault(c => c.Id == id);

            if (catindb == null)
                return RedirectToAction("index", "Cats");

            _ApplicationDbContext.Cats.Remove(catindb);
            _ApplicationDbContext.SaveChanges();

            return RedirectToAction("index", "Cats");
        }
    }
}