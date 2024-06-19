using AutoMapper;
using Homeworke_Hotel_Api.Models;
using Homeworke_Hotel_Api.Models.ModelsWithOut;
using Homeworke_Hotel_Api.Services;
using Homeworke_Hotel_Api.ViewModels.Booking;
using Homeworke_Hotel_Api.ViewModels.Employee;
using Homeworke_Hotel_Api.ViewModels.Hotel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Homeworke_Hotel_Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[Controller]")]
    public class BookingsController : Controller
    {
        private readonly IBookingsRepository Booking;
        private readonly IMapper mapper;

        public BookingsController(IBookingsRepository Booking, IMapper mapper)
        {
            this.Booking = Booking;
            this.mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<Booking>> GetBookings([FromHeader] bool WithOut=true)
        {
            var respone = Booking.GetBookings();
            if (respone == null)
                return NotFound();
            return WithOut ? Ok(mapper.Map<List<BookingWithOutPayments>>(respone)) : Ok(respone);

        }
        [AllowAnonymous]
        [HttpGet("{BookingId}", Name = "GetBooking")]
        public ActionResult<Booking> GetBooking([FromRoute] int BookingId,[FromHeader] bool WithOut = true)
        {
            var respone = Booking.GetBooking(BookingId);
            if (respone == null)
                return NotFound();
            return WithOut ? Ok(mapper.Map<BookingWithOutPayments>(respone)) : Ok(respone);
        }
        [HttpDelete("{BookingId}")]
        public ActionResult DeletBooking([FromRoute]int BookingId)
        {
            var Check = Booking.GetBooking(BookingId);
            if (Check == null)
                return NotFound();
            Booking.DeletBooking(BookingId);
            return Ok();
        }
        [HttpPost]
        public ActionResult<Booking> CreateBooking([FromBody]BookingForCreate booking)
        {
            var BookingForCreate = mapper.Map<Booking>(Booking);
            Booking.CreateBooking(BookingForCreate);
            var BookingForCreateWithOut = mapper.Map<BookingWithOutPayments>(BookingForCreate);
            return CreatedAtRoute("GetBooking", new { BookingId = BookingForCreate.Id }, BookingForCreateWithOut);
        }
        [HttpPatch]
        public ActionResult<Booking> UpdateRoom([FromHeader] int BookingId, [FromBody] JsonPatchDocument<BookingForUpdate> PatchDocument)
        {
            var Check = Booking.GetBooking(BookingId);
            if (Check == null)
                return NotFound();
            Booking.UpdateBooking(BookingId, PatchDocument);
            return NoContent();
        }
    }
}
