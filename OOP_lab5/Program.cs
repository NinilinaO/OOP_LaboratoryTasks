using System;
using System.Text;

namespace PracticalWork5_6
{
    public class Program
    {
        const int MinLength = 1;
        const int MaxLength = 50;
        const int MinValue = -100;
        const int MaxValue = 100;

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            RunMainMenu();
        }

        public static void RunMainMenu()
        {
            var isRunning = true;

            int[,] matrix = null;
            int[][] jaggedArray = null;
            string userString = string.Empty;

            while (isRunning)
            {
                Console.WriteLine("\n=== ГЛАВНОЕ МЕНЮ (Практическая работа №5-6, Вариант 12) ===");
                Console.WriteLine("1. Работа с двумерными массивами (Удаление столбца по номеру K)");
                Console.WriteLine("2. Работа с рваными массивами (Добавление K строк в конец)");
                Console.WriteLine("3. Работа со строками (Удаление 1-го и последнего слова в предложении)");
                Console.WriteLine("4. Выход");

                var choice = ReadIntNumber("Выберите пункт меню (1-4):", 1, 5);

                switch (choice)
                {
                    case 1:
                        RunMatrixMenu(ref matrix);
                        break;
                    case 2:
                        RunJaggedMenu(ref jaggedArray);
                        break;
                    case 3:
                        RunStringMenu(ref userString);
                        break;
                    case 4:
                        isRunning = false;
                        Console.WriteLine("Завершение работы программы. Нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public static void RunMatrixMenu(ref int[,] matrix)
        {
            var back = false;
            int rows = 0, cols = 0;

            while (!back)
            {
                Console.WriteLine("\n--- ДВУМЕРНЫЕ МАССИВЫ ---");
                Console.WriteLine("1. Создать двумерный массив");
                Console.WriteLine("2. Вывести двумерный массив");
                Console.WriteLine("3. Удалить столбец с номером K (Вариант 12)");
                Console.WriteLine("4. Назад в главное меню");

                var choice = ReadIntNumber("Выберите подпункт:", 1, 5);

                switch (choice)
                {
                    case 1:
                        rows = ReadIntNumber("Введите количество строк (1-50):", MinLength, MaxLength);
                        cols = ReadIntNumber("Введите количество столбцов (1-50):", MinLength, MaxLength);
                        matrix = MakeMatrix(rows, cols);
                        Console.WriteLine("Двумерный массив успешно сформирован.");
                        break;
                    case 2:
                        PrintMatrix(matrix);
                        break;
                    case 3:
                        if (matrix == null)
                        {
                            Console.WriteLine("Ошибка: Двумерный массив не создан!");
                            break;
                        }
                        rows = matrix.GetLength(0);
                        cols = matrix.GetLength(1);

                        if (cols <= 1)
                        {
                            Console.WriteLine("Ошибка: В массиве недостаточно столбцов для удаления!");
                            break;
                        }

                        var kCol = ReadIntNumber($"Введите номер столбца K для удаления (1 - {cols}):", 1, cols + 1);
                        DeleteColumn(ref matrix, kCol, ref rows, ref cols);
                        Console.WriteLine("Столбец успешно удален.");
                        break;
                    case 4:
                        back = true;
                        break;
                }
            }
        }

        public static void RunJaggedMenu(ref int[][] jaggedArray)
        {
            var back = false;

            while (!back)
            {
                Console.WriteLine("\n--- РВАНЫЕ МАССИВЫ ---");
                Console.WriteLine("1. Создать рваный массив");
                Console.WriteLine("2. Вывести рваный массив");
                Console.WriteLine("3. Добавить K строк в конец массива (Вариант 12)");
                Console.WriteLine("4. Назад в главное меню");

                var choice = ReadIntNumber("Выберите подпункт:", 1, 5);

                switch (choice)
                {
                    case 1:
                        var rows = ReadIntNumber("Введите количество строк рваного массива (1-50):", MinLength, MaxLength);
                        jaggedArray = MakeJaggedArray(rows);
                        Console.WriteLine("Рваный массив успешно сформирован.");
                        break;
                    case 2:
                        PrintJaggedArray(jaggedArray);
                        break;
                    case 3:
                        if (jaggedArray == null)
                        {
                            Console.WriteLine("Ошибка: Рваный массив не создан!");
                            break;
                        }
                        var kRows = ReadIntNumber("Введите количество строк K для добавления в конец:", 1, MaxLength);
                        AddRowsToEnd(ref jaggedArray, kRows);
                        Console.WriteLine("Строки успешно добавлены в конец рваного массива.");
                        break;
                    case 4:
                        back = true;
                        break;
                }
            }
        }

        public static void RunStringMenu(ref string userString)
        {
            var back = false;

            while (!back)
            {
                Console.WriteLine("\n--- РАБОТА СО СТРОКАМИ ---");
                Console.WriteLine("1. Ввести строку с клавиатуры");
                Console.WriteLine("2. Использовать тестовую строку");
                Console.WriteLine("3. Вывести текущую строку");
                Console.WriteLine("4. Обработать строку (Удалить 1-е и последнее слово в каждом предложении)");
                Console.WriteLine("5. Назад в главное меню");

                var choice = ReadIntNumber("Выберите подпункт:", 1, 6);

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите строку символов (предложения с точками/восклицательными/вопросительными знаками):");
                        userString = Console.ReadLine();
                        Console.WriteLine("Строка успешно введена.");
                        break;
                    case 2:
                        userString = "В лесу родилась елочка! В лесу она росла. Зимой и летом стройная, зеленая была!";
                        Console.WriteLine($"Загружена тестовая строка:\n{userString}");
                        break;
                    case 3:
                        if (string.IsNullOrEmpty(userString))
                        {
                            Console.WriteLine("Строка пуста.");
                        }
                        else
                        {
                            Console.WriteLine($"Текущая строка:\n{userString}");
                        }
                        break;
                    case 4:
                        if (string.IsNullOrEmpty(userString))
                        {
                            Console.WriteLine("Ошибка: Строка не введена!");
                            break;
                        }
                        var result = ProcessStringVariant12(userString);
                        Console.WriteLine($"Результат обработки:\n{result}");
                        break;
                    case 5:
                        back = true;
                        break;
                }
            }
        }


        public static int[,] MakeMatrix(int rows, int cols)
        {
            var matrix = new int[rows, cols];
            Console.WriteLine("Выберите способ заполнения: 1 - ДСЧ, 2 - Вручную");
            var method = ReadIntNumber("", 1, 3);
            var rnd = new Random();

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (method == 1)
                    {
                        matrix[i, j] = rnd.Next(MinValue, MaxValue);
                    }
                    else
                    {
                        matrix[i, j] = ReadIntNumber($"Введите элемент [{i + 1},{j + 1}]:", MinValue, MaxValue);
                    }
                }
            }
            return matrix;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            if (matrix == null)
            {
                Console.WriteLine("Двумерный массив пустой!");
                return;
            }

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            Console.WriteLine("Содержимое двумерного массива:");
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j],5} ");
                }
                Console.WriteLine();
            }
        }

        public static void DeleteColumn(ref int[,] matrix, int kCol, ref int rows, ref int cols)
        {
            var newCols = cols - 1;
            var newMatrix = new int[rows, newCols];
            var targetCol = kCol - 1; 

            for (var i = 0; i < rows; i++)
            {
                var newColIndex = 0;
                for (var j = 0; j < cols; j++)
                {
                    if (j == targetCol) continue;
                    newMatrix[i, newColIndex] = matrix[i, j];
                    newColIndex++;
                }
            }
            matrix = newMatrix;
        }


        public static int[][] MakeJaggedArray(int rows)
        {
            var jagged = new int[rows][];
            Console.WriteLine("Выберите способ заполнения: 1 - ДСЧ, 2 - Вручную");
            var method = ReadIntNumber("", 1, 3);
            var rnd = new Random();

            for (var i = 0; i < rows; i++)
            {
                var cols = ReadIntNumber($"Введите количество столбцов для строки {i + 1} (1-20):", 1, 21);
                jagged[i] = new int[cols];
                for (var j = 0; j < cols; j++)
                {
                    if (method == 1)
                    {
                        jagged[i][j] = rnd.Next(MinValue, MaxValue);
                    }
                    else
                    {
                        jagged[i][j] = ReadIntNumber($"Введите элемент [{i + 1},{j + 1}]:", MinValue, MaxValue);
                    }
                }
            }
            return jagged;
        }

        public static void PrintJaggedArray(int[][] jagged)
        {
            if (jagged == null)
            {
                Console.WriteLine("Рваный массив пустой!");
                return;
            }

            Console.WriteLine("Содержимое рваного массива:");
            for (var i = 0; i < jagged.Length; i++)
            {
                for (var j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write($"{jagged[i][j],5} ");
                }
                Console.WriteLine();
            }
        }

        public static void AddRowsToEnd(ref int[][] jagged, int kRows)
        {
            var oldRows = jagged != null ? jagged.Length : 0;
            var newRows = oldRows + kRows;
            var newJagged = new int[newRows][];

            for (var i = 0; i < oldRows; i++)
            {
                newJagged[i] = jagged[i];
            }

            var rnd = new Random();
            for (var i = oldRows; i < newRows; i++)
            {
                Console.WriteLine($"Формирование новой строки {i + 1}:");
                var cols = ReadIntNumber("Введите количество столбцов для новой строки (1-20):", 1, 21);
                newJagged[i] = new int[cols];

                Console.WriteLine("Выберите способ заполнения новой строки: 1 - ДСЧ, 2 - Вручную");
                var method = ReadIntNumber("", 1, 3);

                for (var j = 0; j < cols; j++)
                {
                    if (method == 1)
                    {
                        newJagged[i][j] = rnd.Next(MinValue, MaxValue);
                    }
                    else
                    {
                        newJagged[i][j] = ReadIntNumber($"Введите элемент [{i + 1},{j + 1}]:", MinValue, MaxValue);
                    }
                }
            }
            jagged = newJagged;
        }

        public static string ProcessStringVariant12(string input)
        {
            var sentenceDelimiters = new char[] { '.', '!', '?' };
            var rawSentences = input.Split(sentenceDelimiters, StringSplitOptions.RemoveEmptyEntries);

            var delimiters = new char[rawSentences.Length];
            var searchIndex = 0;

            for (var i = 0; i < rawSentences.Length; i++)
            {
                var nextPos = input.IndexOfAny(sentenceDelimiters, searchIndex);
                if (nextPos != -1)
                {
                    delimiters[i] = input[nextPos];
                    searchIndex = nextPos + 1;
                }
                else
                {
                    delimiters[i] = '.'; 
                }
            }

            var resultBuilder = new StringBuilder();

            for (var i = 0; i < rawSentences.Length; i++)
            {
                var sentence = rawSentences[i].Trim();
                if (string.IsNullOrEmpty(sentence)) continue;

                var wordSeparators = new char[] { ' ', ',', ';', ':' };
                var words = sentence.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries);

                if (words.Length <= 2)
                {
                    continue;
                }

                var modifiedSentenceBuilder = new StringBuilder();
                for (var w = 1; w < words.Length - 1; w++)
                {
                    modifiedSentenceBuilder.Append(words[w]);
                    if (w < words.Length - 2)
                    {
                        modifiedSentenceBuilder.Append(" ");
                    }
                }

                var processedStr = modifiedSentenceBuilder.ToString();
                if (processedStr.Length > 0)
                {
                    processedStr = char.ToUpper(processedStr[0]) + processedStr.Substring(1);
                }

                resultBuilder.Append(processedStr).Append(delimiters[i]).Append(" ");
            }

            return resultBuilder.ToString().Trim();
        }

        public static int ReadIntNumber(string prompt, int left, int right)
        {
            var okInput = false;
            var number = MinValue;

            do
            {
                if (!string.IsNullOrEmpty(prompt))
                {
                    Console.WriteLine(prompt);
                }

                try
                {
                    var buf = Console.ReadLine();
                    number = Convert.ToInt32(buf); 

                    if (number >= left && number < right)
                    {
                        okInput = true;
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка: Введите число в диапазоне от {left} до {right - 1}!");
                        okInput = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: Требуется ввести целое число!");
                    okInput = false;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка: Число слишком велико или слишком мало!");
                    okInput = false;
                }
            } while (!okInput);

            return number;
        }
    }
}