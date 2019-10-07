using Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRecruitment.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public ICollection<ScheduleDetail> ScheduleDetails { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
