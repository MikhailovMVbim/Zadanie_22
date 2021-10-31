using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Сформировать массив случайных целых чисел (размер  задается пользователем).
 * Вычислить сумму чисел массива и максимальное число в массиве.
 * Реализовать  решение  задачи  с  использованием  механизма  задач продолжения.
 */


namespace Zadanie_22
{
    class Program
    {
        static void Summa (int [] n)
        {
            int s = 0;
            for (int i = 0; i < n.Length; i++)
            {
                s += n[i];
            }
            Console.WriteLine($"Сумма чисел массива равна: {s}");
        }
        static void Max(Task task, object o)
        {
            int[] n = (int []) o;
            int max = n[0];
            for (int i = 0; i < n.Length; i++)
            {
                if (max<n[i])
                {
                    max = n[i];
                }
            }
            Console.WriteLine($"Максимальное число в массиве равно: {max}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("ЗАДАНИЕ 22. ПАРАЛЛЕЛЬНОЕ ПРОГРАММИРОВАНИЕ И БИБЛИОТЕКА TPL");
            Console.WriteLine("----------------------------------------------------------");
            Console.Write("Введите размер массива: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Random random = new Random();
            int[] numbers = new int[n];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(0,100);
            }

            Task task1 = new Task(() => Summa(numbers));
            Action<Task, object> actionTask = new Action<Task, object>(Max);
            Task task2 = task1.ContinueWith(actionTask, numbers);
            task1.Start();


            task2.Wait();
            PrintArray(numbers);
            Console.WriteLine("Работа программы завершена!");
            Console.ReadKey();
        }

        static public void PrintArray (int [] numbers)
        {
            Console.WriteLine();
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
