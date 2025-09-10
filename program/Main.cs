class Program
{
    static void Main()
    {
        var students = new StudentCollection();
        students.AddDefaults();
        Console.WriteLine("\n--- Початковий список студентів ---");
        Console.WriteLine(students.ToShortString());

        students.SortByLastName();
        Console.WriteLine("\n--- Сортування за прізвищем ---");
        Console.WriteLine(students.ToShortString());

        students.SortByBirthDate();
        Console.WriteLine("\n--- Сортування за датою народження ---");
        Console.WriteLine(students.ToShortString());

        students.SortByAverageMark();
        Console.WriteLine("\n--- Сортування за середнім балом ---");
        Console.WriteLine(students.ToShortString());

        Console.WriteLine($"\nМакс. середній бал: {students.MaxAverageMark:F2}");

        Console.WriteLine("\n--- Магістри ---");
        foreach (var s in students.MasterStudents)
            Console.WriteLine(s.ToShortString());

        Console.WriteLine("\n--- Група зі середнім балом = 5 ---");
        foreach (var s in students.AverageMarkGroup(5.0))
            Console.WriteLine(s.ToShortString());

        Console.WriteLine("\n=== Перевірка TestCollections ===");
        var testCol = new TestCollections(10000);  // можеш змінити розмір
        testCol.MeasureSearchTime();
    }
}
