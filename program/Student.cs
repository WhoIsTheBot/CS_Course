using System;
using System.Collections.Generic;
using System.Linq;

public class Student : Person
{
    private Education _education;
    private int _groupNumber;
    private List<Test> _tests;
    private List<Exam> _exams;
    public Education Education
    {
        get => _education;
        init => _education = value;
    }

    public Student(Person person, Education education, int groupNumber)
        : base(person.FirstName, person.LastName, person.BirthDate)
    {
        _education = education;
        _groupNumber = groupNumber;
        _tests = new List<Test>();
        _exams = new List<Exam>();
    }


    public Student() : this(new Person(), Education.Bachelor, 101) { }

    public double AverageGrade => _exams.Count == 0 ? 0 : _exams.Average(e => e.Grade);

    public void AddExams(params Exam[] exams) => _exams.AddRange(exams);
    public void AddTests(params Test[] tests) => _tests.AddRange(tests);


    public override string ToString()
    {
        var testStr = string.Join("\n", _tests);
        var examStr = string.Join("\n", _exams);
        return $"{base.ToString()}, {_education}, Group: {_groupNumber}\nTests:\n{testStr}\nExams:\n{examStr}";
    }

    public string ToShortString()
    {
        return $"{base.ToString()}, {_education}, Group: {_groupNumber}, Avg: {AverageGrade:F2}, Tests: {_tests.Count}, Exams: {_exams.Count}";
    }
}
