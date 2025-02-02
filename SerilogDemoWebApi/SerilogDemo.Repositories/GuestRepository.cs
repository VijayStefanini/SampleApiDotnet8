using SerilogDemo.Data.DBContexts;
using SerilogDemo.Data.Entities;

namespace SerilogDemo.Repositories
{
    public class GuestRepository : GenericRepository<Guest>, IGuestRepository
    {
        public GuestRepository(AppDbContext context) : base(context) { }

        public async Task UpdateGuestPhoneNumberAsync(Guid id, List<string> phoneNumbers)
        {
            var guest = await GetByIdAsync(id);
            if (guest != null)
            {
                guest.PhoneNumbers = string.Join(",", phoneNumbers.ToArray());
            }
        }
    }
}
