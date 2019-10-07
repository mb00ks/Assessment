using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRecruitment.Models;

namespace Assessment.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime DateExam { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
    }
}
