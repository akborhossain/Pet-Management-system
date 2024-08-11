using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pet_Management_System.Data;
using Pet_Management_System.Models.Entities;

namespace Pet_Management_System.Controllers
{
    public class PetsController : Controller
    {
        private readonly ApplicationDBContext dbContext;

        public PetsController( ApplicationDBContext dbContext )
        {
            this.dbContext = dbContext;
        }


        public async Task<IActionResult> Index()
        {
            var pets= await dbContext.Pets.ToListAsync();

            return View(pets);
        }
        [HttpGet]
        public IActionResult Add() { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Pet pet) {

            var LocalPet = new Pet
            {
                PetName = pet.PetName,
                PetType = pet.PetType,
                Age = pet.Age,
                Color = pet.Color,
                Gender = pet.Gender,    
                OwnerName = pet.OwnerName,
                Address = pet.Address,
                ImageName = pet.ImageName,
                ImageFile = pet.ImageFile
   
            };

            await dbContext.Pets.AddAsync(LocalPet);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit( int id) {

            var pet= await dbContext.Pets.FindAsync(id);
            return View(pet);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Pet model)
        {
            var pet =await dbContext.Pets.FindAsync(model.PetId);

            if (pet != null) { 
                pet.PetName = model.PetName;
                pet.PetType = model.PetType;
                pet.Age = model.Age;
                pet.Color = model.Color;    
                pet.Gender = model.Gender;
                pet.OwnerName = model.OwnerName;
                pet.Address = model.Address;
                pet.OwnerName= model.OwnerName;
                pet.ImageName = model.ImageName;
                pet.ImageFile = model.ImageFile;

                await dbContext.SaveChangesAsync();
            
            }
            return View(pet);
        }
        [HttpGet]
        public IActionResult Detail(int id) { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Pet model)
        {

            var pet = await dbContext.Pets
                .AsNoTracking()
                .FirstOrDefaultAsync(x=>x.PetId == model.PetId);
            if (pet != null)
            {
                dbContext.Pets.Remove(model);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
