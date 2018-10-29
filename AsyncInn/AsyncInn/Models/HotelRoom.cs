using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        public int HotelID { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        public decimal RoomID { get; set; }

        [Required]
        public decimal Rate { get; set; }

        [Required]
        public bool PetFriendly { get; set; }

        //Nav Props
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
