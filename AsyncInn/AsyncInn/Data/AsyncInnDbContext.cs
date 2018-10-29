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

        }

        public DbSet<Room> Room { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }

    }
}
