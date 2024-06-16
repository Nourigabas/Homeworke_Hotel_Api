using System.ComponentModel.DataAnnotations;
using static Homeworke_Hotel_Api.Models.RoomStatus;

namespace Homeworke_Hotel_Api.ViewModels.Room
{
    public class RoomForCreate
    {
        public int Number { get; set; }
        public int FloorNumber { get; set; }
        [Required(ErrorMessage = "Don't forget to input HotelId")]
        public int HotelId { get; set; }
        public EStatus Status { get; set; }
    }
}
