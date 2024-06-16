using AutoMapper;
using Homeworke_Hotel_Api.Models.ModelsWithOut;
using Homeworke_Hotel_Api.ViewModels.Booking;

namespace Homeworke_Hotel_Api.Models.Profiles
{
    public class BookingProfiles:Profile
    {
        public BookingProfiles()
        {
            CreateMap<BookingForCreate, Booking>();
            CreateMap<Booking, BookingForUpdate>();
            CreateMap<BookingForUpdate, Booking>();
            CreateMap<Booking, BookingWithOutPayments>();
        }
    }
}
