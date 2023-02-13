using DogApp.Entities;
using DogApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApp.Abstractions
{
    public interface IDogService
    {
        bool Create(string name, int age, string breed, string img);

        bool UpdateDog(int dogId, string name, int age, string breed, string img);

        List<Dog> GetDogs();

        Dog GetDogById(int dogId);

        bool RemoveById(int dogId);

        List<Dog> GetDogs(string searchStringBreed, string searchStringName);
    }
}
