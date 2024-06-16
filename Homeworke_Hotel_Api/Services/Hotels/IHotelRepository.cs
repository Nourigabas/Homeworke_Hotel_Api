using Homeworke_Hotel_Api.Models;
using Homeworke_Hotel_Api.ViewModels.Hotel;
using Microsoft.AspNetCore.JsonPatch;

namespace Homeworke_Hotel_Api.Services.Hotels
{
    public interface IHotelRepository
    {
        public List<Hotel> GetHotels();
        public Hotel GetHotel(int HotelId);
        public void DeletHotel(int HotelId);
        public void CreateHotel(Hotel Hotel);
        public void UpdateHotel(int HotelId, JsonPatchDocument<HotelForUpdate> PatchDocument);

    }
}
