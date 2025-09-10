using System.Collections.Generic;

public class AverageMarkComparer : IComparer<Student>
{
    public int Compare(Student? x, Student? y)
    {
        if (x == null || y == null)
            throw new ArgumentException("Null value");

        return x.AverageGrade.CompareTo(y.AverageGrade);
    }
}
