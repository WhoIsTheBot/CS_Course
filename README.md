# Козловський Василь — 301-А група  
## Лабораторна робота №3  
### Варіант 1  

---

## Опис завдання

У цій лабораторній роботі реалізовано порівняння ефективності пошуку в різних типах колекцій C#. Основною метою є:

- створення узагальненого класу `TestCollections`, який містить:
  - `List<TKey>`
  - `List<string>`
  - `Dictionary<TKey, TValue>`
  - `Dictionary<string, TValue>`
- використання класів `Person` як ключів (TKey) і `Student` як значень (TValue), де `Student` містить поле з типом `Person`
- реалізація інтерфейсів `IComparable`, `IComparer<Person>`, `IComparer<Student>`
- вимірювання часу пошуку в колекціях: перший, центральний, останній і неіснуючий елемент

---

## Структура проєкту

- **Person.cs** — базовий клас з полями, методами та реалізацією порівняння по прізвищу і даті народження
- **Student.cs** — клас-нащадок, який містить списки заліків (`List<Test>`) і екзаменів (`List<Exam>`), а також середній бал
- **StudentCollection.cs** — клас для роботи зі списком студентів та їх сортуванням/фільтрацією
- **TestCollections.cs** — основний клас лабораторної для створення, заповнення та вимірювання часу пошуку в колекціях
- **Exam.cs** — клас іспиту, який реалізує IDateAndCopy
- **Main.cs** — клас заліку, аналогічний до Exam
- **StudentEnumerator.cs** — ітератор для спільних предметів, який реалізує IEnumerator<string> та знаходить предмети, які є і в заліках, і в іспитах
- **IDateAndCopy.cs** — інтерфейс для об'єктів з датою та копіюванням
- **StudentComparer.cs** — компаратор для сортування за середнім балом
- **Main.cs** — точка входу, де демонструється робота всіх методів та класів
---

## Основні можливості

- Сортування студентів:
  - За прізвищем (`IComparable`)
  - За датою народження (`IComparer<Person>`)
  - За середнім балом (`IComparer<Student>`)
- Операції над колекцією студентів:
  - Отримання студентів з формою навчання Master
  - Групування за середнім балом
  - Знаходження максимального середнього балу
- Генерація `TestCollections` із заданою кількістю елементів
- Вимірювання часу пошуку в:
  - `List<Person>`
  - `List<string>`
  - `Dictionary<Person, Student>` (по ключу і по значенню)
  - `Dictionary<string, Student>`

---

```text

## Приклад виводу

--- Початковий список студентів ---
Ivan Ivanov, 20.05.2001, Bachelor, Group: 101, Avg: 4,00, Tests: 3, Exams: 3
Petro Petrov, 10.03.2000, Master, Group: 205, Avg: 3,00, Tests: 3, Exams: 3
Alga Shevchenko, 30.01.2002, SecondEducation, Group: 315, Avg: 4,00, Tests: 3, Exams: 3
Dmytro Koval, 15.12.1999, Bachelor, Group: 140, Avg: 4,00, Tests: 3, Exams: 3
Yulia Savchuk, 25.09.2001, Master, Group: 220, Avg: 4,67, Tests: 3, Exams: 3
Andriy Melnyk, 05.06.2000, Bachelor, Group: 115, Avg: 3,00, Tests: 3, Exams: 3
Nadiia Bondar, 22.04.2002, SecondEducation, Group: 308, Avg: 5,00, Tests: 3, Exams: 3

--- Сортування за прізвищем ---
Nadiia Bondar, 22.04.2002, SecondEducation, Group: 308, Avg: 5,00, Tests: 3, Exams: 3
Ivan Ivanov, 20.05.2001, Bachelor, Group: 101, Avg: 4,00, Tests: 3, Exams: 3
Dmytro Koval, 15.12.1999, Bachelor, Group: 140, Avg: 4,00, Tests: 3, Exams: 3
Andriy Melnyk, 05.06.2000, Bachelor, Group: 115, Avg: 3,00, Tests: 3, Exams: 3
Petro Petrov, 10.03.2000, Master, Group: 205, Avg: 3,00, Tests: 3, Exams: 3
Yulia Savchuk, 25.09.2001, Master, Group: 220, Avg: 4,67, Tests: 3, Exams: 3
Alga Shevchenko, 30.01.2002, SecondEducation, Group: 315, Avg: 4,00, Tests: 3, Exams: 3

--- Сортування за датою народження ---
Dmytro Koval, 15.12.1999, Bachelor, Group: 140, Avg: 4,00, Tests: 3, Exams: 3
Petro Petrov, 10.03.2000, Master, Group: 205, Avg: 3,00, Tests: 3, Exams: 3
Andriy Melnyk, 05.06.2000, Bachelor, Group: 115, Avg: 3,00, Tests: 3, Exams: 3
Ivan Ivanov, 20.05.2001, Bachelor, Group: 101, Avg: 4,00, Tests: 3, Exams: 3
Yulia Savchuk, 25.09.2001, Master, Group: 220, Avg: 4,67, Tests: 3, Exams: 3
Alga Shevchenko, 30.01.2002, SecondEducation, Group: 315, Avg: 4,00, Tests: 3, Exams: 3
Nadiia Bondar, 22.04.2002, SecondEducation, Group: 308, Avg: 5,00, Tests: 3, Exams: 3

--- Сортування за середнім балом ---
Petro Petrov, 10.03.2000, Master, Group: 205, Avg: 3,00, Tests: 3, Exams: 3
Andriy Melnyk, 05.06.2000, Bachelor, Group: 115, Avg: 3,00, Tests: 3, Exams: 3
Dmytro Koval, 15.12.1999, Bachelor, Group: 140, Avg: 4,00, Tests: 3, Exams: 3
Ivan Ivanov, 20.05.2001, Bachelor, Group: 101, Avg: 4,00, Tests: 3, Exams: 3
Alga Shevchenko, 30.01.2002, SecondEducation, Group: 315, Avg: 4,00, Tests: 3, Exams: 3
Yulia Savchuk, 25.09.2001, Master, Group: 220, Avg: 4,67, Tests: 3, Exams: 3
Nadiia Bondar, 22.04.2002, SecondEducation, Group: 308, Avg: 5,00, Tests: 3, Exams: 3

Макс. середній бал: 5,00

--- Магістри ---
Petro Petrov, 10.03.2000, Master, Group: 205, Avg: 3,00, Tests: 3, Exams: 3
Yulia Savchuk, 25.09.2001, Master, Group: 220, Avg: 4,67, Tests: 3, Exams: 3

--- Група зі середнім балом = 5 ---
Nadiia Bondar, 22.04.2002, SecondEducation, Group: 308, Avg: 5,00, Tests: 3, Exams: 3

=== Перевірка TestCollections ===

 Пошук: Name0 Surname0, 01.01.2000
List<Person>.Contains: True, час: 3008 ticks
List<string>.Contains: True, час: 2963 ticks
Dictionary<Person, Student>.ContainsKey: True, час: 3036 ticks
Dictionary<string, Student>.ContainsKey: True, час: 2945 ticks
Dictionary<Person, Student>.ContainsValue: False, час: 10890 ticks

 Пошук: Name5000 Surname5000, 09.09.2013
List<Person>.Contains: True, час: 2257 ticks
List<string>.Contains: True, час: 4192 ticks
Dictionary<Person, Student>.ContainsKey: True, час: 75 ticks
Dictionary<string, Student>.ContainsKey: True, час: 599 ticks
Dictionary<Person, Student>.ContainsValue: False, час: 7984 ticks

 Пошук: Name9999 Surname9999, 18.05.2027
List<Person>.Contains: True, час: 3705 ticks
List<string>.Contains: True, час: 7055 ticks
Dictionary<Person, Student>.ContainsKey: True, час: 67 ticks
Dictionary<string, Student>.ContainsKey: True, час: 62 ticks
Dictionary<Person, Student>.ContainsValue: False, час: 3598 ticks

 Пошук: Not Exists, 01.01.0001
List<Person>.Contains: False, час: 3626 ticks
List<string>.Contains: False, час: 6364 ticks
Dictionary<Person, Student>.ContainsKey: False, час: 72 ticks
Dictionary<string, Student>.ContainsKey: False, час: 53 ticks
Dictionary<Person, Student>.ContainsValue: False, час: 5346 ticks

``` 
