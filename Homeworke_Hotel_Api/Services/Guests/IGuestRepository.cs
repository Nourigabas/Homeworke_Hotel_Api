using Homeworke_Hotel_Api.Models;
using Homeworke_Hotel_Api.ViewModels.Guest;
using Homeworke_Hotel_Api.ViewModels.Hotel;
using Microsoft.AspNetCore.JsonPatch;

namespace Homeworke_Hotel_Api.Services.Guests
{
    public interface IGuestRepository
    {
        public List<Guest> GetGuests();
        public Guest GetGuest(int GuestId);
        public void DeletGuest(int GuestId);
        public void CreateGuest(Guest Guest);
        public void UpdateGuest(int guestId, JsonPatchDocument<GuestForUpdate> patchDocument);
    }
}
