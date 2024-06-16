using Homeworke_Hotel_Api.Models;
using Homeworke_Hotel_Api.ViewModels.Booking;
using Homeworke_Hotel_Api.ViewModels.Hotel;
using Microsoft.AspNetCore.JsonPatch;

namespace Homeworke_Hotel_Api.Services
{
    public interface IBookingsRepository
    {
        public List<Booking> GetBookings();
        public Booking GetBooking(int BookingId);
        public void DeletBooking(int BookingId);
        public void CreateBooking(Booking Booking);
        public void UpdateBooking(int BookingId, JsonPatchDocument<BookingForUpdate> patchDocument);
    }
}
