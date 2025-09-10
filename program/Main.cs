class Program
{
    static void Main()
    {

        Console.WriteLine("\n=== Перевірка методів збереження/копіювання ===");

        var s = new Student();
        if (s.AddFromConsole())
        {
            Console.WriteLine("Введений іспит успішно додано:");

            Console.WriteLine(s);
        }
        else
        {
            Console.WriteLine("Помилка при введенні іспиту");
        }

        s.Save("student.json");

        var s2 = new Student();
        if (s2.Load("student.json"))
        {
            Console.WriteLine("Успішно завантажено з файлу:");


            Console.WriteLine(s2.ToShortString());
        }
        else
        {
            Console.WriteLine("Не вдалося завантажити з файлу.");
        }

        var copy = s.DeepCopy();
        Console.WriteLine("Копія студента:");
        Console.WriteLine(copy);

        Student.Save("static_student.json", s);

        var s3 = new Student();
        Student.Load("static_student.json", s3);
        Console.WriteLine("Завантажено через static Load:");
        Console.WriteLine(s3);

    }
}