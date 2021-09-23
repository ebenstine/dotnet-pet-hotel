using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<Pet> GetPets() {
            return _context.Pets
                .Include(pet => pet.petOwner);
        }

        [HttpPost]
        public Pet PostPet(Pet pet) {
            _context.Add(pet);
            _context.SaveChanges();
            return pet;
        }


        [HttpPut("{id}/checkin")]
        public Pet Put(int id)
        {
            // grabbing the pet info from db
            Pet pet = _context.Pets.Find(id);
            // modifying the pet info (not on db yet)
            pet.checkedInAt = DateTime.Now;
            // update the db with new pet info and
            // save changes to db
            _context.Pets.Update(pet);
            _context.SaveChanges();
            return pet;
        }

        [HttpPut("{id}/checkout")]
        public IActionResult UpdateCheckOut(int id) {
            Pet requestedPet = _context.Pets.Find(id);
            if ((requestedPet) == null) return NotFound();
            requestedPet.checkedInAt = null;
            _context.Update(requestedPet);
            _context.SaveChanges();
            return Ok(requestedPet);      
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePet(int id) {
            Pet pet = _context.Pets.Find(id);
            _context.Pets.Remove(pet);
            _context.SaveChanges();
            return NoContent();
        }
        // [HttpPut("{id}/sell")]
        // public IActionResult SellById(int id) {
        //     BreadInventory bread = _context.BreadInventory.Find(id);
        //     if (bread == null) return NotFound();
        //     if (bread.inventory <= 0) return BadRequest(new { error = "Cant reduce inventory below zero" });
        //     bread.sell();
        //     _context.Update(bread);
        //     _context.SaveChanges();
        //     return Ok(bread);
        // }

        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }
    }
}
