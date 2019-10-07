using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Models
{
    public class QuestionDetail
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Item { get; set; }
        public DateTime Created { get; set; }
        public Question Question { get; set; }
        public ICollection<AnswerDetail> AnswerDetails { get; set; }
    }
}
