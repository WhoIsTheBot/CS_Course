public class Test : IDateAndCopy
{
    public string Subject { get; set; }
    public bool IsPassed { get; set; }
    public DateTime Date { get; init; }

    public Test(string subject, bool isPassed)
    {
        Subject = subject;
        IsPassed = isPassed;
        Date = DateTime.Now;
    }

    public Test() : this("Physics", false) { }

    public override string ToString() =>
        $"Subject: {Subject}, Passed: {IsPassed}";

    public object DeepCopy() => new Test(Subject, IsPassed);

    public override bool Equals(object? obj)
    {
        if (obj is Test other)
            return Subject == other.Subject &&
                   IsPassed == other.IsPassed &&
                   Date == other.Date;
        return false;
    }

    public static bool operator ==(Test? a, Test? b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(Test? a, Test? b) => !(a == b);

    public override int GetHashCode() =>
        HashCode.Combine(Subject, IsPassed, Date);
}
