using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        [Display(Name = "Amenity")]
        public int AmenitiesID { get; set; }

        [Display(Name = "Room")]
        public int RoomID { get; set; }

        //Nav Props
        public Amenities Amenities { get; set; }
        public Room Room { get; set; }
    }
}
