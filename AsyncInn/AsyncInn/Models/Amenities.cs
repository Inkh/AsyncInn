using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Amenities
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        public string Name { get; set; }

        //Nav Props
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }
}
