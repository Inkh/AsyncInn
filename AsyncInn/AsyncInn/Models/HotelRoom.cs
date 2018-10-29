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

        [Required]
        public int RoomNumber { get; set; }

        [Key]
        [Display(Name = "Room Type")]
        public decimal RoomID { get; set; }

        [Required]
        public decimal Rate { get; set; }

        [Required]
        [Display(Name = "Pet Friendly")]
        public bool PetFriendly { get; set; }

        //Nav Props
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
