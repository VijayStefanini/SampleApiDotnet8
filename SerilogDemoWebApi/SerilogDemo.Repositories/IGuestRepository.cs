using SerilogDemo.Data.Entities;

namespace SerilogDemo.Repositories
{
    public interface IGuestRepository : IGenericRepository<Guest>
    {
        Task UpdateGuestPhoneNumberAsync(Guid id, List<string> phoneNumbers);
    }


}
