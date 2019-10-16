using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Models.AssessmentViewModels
{
    public class TahapanTesViewModel
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
