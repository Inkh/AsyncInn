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
        public void CanGetRoomName()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetRoomName")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //Arrange
                Room room = new Room();
                room.Name = "My Room";
                room.Layout = Layout.oneBed;

                room.Name = "RoomOne";
                //Act
                //var roomName = await context.Room.FirstOrDefaultAsync(r => r.Name == room.Name);

                //Assert
                Assert.Equal("RoomOne", room.Name);
            }
        }
    }
}
