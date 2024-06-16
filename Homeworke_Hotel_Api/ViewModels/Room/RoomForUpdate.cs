using static Homeworke_Hotel_Api.Models.RoomStatus;
using System.ComponentModel.DataAnnotations;

namespace Homeworke_Hotel_Api.ViewModels.Room
{
    public class RoomForUpdate
    {
        //تم انشاء هذا الكلاس من اجل ادخال البيانات الاولية اللازمة من اجل عملية تعديل بيانات غرفة  

        public int Number { get; set; }
        public int FloorNumber { get; set; }
        public int HotelId { get; set; }
        public EStatus Status { get; set; }
    }
}
