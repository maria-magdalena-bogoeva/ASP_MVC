using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineTicketsApp.Entities
{
    public class Plane
    {
        public Plane()
        {
            this.Flights = new HashSet<Flight>();
        }
        public int Id { get; set; }
        [Required]
        public int PlaneCode { get; set; }
        [Required]
        public string PlaneType { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public double HandLuggageWeight { get; set; }
        [Required]
        public bool Boarding { get; set; }
        [Required]
        public int AvailablePlaces { get; set; }

        public ICollection<Flight> Flights { get; set; }

    }
}
