using AutoMapper;
using Homeworke_Hotel_Api.Models;
using Homeworke_Hotel_Api.Models.ModelsWithOut;
using Homeworke_Hotel_Api.Services;
using Homeworke_Hotel_Api.ViewModels.Guest;
using Homeworke_Hotel_Api.ViewModels.Hotel;
using Homeworke_Hotel_Api.ViewModels.Room;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Homeworke_Hotel_Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[Controller]")]
    public class RoomsController : Controller
    {
        private readonly IRoomRepository Room;
        private readonly IMapper mapper;

        public RoomsController(IRoomRepository Room, IMapper mapper)
        {
            this.Room = Room;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult<List<Room>> GetRooms([FromHeader]bool WithOut = true)
        {
            var respone = Room.GetRooms();
            if (respone == null)
                return NotFound();
            return WithOut ? Ok(mapper.Map<List<RoomWithOutBookings>>(respone)) : Ok(respone);
        }
        [HttpGet("{RoomId}", Name = "GetRoom")]
        public ActionResult<Room> GetRoom([FromRoute]int RoomId, [FromHeader] bool WithOut = true)
        {
            var respone = Room.GetRoom(RoomId);
            if (respone == null)
                return NotFound();
            return WithOut ? Ok(mapper.Map<RoomWithOutBookings>(respone)) : Ok(respone);
        }
        [HttpDelete("{RoomId}")]
        public ActionResult DeletRoom([FromRoute]int RoomId)
        {
            var Check = Room.GetRoom(RoomId);
            if (Check == null)
                return NotFound();
            Room.DeletRoom(RoomId);
            return Ok();
        }
        [HttpPost]
        public ActionResult<Room> CreateRoom([FromBody]RoomForCreate room)
        {
            var RoomForCreate = mapper.Map<Room>(room);
            Room.CreateRoom(RoomForCreate);
            var RoomForCreateWithOut = mapper.Map<RoomWithOutBookings>(RoomForCreate);
            return CreatedAtRoute("GetEmployee", new { RoomId = RoomForCreate.Id }, RoomForCreateWithOut);
        }

        [HttpPatch]
        public ActionResult<Room> UpdateRoom([FromHeader] int RoomId, [FromBody] JsonPatchDocument<RoomForUpdate>  PatchDocument)
        {
            var Check = Room.GetRoom(RoomId);
            if (Check == null)
                return NotFound();
            Room.UpdateRoom(RoomId, PatchDocument);
            return NoContent();
        }
    }
}
