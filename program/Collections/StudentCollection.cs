using System;
using System.Collections.Generic;
using System.Linq;

public delegate void StudentListHandler(object source, StudentListHandlerEventArgs args);

public class StudentCollection
{
    private List<Student> _students = new List<Student>();
    public string? CollectionName { get; set; }

    public event StudentListHandler? StudentCountChanged;
    public event StudentListHandler? StudentReferenceChanged;

    protected virtual void OnStudentCountChanged(StudentListHandlerEventArgs args)
    {
        StudentCountChanged?.Invoke(this, args);
    }

    protected virtual void OnStudentReferenceChanged(StudentListHandlerEventArgs args)
    {
        StudentReferenceChanged?.Invoke(this, args);
    }

    public void SubscribeToEvents(StudentListHandler countChangedHandler,
    StudentListHandler referenceChangedHandler)
    {
        StudentCountChanged += countChangedHandler;
        StudentReferenceChanged += referenceChangedHandler;
    }

    public void UnsubscribeFromEvents(StudentListHandler countChangedHandler,
        StudentListHandler referenceChangedHandler)
    {
        StudentCountChanged -= countChangedHandler;
        StudentReferenceChanged -= referenceChangedHandler;
    }

    public bool Remove(int j)
    {
        if (j < 0 || j >= _students.Count)
            return false;

        var removedStudent = _students[j];
        _students.RemoveAt(j);
        OnStudentCountChanged(new StudentListHandlerEventArgs(
            CollectionName ?? "UnnamedCollection", "Student removed", removedStudent));
        return true;
    }

    public bool TryRemove(int j, out Student? removedStudent)
    {
        removedStudent = null;
        if (j < 0 || j >= _students.Count)
            return false;

        removedStudent = _students[j];
        _students.RemoveAt(j);
        OnStudentCountChanged(new StudentListHandlerEventArgs(
            CollectionName ?? "UnnamedCollection", "Student removed", removedStudent));
        return true;
    }

    public Student this[int index]
    {
        get
        {
            if (index < 0 || index >= _students.Count)
                throw new IndexOutOfRangeException();
            return _students[index];
        }
        set
        {
            if (index < 0 || index >= _students.Count)
                throw new IndexOutOfRangeException();
            _students[index] = value ?? throw new ArgumentNullException(nameof(value));
            OnStudentReferenceChanged(new StudentListHandlerEventArgs(
                CollectionName ?? "UnnamedCollection", "Student reference changed", value));
        }
    }

    public void AddDefaults()
    {
        var defaultStudents = new[]
        {
        // Студент 1
        CreateDefaultStudent("Ivan", "Ivanov", new DateTime(2001, 5, 20), Education.Bachelor, 101,
            new[] { ("Math", 4), ("Physics", 5), ("History", 3) },
            new[] { ("Math", true), ("Physics", true), ("History", false) }),
        
        // Студент 2
        CreateDefaultStudent("Petro", "Petrov", new DateTime(2000, 3, 10), Education.Master, 205,
            new[] { ("Biology", 3), ("Chemistry", 2), ("English", 4) },
            new[] { ("Biology", true), ("Chemistry", false), ("English", true) }),
        
        // Студент 3
        CreateDefaultStudent("Anna", "Shevchenko", new DateTime(2002, 1, 30), Education.SecondEducation, 315,
            new[] { ("History", 5), ("Math", 4), ("Literature", 3) },
            new[] { ("History", true), ("Math", true), ("Literature", false) }),
        
        // Студент 4
        CreateDefaultStudent("Dmytro", "Koval", new DateTime(1999, 12, 15), Education.Bachelor, 140,
            new[] { ("Physics", 3), ("English", 4), ("Biology", 5) },
            new[] { ("Physics", true), ("English", true), ("Biology", true) }),
        
        // Студент 5
        CreateDefaultStudent("Yulia", "Savchuk", new DateTime(2001, 9, 25), Education.Master, 220,
            new[] { ("Chemistry", 5), ("Math", 5), ("Databases", 4) },
            new[] { ("Chemistry", true), ("Math", true), ("Databases", true) }),
        
        // Студент 6
        CreateDefaultStudent("Andriy", "Melnyk", new DateTime(2000, 6, 5), Education.Bachelor, 115,
            new[] { ("History", 2), ("Literature", 3), ("Programming", 4) },
            new[] { ("History", false), ("Literature", true), ("Programming", true) })
    };

        _students.AddRange(defaultStudents);

        foreach (var student in defaultStudents)
        {
            OnStudentCountChanged(new StudentListHandlerEventArgs(
                CollectionName ?? "UnnamedCollection", "Default student added", student));
        }
    }

    private Student CreateDefaultStudent(string firstName, string lastName, DateTime birthDate,
        Education education, int groupNumber,
        IEnumerable<(string Subject, int Grade)> exams,
        IEnumerable<(string Subject, bool IsPassed)> tests)
    {
        var student = new Student(new Person(firstName, lastName, birthDate), education, groupNumber);

        // Додаємо іспити з поточною датою
        var examList = exams.Select(e => new Exam(e.Subject, e.Grade, DateTime.Now)).ToArray();
        student.AddExams(examList);

        // Додаємо тести
        var testList = tests.Select(t => new Test(t.Subject, t.IsPassed)).ToArray();
        student.AddTests(testList);

        return student;
    }

    public void AddStudents(params Student[] students)
    {
        foreach (var student in students)
        {
            _students.Add(student);
            OnStudentCountChanged(new StudentListHandlerEventArgs(
                CollectionName ?? "UnnamedCollection", "Student added", student));
        }
    }

    // Решта методів залишаються незмінними
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




