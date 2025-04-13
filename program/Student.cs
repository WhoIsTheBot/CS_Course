using System;
using System.Linq;

public class Student
{
    private Person _person;
    private Education _education;
    private int _groupNumber;
    private Exam[] _exams;

    public Student(Person Person, Education Education, int GroupNumber, Exam[] Exams)
    {
        this._person = Person;
        this._education = Education;
        this._groupNumber = GroupNumber;
        this._exams = Exams;
    }

    public Student():this(new Person(), Education.Bachelor, 101, Array.Empty<Exam>()) { }


    public Person Person
    {        get { return _person; }
        init { _person = value; }
    }
    

    public Education Education
    {
        get { return _education; }
        init { _education = value; }
    }

    public int GroupNumber
    {
        get { return _groupNumber; }
        init { _groupNumber = value; }
    }

    public Exam[] Exams
    {
        get { return _exams; }
        init { _exams = value; }
    }

    public double AverageGrade
    {
        get
        {
            if (_exams.Length == 0) return 0;
            return _exams.Average(e => e._grade);
        }
    }

    public bool this[Education index]
    {
        get { return _education == index; }
    }

    public void AddExams(params Exam[] newExams)
    {
        _exams = _exams.Concat(newExams).ToArray();
    }

    public override string ToString()
    {
        string examsStr = string.Join("\n", _exams.Select(e => e.ToString()));
        return $"{_person}\nEducation: {_education}, Group: {_groupNumber}\nExams:\n{examsStr}";
    }

    public string ToShortString()
    {
        return $"{_person}\nEducation: {_education}, Group: {_groupNumber}, Average Grade: {AverageGrade:F2}";
    }
}