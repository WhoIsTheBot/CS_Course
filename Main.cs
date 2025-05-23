using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main()
    {
        Console.WriteLine("Перемноження матриць з використанням Dataflow\n");

        Console.Write("Введіть розмірність матриці A (рядки стовпці): ");
        var aSize = Console.ReadLine()?.Split(' ');
        Console.Write("Введіть розмірність матриці B (рядки стовпці): ");
        var bSize = Console.ReadLine()?.Split(' ');

        if (aSize == null || bSize == null || aSize.Length != 2 || bSize.Length != 2)
        {
            Console.WriteLine("Невірний формат введення.");
            return;
        }

        if (!int.TryParse(aSize[0], out int rowsA) || !int.TryParse(aSize[1], out int colsA) ||
            !int.TryParse(bSize[0], out int rowsB) || !int.TryParse(bSize[1], out int colsB))
        {
            Console.WriteLine("Невірні числа.");
            return;
        }

        if (colsA != rowsB)
        {
            Console.WriteLine("Перемноження неможливе: кількість стовпців A не дорівнює кількості рядків B.");
            return;
        }

        Console.WriteLine("\nГенерація матриць...");
        int[,] A = GenerateMatrix(rowsA, colsA);
        int[,] B = GenerateMatrix(rowsB, colsB);

        Console.WriteLine("Обчислення добутку матриць...");
        int[,] result = MultiplyMatricesParallel(A, B);

        Console.WriteLine("\nРезультат:");
        if (rowsA <= 10 && colsB <= 10)
        {
            PrintMatrix(result);
        }
        else
        {
            Console.WriteLine($"[Матриця розміром {rowsA}x{colsB} не виводиться через великий розмір]");
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
        Console.ReadKey();
    }

    static int[,] GenerateMatrix(int rows, int cols)
    {
        Random rand = new Random();
        int[,] matrix = new int[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                matrix[i, j] = rand.Next(1, 10);
        return matrix;
    }

    static int[,] MultiplyMatricesParallel(int[,] A, int[,] B)
    {
        int rowsA = A.GetLength(0), colsA = A.GetLength(1);
        int rowsB = B.GetLength(0), colsB = B.GetLength(1);
        int[,] result = new int[rowsA, colsB];

        var options = new ExecutionDataflowBlockOptions
        {
            MaxDegreeOfParallelism = Environment.ProcessorCount
        };

        var multiplyBlock = new ActionBlock<(int row, int col)>(pair =>
        {
            int row = pair.row, col = pair.col;
            int sum = 0;
            for (int k = 0; k < colsA; k++)
                sum += A[row, k] * B[k, col];
            result[row, col] = sum;
        }, options);

        for (int i = 0; i < rowsA; i++)
            for (int j = 0; j < colsB; j++)
                multiplyBlock.Post((i, j));

        multiplyBlock.Complete();
        multiplyBlock.Completion.Wait();

        return result;
    }

    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                Console.Write($"{matrix[i, j],5}");
            Console.WriteLine();
        }
    }
}
