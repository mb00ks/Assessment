using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string CreatedId { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<ExamSection> ExamSections { get; set; }
        public ApplicationUser Created { get; set; }
    }
}
