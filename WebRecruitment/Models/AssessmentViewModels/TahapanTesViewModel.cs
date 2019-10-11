using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRecruitment.Models.AssessmentViewModels
{
    public class TahapanTesViewModel
    {
        public int ExamSectionId { get; set; }
        public string ExamSectionName { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
