using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DOOR.EF.Models;

[Table("SCHOOL")]
public partial class School
{
    [Key]
    [Column("SCHOOL_ID")]
    [Precision(8)]
    public int SchoolId { get; set; }

    [Column("SCHOOL_NAME")]
    [StringLength(30)]
    [Unicode(false)]
    public string SchoolName { get; set; } = null!;

    [Column("CREATED_BY")]
    [StringLength(30)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column("CREATED_DATE", TypeName = "DATE")]
    public DateTime CreatedDate { get; set; }

    [Column("MODIFIED_BY")]
    [StringLength(30)]
    [Unicode(false)]
    public string ModifiedBy { get; set; } = null!;

    [Column("MODIFIED_DATE", TypeName = "DATE")]
    public DateTime ModifiedDate { get; set; }

    [InverseProperty("School")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    [InverseProperty("School")]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    [InverseProperty("School")]
    public virtual ICollection<GradeConversion> GradeConversions { get; set; } = new List<GradeConversion>();

    [InverseProperty("School")]
    public virtual ICollection<GradeTypeWeight> GradeTypeWeights { get; set; } = new List<GradeTypeWeight>();

    [InverseProperty("School")]
    public virtual ICollection<GradeType> GradeTypes { get; set; } = new List<GradeType>();

    [InverseProperty("School")]
    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    [InverseProperty("School")]
    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    [InverseProperty("School")]
    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    [InverseProperty("School")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
