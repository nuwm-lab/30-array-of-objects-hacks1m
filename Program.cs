using System;

namespace LabWork
{

    class Result
    { 
    // Клас, що представляє арифметичну прогресію
    class ArithmeticProgression
    {
        public double A0 { get; set; }
        public double D { get; set; }
        public int N { get; set; }

        public ArithmeticProgression(double a0, double d, int n)
        {
            A0 = a0;
            D = d;
            N = n;
        }

        // Сума перших N членів арифметичної прогресії
        public double Sum()
        {
            // Формула: S = n/2 * (2*a0 + (n-1)*d)
            return N * (2 * A0 + (N - 1) * D) / 2.0;
        }

        public override string ToString()
        {
            return $"a0={A0}, d={D}, n={N}, sum={Sum():F4}";
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Арифметичні прогресії: знайти з найбільшою сумою ===");

            int m;
            while (true)
            {
                Console.Write("Введіть кількість прогресій (ціле додатне число): ");
                var line = Console.ReadLine();
                if (int.TryParse(line, out m) && m > 0) break;
                Console.WriteLine("Некоректне число. Спробуйте ще раз.");
            }

            var arr = new ArithmeticProgression[m];

            for (int i = 0; i < m; i++)
            {
                Console.WriteLine($"\nПрогресія #{i + 1}");

                double a0;
                while (true)
                {
                    Console.Write("  Введіть перший член a0: ");
                    if (double.TryParse(Console.ReadLine(), out a0)) break;
                    Console.WriteLine("  Некоректне значення a0. Повторіть.");
                }

                double d;
                while (true)
                {
                    Console.Write("  Введіть різницю d: ");
                    if (double.TryParse(Console.ReadLine(), out d)) break;
                    Console.WriteLine("  Некоректне значення d. Повторіть.");
                }

                int n;
                while (true)
                {
                    Console.Write("  Введіть кількість членів n (ціле додатне): ");
                    if (int.TryParse(Console.ReadLine(), out n) && n > 0) break;
                    Console.WriteLine("  Некоректне значення n. Повторіть.");
                }

                arr[i] = new ArithmeticProgression(a0, d, n);
            }

            // Знайти прогресію з найбільшою сумою
            double maxSum = double.NegativeInfinity;
            int maxIndex = -1;
            for (int i = 0; i < m; i++)
            {
                double s = arr[i].Sum();
                if (s > maxSum)
                {
                    maxSum = s;
                    maxIndex = i;
                }
            }

            Console.WriteLine("\nРезультат:");
            if (maxIndex >= 0)
            {
                Console.WriteLine($"Прогресія з найбільшою сумою: #{maxIndex + 1}");
                Console.WriteLine(arr[maxIndex].ToString());
            }
            else
            {
                Console.WriteLine("Не було введено жодної прогресії.");
            }
        }
        }
    }
}
