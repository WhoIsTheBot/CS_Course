using System;

public class Exam
{
    private string _subject;
    private int _grade;
    private DateTime _examDate;

    public Exam(string subject, int grade, DateTime examDate)
    {
        _subject = subject;
        _grade = grade;
        _examDate = examDate;
    }

    public Exam() : this("Math", 5, new DateTime(2023, 6, 15)) { }

    public string Subject
    {
        get => _subject;
        set => _subject = value;
    }

    public int Grade
    {
        get => _grade;
        set => _grade = value;
    }

    public DateTime ExamDate
    {
        get => _examDate;
        set => _examDate = value;
    }

    public override string ToString()
    {
        return $"{Subject}, Grade: {Grade}, Date: {ExamDate.ToShortDateString()}";
    }
}
