namespace rt11
{
    internal class Program
    {
        static void Wrt(double cur, double mem) // выод интерфейса
        {
            string curStr = cur.ToString("G15");// до 15 зн. чтобы поместилось
            string memStr = mem.ToString("G15");

            Console.WriteLine("┌────────────────────────────────────────┐");
            Console.WriteLine("│        CALCULATOR (o^_^o)              │");
            Console.WriteLine("├────────────────────────────────────────┤");
            Console.WriteLine($"│  M: {memStr,-35}│");
            Console.WriteLine("│                                        │");
            Console.WriteLine("├────────────────────────────────────────┤");
            Console.WriteLine("│  + - * / %   1/x   ^2    sqrt          │");
            Console.WriteLine("│  M+  M-  MR  MS          exit          │");
            Console.WriteLine("├────────────────────────────────────────┤");
            Console.WriteLine($"│ CUR:[ {curStr,-29} ]  │");
            Console.WriteLine("└────────────────────────────────────────┘\n");
        }

        static void Clcltr()
        {
            double cur; // текущее число
            double mem = 0.0; // число в памяти

            while (true) // ввод числа для исключеня ошибок
            {
                Console.Write(":) Введите число (целое или вещественное): ");
                if (double.TryParse(Console.ReadLine(), out cur)) break;
                Console.WriteLine(":) Это не число. Введите число \\_(._.)_/ .");
            }

            while (true)
            {
                Wrt(cur, mem);
                Console.WriteLine(":-) Введите нужную операцию символом (например: +, ^2, SQRT, 1/X, M+)");
                string op = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();

                if (op == "+" || op == "-" || op == "*")
                {
                    double second;
                    while (true)
                    {
                        Console.Write(":-) Пожалуйста, введите число (целое или вещественное): ");
                        if (double.TryParse(Console.ReadLine(), out second)) break;
                        Console.WriteLine("(--_--) Это не число. Введите число :).");
                    }

                    if (op == "+") cur += second;
                    if (op == "-") cur -= second;
                    if (op == "*") cur *= second;
                }
                else if (op == "/" || op == "%")
                {
                    double second;
                    while (true)
                    {
                        Console.Write("(*_*) Пожалуйста, введите число (не ноль!): ");
                        bool ok = double.TryParse(Console.ReadLine(), out second);
                        if (ok && second != 0.0) break;
                        Console.WriteLine("\\_(._.)_/ Некорректно. Введите снова :).");
                    }

                    if (op == "/") cur /= second;
                    if (op == "%") cur %= second; 
                }
                else if (op == "^2")
                {
                    cur = cur * cur;
                }
                else if (op == "SQRT")
                {
                    if (cur < 0)
                        Console.WriteLine("\\_(._.)_/ Число некорректно для данной операции. Выберите другую >:(");
                    else
                        cur = Math.Sqrt(cur);
                }
                else if (op == "1/X")
                {
                    if (cur == 0.0)
                        Console.WriteLine(":'(   \\_(._.)_/Число некорректно для данной операции. Выберите другую ");
                    else
                        cur = 1.0 / cur;
                }
                else if (op == "M+")
                {
                    mem += cur;
                }
                else if (op == "M-")
                {
                    mem -= cur;
                }
                else if (op == "MR")
                {
                    cur = mem;
                }
                else if (op == "MS")
                {
                    mem = cur;
                }
                else if (op == "EXIT")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\\_(._.)_/ Вы ввели некорректную операцию. Пожалуйста, введите другую ");
                }
            }
        }

        static void Main()
        {
            Clcltr();
        }
    }
}