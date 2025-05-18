using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.Specialized;
using System.Diagnostics;

public class TestImmutableCollections
{
    private ImmutableList<Person> personImmutableList;
    private ImmutableList<string> stringImmutableList;
    private ImmutableDictionary<Person, Student> personStudentImmutableDict;
    private ImmutableDictionary<string, Student> stringStudentImmutableDict;

    public TestImmutableCollections(int count)
    {
        var personListBuilder = ImmutableList.CreateBuilder<Person>();
        var stringListBuilder = ImmutableList.CreateBuilder<string>();
        var personDictBuilder = ImmutableDictionary.CreateBuilder<Person, Student>();
        var stringDictBuilder = ImmutableDictionary.CreateBuilder<string, Student>();

        for (int i = 0; i < count; i++)
        {
            var student = TestCollections.GenerateStudent(i);
            var person = new Person(student.FirstName, student.LastName, student.BirthDate);
            var keyString = person.ToString();

            personListBuilder.Add(person);
            stringListBuilder.Add(keyString);
            personDictBuilder.Add(person, student);
            stringDictBuilder.Add(keyString, student);
        }

        personImmutableList = personListBuilder.ToImmutable();
        stringImmutableList = stringListBuilder.ToImmutable();
        personStudentImmutableDict = personDictBuilder.ToImmutable();
        stringStudentImmutableDict = stringDictBuilder.ToImmutable();
    }

    public void MeasureSearchTime()
    {
        if (personImmutableList.Count == 0)
        {
            Console.WriteLine("Immutable колекції порожні.");
            return;
        }

        var first = personImmutableList[0];
        var middle = personImmutableList[personImmutableList.Count / 2];
        var last = personImmutableList[^1];
        var missing = new Person("Not", "Exists", DateTime.MinValue);

        var keys = new[] { first, middle, last, missing };
        foreach (var key in keys)
        {
            string keyStr = key.ToString();

            Console.WriteLine($"\n Пошук в Immutable колекціях: {keyStr}");

            Measure("ImmutableList<Person>.Contains", () => personImmutableList.Contains(key));
            Measure("ImmutableList<string>.Contains", () => stringImmutableList.Contains(keyStr));
            Measure("ImmutableDictionary<Person, Student>.ContainsKey", () => personStudentImmutableDict.ContainsKey(key));
            Measure("ImmutableDictionary<string, Student>.ContainsKey", () => stringStudentImmutableDict.ContainsKey(keyStr));
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

public class TestSortedCollections
{
    private SortedList<Person, Student> personStudentSortedList;
    private SortedList<string, Student> stringStudentSortedList;
    private SortedDictionary<Person, Student> personStudentSortedDict;
    private SortedDictionary<string, Student> stringStudentSortedDict;

    public TestSortedCollections(int count)
    {
        personStudentSortedList = new SortedList<Person, Student>();
        stringStudentSortedList = new SortedList<string, Student>();
        personStudentSortedDict = new SortedDictionary<Person, Student>();
        stringStudentSortedDict = new SortedDictionary<string, Student>();

        for (int i = 0; i < count; i++)
        {
            var student = TestCollections.GenerateStudent(i);
            var person = new Person(student.FirstName, student.LastName, student.BirthDate);
            var keyString = person.ToString();

            personStudentSortedList.Add(person, student);
            stringStudentSortedList.Add(keyString, student);
            personStudentSortedDict.Add(person, student);
            stringStudentSortedDict.Add(keyString, student);
        }
    }

    public void MeasureSearchTime()
    {
        if (personStudentSortedList.Count == 0)
        {
            Console.WriteLine("Sorted колекції порожні.");
            return;
        }

        var first = personStudentSortedList.Keys[0];
        var middle = personStudentSortedList.Keys[personStudentSortedList.Count / 2];
        var last = personStudentSortedList.Keys[^1];
        var missing = new Person("Not", "Exists", DateTime.MinValue);

        var keys = new[] { first, middle, last, missing };
        foreach (var key in keys)
        {
            string keyStr = key.ToString();

            Console.WriteLine($"\n Пошук в Sorted колекціях: {keyStr}");

            Measure("SortedList<Person, Student>.ContainsKey", () => personStudentSortedList.ContainsKey(key));
            Measure("SortedList<string, Student>.ContainsKey", () => stringStudentSortedList.ContainsKey(keyStr));
            Measure("SortedDictionary<Person, Student>.ContainsKey", () => personStudentSortedDict.ContainsKey(key));
            Measure("SortedDictionary<string, Student>.ContainsKey", () => stringStudentSortedDict.ContainsKey(keyStr));
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