using SerilogDemo.Common.UIModels;
using SerilogDemo.Data.Entities;

namespace SerilogDemo.Services
{
    public interface IGuestService
    {
        Task<IEnumerable<GuestModel>> GetAllGuestsAsync();
        Task<GuestModel> GetGuestByIdAsync(Guid id);
        Task CreateGuestAsync(GuestModel guest);
        Task UpdateGuestAsync(Guid id, GuestModel guest);
        Task DeleteGuestAsync(Guid id);
        Task UpdateGuestPhoneNumberAsync(Guid id, List<string> phoneNumbers);
    }


    //public interface IGuestService
    //{
    //    Task<IEnumerable<Guest>> GetAllGuestsAsync();
    //    Task<Guest> GetGuestByIdAsync(Guid id);
    //    Task CreateGuestAsync(Guest guest);
    //    Task UpdateGuestAsync(Guest guest);
    //    Task DeleteGuestAsync(Guid id);
    //}
}
