using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Models
{
    public class AnswerDetail
    {
        public int Id { get; set; }
        public int AnswerId { get; set; }
        public int QuestionDetailId { get; set; }
        public string Item { get; set; }
        public DateTime Created { get; set; }
        public Answer Answer { get; set; }
        public QuestionDetail QuestionDetail { get; set; }
    }
}
