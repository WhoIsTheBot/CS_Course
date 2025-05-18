# Козловський Василь — 301-А група  
## Лабораторна робота №5
### Варіант 1

---

## Опис завдання

Реалізувати типізовану колекцію `StudentCollection`, яка генерує події при зміні елементів, а також вести журнал змін через клас `Journal`.  
Передбачено обробку подій `StudentCountChanged` та `StudentReferenceChanged`, делегати, обробники та журнал подій.

---

## Основні можливості

- Додавання та видалення об'єктів типу `Student` у колекції `StudentCollection`.
- Генерація подій:
  - `StudentCountChanged` — при додаванні або видаленні студентів.
  - `StudentReferenceChanged` — при зміні посилань на об'єкти.
- Клас `Journal` для реєстрації подій, які відбулись із колекціями.
- Підтримка декількох підписок на події однієї або різних колекцій.
- Вивід записів журналу в зручному форматі.

---

## Результат виконання коду

```text
Journal 1 (only collection1 events):
[Collection 1] Student added: Ivan Ivanov, 01.01.2000, Bachelor, Group: 101, Avg: 0,00, Tests: 0, Exams: 0
[Collection 1] Student added: Petro Petrov, 15.05.1999, Master, Group: 202, Avg: 0,00, Tests: 0, Exams: 0
[Collection 1] Student removed: Ivan Ivanov, 01.01.2000, Bachelor, Group: 101, Avg: 0,00, Tests: 0, Exams: 0
[Collection 1] Student reference changed: New Student, 03.03.2001, Bachelor, Group: 303, Avg: 0,00, Tests: 0, Exams: 0

Journal 2 (all events):
[Collection 1] Student added: Ivan Ivanov, 01.01.2000, Bachelor, Group: 101, Avg: 0,00, Tests: 0, Exams: 0
[Collection 1] Student added: Petro Petrov, 15.05.1999, Master, Group: 202, Avg: 0,00, Tests: 0, Exams: 0
[Collection 2] Default student added: Ivan Ivanov, 20.05.2001, Bachelor, Group: 101, Avg: 4,00, Tests: 3, Exams: 3
[Collection 2] Default student added: Petro Petrov, 10.03.2000, Master, Group: 205, Avg: 3,00, Tests: 3, Exams: 3
[Collection 2] Default student added: Anna Shevchenko, 30.01.2002, SecondEducation, Group: 315, Avg: 4,00, Tests: 3, Exams: 3
[Collection 2] Default student added: Dmytro Koval, 15.12.1999, Bachelor, Group: 140, Avg: 4,00, Tests: 3, Exams: 3
[Collection 2] Default student added: Yulia Savchuk, 25.09.2001, Master, Group: 220, Avg: 4,67, Tests: 3, Exams: 3
[Collection 2] Default student added: Andriy Melnyk, 05.06.2000, Bachelor, Group: 115, Avg: 3,00, Tests: 3, Exams: 3
Journal 1 (only collection1 events):
[Collection 1] Student added: Ivan Ivanov, 01.01.2000, Bachelor, Group: 101, Avg: 0,00, Tests: 0, Exams: 0
[Collection 1] Student added: Petro Petrov, 15.05.1999, Master, Group: 202, Avg: 0,00, Tests: 0, Exams: 0
[Collection 1] Student removed: Ivan Ivanov, 01.01.2000, Bachelor, Group: 101, Avg: 0,00, Tests: 0, Exams: 0
[Collection 1] Student reference changed: New Student, 03.03.2001, Bachelor, Group: 303, Avg: 0,00, Tests: 0, Exams: 0

Journal 2 (all events):
[Collection 1] Student added: Ivan Ivanov, 01.01.2000, Bachelor, Group: 101, Avg: 0,00, Tests: 0, Exams: 0
[Collection 1] Student added: Petro Petrov, 15.05.1999, Master, Group: 202, Avg: 0,00, Tests: 0, Exams: 0
[Collection 2] Default student added: Ivan Ivanov, 20.05.2001, Bachelor, Group: 101, Avg: 4,00, Tests: 3, Exams: 3
[Collection 2] Default student added: Petro Petrov, 10.03.2000, Master, Group: 205, Avg: 3,00, Tests: 3, Exams: 3
[Collection 2] Default student added: Anna Shevchenko, 30.01.2002, SecondEducation, Group: 315, Avg: 4,00, Tests: 3, Exams: 3      
[Collection 2] Default student added: Dmytro Koval, 15.12.1999, Bachelor, Group: 140, Avg: 4,00, Tests: 3, Exams: 3
[Collection 2] Default student added: Yulia Savchuk, 25.09.2001, Master, Group: 220, Avg: 4,67, Tests: 3, Exams: 3
[Collection 2] Default student added: Andriy Melnyk, 05.06.2000, Bachelor, Group: 115, Avg: 3,00, Tests: 3, Exams: 3
[Collection 1] Student reference changed: New Student, 03.03.2001, Bachelor, Group: 303, Avg: 0,00, Tests: 0, Exams: 0

Journal 2 (all events):
[Collection 1] Student added: Ivan Ivanov, 01.01.2000, Bachelor, Group: 101, Avg: 0,00, Tests: 0, Exams: 0
[Collection 1] Student added: Petro Petrov, 15.05.1999, Master, Group: 202, Avg: 0,00, Tests: 0, Exams: 0
[Collection 2] Default student added: Ivan Ivanov, 20.05.2001, Bachelor, Group: 101, Avg: 4,00, Tests: 3, Exams: 3
[Collection 2] Default student added: Petro Petrov, 10.03.2000, Master, Group: 205, Avg: 3,00, Tests: 3, Exams: 3
[Collection 2] Default student added: Anna Shevchenko, 30.01.2002, SecondEducation, Group: 315, Avg: 4,00, Tests: 3, Exams: 3      
[Collection 2] Default student added: Dmytro Koval, 15.12.1999, Bachelor, Group: 140, Avg: 4,00, Tests: 3, Exams: 3
[Collection 2] Default student added: Yulia Savchuk, 25.09.2001, Master, Group: 220, Avg: 4,67, Tests: 3, Exams: 3
[Collection 2] Default student added: Andriy Melnyk, 05.06.2000, Bachelor, Group: 115, Avg: 3,00, Tests: 3, Exams: 3
[Collection 2] Default student added: Ivan Ivanov, 20.05.2001, Bachelor, Group: 101, Avg: 4,00, Tests: 3, Exams: 3
[Collection 2] Default student added: Petro Petrov, 10.03.2000, Master, Group: 205, Avg: 3,00, Tests: 3, Exams: 3
[Collection 2] Default student added: Anna Shevchenko, 30.01.2002, SecondEducation, Group: 315, Avg: 4,00, Tests: 3, Exams: 3      
[Collection 2] Default student added: Dmytro Koval, 15.12.1999, Bachelor, Group: 140, Avg: 4,00, Tests: 3, Exams: 3
[Collection 2] Default student added: Yulia Savchuk, 25.09.2001, Master, Group: 220, Avg: 4,67, Tests: 3, Exams: 3
[Collection 2] Default student added: Andriy Melnyk, 05.06.2000, Bachelor, Group: 115, Avg: 3,00, Tests: 3, Exams: 3
[Collection 1] Student removed: Ivan Ivanov, 01.01.2000, Bachelor, Group: 101, Avg: 0,00, Tests: 0, Exams: 0
[Collection 2] Student removed: Petro Petrov, 10.03.2000, Master, Group: 205, Avg: 3,00, Tests: 3, Exams: 3
[Collection 1] Student reference changed: New Student, 03.03.2001, Bachelor, Group: 303, Avg: 0,00, Tests: 0, Exams: 0
[Collection 2] Student reference changed: Another One, 04.04.2002, SecondEducation, Group: 404, Avg: 0,00, Tests: 0, Exams: 0  
``` 
