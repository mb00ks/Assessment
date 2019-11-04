using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Models.AssessmentViewModels
{
    public class TahapanTesViewModel
    {
        public int UjianTahapId { get; set; }
        public int TipeUjianId { get; set; }
        public string Tipe { get; set; }
        public int MenitSoal { get; set; }
        public int LengthParent { get; set; }
        public int ParentId { get; set; }
        public int TipeStatus { get; set; }
        public int JumlahSoal { get; set; }
        public TimeSpan Duration { get; set; }
        public IList<Answer> Answers { get; set; }
    }
}
