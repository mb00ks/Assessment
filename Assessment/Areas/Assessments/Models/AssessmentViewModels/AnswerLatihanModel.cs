using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Areas.Assessments.Models.AssessmentViewModels
{
    public class AnswerLatihanModel
    {
        public IList<int> ReqXData { get; set; }
        public IList<int> ReqYData { get; set; }
        public IList<string> ReqXYDataNilai { get; set; }
        public int ReqPakaiKraepelinId { get; set; }
        public int ReqUjianPegawaiDaftarId { get; set; }
        public int ReqPegawaiId { get; set; }
        public int ReqJadwalTesId { get; set; }
        public int ReqFormulaAssesmentId { get; set; }
        public int ReqFormulaEselonId { get; set; }
        public int ReqUjianId { get; set; }
        public int ReqTipeUjianId { get; set; }
        public int ReqUjianTahapId { get; set; }
    }
}
