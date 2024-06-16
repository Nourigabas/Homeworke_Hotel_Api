using System.ComponentModel.DataAnnotations;

namespace Homeworke_Hotel_Api.ViewModels.Booking
{
    public class BookingForCreate
    {
        public DateTime CheckinAt { get; set; }
        public DateTime CheckoutAt { get; set; }
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Don't forget to input EmployeeId")]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Don't forget to input RoomId")]
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Don't forget to input GuestId")]
        public int GuestId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
