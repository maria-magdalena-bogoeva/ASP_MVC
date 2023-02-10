using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowRoom.Models
{
    public class CarAllViewModel
    {
        public int Id { get; set; }

       
        [Display(Name = "RegNumber")]
        public string RegNumber { get; set; }

        
        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; }

       
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Picture")]
        public string Picture { get; set; }

        [Display(Name = "YearOfManufacture")]
        public DateTime YearOfManufacture { get; set; }

        
        [Display(Name = "Price")]
        public double Price { get; set; }
    }
}
