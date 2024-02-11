using System;
using System.Collections.Generic;

namespace OnlineSchoolWebApplication;

public partial class Subscription
{
    public int Id { get; set; }

    public byte NumberOfLessons { get; set; }

    public int Price { get; set; }

    public virtual ICollection<StudentSubscription> StudentSubscriptions { get; set; } = new List<StudentSubscription>();
}
