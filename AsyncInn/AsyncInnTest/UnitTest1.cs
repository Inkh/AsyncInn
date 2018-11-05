using System;
using Xunit;
using AsyncInn;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models;
using System.Linq;

namespace AsyncInnTest
{
    public class UnitTest1
    {
        /// <summary>
        /// Tests getters on Room model
        /// </summary>
        [Fact]
        public void CanGetRoomNameTest()
        {
            Room room = new Room();
            room.Name = "Cool Room";

            Assert.Equal("Cool Room", room.Name);
        }

        /// <summary>
        /// Tests setters on Room model
        /// </summary>
        [Fact]
        public void CanSetRoomNameTest()
        {
            Room room = new Room();
            room.Name = "New Room";
            room.Layout = Layout.twoBed;

            room.Name = "New Name!";

            Assert.Equal("New Name!", room.Name);
        }

        /// <summary>
        /// Tests CRUD operations on Room table
        /// </summary>
        [Fact]
        public async void RoomCRUDTest()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("Room")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {

                //CREATE
                //Arrange
                Room room = new Room();
                room.Name = "My Room";
                room.Layout = Layout.oneBed;

                context.Room.Add(room);
                context.SaveChanges();

                //READ
                var myRoom = await context.Room.FirstOrDefaultAsync(r => r.Name == room.Name);

                Assert.Equal("My Room", myRoom.Name);


                //UPDATE
                myRoom.Name = "New Name";
                context.Update(myRoom);
                context.SaveChanges();

                var newRoom = await context.Room.FirstOrDefaultAsync(r => r.Name == myRoom.Name);

                Assert.Equal("New Name", newRoom.Name);
                Assert.Equal(1, newRoom.ID);

                //DELETE
                context.Room.Remove(newRoom);
                context.SaveChanges();

                var deletedRoom = await context.Room.FirstOrDefaultAsync(r => r.Name == newRoom.Name);

                Assert.True(deletedRoom == null);
            }
        }

        /// <summary>
        /// Tests getter on Hotel model
        /// </summary>
        [Fact]
        public void CanGetHotelNameTest()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "Jim's crib";

            Assert.Equal("Jim's crib", hotel.Name);
        }

        /// <summary>
        /// Tests setter on Hotel model
        /// </summary>
        [Fact]
        public void CanSetHotelNameTest()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "Jim's crib";

            hotel.Name = "Carlos' crib";

            Assert.Equal("Carlos' crib", hotel.Name);
        }

        /// <summary>
        /// Tests CRUD operations on Hotel table
        /// </summary>
        [Fact]
        public async void HotelCRUDTest()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("Hotel")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {

                //CREATE
                //Arrange
                Hotel hotel = new Hotel();
                hotel.Name = "Async Inn";
                hotel.Phone = "(999)999-9999";
                hotel.Address = "Everywhere";

                context.Hotel.Add(hotel);
                context.SaveChanges();

                //READ
                var myHotel = await context.Hotel.FirstOrDefaultAsync(h => h.Name == hotel.Name);

                Assert.Equal("Async Inn", myHotel.Name);


                //UPDATE
                myHotel.Name = "Sync Inn";
                context.Update(myHotel);
                context.SaveChanges();

                var newHotel = await context.Hotel.FirstOrDefaultAsync(h => h.Name == myHotel.Name);

                Assert.Equal("Sync Inn", newHotel.Name);
                Assert.Equal(1, newHotel.ID);

                //DELETE
                context.Hotel.Remove(newHotel);
                context.SaveChanges();

                var deletedHotel = await context.Hotel.FirstOrDefaultAsync(h => h.Name == newHotel.Name);

                Assert.True(deletedHotel == null);
            }
        }

        /// <summary>
        /// Tests getter on Amenities model
        /// </summary>
        [Fact]
        public void CanGetAmenityName()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "AC";

            Assert.Equal("AC", amenity.Name);
        }

        /// <summary>
        /// Tests setter on Amenities model
        /// </summary>
        [Fact]
        public void CanSetAmenityName()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "AC";

            amenity.Name = "Heater";

            Assert.Equal("Heater", amenity.Name);
        }

        /// <summary>
        /// Tests CRUD operations on Amenities table
        /// </summary>
        [Fact]
        public async void AmenitiesCRUDTest()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("Room")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {

                //CREATE
                //Arrange
                Amenities amenity = new Amenities();
                amenity.Name = "AC";

                context.Amenities.Add(amenity);
                context.SaveChanges();

                //READ
                var myAmenity = await context.Amenities.FirstOrDefaultAsync(a => a.Name == amenity.Name);

                Assert.Equal("AC", myAmenity.Name);


                //UPDATE
                myAmenity.Name = "Heater";
                context.Update(myAmenity);
                context.SaveChanges();

                var newAmenity = await context.Amenities.FirstOrDefaultAsync(a => a.Name == myAmenity.Name);

                Assert.Equal("Heater", newAmenity.Name);
                Assert.Equal(1, newAmenity.ID);

                //DELETE
                context.Amenities.Remove(newAmenity);
                context.SaveChanges();

                var deletedAmenity = await context.Amenities.FirstOrDefaultAsync(a => a.Name == newAmenity.Name);

                Assert.True(deletedAmenity == null);
            }
        }
    }
}
