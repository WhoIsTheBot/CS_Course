class Program
{
    static void Main()
    {
        var collection1 = new StudentCollection { CollectionName = "Collection 1" };
        var collection2 = new StudentCollection { CollectionName = "Collection 2" };

        var journal1 = new Journal();
        var journal2 = new Journal();

        collection1.StudentCountChanged += journal1.StudentCollectionChanged;
        collection1.StudentReferenceChanged += journal1.StudentCollectionChanged;

        collection1.StudentCountChanged += journal2.StudentCollectionChanged;
        collection1.StudentReferenceChanged += journal2.StudentCollectionChanged;
        collection2.StudentCountChanged += journal2.StudentCollectionChanged;
        collection2.StudentReferenceChanged += journal2.StudentCollectionChanged;

        collection1.AddStudents(
            new Student(new Person("Ivan", "Ivanov", new DateTime(2000, 1, 1)), Education.Bachelor, 101),
            new Student(new Person("Petro", "Petrov", new DateTime(1999, 5, 15)), Education.Master, 202)
        );

        collection2.AddDefaults();

        collection1.Remove(0);
        collection2.Remove(1);

        collection1[0] = new Student(new Person("New", "Student", new DateTime(2001, 3, 3)), Education.Bachelor, 303);
        collection2[0] = new Student(new Person("Another", "One", new DateTime(2002, 4, 4)), Education.SecondEducation, 404);

        Console.WriteLine("Journal 1 (only collection1 events):");
        Console.WriteLine(journal1);

        Console.WriteLine("\nJournal 2 (all events):");
        Console.WriteLine(journal2);
    }
}