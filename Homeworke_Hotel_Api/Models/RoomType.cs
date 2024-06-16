using Homeworke_Hotel_Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDomin
{
    public class RoomType
    {
        public RoomType()
        {
            Rooms = new List<Room>();
        }
        //اي ان المفتاج 
        //id 
        //هوي
        //PrimaryKay
        [Key]
        public int Id { get; set; }
        public string TypeName { get; set; }
        public int NumOfBeds { get; set; }
        //تم وضعها العلاقة هذه 
        //لكي تبقى البيانات محفوظة في 
        //database
        //عند الحذف
        public bool IsDeleted { get; set; } = false;
        //ربط نوع الغرفة بالغرف
        public List<Room> Rooms { get; set; }
    }
}
