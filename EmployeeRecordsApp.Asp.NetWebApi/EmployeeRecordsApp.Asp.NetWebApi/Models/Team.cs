using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeRecordsApp.Asp.NetWebApi.Models
{
    public class Team
    {

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(2000, 2020)]
        public int Founded { get; set; }
        [Required]
        [Range(0, 49)]
        public int CompletedProjects { get; set; }
    }
}