using System;

class Program
{
    static void Main()
    {
        // Перевірка рівності Person
        Person p1 = new Person("Alice", "Smith", new DateTime(2000, 1, 1));
        Person p2 = new Person("Alice", "Smith", new DateTime(2000, 1, 1));
        Console.WriteLine($"p1 == p2: {p1 == p2}"); // True
        Console.WriteLine($"Hash codes: {p1.GetHashCode()}, {p2.GetHashCode()}");

 
        Student student = new Student(
                new Person("Alice", "Smith", new DateTime(2000, 1, 1)),
                Education.Master,
                202
            );
        student.AddExams(
            new Exam("Physics", 4, new DateTime(2023, 6, 10)),
            new Exam("Chemistry", 5, new DateTime(2023, 6, 12))
        );

        student.AddTests(
            new Test("Physics", true),
            new Test("Mathematics", false),
            new Test("Chemistry", true)
        );


        Console.WriteLine(student.ToString()); 
        Console.WriteLine($"Average grade: {student.AverageGrade}");

        Console.WriteLine($"Person property of student: {student.Person}");

        Student copy = (Student)student.DeepCopy();
        Console.WriteLine($"Original group: {student.GroupNumber}, Copy group: {copy.GroupNumber}");

        try
        {
            Student invalidStudent = new Student { GroupNumber = 50 }; 
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }

        Console.WriteLine("\nІспити з оцінкою > 3:");
        foreach (Exam exam in student.GetExamsAbove(3))
            Console.WriteLine(exam);

        Console.WriteLine("Спільні предмети:");
        foreach (string subject in student)
            Console.WriteLine(subject);

        Console.WriteLine("\nЗдані заліки та іспити:");
        foreach (object item in student.GetAllPassedItems())
            Console.WriteLine(item);

        Console.WriteLine("\nЗаліки зі зданими іспитами:");
        foreach (Test test in student.GetPassedTestsWithExams())
            Console.WriteLine(test);
    }
}