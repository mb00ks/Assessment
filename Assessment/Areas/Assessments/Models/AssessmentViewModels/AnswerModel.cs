using Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Areas.Assessments.Models.AssessmentViewModels
{
    public class AnswerModel
    {
        public int Nomer { get; set; }
        public int UjianId { get; set; }
        public int UjianBankSoalId { get; set; }
        public int PegawaiId { get; set; }
        public int Urut { get; set; }
        public int BankSoalId { get; set; }
        public int BankSoalPilihanId { get; set; }
        public int UjianPegawaiId { get; set; }
        public int UjianTahapId { get; set; }
        public bool? IsNext { get; set; }
        //public int ExamEmployeeId { get; set; }
        //public int SectionId { get; set; }
        //public int QuestionId { get; set; }
        //public int? QuestionDetailId { get; set; }
        //public bool? IsNext { get; set; }
        //public IList<QuestionDetail> QuestionDetails { get; set; }
    }
}
