using Microsoft.AspNetCore.Mvc;
using SerilogDemo.Common.UIModels;
using SerilogDemo.Services;
using SerilogDemo.Data.Entities;
using SerilogDemoWebApi.Authorization;

namespace SerilogDemoWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;
        private readonly ILogger<GuestController> _logger;
        public GuestController(IGuestService guestService, ILogger<GuestController> logger)
        {
            _guestService = guestService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guest>>> GetGuests()
        {
            _logger.LogInformation("Logging Information for Action GetGuests");
            var guests = await _guestService.GetAllGuestsAsync();
            return Ok(guests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Guest>> GetGuest(Guid id)
        {
            var guest = await _guestService.GetGuestByIdAsync(id);
            if (guest == null)
            {
                return NotFound();
            }
            return Ok(guest);
        }

        [HttpPost]
        public async Task<ActionResult> CreateGuest([FromBody] GuestModel guest)
        {
            await _guestService.CreateGuestAsync(guest);
            return CreatedAtAction(nameof(GetGuest), new { id = guest.Id }, guest);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGuest(Guid id, [FromBody] GuestModel guest)
        {
            if (id != guest.Id)
            {
                return BadRequest();
            }

            await _guestService.UpdateGuestAsync(id, guest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGuest(Guid id)
        {
            await _guestService.DeleteGuestAsync(id);
            return NoContent();
        }

        [HttpPatch("{id}/phoneNumbers")]
        public async Task<ActionResult> UpdatePhoneNumbers(Guid id, [FromBody] List<string> phoneNumbers)
        {
            if (phoneNumbers == null || phoneNumbers.Count == 0) return BadRequest("Phone numbers cannot be empty.");
            await _guestService.UpdateGuestPhoneNumberAsync(id, phoneNumbers);
            return NoContent();
        }
        
    }

}
