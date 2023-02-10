using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowRoom.Entities
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "The RegNumber must be 8 symbols ")]
        [MaxLength(8)]
        public string RegNumber { get; set; }
        [Required]
        [MaxLength(30)]
        public string Manufacturer { get; set; }
        [Required]
        [MaxLength(30)]
        public string Model { get; set; }
        [Required]
        public string Picture { get; set; }
        public DateTime YearOfManufacture { get; set; }
        [Required]
        [Range(1000, 30000, ErrorMessage = "The price must be  between 1000 and 30000 ")]
        public double Price { get; set; }

    }
}
