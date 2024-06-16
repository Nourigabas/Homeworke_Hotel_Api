using static Homeworke_Hotel_Api.Models.RoomStatus;

namespace Homeworke_Hotel_Api.Models.ModelsWithOut
{
    public class RoomWithOutBookings
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int FloorNumber { get; set; }
        public EStatus Status { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int HotelId { get; set; }
    }
}
