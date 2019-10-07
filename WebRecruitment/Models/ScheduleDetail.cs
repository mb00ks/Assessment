using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRecruitment.Models;

namespace Assessment.Models
{
    public class ScheduleDetail
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public int EmployeeId { get; set; }
        public int ExamId { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime Created { get; set; }
        public Schedule Schedule { get; set; }
        public Employee Employee { get; set; }
        public Exam Exam { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
