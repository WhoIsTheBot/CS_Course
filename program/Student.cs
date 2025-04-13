using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Student : Person, IDateAndCopy, IEnumerable<string>
{
    private Education _education;
    private int _groupNumber;
    private ArrayList _tests = new ArrayList();
    private ArrayList _exams = new ArrayList();

    public Student(Person person, Education education, int groupNumber)
        : base(person.FirstName, person.LastName, person.BirthDate)
    {
        _education = education;
        _groupNumber = groupNumber; 
    }


    public Student() : this(new Person(), Education.Bachelor, 101) { }


    public Person Person
    {
        get => new Person(_firstName, _lastName, _birthDate);
        init
        {
            _firstName = value.FirstName;
            _lastName = value.LastName;
            _birthDate = value.BirthDate;
        }
    }

    public int GroupNumber
    {
        get => _groupNumber;
        init
        {
            if (value < 101 || value > 699)
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Номер группы должен быть от 101 до 699."
                );
            _groupNumber = value;
        }
    }

    public double AverageGrade
    {
        get => _exams.Count == 0
            ? 0
            : _exams.Cast<Exam>().Average(e => e.Grade);
    }

    public void AddExams(params Exam[] exams)
    {
        if (exams == null)
            throw new ArgumentNullException(nameof(exams));

        _exams.AddRange(exams);
    }

    public void AddTests(params Test[] tests)
    {
        if (tests == null)
            throw new ArgumentNullException(nameof(tests));

        _tests.AddRange(tests);
    }

    public override string ToString()
    {
        string tests = string.Join("\n", _tests.Cast<Test>().Select(t => t.ToString()));
        string exams = string.Join("\n", _exams.Cast<Exam>().Select(e => e.ToString()));
        return $"{base.ToString()}\nОсвіта: {_education}, Группа: {_groupNumber}\nЗаліки:\n{tests}\nІспити:\n{exams}";
    }

    public override string ToShortString()
    {
        return $"{base.ToShortString()}\nОсвіта: {_education}, Группа: {_groupNumber}, Середній балл: {AverageGrade:F2}";
    }

    public override object DeepCopy()
    {
        Student copy = new Student(
            (Person)base.DeepCopy(),
            _education,
            _groupNumber
        );

        copy._tests = new ArrayList();
        foreach (Test test in _tests)
            copy._tests.Add(test.DeepCopy());

        copy._exams = new ArrayList();
        foreach (Exam exam in _exams)
            copy._exams.Add(exam.DeepCopy());

        return copy;
    }


    public IEnumerator<string> GetEnumerator()
    {
        return new StudentEnumerator(_tests, _exams);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<Exam> GetExamsAbove(int minGrade)
    {
        foreach (Exam exam in _exams)
            if (exam.Grade > minGrade)
                yield return exam;
    }


    // Ітератор для зданих заліків та іспитів з оцінкою > 2
    public IEnumerable GetAllPassedItems()
    {
        foreach (var item in _tests)
            if (item is Test test && test.IsPassed)
                yield return test;

        foreach (var item in _exams)
            if (item is Exam exam && exam.Grade > 2)
                yield return exam;
    }

    // Ітератор для заліків з відповідними іспитами
    public IEnumerable<Test> GetPassedTestsWithExams()
    {
        foreach (Test test in _tests)
            if (test.IsPassed && _exams.Cast<Exam>().Any(e => e.Subject == test.Subject && e.Grade > 2))
                yield return test;
    }
}