using HotelDomin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Homeworke_Hotel_Api.Models.RoomStatus;

namespace Homeworke_Hotel_Api.Models
{

    public class Room
    {
        public Room()
        {
            Bookings = new List<Booking>();
        }
        //اي ان المفتاج 
        //id 
        //هوي
        //PrimaryKay
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public int FloorNumber { get; set; }
        public EStatus Status { get; set; }
        //تم وضعها العلاقة هذه 
        //لكي تبقى البيانات محفوظة في 
        //database
        //عند الحذف
        public bool IsDeleted { get; set; } = false;
        //ربط الفندق بالغرفة
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        //ربط الحجوزات بالغرفة
        public List <Booking> Bookings { get; set; }
        //ربط نوع الغرفة بالغرفة
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }

    }
}
