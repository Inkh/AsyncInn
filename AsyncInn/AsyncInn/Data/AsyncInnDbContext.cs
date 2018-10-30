using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Recognizes Composite Keys
            modelBuilder.Entity<RoomAmenities>().HasKey(
                ce => new { ce.RoomID, ce.AmenitiesID }
                );

            modelBuilder.Entity<HotelRoom>().HasKey(
                ce => new { ce.RoomID, ce.HotelID }
                );

            //Seeds 5 amenities into DB
            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "Air Conditioning"
                },
                new Amenities
                {
                    ID = 2,
                    Name = "Private Parking"
                },
                new Amenities
                {
                    ID = 3,
                    Name = "Heater"
                },
                new Amenities
                {
                    ID = 4,
                    Name = "In-unit washer dryer"
                },
                new Amenities
                {
                    ID = 5,
                    Name = "Jacuzzi"
                }
                );

            //Seeds 6 room types into DB
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "Single",
                    Layout = Layout.oneBed
                },
                new Room
                {
                    ID = 2,
                    Name = "Double",
                    Layout = Layout.twoBed
                },
                new Room
                {
                    ID = 3,
                    Name = "Personal Resort",
                    Layout = Layout.studio
                },
                new Room
                {
                    ID = 4,
                    Name = "Executive Suite",
                    Layout = Layout.oneBed
                },
                new Room
                {
                    ID = 5,
                    Name = "Halloween Party Special",
                    Layout = Layout.twoBed
                },
                new Room
                {
                    ID = 6,
                    Name = "Budget BnB",
                    Layout = Layout.studio
                }
                );

            //Seeds 5 hotels into DB
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Waterfront Inn",
                    Address = "1989 Waterfront Ave",
                    Phone = "(888) 921-1023"
                },
                new Hotel
                {
                    ID = 2,
                    Name = "Code Fellows",
                    Address = "2901 3rd Ave #300",
                    Phone = "(206) 681 - 9318"
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Async Inn Prima",
                    Address = "2901 3rd Ave #200",
                    Phone = "(317) 792 - 8429"
                },
                new Hotel
                {
                    ID = 4,
                    Name = "Crib of Jim",
                    Address = "1922 1st Ave",
                    Phone = "(999) 888-7777"
                },
                new Hotel
                {
                    ID = 5,
                    Name = "Budget Inn",
                    Address = "22323 Budget Ave",
                    Phone = "(909) 887-2348"
                }
                );

        }

        public DbSet<Room> Room { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }

    }
}
