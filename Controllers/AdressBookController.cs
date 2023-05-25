using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC3.Models;

namespace WebAppMVC3.Controllers
{
    public class AdressBookController : Controller
    {
        List<AdressBook> books = new List<AdressBook>()
            {
                new AdressBook()
                {
                Id = 0,
                FIO = "FIO123",
                Email="faasd@yewer.ru",
                Birthday=DateTime.Now,
                //Birthday= DateOnly.FromDateTime(DateTime.Now)
                },
                new AdressBook()
                {
                Id = 1,
                FIO = "dasdasd3",
                Email="faasd@yewer.ru",
                Birthday=DateTime.Now,
                //Birthday= DateOnly.FromDateTime(DateTime.Now)
                },
                new AdressBook()
                {
                Id = 2,
                FIO = "FIO42312323",
                Email="fasdasdasd@yewer.ru",
                Birthday=DateTime.Now,
                //Birthday= DateOnly.FromDateTime(DateTime.Now),
                }
            };
        public ActionResult Index()
        {
            return View(books);
        }

        public ActionResult AdressList()
        {

            return View(books);
        }

        // GET: AdressBookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdressBookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            var valuesList = new List<string>();

            valuesList.Add(collection["id"]);
            valuesList.Add(collection["field2"]);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdressBookController/Edit/5
        public ActionResult Edit(int id)
        {
            var adress = books.Where(x => x.Id == id).FirstOrDefault();
            return View(adress);
        }

        // POST: AdressBookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdressBookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdressBookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
