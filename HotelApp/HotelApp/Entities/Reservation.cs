using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        [ForeignKey("Room")]
        [Required]
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public string RoomPic { get; set; }

        [ForeignKey("Client")]
        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Nights { get; set; }



    }
}
