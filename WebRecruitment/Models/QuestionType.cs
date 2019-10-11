using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRecruitment.Models;

namespace Assessment.Models
{
    public class QuestionType
    {
        public int Id { get; set; }
        public string CreatedId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ApplicationUser Created { get; set; }
    }
}
