using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    // public enum PetBreedType {}
    // public enum PetColorType {}
    public class Pet {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Breed {get; set;}
        public string Color {get; set;}

        
        public Nullable <DateTime> checkedInAt { get; set; }
        
        /*[Timestamp]
        public DateTime? checkedInAt { get; set; }
        public void checkedIn() {this.checkedInAt = DateTime.Now;}
        public void checkedOut() {this.checkedInAt = null;}*/

        [ForeignKey("PetOwners")]
        public int petOwnerid {get; set;}

        public PetOwner petOwner {get; set;}
    }
}
