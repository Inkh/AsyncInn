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
                .UseInMemoryDatabase("Amenity")
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

        /// <summary>
        /// Tests getter on HotelRoom model
        /// </summary>
        [Fact]
        public void CanGetHotelRoomTest()
        {
            HotelRoom myHR = new HotelRoom();
            myHR.HotelID = 1;
            myHR.RoomID = 1;
            myHR.Rate = 25;
            myHR.RoomNumber = 239;

            Assert.Equal(1, myHR.HotelID);
            Assert.Equal(25, myHR.Rate);
        }

        /// <summary>
        /// Tests setter on HotelRoom model
        /// </summary>
        [Fact]
        public void CanSetHotelRoomsTest()
        {
            HotelRoom myHR = new HotelRoom();
            myHR.HotelID = 1;
            myHR.RoomID = 1;
            myHR.Rate = 25;
            myHR.RoomNumber = 239;

            myHR.RoomNumber = 1;
            myHR.Rate = 10;

            Assert.Equal(1, myHR.RoomNumber);
            Assert.Equal(10, myHR.Rate);
        }

        /// <summary>
        /// Tests CRUD operations on HotelRooms table
        /// </summary>
        [Fact]
        public async void HotelRoomsCRUDTest()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("HotelRoom")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {

                //CREATE
                //Arrange
                HotelRoom myHR = new HotelRoom();
                myHR.HotelID = 1;
                myHR.RoomID = 1;
                myHR.PetFriendly = true;
                myHR.RoomNumber = 2;
                myHR.Rate = 99;

                context.Add(myHR);
                context.SaveChanges();

                //READ
                var newHR = await context.HotelRooms.FirstOrDefaultAsync(hr => hr.HotelID == myHR.HotelID && hr.RoomID == myHR.RoomID);

                Assert.Equal(99, myHR.Rate);
                Assert.Equal(1, myHR.HotelID);

                //UPDATE
                newHR.Rate = 230;
                context.Update(newHR);
                context.SaveChanges();

                var changedHR = await context.HotelRooms.FirstOrDefaultAsync(hr => hr.HotelID == newHR.HotelID && hr.RoomID == newHR.RoomID);

                Assert.Equal(230, changedHR.Rate);
                Assert.Equal(1, changedHR.HotelID);
                Assert.Equal(1, changedHR.RoomID);

                //DELETE
                context.HotelRooms.Remove(changedHR);
                context.SaveChanges();

                var deletedHR = await context.HotelRooms.FirstOrDefaultAsync(hr => hr.HotelID == changedHR.HotelID && hr.RoomID == changedHR.RoomID);

                Assert.True(deletedHR == null);
            }
        }

        /// <summary>
        /// Tests getter on RoomAmenities model
        /// </summary>
        [Fact]
        public void CanGetRoomAmenitiesTest()
        {
            RoomAmenities ra = new RoomAmenities();
            ra.RoomID = 1;
            ra.AmenitiesID = 2;

            Assert.Equal(1, ra.RoomID);
            Assert.Equal(2, ra.AmenitiesID);
        }

        /// <summary>
        /// Tests setter on RoomAmenities model
        /// </summary>
        [Fact]
        public void CanSetRoomAmenitiesTest()
        {
            RoomAmenities ra = new RoomAmenities();
            ra.RoomID = 1;
            ra.AmenitiesID = 2;

            ra.RoomID = 10;

            Assert.Equal(10, ra.RoomID);
            Assert.Equal(2, ra.AmenitiesID);
        }

        /// <summary>
        /// Tests CRUD operations on RoomAmenities table
        /// </summary>
        [Fact]
        public async void RoomAmenitiesCRUDTest()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("RoomAmenities")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {

                //CREATE
                //Arrange
                Amenities myAm = new Amenities { Name = "AC" };
                Room myRoom = new Room { Name = "Jim crib", Layout = Layout.studio };

                RoomAmenities myRA = new RoomAmenities();
                myRA.Room = myRoom;
                myRA.Amenities = myAm;

                context.Add(myRA);
                context.SaveChanges();

                //READ
                var newRA = await context.RoomAmenities.FirstOrDefaultAsync(ra => ra.Room.Name == myRA.Room.Name && ra.Amenities.Name == myRA.Amenities.Name);

                Assert.Equal("Jim crib", newRA.Room.Name);
                Assert.Equal("AC", newRA.Amenities.Name);

                //UPDATE
                newRA.Room.Name = "Carlos crib";
                context.Update(newRA);
                context.SaveChanges();

                var changedRA = await context.RoomAmenities.FirstOrDefaultAsync(ra => ra.Room.Name == newRA.Room.Name && ra.Amenities.Name == newRA.Amenities.Name);

                Assert.Equal("Carlos crib", changedRA.Room.Name);
                Assert.Equal("AC", changedRA.Amenities.Name);

                //DELETE
                context.RoomAmenities.Remove(changedRA);
                context.SaveChanges();

                var deletedRA = await context.RoomAmenities.FirstOrDefaultAsync(ra => ra.Room.Name == changedRA.Room.Name && ra.Amenities.Name == changedRA.Amenities.Name);

                Assert.True(deletedRA == null);
            }
        }
    }
}
