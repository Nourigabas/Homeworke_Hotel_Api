namespace Homeworke_Hotel_Api.Models.ModelsWithOut
{
    public class EmployeeWithOutBooking
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public int HotelId { get; set; }
    }
}
