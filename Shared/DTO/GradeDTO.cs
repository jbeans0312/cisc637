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
	public class GradeDTO
	{
        public int SchoolId { get; set; }
        public int StudentId { get; set; }
        public int SectionId { get; set; }
        [StringLength(2)]
        public string GradeTypeCode { get; set; } = null!;
        [Precision(3)]
        public byte GradeCodeOccurrence { get; set; }

        public decimal NumericGrade { get; set; }
        public string? Comments { get; set; }

        [StringLength(30)]
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }

        [StringLength(30)]
        public string ModifiedBy { get; set; } = null!;
        public DateTime ModifiedDate { get; set; }
    }
}

