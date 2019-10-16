using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Models;

namespace Assessment.Models
{
    public class AnswerDetail
    {
        public int Id { get; set; }
        public int AnswerId { get; set; }
        public int QuestionDetailId { get; set; }
        public string CreatedId { get; set; }
        public string Item { get; set; }
        public DateTime CreatedDate { get; set; }
        public Answer Answer { get; set; }
        public QuestionDetail QuestionDetail { get; set; }
        public ApplicationUser Created { get; set; }
    }
}
