using System.IO;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class Student : Person
{
    private Education _education;
    private int _groupNumber;
    private List<Test> _tests;
    private List<Exam> _exams;
    public Education Education
    {
        get => _education;
        init => _education = value;
    }

    public Student(Person person, Education education, int groupNumber)
        : base(person.FirstName, person.LastName, person.BirthDate)
    {
        _education = education;
        _groupNumber = groupNumber;
        _tests = new List<Test>();
        _exams = new List<Exam>();
    }


    public Student() : this(new Person(), Education.Bachelor, 101) { }

    public double AverageGrade => _exams.Count == 0 ? 0 : _exams.Average(e => e.Grade);

    public void AddExams(params Exam[] exams) => _exams.AddRange(exams);
    public void AddTests(params Test[] tests) => _tests.AddRange(tests);

    // Removed duplicate definition of Education property


    public override string ToString()
    {
        var testStr = string.Join("\n", _tests);
        var examStr = string.Join("\n", _exams);
        return $"{base.ToString()}, {_education}, Group: {_groupNumber}\nTests:\n{testStr}\nExams:\n{examStr}";
    }

    public string ToShortString()
    {
        return $"{base.ToString()}, {_education}, Group: {_groupNumber}, Avg: {AverageGrade:F2}, Tests: {_tests.Count}, Exams: {_exams.Count}";
    }

    public Student DeepCopy()
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
                WriteIndented = false
            };
            var json = JsonSerializer.Serialize(this, options);
            return JsonSerializer.Deserialize<Student>(json, options) ?? new Student();
        }
        catch
        {
            return new Student();
        }
    }

    public bool Save(string filename)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(this, options);
            File.WriteAllText(filename, json);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool Save(string filename, Student obj)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(obj, options);
            File.WriteAllText(filename, json);
            return true;
        }
        catch
        {
            return false;
        }
    }


    public bool Load(string filename)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
                WriteIndented = true
            };
            var json = File.ReadAllText(filename);
            var temp = JsonSerializer.Deserialize<Student>(json, options);
            if (temp == null) return false;

            _firstName = temp._firstName;
            _lastName = temp._lastName;
            _birthDate = temp._birthDate;
            _education = temp._education;
            _groupNumber = temp._groupNumber;
            _tests = temp._tests;
            _exams = temp._exams;
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool Load(string filename, Student obj)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
                WriteIndented = true
            };
            var json = File.ReadAllText(filename);
            var temp = JsonSerializer.Deserialize<Student>(json, options);
            if (temp == null)
                return false;

            obj._firstName = temp._firstName;
            obj._lastName = temp._lastName;
            obj._birthDate = temp._birthDate;
            obj._education = temp._education;
            obj._groupNumber = temp._groupNumber;
            obj._tests = temp._tests;
            obj._exams = temp._exams;
            return true;
        }
        catch
        {
            return false;
        }
    }


    public bool AddFromConsole()
    {
        Console.WriteLine("Введіть іспит у форматі: Назва;Оцінка;Дата (yyyy-MM-dd)");
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Невірний формат.");
            return false;
        }
        var parts = input.Split(new[] { ';', ',', '|' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length != 3)
        {
            Console.WriteLine("Невірний формат.");
            return false;
        }

        try
        {
            string subject = parts[0].Trim();
            int grade = int.Parse(parts[1].Trim());
            DateTime date = DateTime.Parse(parts[2].Trim());
            _exams.Add(new Exam(subject, grade, date));
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
            return false;
        }
    }
    
}
