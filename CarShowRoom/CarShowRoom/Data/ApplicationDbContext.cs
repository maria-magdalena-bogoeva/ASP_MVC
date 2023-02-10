using CarShowRoom.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CarShowRoom.Models;

namespace CarShowRoom.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarShowRoom.Models.CarCreateViewModel> CarCreateViewModel { get; set; }
        public DbSet<CarShowRoom.Models.CarAllViewModel> CarAllViewModel { get; set; }
        public DbSet<CarShowRoom.Models.CarDetailsViewModel> CarDetailsViewModel { get; set; }
        public DbSet<CarShowRoom.Models.CarEditViewModel> CarEditViewModel { get; set; }
        public DbSet<CarShowRoom.Models.CarDeleteViewModel> CarDeleteViewModel { get; set; }
    }
}
