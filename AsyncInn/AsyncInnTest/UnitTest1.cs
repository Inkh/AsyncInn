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
        [Fact]
        public void CanGetRoomNameTest()
        {
            Room room = new Room();
            room.Name = "Cool Room";

            Assert.Equal("Cool Room", room.Name);
        }

        [Fact]
        public void CanSetRoomNameTest()
        {
            Room room = new Room();
            room.Name = "New Room";
            room.Layout = Layout.twoBed;

            room.Name = "New Name!";

            Assert.Equal("New Name!", room.Name);
        }

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

        [Fact]
        public async void CanSaveRoomTest()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("Room")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //Arrange
                Room room = new Room();
                room.Name = "My Room";
                room.Layout = Layout.oneBed;

                context.Room.Add(room);
                context.SaveChanges();

                //Act
                var roomName = await context.Room.FirstOrDefaultAsync(r => r.Name == room.Name);

                //Assert
                Assert.Equal("My Room", roomName.Name);
            }
        }
    }
}
