using System.ComponentModel.DataAnnotations;

namespace WebAppMVC3.Models
{
    public class AdressBookFilter
    {
        public int? Id { get; set; }
        public string? Email { get; set; }
        public string? FIO { get; set; }
        public DateTime? BirthdayFrom { get; set; }
        public DateTime? BirthdayTo { get; set; }
        public List<AdressBook>? AdressBooksList { get; set; }
    }
}
