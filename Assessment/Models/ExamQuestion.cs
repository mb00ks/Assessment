﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Models;

namespace Assessment.Models
{
    public class ExamQuestion
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int ExamSectionId { get; set; }
        public int QuestionId { get; set; }
        public string CreatedId { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime CreatedDate { get; set; }
        public ExamSection ExamSection { get; set; }
        public Question Question { get; set; }
        public ApplicationUser Created { get; set; }
    }
}
