using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Areas.Assessments.Models.AssessmentViewModels
{
    public class FinishViewModel
    {
        public int UjianId { get; set; }
        public int UjianPegawaiDaftarId { get; set; }
        public int UjianTahapId { get; set; }
        public string Tipe { get; set; }
        public string TipeInfo { get; set; }
        public double MenitSoal { get; set; }
        public int TipeUjianId { get; set; }
        public int LengthParent { get; set; }
        public int ParentId { get; set; }
        public int TipeStatus { get; set; }
        public int JumlahSoal { get; set; }
        public ICollection<Jawaban> Jawabans { get; set; }
    }
}
