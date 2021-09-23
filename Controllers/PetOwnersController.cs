using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet("{id}")]
        public PetOwner GetPetById(int id) {
            return _context.PetOwners
            // .include(petOwner => petOwner.id)
            .SingleOrDefault(petOwner => petOwner.Id == id);
        }

        

        [HttpGet]
        public IEnumerable<PetOwner> GetPets() {
            return _context.PetOwners;
        }

        [HttpPost]
        public PetOwner PostOwner(PetOwner petOwner) {
            // save the object to the db
            _context.PetOwners.Attach(petOwner);
            // return a response
            _context.SaveChanges();
            return petOwner;
        }

        
        
        [HttpDelete("{id}")]
        public IActionResult DeletePetOwner(int id) {
            PetOwner petOwner = _context.PetOwners.Find(id);
            _context.PetOwners.Remove(petOwner);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
