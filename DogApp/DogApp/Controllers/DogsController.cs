using DogApp.Abstractions;
using DogApp.Data;
using DogApp.Entities;
using DogApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApp.Controllers
{
    public class DogsController : Controller
    {
        //public readonly ApplicationDbContext context;
        private readonly IDogService _dogService;
        //public DogsController(ApplicationDbContext context)
        //{
        //    this.context = context;
        //}
        public DogsController(IDogService dogService)
        {
            this._dogService = dogService;
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
        public IActionResult Create(DogCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var created = _dogService.Create(bindingModel.Name, bindingModel.Age, bindingModel.Breed, bindingModel.Img);
                if (created)
                {
                    return this.RedirectToAction("Success");
                }
                //Dog dogFromDb = new Dog
                //{
                //    Name = bindingModel.Name,
                //    Age = bindingModel.Age,
                //    Breed = bindingModel.Breed,
                //    Img = bindingModel.Img,
                //};
                //context.Dogs.Add(dogFromDb);
                //context.SaveChanges();

                //return this.RedirectToAction("Success");
            }
            return this.View();
        }

        public IActionResult Success()
        {
            return this.View();
        }
        public IActionResult All(string searchStringBreed, string searchStringName)
        {
            List<DogAllViewModel> dogs = _dogService.GetDogs().Select(dogFromDb => new DogAllViewModel
            {
                Id = dogFromDb.Id,
                Name = dogFromDb.Name,
                Age = dogFromDb.Age,
                Breed = dogFromDb.Breed,
                Img = dogFromDb.Img
            }).ToList();
            //List<DogAllViewModel> dogs = context.Dogs.Select(dogFromDb => new DogAllViewModel
            //{}).ToList();
            if (!String.IsNullOrEmpty(searchStringBreed) && !String.IsNullOrEmpty(searchStringName))
            {
                dogs = dogs.Where(d => d.Breed.ToLower() == searchStringBreed.ToLower() && d.Name.ToLower() == searchStringName.ToLower()).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringBreed))
            {
                dogs = dogs.Where(d => d.Breed.ToLower() == searchStringBreed.ToLower()).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringName))
            {
                dogs = dogs.Where(d => d.Name.ToLower() == searchStringName.ToLower()).ToList();
            }

            return View(dogs);
        }

        public IActionResult Sort()
        {
           List<DogAllViewModel> dogs = _dogService.GetDogs().Select(dogFromDb => new DogAllViewModel
           //List <DogAllViewModel> dogs = context.Dogs.Select(dogFromDb => new DogAllViewModel
            {
                Id = dogFromDb.Id,
                Name = dogFromDb.Name,
                Age = dogFromDb.Age,
                Breed = dogFromDb.Breed,
                Img = dogFromDb.Img
            }).OrderBy(x => x.Name).ToList();



            return View(dogs);
        }
        public IActionResult Edit(int id)
        {
            Dog item = _dogService.GetDogById(id);
            if (item == null)
            {
                return NotFound();
            }
            DogEditViewModel dog = new DogEditViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Img = item.Img
            };
            return View(dog);
            //if (id == null)
            //{

            //    return NotFound();
            //}

            //Dog item = context.Dogs.Find(id);
            //if (item == null)
            //{
            //    return NotFound();
            //}






        }
        [HttpPost]
        public IActionResult Edit(int id, DogEditViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var updated = _dogService.UpdateDog(id, bindingModel.Name, bindingModel.Age, bindingModel.Breed, bindingModel.Img);
                if (updated)
                {
                    return this.RedirectToAction("All");
                }
                //Dog dog = new Dog
                //{
                //    Id = bindingModel.Id,
                //    Name = bindingModel.Name,
                //    Age = bindingModel.Age,
                //    Breed = bindingModel.Breed,
                //    Img = bindingModel.Img

                //};
                //context.Dogs.Update(dog);
                //context.SaveChanges();
                //return this.RedirectToAction("All");
            }
            return this.View(bindingModel);
        }
        public IActionResult Delete(int id)
        {
            Dog item = _dogService.GetDogById(id);
            if (item == null)
            {
                return NotFound();
            }

            //Dog item = context.Dogs.Find(id);
            //if (item == null)
            //{
            //    return NotFound();
            //}

            DogDeleteViewModel dog = new DogDeleteViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Img = item.Img
            };

            return View(dog);


        }
        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _dogService.RemoveById(id);
            if (deleted)
            {
                return this.RedirectToAction("All", "Dogs");
            }
            else
            {
                return View();
            }
            //Dog item = context.Dogs.Find(id);
            //if (item == null)
            //{
            //    return NotFound();
            //}
            //context.Dogs.Remove(item);
            //context.SaveChanges();
            //return this.RedirectToAction("All", "Dogs");
        }

        public IActionResult Details(int id)
        {

            Dog item = _dogService.GetDogById(id);

            if (item == null)
            {
                return NotFound();
            }
            //Dog item = context.Dogs.Find(id);
            //if (item == null)
            //{
            //    return NotFound();
            //}
            DogDetailsViewModel dog = new DogDetailsViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Img = item.Img

            };
            return View(dog);
        }
    }
}

