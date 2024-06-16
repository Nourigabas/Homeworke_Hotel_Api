using AutoMapper;
using Homeworke_Hotel_Api.Models.ModelsWithOut;
using Homeworke_Hotel_Api.ViewModels.Hotel;

namespace Homeworke_Hotel_Api.Models.Profiles
{
    public class HotelProfiles:Profile
    {
        public HotelProfiles()
        {
            CreateMap<HotelForCreate, Hotel>();
            CreateMap<Hotel, HotelForUpdate>();
            CreateMap<HotelForUpdate, Hotel>();
            CreateMap<Hotel, HotelWithOutRoomsAndEmployees>();

        }
    }
}
