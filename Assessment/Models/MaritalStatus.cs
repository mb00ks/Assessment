﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Models;

namespace Assessment.Models
{
    public class MaritalStatus
    {
        public int Id { get; set; }
        public string CreatedId { get; set; }
        [Required] public string Code { get; set; }
        [Required] public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ApplicationUser Created { get; set; }
    }
}
