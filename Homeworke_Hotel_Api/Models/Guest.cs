using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeworke_Hotel_Api.Models
{
    public class Guest
    {
        public Guest()
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
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //تم وضعها العلاقة هذه 
        //لكي تبقى البيانات محفوظة في 
        //database
        //عند الحذف
        public bool IsDeleted { get; set; } = false;
        //ربط الزبون بالحجوزات

        //تم وضع العلاقة 
        //one to many 
        //ومناقشة انه اذا لا يمكن للزبون ان يكون له اكثر من حجز في وثت واحد
        public List <Booking> Bookings { get; set; }
    }
}
