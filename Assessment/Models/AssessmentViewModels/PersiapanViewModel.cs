﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Models.AssessmentViewModels
{
    public class PersiapanViewModel
    {
        public DateTime DateExam { get; set; }
        public DateTime TanggalAwal { get; set; }
        public DateTime TanggalAkhir { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
