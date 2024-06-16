namespace Homeworke_Hotel_Api.ViewModels.Guest
{
    public class GuestForUpdate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
