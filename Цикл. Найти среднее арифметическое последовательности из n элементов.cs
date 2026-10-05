// Дана последовательность целых чисел из n элементов. Найти среднее арифметическое последовательности из n элементов
using System;
class Program
{
    static int input()
    {
        int size = 0;
        bool ok = true;
        do
        {
            try
            {
                Console.WriteLine("Введите количество чисел");
                size = Convert.ToInt32(Console.ReadLine());
                ok = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Неправильный ввод, введите целое число!");
                ok = false;
            }

            if (size <= 0)
            {
                Console.WriteLine("Число должно быть больше 0!");
                ok = false;

            }
        }
        while (!ok);
        return size;
    }

    static void Main(string[] args)
    {
         int sum = 0;
       

        int size = input();

        double srednee = 0;
        int number;
        for (int i = 0; i < size; i++)
        {
            try
            {
                Console.WriteLine("Введите {0} число", i + 1);
                number = Convert.ToInt32(Console.ReadLine());
                sum += number;
            }
            catch (FormatException)
            {
                Console.WriteLine("Неправильный ввод, введите целое число!");
                i--;
            }
        }
        srednee = (double)sum / size;
        Console.WriteLine("Среднее арифметическое последовательности равно: " + srednee);
        Console.ReadLine();
    }
    
}




