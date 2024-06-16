using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeworke_Hotel_Api.Models
{
    public class Employee
    {
        public Employee()
        {
            Bookings = new List<Booking>();
        }
        //اي ان المفتاج 
        //id 
        //هوي
        //PrimaryKay
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        //تم وضعها العلاقة هذه 
        //لكي تبقى البيانات محفوظة في 
        //database
        //عند الحذف
        public bool IsDeleted { get; set; } = false;
        //ربط الفندق بالموظف
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        //ربط الحجوزات بالموظف
        public List <Booking> Bookings{ get; set; }
    }
}
