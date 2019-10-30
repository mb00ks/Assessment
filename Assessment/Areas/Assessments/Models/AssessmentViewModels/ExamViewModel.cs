using Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Areas.Assessments.Models.AssessmentViewModels
{
    public class ExamViewModel
    {
        public int UjianBankSoalId { get; set; }
        public int BankSoalId { get; set; }
        public int TipeSoal { get; set; }
        public string Judul { get; set; }
        public string PathGambar { get; set; }
        public string PathSoal { get; set; }
        public string PathJawaban { get; set; }
        //public int ExamEmployeeId { get; set; }
        //public int SectionId { get; set; }
        //public int QuestionId { get; set; }
        //public int QuestionDetailId { get; set; }
        //public int Number { get; set; }
        //public bool IsNext { get; set; }
        //public string SectionName { get; set; }
        //public TimeSpan Duration { get; set; }
        //public Question Question { get; set; }
        //public IList<QuestionDetail> QuestionDetails { get; set; }
        //public IList<ExamQuestion> ExamQuestions { get; set; }
        //public IList<Answer> Answers { get; set; }
    }
}
