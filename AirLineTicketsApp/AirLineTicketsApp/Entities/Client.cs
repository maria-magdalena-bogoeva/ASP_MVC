using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineTicketsApp.Entities
{
    public class Client
    {
        public Client()
        {
            this.Reservations = new HashSet<Reservation>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(10)]
        public string PhoneNum { get; set; }

        [Required]
        public string Adress { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
