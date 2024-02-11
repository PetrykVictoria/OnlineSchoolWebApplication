using System;
using System.Collections.Generic;

namespace OnlineSchoolWebApplication;

public partial class StudentSubscription
{
    public int StudentId { get; set; }

    public int SubscriptionId { get; set; }

    public byte Status { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual Subscription Subscription { get; set; } = null!;
}
