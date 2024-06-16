using AutoMapper;
using Homeworke_Hotel_Api.Models.ModelsWithOut;
using Homeworke_Hotel_Api.ViewModels.Room;

namespace Homeworke_Hotel_Api.Models.Profiles
{
    public class RoomProfiles:Profile
    {
        public RoomProfiles()
        {
            CreateMap<RoomForCreate, Room>();
            CreateMap<Room, RoomForUpdate>();
            CreateMap<RoomForUpdate, Room>();
            CreateMap<Room, RoomWithOutBookings>();
        }
    }
}
