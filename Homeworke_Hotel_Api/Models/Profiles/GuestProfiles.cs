using AutoMapper;
using Homeworke_Hotel_Api.Models.ModelsWithOut;
using Homeworke_Hotel_Api.ViewModels.Guest;

namespace Homeworke_Hotel_Api.Models.Profiles
{
    public class GuestProfiles:Profile
    {
        public GuestProfiles()
        {
            CreateMap<GuestForCreate, Guest>();
            CreateMap<Guest, GuestForUpdate>();
            CreateMap<GuestForUpdate, Guest>();
            CreateMap<Guest, GuestWithOutBookings>();
        }
    }
}
