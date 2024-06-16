using AutoMapper;
using Homeworke_Hotel_Api.Data;
using Homeworke_Hotel_Api.Models;
using Homeworke_Hotel_Api.ViewModels.Hotel;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace Homeworke_Hotel_Api.Services.Hotels
{

    public class HotelRepository : IHotelRepository
    {
        private readonly DataBaseContext context;
        private readonly IMapper mapper;

        public HotelRepository(DataBaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }

        public void CreateHotel(Hotel Hotel)
        {
            context.Hotels.Add(Hotel);
            context.SaveChanges();
        }

        public List<Hotel> GetHotels()
        {
            var respone = context.Hotels
                                 .Where(e => e.IsDeleted == false)
                                 .Include(e=>e.Rooms)
                                 .Include(e=>e.Employees)
                                 .ToList();
            return respone;
        }
        public Hotel GetHotel(int HotelId)
        {
            var respone = context.Hotels
                                 .Where(e => e.Id == HotelId && e.IsDeleted == false)
                                 .Include(e => e.Rooms)
                                 .Include(e => e.Employees)
                                 .FirstOrDefault();
            return respone;
        }
        public void DeletHotel(int HotelId)
        {
            var respone = context.Hotels.FirstOrDefault(e => e.Id == HotelId);
            respone.IsDeleted = true;
            context.SaveChanges();
        }
        public void UpdateHotel(int HotelId, JsonPatchDocument<HotelForUpdate> PatchDocument)
        {
            var Hotel = context.Hotels.FirstOrDefault(e => e.Id == HotelId);
            var HotelToPatch = mapper.Map<HotelForUpdate>(Hotel);
            PatchDocument.ApplyTo(HotelToPatch);
            mapper.Map(HotelToPatch, Hotel);
            context.SaveChanges();
            return;
        }
    }
}
