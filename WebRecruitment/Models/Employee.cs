using Assessment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebRecruitment.Models
{
    public class Gender
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class Religion
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class MaritalStatus
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string UserForeignKey { get; set; }

        [Required]
        public int GenderId { get; set; }

        [Required]
        public int ReligionId { get; set; }

        [Required]
        public int MaritalStatusId { get; set; }

        [Required]
        public int IdentityNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }

        [Required]
        public string BirthDatePlace { get; set; }

        public Gender Gender { get; set; }
        public string Address { get; set; }
        public Religion Religion { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime Created { get; set; }
        public ICollection<ScheduleDetail> ScheduleDetails { get; set; }
    }
}
