using AutoMapper;
using Azure;
using Homeworke_Hotel_Api.Data;
using Homeworke_Hotel_Api.Models;
using Homeworke_Hotel_Api.ViewModels.Guest;
using Homeworke_Hotel_Api.ViewModels.Hotel;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace Homeworke_Hotel_Api.Services.Guests
{

    public class GuestRepository : IGuestRepository
    {
        private readonly DataBaseContext context;
        private readonly IMapper mapper;

        public GuestRepository(DataBaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<Guest> GetGuests()
        {
            var respone = context.Guests
                                 .Where(e => e.IsDeleted == false)
                                 .Include(e=>e.Bookings)
                                 .ToList();
            return respone;
        }
        public Guest GetGuest(int GuestId)
        {
            var respone = context.Guests
                                 .Where(e => e.Id == GuestId && e.IsDeleted == false)
                                 .Include(e => e.Bookings)
                                 .FirstOrDefault();
            return respone;
        }
        public void DeletGuest(int GuestId)
        {
            var respone = context.Guests.FirstOrDefault(e => e.Id == GuestId);
            respone.IsDeleted = true;
            context.SaveChanges();
        }
        public void CreateGuest(Guest Guest)
        {
            context.Guests.Add(Guest);
            context.SaveChanges();
        }

        public void UpdateGuest(int GuestId, JsonPatchDocument<GuestForUpdate> PatchDocument)
        {

            var Guest = context.Guests.FirstOrDefault(e => e.Id == GuestId);
            var GuestToPatch = mapper.Map<GuestForUpdate>(Guest);
            PatchDocument.ApplyTo(GuestToPatch);
            mapper.Map(GuestToPatch, Guest);
            context.SaveChanges();
            return;
        }
    }
}
