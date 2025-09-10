# Козловський Василь — 301-А група  
## Лабораторна робота №6
## Варіант 1

---

## Опис завдання

У цій лабораторній роботі необхідно модифікувати клас Student, додавши до нього підтримку глибокого копіювання, збереження/завантаження об'єктів у/з файлу та взаємодії з користувачем через консоль. Основна мета — реалізувати механізми серіалізації та десеріалізації об’єкта Student, який містить список об’єктів Exam.

---

## Основні можливості
- Глибоке копіювання:
```csharp
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
```

- Збереження об'єкта у файл (екземплярний метод):
```csharp
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

```

- Збереження об'єкта у файл (статичний метод):
```csharp
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

```

- Завантаження об'єкта з файлу (екземплярний метод):
```csharp
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
```

- Завантаження об'єкта з файлу (екземплярний метод):
```csharp
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
```

- Додавання нового іспиту через консоль:
```csharp
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
```


---

## Результат виконання коду

```text
=== Перевірка методів збереження/копіювання ===

Введіть іспит у форматі: Назва;Оцінка;Дата (yyyy-MM-dd)
Математика;78;2025-06-04

Введений іспит успішно додано:
John Doe, 01.01.2000, Bachelor, Group: 101
Tests:
Biology, true
Exams:
Математика, Оцінка: 78, Дата: 04.06.2025

Успішно завантажено з файлу:
John Doe, 01.01.2000, Bachelor, Group: 101, Avg: 0,00, Tests: 1, Exams: 1

Копія студента:
John Doe, 01.01.2000, Bachelor, Group: 101
Tests:
Biology, true
Exams:
Математика, Оцінка: 78, Дата: 04.06.2025

Завантажено через static Load:
John Doe, 01.01.2000, Bachelor, Group: 101
Tests:
Biology, true
Exams:
Математика, Оцінка: 78, Дата: 04.06.2025

``` 
