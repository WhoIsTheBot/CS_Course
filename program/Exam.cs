using System;

public class Exam
{
    public string _subject { get; set; } 
    public int _grade { get; set; }
    public DateTime _examDate { get; set; }

    public Exam(string Subject, int Grade, DateTime ExamDate)
    {
        this._subject = Subject;
        this._grade = Grade;
        this._examDate = ExamDate;
    }

    public Exam() : this("Math", 5, new DateTime(2023, 6, 15)) { }

    public override string ToString()
    {
        return $"{_subject}, Grade: {_grade}, Date: {_examDate.ToShortDateString()}";
    }
}