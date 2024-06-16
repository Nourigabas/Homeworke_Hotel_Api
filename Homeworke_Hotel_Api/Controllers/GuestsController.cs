using AutoMapper;
using Homeworke_Hotel_Api.Models;
using Homeworke_Hotel_Api.Models.ModelsWithOut;
using Homeworke_Hotel_Api.Services.Guests;
using Homeworke_Hotel_Api.ViewModels.Booking;
using Homeworke_Hotel_Api.ViewModels.Guest;
using Homeworke_Hotel_Api.ViewModels.Hotel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Homeworke_Hotel_Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[Controller]")]
    public class GuestsController : Controller
    {
        private readonly IGuestRepository Guest;
        private readonly IMapper mapper;

        public GuestsController(IGuestRepository Guest, IMapper mapper)
        {
            this.Guest = Guest;
            this.mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<Guest>> GetGuests([FromHeader] bool WithOut = true)
        {
            var respone = Guest.GetGuests();
            if (respone == null)
                return NotFound();
            return WithOut ? Ok(mapper.Map<List<GuestWithOutBookings>>(respone)) : Ok(respone);
        }

        [AllowAnonymous]
        [HttpGet("{GuestId}", Name = "GetGuest")]
        public ActionResult<Guest> GetGuest([FromRoute]int GuestId,[FromHeader] bool WithOut = true)
        {
            var respone = Guest.GetGuest(GuestId);
            if (respone == null)
                return NotFound();
            return WithOut ? Ok(mapper.Map<GuestWithOutBookings>(respone)) : Ok(respone);
        }


        [HttpDelete("{GuestId}")]
        public ActionResult DeletGuest([FromRoute] int GuestId)
        {
            var Check = Guest.GetGuest(GuestId);
            if (Check == null)
                return NotFound();
            Guest.DeletGuest(GuestId);
            return Ok();
        }


        [HttpPost]
        public ActionResult<Guest> CreateGuest([FromBody] GuestForCreate guest)
        {
            var GuestForCreate = mapper.Map<Guest>(guest);
            Guest.CreateGuest(GuestForCreate);
            var GuestForCreateWithOut = mapper.Map<GuestWithOutBookings>(GuestForCreate);
            return CreatedAtRoute("GetGuest", new { GuestId = GuestForCreate.Id }, GuestForCreateWithOut);
        }
        [HttpPatch]
        public ActionResult<Guest> UpdateGuest([FromHeader] int GuestId, [FromBody] JsonPatchDocument<GuestForUpdate> PatchDocument)
        {
            var Check = Guest.GetGuest(GuestId);
            if (Check == null)
                return NotFound();
            Guest.UpdateGuest(GuestId, PatchDocument);
            return NoContent();
        }
    }
}
