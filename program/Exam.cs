public class Exam : IDateAndCopy
{
    public string Subject { get; set; }
    public int Grade { get; set; }
    public DateTime ExamDate { get; set; }
    public DateTime Date { get; init; }

    public Exam(string subject, int grade, DateTime examDate)
    {
        Subject = subject;
        Grade = grade;
        ExamDate = examDate;
        Date = DateTime.Now;
    }

    public Exam() : this("Math", 5, new DateTime(2023, 6, 15)) { }

    // Перевизначення Equals, ==, !=
    public override bool Equals(object? obj)
    {
        if (obj is Exam other)
            return Subject == other.Subject &&
                   Grade == other.Grade &&
                   ExamDate == other.ExamDate;
        return false;
    }

    public static bool operator ==(Exam a, Exam b) => a.Equals(b);
    public static bool operator !=(Exam a, Exam b) => !a.Equals(b);

    public override int GetHashCode() =>
        HashCode.Combine(Subject, Grade, ExamDate);

    // Глибока копія
    public object DeepCopy() =>
        new Exam(Subject, Grade, ExamDate);

        public override string ToString()
    {
        return $"{Subject}, Оцінка: {Grade}, Дата: {ExamDate.ToShortDateString()}";
    }
}