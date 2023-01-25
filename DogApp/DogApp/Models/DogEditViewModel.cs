using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogApp.Models
{
    public class DogEditViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Required]
        [Range(1, 30, ErrorMessage = "Age mustbe a positive number and lower than 30!")]
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Breed")]
        public string Breed { get; set; }

        [Display(Name = "Dog Img")]
        public string Img { get; set; }
    }
}
