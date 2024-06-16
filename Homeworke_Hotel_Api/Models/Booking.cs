using HotelDomin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeworke_Hotel_Api.Models
{
    public class Booking
    {
        public Booking()
        {
            Payments = new List<Payment>();
        }
        //اي ان المفتاج 
        //id 
        //هوي
        //PrimaryKay
        [Key]
        public int Id { get; set; }
        public DateTime CheckinAt { get; set; }
        public DateTime CheckoutAt { get; set; }
        public decimal Price { get; set; }
        //تم وضعها العلاقة هذه 
        //لكي تبقى البيانات محفوظة في 
        //database
        //عند الحذف
        public bool IsDeleted { get; set; } = false;
        //ربط الموظف بالحجز
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        //ربط الغرفة بالحجز
        public Room Room { get; set; }
        public int RoomId { get; set; }
        //ربط الزبون بالحجز
        public Guest Guest { get; set; }
        public int GuestId { get; set; }
        //ربط الدفعات المالية بالحجز
        public List<Payment> Payments { get; set; }

    }
}
