using System;
using System.Collections.Generic;
using System.Linq;

public class StudentCollection
{
    private List<Student> _students = new List<Student>();

    public void AddDefaults()
    {
        var s1 = new Student(new Person("Ivan", "Ivanov", new DateTime(2001, 5, 20)), Education.Bachelor, 101);
        s1.AddExams(
            new Exam("Math", 4, new DateTime(2024, 6, 1)),
            new Exam("Physics", 5, new DateTime(2024, 6, 3)),
            new Exam("History", 3, new DateTime(2024, 6, 5))
        );
        s1.AddTests(
            new Test("Math", true),
            new Test("Physics", true),
            new Test("History", false)
        );

        var s2 = new Student(new Person("Petro", "Petrov", new DateTime(2000, 3, 10)), Education.Master, 205);
        s2.AddExams(
            new Exam("Biology", 3, new DateTime(2024, 6, 2)),
            new Exam("Chemistry", 2, new DateTime(2024, 6, 4)),
            new Exam("English", 4, new DateTime(2024, 6, 6))
        );
        s2.AddTests(
            new Test("Biology", true),
            new Test("Chemistry", false),
            new Test("English", true)
        );

        var s3 = new Student(new Person("Alga", "Shevchenko", new DateTime(2002, 1, 30)), Education.SecondEducation, 315);
        s3.AddExams(
            new Exam("History", 5, new DateTime(2024, 6, 5)),
            new Exam("Math", 4, new DateTime(2024, 6, 6)),
            new Exam("Literature", 3, new DateTime(2024, 6, 7))
        );
        s3.AddTests(
            new Test("History", true),
            new Test("Math", true),
            new Test("Literature", false)
        );

        var s4 = new Student(new Person("Dmytro", "Koval", new DateTime(1999, 12, 15)), Education.Bachelor, 140);
        s4.AddExams(
            new Exam("Physics", 3, new DateTime(2024, 6, 7)),
            new Exam("English", 4, new DateTime(2024, 6, 8)),
            new Exam("Biology", 5, new DateTime(2024, 6, 9))
        );
        s4.AddTests(
            new Test("Physics", true),
            new Test("English", true),
            new Test("Biology", true)
        );

        var s5 = new Student(new Person("Yulia", "Savchuk", new DateTime(2001, 9, 25)), Education.Master, 220);
        s5.AddExams(
            new Exam("Chemistry", 5, new DateTime(2024, 6, 9)),
            new Exam("Math", 5, new DateTime(2024, 6, 10)),
            new Exam("Databases", 4, new DateTime(2024, 6, 11))
        );
        s5.AddTests(
            new Test("Chemistry", true),
            new Test("Math", true),
            new Test("Databases", true)
        );

        var s6 = new Student(new Person("Andriy", "Melnyk", new DateTime(2000, 6, 5)), Education.Bachelor, 115);
        s6.AddExams(
            new Exam("History", 2, new DateTime(2024, 6, 11)),
            new Exam("Literature", 3, new DateTime(2024, 6, 12)),
            new Exam("Programming", 4, new DateTime(2024, 6, 13))
        );
        s6.AddTests(
            new Test("History", false),
            new Test("Literature", true),
            new Test("Programming", true)
        );

        var s7 = new Student(new Person("Nadiia", "Bondar", new DateTime(2002, 4, 22)), Education.SecondEducation, 308);
        s7.AddExams(
            new Exam("Programming", 5, new DateTime(2024, 6, 13)),
            new Exam("Databases", 5, new DateTime(2024, 6, 14)),
            new Exam("Math", 5, new DateTime(2024, 6, 15))
        );
        s7.AddTests(
            new Test("Programming", true),
            new Test("Databases", true),
            new Test("Math", true)
        );

        _students.AddRange(new[] { s1, s2, s3, s4, s5, s6, s7 });
    }


    public void AddStudents(params Student[] students)
    {
        _students.AddRange(students);
    }

    public override string ToString()
    {
        return string.Join("\n\n", _students.Select(s => s.ToString()));
    }

    public string ToShortString()
    {
        return string.Join("\n", _students.Select(s => s.ToShortString()));
    }

    public void SortByLastName() => _students.Sort(); 
    public void SortByBirthDate() => _students.Sort(new Person()); 
    public void SortByAverageMark() => _students.Sort(new AverageMarkComparer());

    public double MaxAverageMark =>
        _students.Count == 0 ? 0 : _students.Max(s => s.AverageGrade);

    public IEnumerable<Student> MasterStudents =>
        _students.Where(s => s is not null && s.Education == Education.Master);

    public List<Student> AverageMarkGroup(double value)
    {
        return _students
            .Where(s => Math.Abs(s.AverageGrade - value) < 0.0001)
            .ToList();
    }
}
