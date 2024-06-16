using AutoMapper;
using Azure;
using Homeworke_Hotel_Api.Data;
using Homeworke_Hotel_Api.Models;
using Homeworke_Hotel_Api.Models.ModelsWithOut;
using Homeworke_Hotel_Api.Services.Hotels;
using Homeworke_Hotel_Api.ViewModels.Hotel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
namespace Homeworke_Hotel_Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[Controller]")]
    public class HotelsController : Controller
    {
        private readonly IHotelRepository Hotel;
        private readonly IMapper mapper;

        public HotelsController(IHotelRepository Hotel, IMapper mapper)
        {
            this.Hotel = Hotel;
            this.mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<Hotel>> GetHotels([FromHeader]bool WithOut = true)
        {
            var respone = Hotel.GetHotels();
            if (respone == null)
                return NotFound();
            return WithOut ? Ok(mapper.Map<List<HotelWithOutRoomsAndEmployees>>(respone)) : Ok(respone);
        }
        [AllowAnonymous]
        [HttpGet("{HotelId}", Name = "GetHotel")]
        public ActionResult<Hotel> GetHotel([FromRoute]int HotelId, [FromHeader]bool WithOut = true)
        {
            var respone = Hotel.GetHotel(HotelId);
            if (respone == null)
                return NotFound();
            return WithOut ? Ok(mapper.Map<HotelWithOutRoomsAndEmployees>(respone)) : Ok(respone);
        }
        [HttpDelete("{HotelId}")]
        public ActionResult DeletHotel([FromRoute]int HotelId)
        {
            var Check = Hotel.GetHotel(HotelId);
            if (Check == null)
                return NotFound();
            Hotel.DeletHotel(HotelId);
            return Ok();
        }
        [HttpPost]
        public ActionResult<Hotel> CreateHotel([FromBody]HotelForCreate hotel)
        {
            var HotelForCreate = mapper.Map<Hotel>(hotel);
            Hotel.CreateHotel(HotelForCreate);
            var HotelForCreateWithOut = mapper.Map<HotelWithOutRoomsAndEmployees>(HotelForCreate);
            return CreatedAtRoute("GetHotel", new { HotelId = HotelForCreate.Id }, HotelForCreateWithOut);
        }

        [HttpPatch]
        public ActionResult<Hotel> UpdateHotel([FromHeader] int HotelId, [FromBody] JsonPatchDocument<HotelForUpdate> PatchDocument)
        {
            var Check = Hotel.GetHotel(HotelId);
            if (Check == null)
                return NotFound();
            Hotel.UpdateHotel(HotelId, PatchDocument);
            return NoContent();
        }
    }
}
