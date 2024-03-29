﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Models;

namespace Assessment.Models
{
    public class ExamSection
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int SectionId { get; set; }
        public string CreatedId { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        [DataType(DataType.MultilineText)] public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public Exam Exam { get; set; }
        public Section Section { get; set; }
        public ICollection<ExamQuestion> ExamQuestions { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ApplicationUser Created { get; set; }
    }
}
