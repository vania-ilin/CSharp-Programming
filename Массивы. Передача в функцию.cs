using System;

class Program
{

    static void PrintMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Формирование массива");
        Console.WriteLine("2. Печать массива");
        Console.WriteLine("3. Удаление элементов из массива");
        Console.WriteLine("4. Добавление элементов в массив");
        Console.WriteLine("5. Перестановка элементов в массиве");
        Console.WriteLine("6. Поиск (линейный) элемента в массиве");
        Console.WriteLine("7. Сортировка массива ");
        Console.WriteLine("8. Поиск (бинарный) - после сортировки");
        Console.WriteLine("9. Выход");
        Console.WriteLine();
    }

    static void Main()
    {
        int[] arr = null;
        int check;

        Console.WriteLine("Введите количество элементов в массиве");
        int size = Convert.ToInt32(Console.ReadLine()); Console.WriteLine();
        if (size <= 0)
        {
            Console.WriteLine("Не правильно задан размер массива");
        }




        do
        {
            PrintMenu();
            Console.WriteLine("Введите пункт меню:");
            check = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (check)
            {
                case 1:
                    {

                        f1(ref arr, ref size);
                        Console.ReadLine(); // задержка экрана
                        break;
                    }

                case 2:
                    {
                        f2(ref arr, ref size);
                        Console.ReadLine(); // задержка экрана
                        break;
                    }

                case 3:
                    {
                        f3(ref arr, ref size);
                        Console.ReadLine(); // задержка экрана
                        break;
                    }

                case 4:
                    {
                        f4(ref arr, ref size);
                        Console.ReadLine(); // задержка экрана
                        break;
                    }

                case 5:
                    {
                        f5(ref arr, ref size);
                        Console.ReadLine(); // задержка экрана
                        break;
                    }

                case 6:
                    {

                        f6(ref arr, ref size);
                        Console.ReadLine(); // задержка экрана
                        break;
                    }

                case 7:
                    {
                        f7(ref arr, ref size);
                        Console.ReadLine(); // задержка экрана
                        break;
                    }

                case 8:
                    {
                        f8(ref arr, ref size);
                        Console.ReadLine(); // задержка экрана
                        break;
                    }

            }
        } while (check < 8);


        Console.ReadLine();
    }

    static void f1(ref int[] arr, ref int size)
    {
        Random rnd = new Random();
        arr = new int[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = rnd.Next(-50, 50);
        }
        Console.WriteLine("Массив сформирован");
        Console.WriteLine();

    }

    static void f2(ref int[] arr, ref int size)
    {
        Console.WriteLine("2. ПЕЧАТЬ ");

        for (int i = 0; i < size; i++)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }

    static void f3(ref int[] arr, ref int size)
    {
        Console.WriteLine("3. УДАЛИТЬ Все четные элементы ");
        int count = 0;
        for (int i = 0; i < size; i++)
        {
            if (arr[i] % 2 != 0) // считаем кол-во нечетных
                count++;
        }

        int[] temp = new int[count];
        int j = 0;
        for (int i = 0; i < size; i++)
            if (arr[i] % 2 != 0) // переписываем только нечетные в новый массив
            {
                temp[j] = arr[i];
                j++;
            }
        arr = temp; // перестявляем ссылку на старый массив
        size = count;

        Console.WriteLine("Массив после удаления чётных элементов:");
        for (int i = 0; i < size; i++)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
        Console.WriteLine();
    }

    static void f4(ref int[] arr, ref int size)
    {
        Console.WriteLine("4. ДОБАВЛЕНИЕ К элементов в конец массива ");

        Console.WriteLine("Введите количество добавляемых элементов в конец массива: ");

        int K = int.Parse(Console.ReadLine());
        Random rnd = new Random();

        int[] temp2 = new int[size + K];
        for (int i = 0; i < size + K; i++)
        {
            if (i < size)
                temp2[i] = arr[i];
            else
                temp2[i] = rnd.Next(-50, 50);

        }
        arr = temp2;
        size += K;
        Console.WriteLine("Массив после добавления " + K + " элементов в конец массива:");
        for (int i = 0; i < size; i++)
            Console.Write(arr[i] + " ");
        Console.WriteLine();

    }

    static void f5(ref int[] arr, ref int size)
    {
        Console.WriteLine();
        Console.WriteLine("5. ПЕРЕСТАНОВКА Положительные  элементы переставить в начало  массива, отрицательные   - в конец ");

        int[] temp3 = new int[size];
        int count_positive = 0;
        int i0;
        for (i0 = 0; i0 < size; i0++)
        {
            if (arr[i0] > 0)
            {
                temp3[count_positive] = arr[i0];
                count_positive++;
            }
        }
        int count_negative = count_positive; // запоминаем значение счетчика полодительных элементов
        for (i0 = 0; i0 < size; i0++)
        {
            if (arr[i0] < 0)
            {
                temp3[count_negative] = arr[i0];
                count_negative++;
            }
        }
        arr = temp3;

        Console.WriteLine("Массив с перестановкой:");
        for (int i = 0; i < size; i++)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }

    static void f6(ref int[] arr, ref int size)
    {
        Console.WriteLine();
        Console.WriteLine("6. ПОИСК (Линейный) Первый отрицательный ");

        int index = -1;

        for (int i = 0; i < size; i++)
            if (arr[i] < 0)
            {
                index = i; break;
            }
        Console.WriteLine("Линейный поиск элемента выполнен. Позиция найденного элемента (Первый отрицательный) имеет индекс" + (int)(index));
        Console.WriteLine();
    }

    static void f7(ref int[] arr, ref int size)
    {
        Console.WriteLine();
        Console.WriteLine("7. СОРТИРОВКА Простой выбор (выделение) ");

        int c0;
        for (int i = 0; i < size - 1; i++)
        {
            int nMin = i;
            for (int j = i + 1; j < size; j++)
                if (arr[j] < arr[nMin]) nMin = j; // если найден элемент, который меньше минимального, то запомним его номер
            c0 = arr[i];  // меняем местами i-ый  и найденный новый минимум
            arr[i] = arr[nMin];
            arr[nMin] = c0;
        }

        Console.WriteLine("Массив после сортировки:");
        for (int i = 0; i < size; i++)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }

    static void f8(ref int[] arr, ref int size)
    {
        Console.WriteLine();
        Console.WriteLine("8. ПОИСК (Бинарный)");
        Console.WriteLine("Искомый элемент для бинарного поиска: ");
        int numberFindElement = int.Parse(Console.ReadLine());

        int L, R, c, countEqual = 0;
        L = 0; R = size;      // начальный отрезок
        while (L < R - 1)
        {
            c = (L + R) / 2;   // нашли середину 
            if (numberFindElement < arr[c]) // сжатие отрезка
                R = c;
            else L = c;
            countEqual++;
        }
        Console.WriteLine("Бинарный поиск элемента выполнен");
        if (arr[L] == numberFindElement)
            Console.WriteLine("Позиция найденного элемента: " + L);
        else Console.WriteLine("Не найден!");
        Console.WriteLine();
        Console.WriteLine("Количество сравнений: " + countEqual);
        Console.WriteLine();
    }


}
