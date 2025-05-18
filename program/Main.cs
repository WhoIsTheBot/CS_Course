class Program
{
    static void Main()
    {
        var students = new StudentCollection();
        // students.AddDefaults();
        // Console.WriteLine("\n--- Початковий список студентів ---");
        // Console.WriteLine(students.ToShortString());

        // students.SortByLastName();
        // Console.WriteLine("\n--- Сортування за прізвищем ---");
        // Console.WriteLine(students.ToShortString());

        // students.SortByBirthDate();
        // Console.WriteLine("\n--- Сортування за датою народження ---");
        // Console.WriteLine(students.ToShortString());

        // students.SortByAverageMark();
        // Console.WriteLine("\n--- Сортування за середнім балом ---");
        // Console.WriteLine(students.ToShortString());

        // Console.WriteLine($"\nМакс. середній бал: {students.MaxAverageMark:F2}");

        // Console.WriteLine("\n--- Магістри ---");
        // foreach (var s in students.MasterStudents)
        //     Console.WriteLine(s.ToShortString());

        // Console.WriteLine("\n--- Група зі середнім балом = 5 ---");
        // foreach (var s in students.AverageMarkGroup(5.0))
        //     Console.WriteLine(s.ToShortString());

        


        // TestCollections
        Console.WriteLine("\n=== Перевірка TestCollections ===");
        int collectionSize = 10000;
        
        Console.WriteLine("\n=== Стандартні колекції ===");
        var testCol = new TestCollections(collectionSize);
        testCol.MeasureSearchTime();
        
        Console.WriteLine("\n=== Immutable колекції ===");
        var testImmutableCol = new TestImmutableCollections(collectionSize);
        testImmutableCol.MeasureSearchTime();
        
        Console.WriteLine("\n=== Sorted колекції ===");
        var testSortedCol = new TestSortedCollections(collectionSize);
        testSortedCol.MeasureSearchTime();
    }
}
