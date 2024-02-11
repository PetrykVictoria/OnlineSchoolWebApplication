using System;
using System.Collections.Generic;

namespace OnlineSchoolWebApplication.Models;

public partial class Specialization
{
    public int Id { get; set; }

    public string SpecializationName { get; set; } = null!;

    public virtual ICollection<TeacherSpecialization> TeacherSpecializations { get; set; } = new List<TeacherSpecialization>();
}
