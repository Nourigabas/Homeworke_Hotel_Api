using System.ComponentModel.DataAnnotations;

namespace Homeworke_Hotel_Api.Models
{
    public class Hotel
    {
        public Hotel()
        {
            Employees = new List<Employee>();
            Rooms = new List<Room>();
        }
        //اي ان المفتاج 
        //id 
        //هوي
        //PrimaryKay
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        //تم وضعها العلاقة هذه 
        //لكي تبقى البيانات محفوظة في 
        //database
        //عند الحذف
        public bool IsDeleted { get; set; } = false;
        //ربط الموظفين بالفندق
        public List<Employee> Employees { get; set; }
        //ربط الغرف بالفندق
        public List<Room> Rooms { get; set; }

    }
}
