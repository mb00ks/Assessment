using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebRecruitment.Models
{
    public class Navigation
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        public int? PrevOrderId { get; set; }
        public int? NextOrderId { get; set; }
        public string Path { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Route { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
