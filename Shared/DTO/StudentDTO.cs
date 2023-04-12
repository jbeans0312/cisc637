using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DOOR.Shared.DTO;

namespace DOOR.Shared.DTO
{
	public class StudentDTO
	{
		public int StudentId { get; set; }
        [StringLength(5)]
        public string? Salutation { get; set; }
        [StringLength(25)]
        public string? FirstName { get; set; }
        [StringLength(25)]
        public string LastName { get; set; } = null!;
        [StringLength(25)]

        public string? StreetAddress { get; set; }
        [StringLength(5)]
        public string Zip { get; set; } = null!;
        [StringLength(15)]
        public string? Phone { get; set; }
        [StringLength(50)]
        public string? Employer { get; set; }
        public DateTime RegistrationDate { get; set; }

        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        [StringLength(30)]

        public string ModifiedBy { get; set; } = null!;
        public DateTime ModifiedDate { get; set; }

        public int SchoolId { get; set; }

    }
}

