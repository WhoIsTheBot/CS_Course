using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Student student = new Student
        {
            Person = new Person("Alice", "Smith", new DateTime(1999, 5, 15)),
            Education = Education.Master,
            GroupNumber = 202
        };
        Console.WriteLine(student.ToShortString());

        Console.WriteLine($"Is Master: {student[Education.Master]}");
        Console.WriteLine($"Is Bachelor: {student[Education.Bachelor]}");
        Console.WriteLine($"Is SecondEducation: {student[Education.SecondEducation]}");

        student.AddExams(
            new Exam("Physics", 4, new DateTime(2023, 6, 10)),
            new Exam("Chemistry", 5, new DateTime(2023, 6, 12))
        );

        Console.WriteLine(student.ToString());
        Console.WriteLine(student.ToShortString());

        Console.WriteLine("Введіть кількість рядків та стовпців у форматі: 2000, 2000");
        string input = Console.ReadLine() ?? string.Empty;
        char[] separators = { ' ', ',', ';', ':' };
        string[] parts = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

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

        long totalElements = (long)nRows * nColumns;
        if (totalElements > int.MaxValue)
        {
            Console.WriteLine("Занадто великий розмір масиву!");
            return;
        }

        Exam[] oneDimensionalArray = new Exam[totalElements];
        Exam[,] twoDimensionalRectangularArray = new Exam[nRows, nColumns];
        Exam[][] twoDimensionalJaggedArray = new Exam[nRows][];
        Exam[][] twoDimensionalJaggedArrayVariable = new Exam[nRows][];

        for (int i = 0; i < totalElements; i++)
        {
            oneDimensionalArray[i] = new Exam();
        }

        for (int i = 0; i < nRows; i++)
        {
            twoDimensionalJaggedArray[i] = new Exam[nColumns];
            twoDimensionalJaggedArrayVariable[i] = new Exam[i + 1];

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

        // Одновимірний масив
        int startTime = Environment.TickCount;
        for (int i = 0; i < totalElements; i++)
        {
            oneDimensionalArray[i].Grade = 5;
        }
        int endTime = Environment.TickCount;
        Console.WriteLine($"Час виконання для одновимірного масиву: {endTime - startTime} ms");

        // Двовимірний прямокутний масив
        startTime = Environment.TickCount;
        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < nColumns; j++)
            {
                twoDimensionalRectangularArray[i, j].Grade = 5;
            }
        }
        endTime = Environment.TickCount;
        Console.WriteLine($"Час виконання для двовимірного прямокутного масиву: {endTime - startTime} ms");

        // Зубчастий масив з однаковою кількістю елементів
        startTime = Environment.TickCount;
        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < nColumns; j++)
            {
                twoDimensionalJaggedArray[i][j].Grade = 5;
            }
        }
        endTime = Environment.TickCount;
        Console.WriteLine($"Час виконання для двовимірного зубчастого масиву (однакова кількість елементів): {endTime - startTime} ms");

        twoDimensionalJaggedArrayVariable = new Exam[nRows][];
        int[] rowSizes = new int[nRows];

        // Спочатку рівномірно по totalElements
        int baseSize = (int)(totalElements / nRows);
        int remainder = (int)(totalElements % nRows);

        // Розподіл кількості елементів
        for (int i = 0; i < nRows; i++)
        {
            rowSizes[i] = baseSize + (i < remainder ? 1 : 0);
        }

        // Ініціалізація масиву та об'єктів
        for (int i = 0; i < nRows; i++)
        {
            twoDimensionalJaggedArrayVariable[i] = new Exam[rowSizes[i]];
            for (int j = 0; j < rowSizes[i]; j++)
            {
                twoDimensionalJaggedArrayVariable[i][j] = new Exam();
            }
        }

        // Вимір часу заповнення .Grade
        startTime = Environment.TickCount;
        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < twoDimensionalJaggedArrayVariable[i].Length; j++)
            {
                twoDimensionalJaggedArrayVariable[i][j].Grade = 5;
            }
        }
        endTime = Environment.TickCount;
        Console.WriteLine($"Час виконання для зубчастого масиву (рівномірний розподіл): {endTime - startTime} ms");
    }
}
