using AutoMapper;
using Homeworke_Hotel_Api.Data;
using Homeworke_Hotel_Api.Models;
using Homeworke_Hotel_Api.ViewModels.Booking;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Homeworke_Hotel_Api.Services.Bookings
{
    public class BookingsRepository : IBookingsRepository
    {
        private readonly DataBaseContext context;
        private readonly IMapper mapper;

        public BookingsRepository(DataBaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void CreateBooking(Booking Booking)
        {
            context.Bookings.Add(Booking);
            context.SaveChanges();
        }
        public List<Booking> GetBookings()
        {
            var respone = context.Bookings
                         .Where(e => e.IsDeleted == false)
                         .Include(e => e.Payments)
                         .ToList();
            return respone;

        }
        public Booking GetBooking(int BookingId)
        {
            var respone = context.Bookings
                                 .Where(e => e.Id == BookingId && e.IsDeleted == false)
                                 .Include(e => e.Payments)
                                 .FirstOrDefault();
            return respone;
        }
        public void DeletBooking(int BookingId)
        {
            var respone = context.Bookings.FirstOrDefault(e => e.Id == BookingId);
            respone.IsDeleted = true;
            context.SaveChanges();
        }

        public void UpdateBooking(int BookingId, JsonPatchDocument<BookingForUpdate> patchDocument)
        {
            var Booking = context.Bookings.FirstOrDefault(e => e.Id == BookingId);
            var BookingToPatch = mapper.Map<BookingForUpdate>(Booking);
            patchDocument.ApplyTo(BookingToPatch);
            mapper.Map(BookingToPatch, Booking);
            context.SaveChanges();
            return;
        }
    }
}
