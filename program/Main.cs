using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Створення об'єкта Student
        Student student = new Student
        {
            Person = new Person("Alice", "Smith", new DateTime(1999, 5, 15)),
            Education = Education.Master,
            GroupNumber = 202
        };
        Console.WriteLine(student.ToShortString());

        // Виведення значень індексатора
        Console.WriteLine($"Is Master: {student[Education.Master]}");
        Console.WriteLine($"Is Bachelor: {student[Education.Bachelor]}");
        Console.WriteLine($"Is SecondEducation: {student[Education.SecondEducation]}");
        // Присвоєння значень властивостям
        student.AddExams(new Exam("Physics", 4, new DateTime(2023, 6, 10)), new Exam("Chemistry", 5, new DateTime(2023, 6, 12)));

        Console.WriteLine(student.ToString());

        // Запрошення до вводу з обробкою помилок
        Console.WriteLine("Введіть кількість рядків та стовпців у форматі: 2000, 2000");
        string input = Console.ReadLine() ?? string.Empty;
        char[] separators = { ' ', ',', ';', ':' };
        string[] parts = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        // Перевірка коректності вводу
        if (parts.Length != 2)
        {
            Console.WriteLine("Невірний формат вводу!");
            return;
        }

        int nRows, nColumns;
        try
        {
            nRows = int.Parse(parts[0]);
            nColumns = int.Parse(parts[1]);
        }
        catch (FormatException)
        {
            Console.WriteLine("Введено нечислові значення!");
            return;
        }

        // Перевірка на переповнення
        long totalElements = (long)nRows * nColumns;
        if (totalElements > int.MaxValue)
        {
            Console.WriteLine("Занадто великий розмір масиву!");
            return;
        }

        // Ініціалізація масивів
        Exam[] oneDimensionalArray = new Exam[totalElements];
        Exam[,] twoDimensionalRectangularArray = new Exam[nRows, nColumns];
        Exam[][] twoDimensionalJaggedArray = new Exam[nRows][];
        Exam[][] twoDimensionalJaggedArrayVariable = new Exam[nRows][];

        // Ініціалізація масивів
        for (int i = 0; i < totalElements; i++)
        {
            oneDimensionalArray[i] = new Exam();
        }

        for (int i = 0; i < nRows; i++)
        {
            twoDimensionalJaggedArray[i] = new Exam[nColumns];
            twoDimensionalJaggedArrayVariable[i] = new Exam[i + 1]; // Ініціалізація кожного рядка з різною кількістю елементів

            for (int j = 0; j < nColumns; j++)
            {
                twoDimensionalRectangularArray[i, j] = new Exam();
                twoDimensionalJaggedArray[i][j] = new Exam();
            }

            for (int j = 0; j < twoDimensionalJaggedArrayVariable[i].Length; j++)
            {
                twoDimensionalJaggedArrayVariable[i][j] = new Exam();
            }
        }

        // Вимірювання часу для одновимірного масиву
        int startTime = Environment.TickCount;
        for (int i = 0; i < totalElements; i++)
        {
            oneDimensionalArray[i]._grade = 5;
        }
        int endTime = Environment.TickCount;
        Console.WriteLine($"Час виконання для одновимірного масиву: {endTime - startTime} ms");

        // Вимірювання часу для двовимірного прямокутного масиву
        startTime = Environment.TickCount;
        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < nColumns; j++)
            {
                twoDimensionalRectangularArray[i, j]._grade = 5;
            }
        }
        endTime = Environment.TickCount;
        Console.WriteLine($"Час виконання для двовимірного прямокутного масиву: {endTime - startTime} ms");

        // Вимірювання часу для двовимірного зубчастого масиву з однаковою кількістю елементів
        startTime = Environment.TickCount;
        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < nColumns; j++)
            {
                twoDimensionalJaggedArray[i][j]._grade = 5;
            }
        }
        endTime = Environment.TickCount;
        Console.WriteLine($"Час виконання для двовимірного зубчастого масиву (однакова кількість елементів): {endTime - startTime} ms");

        // Ініціалізація зубчастого масиву з різною кількістю елементів
        twoDimensionalJaggedArrayVariable = new Exam[nRows][];
        int[] elementsPerRow = new int[nRows];

        // Базовий розподіл: перші N-1 рядків мають по nColumns елементів
        for (int i = 0; i < nRows - 1; i++)
        {
            elementsPerRow[i] = nColumns;
        }

        // Останній рядок отримує решту елементів
        elementsPerRow[nRows - 1] = (int)totalElements - (nColumns * (nRows - 1));

        // Перевірка коректності
        if (elementsPerRow[nRows - 1] < 0)
        {
            Console.WriteLine("Неможливий розподіл елементів!");
            return;
        }

        // Ініціалізація масиву
        for (int i = 0; i < nRows; i++)
        {
            twoDimensionalJaggedArrayVariable[i] = new Exam[elementsPerRow[i]];
            for (int j = 0; j < elementsPerRow[i]; j++)
            {
                twoDimensionalJaggedArrayVariable[i][j] = new Exam();
            }
        }

        startTime = Environment.TickCount;
        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < twoDimensionalJaggedArrayVariable[i].Length; j++)
            {
                twoDimensionalJaggedArrayVariable[i][j]._grade = 5;
            }
        }
        endTime = Environment.TickCount;
        Console.WriteLine($"Час для зубчастого масиву (різна кількість): {endTime - startTime} ms");
    }
}