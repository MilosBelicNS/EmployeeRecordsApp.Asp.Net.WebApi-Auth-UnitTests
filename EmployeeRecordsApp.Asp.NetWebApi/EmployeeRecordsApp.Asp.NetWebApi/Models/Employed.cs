using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeRecordsApp.Asp.NetWebApi.Models
{
    public class Employed
    {

        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Role { get; set; }
        [Required]
        [Range(1960, 1994)]
        public int Birth { get; set; }
        [Required]
        [Range(2001, 2020)]
        public int EmploymentYear { get; set; }
        [Required]
        [Range(301, 9999)]
        public decimal Salary { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

    }
}