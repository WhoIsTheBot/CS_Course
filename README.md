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
