# Козловський Василь — 301-А група  
## Лабораторна робота №4
### Варіант 1

---

## Опис завдання

 - Використовуючи завдання лабораторної роботи №3 використати відповідні Immutable (ImmutableList ImmutableDictionary) та Sorted (SortedList, Sorted Dictionary) колекції для реалізації завдання попередньої лабораторної роботи та зробити порівняння виконання часу Standard vs Immutable vs Sorted.

---

## Основні можливості

- MeasureSearchTime() – виконує пошук чотирьох типів ключів (перший, середній, останній, відсутній) у відповідних колекціях і вимірює час виконання операцій Contains/ContainsKey.
- Measure(string label, Func<bool> func) – замір часу однієї операції за допомогою Stopwatch.

---

## Основні можливості

```csharp
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

```

## Результат виконання коду

```text

=== Перевірка TestCollections ===

=== Стандартні колекції ===

 Пошук: Name0 Surname0, 01.01.2000
List<Person>.Contains: True, час: 715 ticks
List<string>.Contains: True, час: 869 ticks
Dictionary<Person, Student>.ContainsKey: True, час: 586 ticks
Dictionary<string, Student>.ContainsKey: True, час: 508 ticks
Dictionary<Person, Student>.ContainsValue: False, час: 2623 ticks

 Пошук: Name5000 Surname5000, 09.09.2013
List<Person>.Contains: True, час: 469 ticks
List<string>.Contains: True, час: 875 ticks
Dictionary<Person, Student>.ContainsKey: True, час: 13 ticks
Dictionary<string, Student>.ContainsKey: True, час: 192 ticks
Dictionary<Person, Student>.ContainsValue: False, час: 1011 ticks

 Пошук: Name9999 Surname9999, 18.05.2027
List<Person>.Contains: True, час: 1048 ticks
List<string>.Contains: True, час: 1999 ticks
Dictionary<Person, Student>.ContainsKey: True, час: 7 ticks
Dictionary<string, Student>.ContainsKey: True, час: 6 ticks
Dictionary<Person, Student>.ContainsValue: False, час: 586 ticks

 Пошук: Not Exists, 01.01.0001
List<Person>.Contains: False, час: 501 ticks
List<string>.Contains: False, час: 796 ticks
Dictionary<Person, Student>.ContainsKey: False, час: 9 ticks
Dictionary<string, Student>.ContainsKey: False, час: 8 ticks
Dictionary<Person, Student>.ContainsValue: False, час: 517 ticks

=== Immutable колекції ===

 Пошук в Immutable колекціях: Name0 Surname0, 01.01.2000
ImmutableList<Person>.Contains: True, час: 1677 ticks
ImmutableList<string>.Contains: True, час: 1411 ticks
ImmutableDictionary<Person, Student>.ContainsKey: True, час: 1144 ticks
ImmutableDictionary<string, Student>.ContainsKey: True, час: 994 ticks

 Пошук в Immutable колекціях: Name5000 Surname5000, 09.09.2013
ImmutableList<Person>.Contains: True, час: 5286 ticks
ImmutableList<string>.Contains: True, час: 5926 ticks
ImmutableDictionary<Person, Student>.ContainsKey: True, час: 49 ticks
ImmutableDictionary<string, Student>.ContainsKey: True, час: 45 ticks

 Пошук в Immutable колекціях: Name9999 Surname9999, 18.05.2027
ImmutableList<Person>.Contains: True, час: 10167 ticks
ImmutableList<string>.Contains: True, час: 15201 ticks
ImmutableDictionary<Person, Student>.ContainsKey: True, час: 156 ticks
ImmutableDictionary<string, Student>.ContainsKey: True, час: 98 ticks

 Пошук в Immutable колекціях: Not Exists, 01.01.0001
ImmutableList<Person>.Contains: False, час: 9919 ticks
ImmutableList<string>.Contains: False, час: 17341 ticks
ImmutableDictionary<Person, Student>.ContainsKey: False, час: 104 ticks
ImmutableDictionary<string, Student>.ContainsKey: False, час: 72 ticks

=== Sorted колекції ===

 Пошук в Sorted колекціях: Name0 Surname0, 01.01.2000
SortedList<Person, Student>.ContainsKey: True, час: 646 ticks
SortedList<string, Student>.ContainsKey: True, час: 808 ticks
SortedDictionary<Person, Student>.ContainsKey: True, час: 2407 ticks
SortedDictionary<string, Student>.ContainsKey: True, час: 623 ticks

 Пошук в Sorted колекціях: Name5499 Surname5499, 21.01.2015
SortedList<Person, Student>.ContainsKey: True, час: 49 ticks
SortedList<string, Student>.ContainsKey: True, час: 58 ticks
SortedDictionary<Person, Student>.ContainsKey: True, час: 58 ticks
SortedDictionary<string, Student>.ContainsKey: True, час: 61 ticks

 Пошук в Sorted колекціях: Name9999 Surname9999, 18.05.2027
SortedList<Person, Student>.ContainsKey: True, час: 44 ticks
SortedList<string, Student>.ContainsKey: True, час: 50 ticks
SortedDictionary<Person, Student>.ContainsKey: True, час: 59 ticks
SortedDictionary<string, Student>.ContainsKey: True, час: 111 ticks

 Пошук в Sorted колекціях: Not Exists, 01.01.0001
SortedList<Person, Student>.ContainsKey: False, час: 22 ticks
SortedList<string, Student>.ContainsKey: False, час: 17 ticks
SortedDictionary<Person, Student>.ContainsKey: False, час: 22 ticks
SortedDictionary<string, Student>.ContainsKey: False, час: 23 ticks

``` 
