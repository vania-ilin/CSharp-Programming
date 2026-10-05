// Лабораторная №9. Вариант 13
class Money
{
    int rub;
    int kop;
    public static int count = 0; // счетчик объектов

    public int Rub
    {
        get { return rub; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Error");
                rub = 0;
            }
            else rub = value;
        }
    }

    public int Kop
    {
        get { return kop; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Error");
                kop = 0;
            }
            if (value > 99)
            {
                rub += value / 100;
                kop = value % 100;
            }
            else kop = value;
        }
    }
    public Money()
    {
        Rub = 0;
        Kop = 0;
        count++;
    }

    public Money(int r, int k)
    {
        Rub = r;
        Kop = k;
        count++;
    }
    public void Show()
    {
        if (this.Kop < 0 || this.Rub < 0)
        {

        }
        else
        {
            Console.WriteLine($"{Rub} руб. {Kop} коп.");
        }
    }

    public Money MinusKop(int kop) // пользовательский метод по заданию
    {
        if (kop > 99 || kop < 0)
        {
            Console.WriteLine("Error. Вычитание не выполнено");
            return null;
        }
        else
        {
            this.Kop -= kop;
            return this;
        }

    }


    public static Money operator -(Money m1, Money m2) // разность 2-х объектов типа Money
    {

        Money m = new Money();
        Money f = new Money();
        if (m1.Kop < m2.Kop) // случай, когда у уменьшаемого копеек меньше, чем у вычитаемого, например, 3р10к - 2р20к
        {
            int l = m1.Rub * 100 + m1.Kop; // перерасчет в копейки
            int e = m2.Rub * 100 + m2.Kop;
            int raz = l - e; // непосредственно вычитание (в копейках)
            if (raz > 0)
                f = new Money(0, raz); // преобразуем обратно в рубли за счеты вызова конструктора
            m = f;
            return m;
        }
        else // случай, когда у уменьшаемого копеек больше, чем у вычитаемого, например, 4р20к - 3р10к
        {
            m.Rub = m1.Rub - m2.Rub;
            m.Kop = m1.Kop - m2.Kop;
            return m;
        }
    }

    public static Money operator -(Money m1, int k) // вычитаем только копейки
    {
        if (k > 99)
        {
            Console.WriteLine("Копеек не может быть больше 99");
            return null;
        }
        else
        {
            Money m = new Money();
            m.Rub = m1.Rub;
            m.Kop = m1.Kop - k; // вычитаем только копейки
            return m;
        }
    }

    public static Money operator -(int k, Money m1) // вычитаем только копейки
    {
        if (k > 99)
        {
            Console.WriteLine("Копеек не может быть больше 99");
            return null;
        }
        else
        {
            Money m = new Money();
            m.Rub = m1.Rub;
            m.Kop = k - m1.Kop;
            return m;
        }
    }

    public static Money operator +(Money m1, Money m2)
    {
        Money m = new Money();
        m.Rub = m1.Rub + m2.Rub;
        m.Kop = m1.Kop + m2.Kop;
        return m;
    }

    public static Money operator +(Money m1, int k)
    {
        if (k > 99)
        {
            Console.WriteLine("Копеек не может быть больше 99");
            return null;
        }
        else
        {
            Money m = new Money();
            m.Rub = m1.Rub;
            m.Kop = m1.Kop + k;
            return m;
        }
    }

    public static Money operator +(int k, Money m1) // перегрузка бинарного оператора
    {
        if (k > 99)
        {
            Console.WriteLine("Копеек не может быть больше 99");
            return null;
        }
        else
        {
            Money m = new Money();
            m.Rub = m1.Rub;
            m.Kop = k + m1.Kop;
            return m;
        }
    }
    public static Money operator ++(Money m1)
    {
        Money m = new Money();
        m.Rub = m1.Rub;
        m.Kop = m1.Kop + 1;
        return m;
    }
    public static Money operator --(Money m1)
    {
        Money m = new Money();
        m.Rub = m1.Rub;
        m.Kop = m1.Kop - 1;
        return m;
    }

    public static explicit operator int(Money m) // явное преобразование  к типу int
    {
        // по заданию: int (явная) результатом является количество рублей (копейки отбрасываются);
        if (m.Rub > 0 && m.Kop > 0)
            return m.Rub; // обрезаем часть с копейками
        else return 0;
    }
    public static implicit operator bool(Money m) // неявное преобразование
    {
        // по заданию: bool (неявная) результатом является true, если  денежная сумма не равна 0.
        bool ok;
        if ((m.Rub == 0 && m.Kop == 0) || m.Rub < 0 || m.Kop < 0) return ok = false;
        else return ok = true;
    }

    public static Money operator /(Money s, int k)
    {
        Money m = new Money();
        m.Rub = s.Rub / k;
        m.Kop = s.Kop / k;
        return m;

    }

}


class MoneyArray
{
    Money[] arr = null;
    static Random rnd = new Random();
    public static int count = 0; // статическая компонента, счетчик объектов

    public int Length
    {
        get
        {
            return arr.Length;
        }
    }

    public MoneyArray() // конструктор без параметра
    {
        arr = new Money[1]; // например создадим массив из одного элемента
        arr[0] = new Money();
        count++;
    }

    public MoneyArray(int size) // конструктор с 1 параметром размером массива
    {
        arr = new Money[size];
        for (int i = 0; i < size; i++)
        {
            Money m = new Money(rnd.Next(0, 100), rnd.Next(0, 100));
            arr[i] = m;
            count++;
        }
    }

    public MoneyArray(params Money[] list) //конструктор с переменным числом параметров (объектов типа Money)
    {
        arr = new Money[list.Length];
        for (int i = 0; i < list.Length; i++)
        {
            arr[i] = list[i];
            count++;
        }
    }

    public void Show()
    {
        if (arr == null || arr.Length == 0)
        {
            Console.WriteLine("Массив пустой");
        }
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i].Show(); // вызов Show() у Money
        }
    }

    public Money this[int index] // индексатор
    {
        get
        {
            if (index >= 0 && index < arr.Length)
                return arr[index];
            else
            {
                Console.WriteLine("Ошибка в индекаторе по get");
                return new Money(0, 0); // все равно что нибудь вернем, например, новый объект типа Money
            }
        }
        set
        {
            if (index >= 0 && index < arr.Length)
                arr[index] = value;
            else
            {
                Console.WriteLine("Ошибка в индекаторе по set");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--------------ЧАСТЬ 1-----------------");

        Money n1 = new Money(3, 125);
        n1.Show(); // 4 руб. 25 коп.

        Money n2 = new Money(2, 025);
        n2.Show(); // 2 руб. 25 коп.

        Money n3 = new Money(4, 325);
        n3.Show(); // 7 руб. 25 коп.

        Money n4 = new Money(8, 238);
        n4.Show(); // 10 руб. 38 коп.

        Money n5 = new Money(7, 220);
        n5.Show(); // 9 руб. 20 коп.

        Money n6 = new Money(0, 20);
        n6.Show(); // 0 руб. 20 коп.

        Money n7 = new Money(6, -98); // Error

        Console.WriteLine();
        Console.WriteLine("Тестируем метод --Вычитание--");

        n1.MinusKop(5); // Money(3, 125) - 5 копеек = 4 руб. 20 коп.
        n1.Show(); Console.WriteLine(" ");

        n2.MinusKop(23); // Money(2, 025) - 23 копейки = 2 руб. 2 коп.
        n2.Show(); Console.WriteLine(" ");

        n3.MinusKop(726); // Money(4, 325) - 726 копеек = Error. Вычитание не выполнено


        n4.MinusKop(26); // Money(8, 238) - 26 копеек = 10 руб. 12 коп.
        n4.Show(); Console.WriteLine(" ");

        n5.MinusKop(-20); // Money(7, 220) - (-20) копеек = Error. Вычитание не выполнено

        Console.WriteLine(" ");
        Console.WriteLine("Количество созданных в программе объектов: " + Money.count);
        Console.WriteLine(" ");


        Console.WriteLine("-----------------ЧАСТЬ 2---------------------");
        n1--; n1.Show(); // было 4 руб. 20 коп. , стало 4 руб. 19 коп.

        n1++; n1.Show(); // было 4 руб. 19 коп. , стало 4 руб. 20 коп.

        int x = (int)n1;  // результатом является количество рублей (копейки отбрасываются)
        Console.WriteLine(x); // было 4 руб. 20 коп. , стало 4 

        bool ok = n1; // результатом является true, если  денежная сумма не равна 0
        Console.WriteLine(ok); // True

        Money m7 = new Money(0, 25);
        x = (int)m7; Console.WriteLine(x); // было 0 руб. 25 коп., стало 0

        ok = m7; Console.WriteLine(ok); // True

        Money m6 = new Money(0, -9); // Error
        x = (int)m6; Console.WriteLine(x); // 0

        ok = m6; Console.WriteLine(ok); // False
        Console.WriteLine();


        Money m1 = new Money();
        m1 = n6 + 20; // добавление копеек: n6 (0 руб. 20 коп.) + 20 коп.
        m1.Show(); // 0 руб. 40 коп.

        m1 = 20 + n6;
        m1.Show(); // 0 руб. 40 коп.
        Console.WriteLine();

        Money m2 = new Money(4, 20);
        Money m3 = new Money(3, 10);
        m1 = m2 - m3;
        m1.Show(); // 1 руб. 10 коп.

        m1 = m3 - m2; // 3р10к - 4р20к =  0 руб. 0 коп. !!!!!!!!!!
                      // КОММЕНТ.: обнуление идет в свойствах Rub и Kop когда значение value < 0
        m1.Show();

        Money m4 = new Money(2, 20);
        m1 = m3 - m4; // 3р 10к - 2р 20к
        m1.Show(); // 0 руб. 90 коп.

        Console.WriteLine();


        Console.WriteLine("ЧАСТЬ 3");
        Console.WriteLine("Создаём массив с помощью конструктора без параметров");
        MoneyArray mar = new MoneyArray(4);
        mar.Show(); Console.WriteLine();

        Console.WriteLine("Количество созданных в программе объектов:" + MoneyArray.count);

        Console.WriteLine("Создаём массив с помощью конструктора c параметром");
        MoneyArray mar1 = new MoneyArray(m1, m2, m3);
        mar1.Show(); Console.WriteLine();

        Console.WriteLine("Количество созданных в программе объектов:" + MoneyArray.count);
        Console.WriteLine();

        Console.WriteLine("доступ через индексатор");
        mar[1].Show();              // доступ через индексатор (индексирование через [] для типа MoneyArray)
        mar[1] = new Money(1, 1);   // доступ через индексатор (индексирование через [] для типа MoneyArray)
        mar[1].Show();              // доступ через индексатор (индексирование через [] для типа MoneyArray)
        Console.WriteLine();

        mar[100] = new Money(5, 5); // Ошибка в индексаторе по set
        mar[100].Show(); // Ошибка в индекаторе по get
        Console.WriteLine();


        Console.WriteLine("Среднее арифметическое:");
        Money sred = new Money();
        Money s = new Money(0, 0);
        {
            for (int i = 0; i < mar.Length; i++)
            {
                s = s + mar[i];     // доступ через индексатор (индексирование через [] для типа MoneyArray)
            }
            int k = mar.Length;
            sred = s / k;
        }
        sred.Show();


    }
}
