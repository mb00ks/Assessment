using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebRecruitment.Models
{
    public class EmployeeViewModel
    {
        public int GenderId { get; set; }
        public int ReligionId { get; set; }
        public int MaritalStatusId { get; set; }
        public int IdentityNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDatePlace { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Password)]
        [StringLength(maximumLength: 8, MinimumLength = 6, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
