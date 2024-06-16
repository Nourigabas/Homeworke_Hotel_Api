namespace Homeworke_Hotel_Api.ViewModels.Hotel
{
    public class HotelForCreate
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
