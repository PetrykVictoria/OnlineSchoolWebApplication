using System;
using System.Collections.Generic;
using OnlineSchoolWebApplication.Models;

namespace OnlineSchoolWebApplication;

public partial class TeacherSpecialization
{
    public int Id { get; set; }

    public int TeacherId { get; set; }

    public int SpecializationId { get; set; }

    public DateOnly StartDate { get; set; }

    public virtual Specialization Specialization { get; set; } = null!;

    public virtual ICollection<StudentTeacher> StudentTeachers { get; set; } = new List<StudentTeacher>();

    public virtual Teacher Teacher { get; set; } = null!;
}
