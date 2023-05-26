using WebAppMVC3.Models;

namespace WebAppMVC3.Data
{
    public class AdressRepository
    {
        private ApplicationContext Context;
        public AdressRepository(ApplicationContext context)
        {
            Context = context;
        }
        public IQueryable<AdressBook> GetAdressBooks()
        {
            return Context.AdressBook.OrderBy(x => x.FIO);
            //return Context.Adress.OrderBy(x => x.FIO);
        }

        public AdressBook GetAdressBook(int id)
        {
            return Context.AdressBook.Single(x => x.Id == id);
            //return Context.Adress.Single(x => x.Id == id);
        }
        public int SaveAdress(AdressBook adressBook)
        {
            if(adressBook.Id == default)
                Context.Entry(adressBook).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            else
                Context.Entry(adressBook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return adressBook.Id;
        }

        public void DeleteAdressBook(AdressBook adressBook) {
            Context.AdressBook.Remove(adressBook);
            //Context.Adress.Remove(adressBook);
            Context.SaveChanges();
        }

    }
}
