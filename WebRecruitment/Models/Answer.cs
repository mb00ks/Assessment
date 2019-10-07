using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRecruitment.Models;

namespace Assessment.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int ScheduleDetailId { get; set; }
        public int QuestionId { get; set; }
        public string Item { get; set; }
        public DateTime Created { get; set; }
        public ScheduleDetail ScheduleDetail { get; set; }
        public Question Question { get; set; }
        public ICollection<AnswerDetail> AnswerDetails { get; set; }
    }
}
