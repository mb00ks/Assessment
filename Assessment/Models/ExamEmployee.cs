using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Models;

namespace Assessment.Models
{
    public class ExamEmployee
    {
        public int Id { get; set; }
        public int ExamScheduleId { get; set; }
        public int EmployeeId { get; set; }
        public string CreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public ExamSchedule ExamSchedule { get; set; }
        public Employee Employee { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ApplicationUser Created { get; set; }
    }
}
