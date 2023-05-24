using System.ComponentModel.DataAnnotations;

namespace WebAppMVC3.Models
{
    public class AdressBook
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Не указан електронный адресс")]
        [EmailAddress(ErrorMessage ="Некорректный адрес")]
        public string Email { get; set; }
        public string FIO { get; set; }
        //public DateTime Birthday { get; set; }

        public DateOnly Birthday { get; set; }
    }
}
