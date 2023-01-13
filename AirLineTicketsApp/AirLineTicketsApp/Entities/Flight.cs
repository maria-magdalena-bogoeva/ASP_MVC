using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineTicketsApp.Entities
{
    public class Flight
    {
        public Flight()
        {
            this.Reservations = new HashSet<Reservation>();
        }
        public int Id { get; set; }
        [Required]
        public int FlightNum { get; set; }
        [Required]
        public string Departure { get; set; }
        [Required]
        public string FinalDestination { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }
        [ForeignKey("Plane")]
        [Required]
        
        public int PlaneId { get; set; }
        public Plane Plane { get; set; }
        [Required]
        public decimal TicketPrice { get; set; }
        public double Discount { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
