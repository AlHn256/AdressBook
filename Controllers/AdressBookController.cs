using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebAppMVC3.Data;
using WebAppMVC3.Models;

namespace WebAppMVC3.Controllers
{
    public class AdressBookController : Controller
    {
        private readonly AdressRepository Repository;

        public AdressBookController(AdressRepository repository)
        {
            Repository = repository;    
        }

        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var books = Repository.GetAdressBooks().ToList();
            return View(books);
        }

        public ActionResult AdressBookFilter(AdressBookFilter filter)
        {
            AdressBookFilter  adressBookFilter = new AdressBookFilter();

            var AdressBooksList = Repository.GetAdressBooks();

            if (filter.Id != null) AdressBooksList = AdressBooksList.Where(x => x.Id == filter.Id);
            if (filter.FIO != null) AdressBooksList = AdressBooksList.Where(x => x.FIO == filter.FIO);
            if (filter.Email != null) AdressBooksList = AdressBooksList.Where(x => x.Email == filter.Email);
            if (filter.BirthdayFrom != null) AdressBooksList = AdressBooksList.Where(x => x.Birthday > filter.BirthdayFrom);
            if (filter.BirthdayTo != null) AdressBooksList = AdressBooksList.Where(x => x.Birthday < filter.BirthdayTo);

            adressBookFilter.AdressBooksList = AdressBooksList.ToList();
            return View(adressBookFilter);
        }

        // GET: AdressBookController/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdressBookController/Create
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdressBook adress)
        {
            Repository.SaveAdress(adress);

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
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            var adress = Repository.GetAdressBook(id);
            return View(adress);
        }

        // POST: AdressBookController/Edit/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AdressBook adress)
        {
            Repository.SaveAdress(adress);

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
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            var adress = Repository.GetAdressBook(id);
            return View(adress);
        }

        // POST: AdressBookController/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            AdressBook adress = Repository.GetAdressBook(id);
            Repository.DeleteAdressBook(adress);
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
