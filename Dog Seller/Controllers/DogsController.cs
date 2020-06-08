using Dog_Seller.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dog_Seller.Controllers
{
    [Authorize(Roles ="CanManage")]
    public class DogsController : Controller
    {
        private ApplicationDbContext _ApplicationDbContext;

        public DogsController()
        {
            _ApplicationDbContext = new ApplicationDbContext();
        }

        // GET: Dog
        [AllowAnonymous]
        public ActionResult Index()
        {
            var dogs = _ApplicationDbContext.Dogs;
            var a=dogs.OrderBy(m => m.Age);
            if (User.IsInRole("CanManage"))
                return View("List", a);

            return View("ReadOnlyList", a);
        }


        public ActionResult Create()
        {
            var dog = new Dog();
            return View(dog);
        }

        public ActionResult Edit(int Id)
        {
            var dogindb = _ApplicationDbContext.Dogs.FirstOrDefault(c => c.Id == Id);
            if (dogindb == null)
                return HttpNotFound();


            return View(dogindb);
        }

        public ActionResult Save(Dog dog, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", dog);
            }

            if (dog.Id == 0)
            {
                if (file != null)
                {
                    Random rnd = new Random();
                    int i = rnd.Next();
                    dog.Image = i + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Images//") + dog.Image);
                }
                _ApplicationDbContext.Dogs.Add(dog);

            }
            else
            {
                var dogindb = _ApplicationDbContext.Dogs.FirstOrDefault(c => c.Id == dog.Id);
                dogindb.Age = dog.Age;
                dogindb.Price = dog.Price;
                dogindb.Type = dog.Type;
            }

            _ApplicationDbContext.SaveChanges();



            return RedirectToAction("Index", "Dogs");
        }
        public ActionResult Delete(int id)
        {
            var dogindb = _ApplicationDbContext.Dogs.FirstOrDefault(c => c.Id == id);

            if (dogindb == null)
                return RedirectToAction("index", "Dogs");

            _ApplicationDbContext.Dogs.Remove(dogindb);
            _ApplicationDbContext.SaveChanges();

            return RedirectToAction("index", "Dogs");
        }
    }
}