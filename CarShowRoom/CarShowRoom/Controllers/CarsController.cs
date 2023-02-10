using CarShowRoom.Data;
using CarShowRoom.Entities;
using CarShowRoom.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowRoom.Controllers
{
    public class CarsController : Controller
    {
        public readonly ApplicationDbContext context;
        public CarsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult Create(CarCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Car carFromDb = new Car
                {
                    RegNumber = bindingModel.RegNumber,
                    Manufacturer = bindingModel.Manufacturer,
                    Model = bindingModel.Model,
                    Picture = bindingModel.Picture,
                    YearOfManufacture= bindingModel.YearOfManufacture,
                    Price= bindingModel.Price,
                };
                context.Cars.Add(carFromDb);
                context.SaveChanges();

                return this.RedirectToAction("Success");
            }
            return this.View();
        }
        public IActionResult Success()
        {
            return this.View();
        }
        // public IActionResult All(string searchModel, double searchPrice)
        public IActionResult All(string searchModel, string searchPrice)
        {
            List<CarAllViewModel> cars = context.Cars.Select(carFromDb => new CarAllViewModel
            {
                RegNumber = carFromDb.RegNumber,
                Manufacturer = carFromDb.Manufacturer,
                Model = carFromDb.Model,
                Picture = carFromDb.Picture,
                YearOfManufacture = carFromDb.YearOfManufacture,
                Price = carFromDb.Price,
            }).ToList();
            if (!String.IsNullOrEmpty(searchModel) && !String.IsNullOrEmpty(searchPrice))
            {
                cars = cars.Where(d => d.Model.ToLower() == searchModel.ToLower() && d.Price == double.Parse(searchPrice)).ToList();
            }
            else if (!String.IsNullOrEmpty(searchModel))
            {
                cars = cars.Where(d => d.Model.ToLower() == searchModel.ToLower()).ToList();
            }
            else if (!String.IsNullOrEmpty(searchPrice))
            {
                cars = cars.Where(d => d.Price== double.Parse(searchPrice)).ToList();
            }
            return View(cars);
        }
        public IActionResult Sort()
        {
            List<CarAllViewModel> cars = context.Cars.Select(carFromDb => new CarAllViewModel
            {
                RegNumber = carFromDb.RegNumber,
                Manufacturer = carFromDb.Manufacturer,
                Model = carFromDb.Model,
                Picture = carFromDb.Picture,
                YearOfManufacture = carFromDb.YearOfManufacture,
                Price = carFromDb.Price,
            }).OrderBy(x => x.Price).ToList();
            return View(cars);
        }
            
            
            public IActionResult Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            Car item = context.Cars.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            CarDetailsViewModel car = new CarDetailsViewModel()
            {
                
                RegNumber = item.RegNumber,
                Manufacturer = item.Manufacturer,
                Model = item.Model,
                Picture = item.Picture,
                YearOfManufacture = item.YearOfManufacture,
                Price = item.Price,

            };
            return View(car);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {

                return NotFound();
            }

            Car item = context.Cars.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            CarEditViewModel car = new CarEditViewModel()
            {

                RegNumber = item.RegNumber,
                Manufacturer = item.Manufacturer,
                Model = item.Model,
                Picture = item.Picture,
                YearOfManufacture = item.YearOfManufacture,
                Price = item.Price,
            };

            return View(car);


        }
        [HttpPost]
        public IActionResult Edit(CarEditViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Car car = new Car
                {
                    RegNumber = bindingModel.RegNumber,
                    Manufacturer = bindingModel.Manufacturer,
                    Model = bindingModel.Model,
                    Picture = bindingModel.Picture,
                    YearOfManufacture = bindingModel.YearOfManufacture,
                    Price = bindingModel.Price,

                };
                context.Cars.Update(car);
                context.SaveChanges();
                return this.RedirectToAction("All");
            }
            return this.View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {

                return NotFound();
            }

            Car item = context.Cars.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            CarDeleteViewModel car = new CarDeleteViewModel()
            {
                RegNumber = item.RegNumber,
                Manufacturer = item.Manufacturer,
                Model = item.Model,
                Picture = item.Picture,
                YearOfManufacture = item.YearOfManufacture,
                Price = item.Price,
            };

            return View(car);


        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Car item = context.Cars.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            context.Cars.Remove(item);
            context.SaveChanges();
            return this.RedirectToAction("All", "Cars");
        }
    }
}
