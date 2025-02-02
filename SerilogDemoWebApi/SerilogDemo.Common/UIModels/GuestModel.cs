using SerilogDemo.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerilogDemo.Common.UIModels
{

    public class GuestModel
    {
        public Guid Id { get; set; }

        [Required]
        public EnumUserTitle Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(1)]
        public List<string> PhoneNumbers { get; set; }

        public GuestModel()
        {
            Id = Guid.NewGuid();
            Title = EnumUserTitle.None;
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthDate = DateTime.Today;
            Email = string.Empty;
            PhoneNumbers = new List<string>();
        }
    }
}
