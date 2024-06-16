using AutoMapper;
using Homeworke_Hotel_Api.Models.ModelsWithOut;
using Homeworke_Hotel_Api.ViewModels.Room;

namespace Homeworke_Hotel_Api.Models.Profiles
{
    public class RoomProfiles:Profile
    {
        public RoomProfiles()
        {
            //تم انشاء هذا الكلاس من اجل تحويل البيانات من نوع الى اخر لاغراض عديدة 
            //منها ارجاع البيانات عند طلبها بدون الخواص المرتبطة بها 
            CreateMap<RoomForCreate, Room>();
            CreateMap<Room, RoomForUpdate>();
            CreateMap<RoomForUpdate, Room>();
            CreateMap<Room, RoomWithOutBookings>();
        }
    }
}
