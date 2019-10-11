using Assessment.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebRecruitment.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Employee Employee { get; set; }
        [InverseProperty("Created")] public ICollection<Answer> Answers { get; set; }
        [InverseProperty("Created")] public ICollection<AnswerDetail> AnswerDetails { get; set; }
        [InverseProperty("Created")] public ICollection<City> Cities { get; set; }
        [InverseProperty("Created")] public ICollection<Employee> Employees { get; set; }
        [InverseProperty("Created")] public ICollection<Exam> Exams { get; set; }
        [InverseProperty("Created")] public ICollection<ExamSection> ExamSections { get; set; }
        [InverseProperty("Created")] public ICollection<ExamQuestion> ExamQuestions { get; set; }
        [InverseProperty("Created")] public ICollection<ExamSchedule> ExamSchedules { get; set; }
        [InverseProperty("Created")] public ICollection<ExamEmployee> ExamEmployees { get; set; }
        [InverseProperty("Created")] public ICollection<Gender> Genders { get; set; }
        [InverseProperty("Created")] public ICollection<MaritalStatus> MaritalStatuses { get; set; }
        [InverseProperty("Created")] public ICollection<QuestionType> QuestionTypes { get; set; }
        [InverseProperty("Created")] public ICollection<Question> Questions { get; set; }
        [InverseProperty("Created")] public ICollection<QuestionDetail> QuestionDetails { get; set; }
        [InverseProperty("Created")] public ICollection<Religion> Religions { get; set; }
    }
}
