using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Room
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Room Name")]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(Layout))]
        public Layout Layout { get; set; }

        //Nav Props
        public ICollection<HotelRoom> HotelRoom { get; set; }
        public ICollection<RoomAmenities> RoomAmenities { get; set; }

    }

    public enum Layout
    {
        [Display(Name = "Studio")]
        studio,
        [Display(Name = "Two bed")]
        twoBed,
        [Display(Name = "One bed")]
        oneBed
    }
}
