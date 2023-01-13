using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.Entities
{
    public class Room
    {
        public Room()
        {
            this.Reservations = new HashSet<Reservation>();
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(3)]
        public int RoomNumber { get; set; }
      
        public string Picture { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Bonus { get; set; }
        [Required]
        public decimal Price { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
