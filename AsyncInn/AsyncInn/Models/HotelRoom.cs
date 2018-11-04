using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        [Display(Name = "Hotel")]
        public int HotelID { get; set; }

        [Required(ErrorMessage = "This field cannot be empty")]
        public int RoomNumber { get; set; }

        [Display(Name = "Room Type")]
        public int RoomID { get; set; }

        [Required(ErrorMessage = "This field cannot be empty")]
        public decimal Rate { get; set; }

        [Required]
        [Display(Name = "Pet Friendly")]
        public bool PetFriendly { get; set; }

        //Nav Props
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
