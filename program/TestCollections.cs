using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class TestCollections
{
    private List<Person> personList;
    private List<string> stringList;
    private Dictionary<Person, Student> personStudentDict;
    private Dictionary<string, Student> stringStudentDict;

    public static Student GenerateStudent(int index)
    {
        var person = new Person($"Name{index}", $"Surname{index}", new DateTime(2000, 1, 1).AddDays(index));
        var student = new Student(person, Education.Bachelor, 100 + (index % 50));
        student.AddExams(new Exam("Math", index % 6 + 1, DateTime.Now));
        student.AddTests(new Test("Math", index % 2 == 0));
        return student;
    }

    public TestCollections(int count)
    {
        personList = new List<Person>();
        stringList = new List<string>();
        personStudentDict = new Dictionary<Person, Student>();
        stringStudentDict = new Dictionary<string, Student>();

        for (int i = 0; i < count; i++)
        {
            var student = GenerateStudent(i);
            var person = new Person(student.FirstName, student.LastName, student.BirthDate);
            var keyString = person.ToString();

            personList.Add(person);
            stringList.Add(keyString);
            personStudentDict[person] = student;
            stringStudentDict[keyString] = student;
        }
    }

    public void MeasureSearchTime()
    {
        if (personList.Count == 0)
        {
            Console.WriteLine("Колекції порожні.");
            return;
        }

        var first = personList[0];
        var middle = personList[personList.Count / 2];
        var last = personList[^1];
        var missing = new Person("Not", "Exists", DateTime.MinValue);

        var keys = new[] { first, middle, last, missing };
        foreach (var key in keys)
        {
            string keyStr = key.ToString();

            Console.WriteLine($"\n Пошук: {keyStr}");

            Measure("List<Person>.Contains", () => personList.Contains(key));
            Measure("List<string>.Contains", () => stringList.Contains(keyStr));
            Measure("Dictionary<Person, Student>.ContainsKey", () => personStudentDict.ContainsKey(key));
            Measure("Dictionary<string, Student>.ContainsKey", () => stringStudentDict.ContainsKey(keyStr));
            Measure("Dictionary<Person, Student>.ContainsValue", () => personStudentDict.ContainsValue(new Student(key, Education.Bachelor, 101)));
        }
    }

    private void Measure(string label, Func<bool> func)
    {
        Stopwatch sw = Stopwatch.StartNew();
        bool result = func();
        sw.Stop();
        Console.WriteLine($"{label}: {result}, час: {sw.ElapsedTicks} ticks");
    }
}
