using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Areas.Assessments.Models.AssessmentViewModels
{
    public class KraepelinViewModel
    {
        public int PakaiKraepelinId { get; set; }
        public int Xdata { get; set; }
        public int Ydata { get; set; }
        public int MinXdata { get; set; }
        public int CheckMinXdata { get; set; }
        public int BatasSoal { get; set; }
        public ICollection<KraepelinViewModelSoal> KraepelinViewModelSoals { get; set; }
        public ICollection<KraepelinViewModelJawaban> KraepelinViewModelJawabans { get; set; }
    }
    public class KraepelinViewModelSoal
    {
        public int PakaiKraepelinId { get; set; }
        public string Koordinat { get; set; }
        public int Xdata { get; set; }
        public int Ydata { get; set; }
        public int Nilai { get; set; }
    }
    public class KraepelinViewModelJawaban
    {
        public int PakaiKraepelinId { get; set; }
        public string Koordinat { get; set; }
        public int Xdata { get; set; }
        public int Ydata { get; set; }
        public int Nilai { get; set; }
    }
}
