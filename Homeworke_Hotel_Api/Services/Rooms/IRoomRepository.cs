using Homeworke_Hotel_Api.Models;
using Homeworke_Hotel_Api.ViewModels.Hotel;
using Homeworke_Hotel_Api.ViewModels.Room;
using Microsoft.AspNetCore.JsonPatch;

namespace Homeworke_Hotel_Api.Services
{
    public interface IRoomRepository
    {
        public List<Room> GetRooms();
        public Room GetRoom(int RoomId);
        public void DeletRoom(int RoomId);
        public void CreateRoom(Room room);
        public void UpdateRoom(int roomId, JsonPatchDocument<RoomForUpdate> patchDocument);
    }
}
