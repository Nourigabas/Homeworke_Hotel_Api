using Homeworke_Hotel_Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDomin
{
    public class Payment
    {
        //اي ان المفتاج 
        //id 
        //هوي
        //PrimaryKay
        [Key]
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        //تم وضعها العلاقة هذه 
        //لكي تبقى البيانات محفوظة في 
        //database
        //عند الحذف
        public bool IsDeleted { get; set; } = false;
        //ربط الدفعة المالية بالحجز
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}
