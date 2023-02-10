using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowRoom.Models
{
    public class CarEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "The RegNumber must be 8 symbols ")]
        [MaxLength(8)]
        [Display(Name = "RegNumber")]
        public string RegNumber { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Picture")]
        public string Picture { get; set; }

        [Display(Name = "YearOfManufacture")]
        public DateTime YearOfManufacture { get; set; }

        [Required]
        [Range(1000, 30000, ErrorMessage = "The price must be  between 1000 and 30000 ")]
        [Display(Name = "Price")]
        public double Price { get; set; }
    }
}
