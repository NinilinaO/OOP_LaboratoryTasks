using System;

namespace TaylorSeriesApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Лабораторная работа №3 (Вариант 12) ===");

            var a = ReadDouble("Введите начальное значение a (0,1): ");
            var b = ReadDouble("Введите конечное значение b (0,8): ");
            var k = ReadInt("Введите количество шагов k: ");
            var n = ReadInt("Введите количество членов ряда n (для вар. 12 n = 35): ");
            var eps = 0.0001;

            var step = (b - a) / k;

            Console.WriteLine("\nВычисление функции");
            Console.WriteLine("X\t\tSN\t\tSE\t\tY");

            var currentX = a;
            // Компенсация машинной погрешности double при сравнении
            while (currentX <= b + step / 2.0)
            {
                var sumN = CalculateSeriesN(currentX, n);
                var sumEps = CalculateSeriesEps(currentX, eps);
                var exactY = CalculateExactY(currentX);

                Console.WriteLine($"{currentX:F4}\t\t{sumN:F5}\t\t{sumEps:F5}\t\t{exactY:F5}");

                currentX += step;
            }

            // Ожидание нажатия любой клавиши перед завершением
            Console.WriteLine("\nНажмите любую клавишу для завершения работы...");
            Console.ReadKey();
        }

        // Вычисление точного значения функции Y
        public static double CalculateExactY(double x)
        {
            // y = -1/2 * ln(1 - 2*x*cos(PI/3) + x^2)
            return -0.5 * Math.Log(1 - 2 * x * Math.Cos(Math.PI / 3.0) + x * x);
        }

        // Вычисление суммы для заданного N
        public static double CalculateSeriesN(double x, int n)
        {
            var sum = 0.0;

            for (var i = 1; i <= n; i++)
            {
                var term = Math.Pow(x, i) * Math.Cos(i * Math.PI / 3.0) / i;
                sum += term;
            }

            return sum;
        }

        // Вычисление суммы для заданной точности EPS
        public static double CalculateSeriesEps(double x, double eps)
        {
            var sum = 0.0;
            var i = 1;
            var term = Math.Pow(x, i) * Math.Cos(i * Math.PI / 3.0) / i;

            while (Math.Abs(term) >= eps)
            {
                sum += term;
                i++;
                term = Math.Pow(x, i) * Math.Cos(i * Math.PI / 3.0) / i;
            }

            // Добавляем последний член, который стал меньше eps (по классике программирования рядов Тейлора)
            sum += term;

            return sum;
        }

        public static double ReadDouble(string prompt)
        {
            double result;
            Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Ошибка ввода! Ожидается вещественное число. Повторите ввод.");
                Console.Write(prompt);
            }
            return result;
        }

        public static int ReadInt(string prompt)
        {
            int result;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out result) || result <= 0)
            {
                Console.WriteLine("Ошибка ввода! Ожидается положительное целое число. Повторите ввод.");
                Console.Write(prompt);
            }
            return result;
        }
    }
}