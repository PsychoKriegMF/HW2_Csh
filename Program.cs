using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Reflection;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace HW2_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Задание 1.");

            int[] A = new int[5];
            double[,] B = new double[3, 4];

            Console.WriteLine("Заполним массив числами.");
            for (int i = 0; i < A.Length; i++)
            {
                Console.WriteLine("Введите " + (i + 1) + " значение");
                int.TryParse(Console.ReadLine(), out A[i]);
            }
            Console.Clear();

            //вывод одномерного массива
            Console.WriteLine("Одномерный массив:");
            foreach (int i in A)
            {
                Console.Write("{0,5}", i);
            }
            Console.WriteLine();
            Array.Sort(A);

            //Создание и вывод двумерного массива
            Random random = new Random();

            Console.WriteLine("Двумерный массив:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    B[i, j] = random.NextDouble() * 100;
                    Console.Write("{0,8:F2}", B[i, j]);
                }
                Console.WriteLine();
            }


            //Находим максимум и минимум в двумерном массиве
            double min = B[0, 0], max = B[0, 0];

            foreach (var i in B)
            {
                foreach (var j in B)
                {
                    if (i < min) { min = i; }
                    if (j < min) { min = i; }
                    if (i > max) { max = i; }
                    if (j > max) { max = j; }
                }
            }

            // сумма / произведение всех элементов, и сумма четных элементов
            double sumA = 0;
            double prodA = 1;
            double sumChet = 0;
            foreach (var i in A)
            {
                sumA += i;
                prodA *= i;
                if (i % 2 == 0)
                {
                    sumChet += i;
                }
            }

            // Сумма нечетных столбцов массива B + всех элементов, а так же произведение 
            double sumB = 0;
            double sumNechet = 0;
            double prodB = 1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j == 0 || j == 2)
                    {
                        sumNechet += B[i, j];
                    }
                    sumB += B[i, j];
                    prodB *= B[i, j];

                }
            }

            if (min < A[0])
            {
                Console.WriteLine($"Минимальное число из обоих массивов: " + Math.Round(min, 2));
            }
            else
            {
                Console.WriteLine($"Минимальное число из обоих массивов: " + A[0]);
            }
            if (max > A[A.Length - 1])
            {
                Console.WriteLine($"Максимальное число из обоих массивов: " + Math.Round(max, 2));
            }
            else
            {
                Console.WriteLine($"Максимальное число из обоих массивов: " + A[A.Length - 1]);
            }

            Console.WriteLine($"Сумма всех элементов массивов = " + Math.Round(sumA + sumB, 2));
            Console.WriteLine($"Произведение всех элементов массивов = " + Math.Round(prodA + prodB, 2));
            Console.WriteLine($"Сумма четных элементов массива А = " + sumChet);
            Console.WriteLine($"Сумма нечетных столбцов массива В = " + Math.Round(sumNechet, 2));
            Console.WriteLine("Нaжмите любую клавишу для продолжения...");
            Console.WriteLine();
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine("Задание 2.");

            int[,] arr = new int[5, 5];
            int minEl = arr[0, 0], maxEl = arr[0, 0], sumEl = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = random.Next(-100, 100);
                }
            }
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] < minEl)
                    {
                        minEl = arr[i, j];
                    }
                    if (arr[i, j] > maxEl)
                    {
                        maxEl = arr[i, j];
                    }
                }
            }
            //Просто вывод получившейся матрицы
            Console.WriteLine("Матрица: ");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("{0,6}", arr[i, j]);
                }
                Console.WriteLine();
            }
            //Сумма от минимального до максимального значений (элементов между ними)
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] >= minEl && arr[i, j] <= maxEl)
                        sumEl += arr[i, j];
                }
            }
            Console.WriteLine("Сумма элементов от минимального до максимального значения = " + sumEl);
            Console.WriteLine("Нaжмите любую клавишу для продолжения...");
            Console.WriteLine();
            Console.ReadKey(true);
            Console.Clear();


            Console.WriteLine("Задание 3.");

            Console.WriteLine("Введите строку для шифровки-> ");
            string str = Console.ReadLine();
            string strCipher = ""; // строка для сохранения шифровки
            foreach (char el in str)
            {
                strCipher += Convert.ToChar(Convert.ToInt16(el) + 3);
            }
            str = strCipher;
            strCipher = "";
            Console.WriteLine("Зашифрованная строка -> " + str);
            //дешифруем
            foreach (char el in str)
            {
                strCipher += Convert.ToChar(Convert.ToInt16(el) - 3);
            }
            str = strCipher;
            strCipher = "";
            Console.WriteLine("Дешифрованная строка -> " + str);

            Console.WriteLine("Нaжмите любую клавишу для продолжения...");
            Console.WriteLine();
            Console.ReadKey(true);
            Console.Clear();



            Console.WriteLine("Задание 4.");

            Console.WriteLine("Создаем две матрицы и заполняем случайными числами.");

            int[,] matrix1 = new int[5, 5];
            int[,] matrix2 = new int[5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix1[i, j] = random.Next(1, 10);
                    matrix2[i, j] = random.Next(11, 20);
                }
            }

            Console.WriteLine("Матрица 1:");

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("{0,6}", matrix1[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Матрица 2:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("{0,6}", matrix2[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Умножаем матрицу на число.");
            Console.Write("Введите число на которое хотите умножить матрицу ->");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix1[i, j] *= n;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Результат умножения матрицы на " + n);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("{0,6}", matrix1[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Складываем матрицы 1 и 2.");
            int[,] matrixResult = new int[5, 5];  //новая матрица для созранени результатов операций

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrixResult[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            Console.WriteLine("Результат сложения матриц:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("{0,6}", matrixResult[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Произведение матриц 1 и 2.");

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrixResult[i, j] = matrix1[i, j] * matrix2[i, j];
                }
            }


            Console.WriteLine("Результат произведения матриц:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("{0,6}", matrixResult[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Нaжмите любую клавишу для продолжения...");
            Console.WriteLine();
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine("Задание 5.");
            Console.WriteLine("Введите арифметическое выражение (только + и -) в формате (1 + 3 либо 12 - 9):"); // пробелы должны быть
            string input = Console.ReadLine();

            string[] parts = input.Split(' ');
            double result = double.Parse(parts[0]);

            for (int i = 1; i < parts.Length; i += 2)
            {
                string operation = parts[i];
                double operand = double.Parse(parts[i + 1]);

                switch (operation)
                {
                    case "+":
                        result += operand;
                        break;
                    case "-":
                        result -= operand;
                        break;
                }
            }
            Console.WriteLine("Результат: " + result);

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Задание 6. Изменение регистра.");
            Console.WriteLine("Введите текст-> ");
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder(text);
            bool up = false;
            sb[0] = Char.ToUpper(sb[0]);  // ну почему то решил здесь оставить 
            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] == '.')
                {
                    up = true;
                }
                else if (Char.IsLetter(sb[i]) && up)
                {
                    sb[i] = Char.ToUpper(sb[i]);
                    up = false;
                }
            }
            text = sb.ToString();
            Console.WriteLine(text);
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();



            Console.WriteLine("Задание 7.");
            Console.WriteLine("Недопустимые слова.\n");

            string text2 = "Я убил для тебя тюльпан\r\nУкрал у земли тюльпан\r\nНамотал резиновый пучок\r\nТак для кого же кровь его течёт?\r\nТюльпан";
            Console.WriteLine("Исходный текст: \n" + text2);
            Console.WriteLine("\n");
            string ban = "тюльпан"; // запретное слово         
            string repl = "***"; // замена слова

            //Сначала привел все к нижнему регистру чтобы найти все слова , потом вернул опять заглавные 
            text2 = text2.ToLower().Replace(ban, repl);
            StringBuilder text3 = new StringBuilder(text2);
            bool up2 = false;
            text3[0] = Char.ToUpper(text3[0]);
            for (int i = 0;i < text3.Length; i++)
            {
                if (text3[i]=='.' || text3[i] == '\r'|| text3[i] == '\n')
                {
                    up2 = true;
                }
                else if (Char.IsLetter(text3[i])&& up2)
                {
                    text3[i]= Char.ToUpper(text3[i]);
                    up2 = false;
                }
            }
            text2 = text3.ToString();
            Console.WriteLine("Фильтрованный текст: \n" + text2);
            
            int counter = 0; //счетчик замен       
            string[] wordsinText2 = text2.Split(new char[] { ' ', ',', '\r', '\n', '\t' });
            foreach (var word in wordsinText2)
            {
                if (repl == word.ToLower())
                {
                    counter++;
                }
            }
            Console.WriteLine("Произведено замен слов - " + counter);







        }
    }
}
