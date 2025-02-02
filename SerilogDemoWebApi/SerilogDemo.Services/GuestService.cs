using AutoMapper;
using SerilogDemo.Common.UIModels;
using SerilogDemo.Data.Entities;
using SerilogDemo.Repositories.UnitOfWork;

namespace SerilogDemo.Services
{
    public class GuestService : IGuestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GuestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GuestModel>> GetAllGuestsAsync()
        {
            var result = await _unitOfWork.Guests.GetAllAsync();
            return result.Select(x => _mapper.Map<GuestModel>(x));
        }

        public async Task<GuestModel> GetGuestByIdAsync(Guid id)
        {
            var guest = await _unitOfWork.Guests.GetByIdAsync(id);
            return _mapper.Map<GuestModel>(guest);
        }

        public async Task CreateGuestAsync(GuestModel guestModel)
        {
            var guest = _mapper.Map<Guest>(guestModel);
            await _unitOfWork.Guests.CreateAsync(guest);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateGuestAsync(Guid id, GuestModel guestModel)
        {
            if (id == guestModel.Id)
            {
                var guest = _mapper.Map<Guest>(guestModel);
                await _unitOfWork.Guests.UpdateAsync(guest);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task DeleteGuestAsync(Guid id)
        {
            await _unitOfWork.Guests.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
        public async Task UpdateGuestPhoneNumberAsync(Guid id, List<string> phoneNumbers)
        {
            await _unitOfWork.Guests.UpdateGuestPhoneNumberAsync(id, phoneNumbers);
            await _unitOfWork.CompleteAsync();
        }
    }

    //public class GuestService : IGuestService
    //{
    //    private readonly IUnitOfWork _unitOfWork;
    //    private readonly IMapper _mapper;

    //    public GuestService(IUnitOfWork unitOfWork, IMapper mapper)
    //    {
    //        _unitOfWork = unitOfWork;
    //        _mapper = mapper;
    //    }

    //    public IEnumerable<GuestModel> GetAllGuests() => _unitOfWork.Guests.GetAll().Select(x=> _mapper.Map<GuestModel>(x));
    //    public GuestModel GetGuestById(Guid id) => _mapper.Map<GuestModel>(_unitOfWork.Guests.GetById(id));
    //    public void CreateGuest(GuestModel guestModel)
    //    {
    //        var guest = _mapper.Map<Guest>(guestModel);
    //        _unitOfWork.Guests.Add(guest);
    //        _unitOfWork.Commit();
    //    }
    //    public void UpdateGuest(Guid id, GuestModel guestModel)
    //    {
    //        if (id == guestModel.Id)
    //        {
    //            var guest = _mapper.Map<Guest>(guestModel);
    //            _unitOfWork.Guests.Update(guest);
    //            _unitOfWork.Commit();
    //        }
    //    }
    //    public void DeleteGuest(Guid id)
    //    {
    //        _unitOfWork.Guests.Delete(id);
    //        _unitOfWork.Commit();
    //    }
    //    public void UpdateGuestPhoneNumber(Guid id, List<string> phoneNumbers)
    //    {
    //        _unitOfWork.Guests.UpdatePhoneNumber(id, phoneNumbers);
    //        _unitOfWork.Commit();
    //    }
    //}

}
