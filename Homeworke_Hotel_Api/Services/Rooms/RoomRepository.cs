using AutoMapper;
using Homeworke_Hotel_Api.Data;
using Homeworke_Hotel_Api.Models;
using Homeworke_Hotel_Api.ViewModels.Hotel;
using Homeworke_Hotel_Api.ViewModels.Room;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Homeworke_Hotel_Api.Services
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DataBaseContext context;
        private readonly IMapper mapper;

        public RoomRepository(DataBaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<Room> GetRooms()
        {
            var respone = context.Rooms
                                 .Where(e => e.IsDeleted == false)
                                 .Include(e=>e.Bookings)
                                 .ToList();
            return respone;
        }
        public Room GetRoom(int RoomId)
        {
            var respone = context.Rooms
                                 .Where(e => e.Id == RoomId && e.IsDeleted == false)
                                 .Include(e => e.Bookings)
                                 .FirstOrDefault();
            return respone;
        }
        public void DeletRoom(int RoomId)
        {
            var respone =  context.Rooms.FirstOrDefault(e => e.Id == RoomId);
            respone.IsDeleted = true;
            context.SaveChanges();
        }
        public void CreateRoom(Room room)
        {
             context.Rooms.Add(room);
             context.SaveChanges();
        }

        public void UpdateRoom(int RoomId, JsonPatchDocument<RoomForUpdate> PatchDocument)
        {
            var Room = context.Rooms.FirstOrDefault(e => e.Id == RoomId);
            var RoomToPatch = mapper.Map<RoomForUpdate>(Room);
            PatchDocument.ApplyTo(RoomToPatch);
            mapper.Map(RoomToPatch, Room);
            context.SaveChanges();
            return;
        }
    }
}
