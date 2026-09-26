using System;

namespace App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("=== Задача 1 ===");

            var n = ReadInt("Введите значение n: ");
            var m = ReadInt("Введите значение m: ");

            var firstResult = n++ * m;
            var secondResult = m-- < n;
            var thirdResult = ++m > n;

            Console.WriteLine("Операция 1.1 (n++ * m): " + firstResult);
            Console.WriteLine("Операция 1.2 (m-- < n): " + secondResult);
            Console.WriteLine("Операция 1.3 (++m > n): " + thirdResult);

            var x = ReadDouble("Введите значение x: ");

            var innerValue = x + Math.Pow(Math.Abs(x), 0.25);
            if (innerValue < 0)
            {
                Console.WriteLine("Операция 1.4: Выражение под корнем меньше 0. Вычислить невозможно.");
            }
            else
            {
                var fourthResult = Math.Sqrt(innerValue) + Math.Abs(x);
                Console.WriteLine("Операция 1.4: " + fourthResult);
            }

            
            Console.WriteLine("\n=== Задача 2 ===");
            var pointX = ReadDouble("Проверка вхождения точки в область. Введите значение x: ");
            var pointY = ReadDouble("Введите значение y: ");

            var isInArea = IsPointInArea(pointX, pointY);
            Console.WriteLine("Операция 2: " + isInArea);

            
            Console.WriteLine("\n=== Задача 3 ===");

            var floatA = 1000f;
            var floatB = 0.0001f;

            var doubleA = 1000.0;
            var doubleB = 0.0001;

            var floatResult = (float)((Math.Pow(floatA + floatB, 4) - Math.Pow(floatA, 4))
                / (6 * floatA * floatA * floatB * floatB + 4 * floatA * Math.Pow(floatB, 3) + Math.Pow(floatB, 4) + 4 * Math.Pow(floatA, 3) * floatB));

            var doubleResult = (Math.Pow(doubleA + doubleB, 4) - Math.Pow(doubleA, 4))
                / (6 * doubleA * doubleA * doubleB * doubleB + 4 * doubleA * Math.Pow(doubleB, 3) + Math.Pow(doubleB, 4) + 4 * Math.Pow(doubleA, 3) * doubleB);

            Console.WriteLine("Операция 3.1, float: " + floatResult);
            Console.WriteLine("Операция 3.2, double: " + doubleResult);
            Console.WriteLine("Операция 3, точный результат: 1");
        }

        
        public static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            if (!int.TryParse(Console.ReadLine(), out var result))
            {
                Console.WriteLine("Ошибка ввода! Введено не число.");
                Environment.Exit(0);
            }
            return result;
        }

        
        public static double ReadDouble(string prompt)
        {
            Console.Write(prompt);
            if (!double.TryParse(Console.ReadLine(), out var result))
            {
                Console.WriteLine("Ошибка ввода! Введено не число.");
                Environment.Exit(0);
            }
            return result;
        }

        public static bool IsPointInArea(double pointX, double pointY)
        {
            return (pointX * pointX + pointY * pointY <= 1) && (pointX * pointY <= 0);
        }
    }
}
