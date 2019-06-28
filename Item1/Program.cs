using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item1
{

    /*---Задание 1---
     Дан массив целых чисел. Напишите функцию, которая получает данный массив в
    качестве аргумента и сортирует его по возрастанию, а также программу для
    демонстрации работы этой функции.*/


    class Program
    {
        static void Main(string[] args)
        {
           int length=CheckingValue("размерность массива"); //переменная, хранящая размерность массива
            Console.WriteLine(length);
            int[] arr = new int[length];//массив целых чисел.
            for(int i=0;i<arr.Length;i++)//добавление элементов в массив
            {
                arr[i] = CheckingValue("элемент массива");
            }
            Sort(arr);//сортировка
            Show(arr);//вывод
            Console.ReadKey();

        }
        //сортировка вставками.
        static void Sort(int[] a)
        {
            int temp;
            for (int i = 1; i < a.Length; i++)
            {
                for(int j=i;j>=1 && a[j] < a[j - 1];j--)
                {
                    temp = a[j];
                    a[j] = a[j - 1];
                    a[j - 1] = temp;
                    Console.Write(a[j]);
                }
            }
        }
        //вывод массива
        static void Show(int[] array)
        {
            Console.WriteLine("Вывод массива:");
            foreach (int a in array)
            {
                Console.Write(a + " ");
            }
        }
        //проверка введенных параметров на предмет: являются ли они целым числом.
        static int CheckingValue(string s)
        {
            int value = 0;
            bool isNum = false;
            while (isNum == false)
            {
                Console.WriteLine("Введите " + s + ":");
                string answer = Console.ReadLine();
                try
                {
                    value = Int32.Parse(answer);
                    if (s.Equals("размерность массива") && value >= 0) isNum = true; // если проверяется величина размерности массива, то полученная величина должна быть не равна нулю
                    else if (s.Equals("элемент массива")) isNum = true;
                    else Console.WriteLine("Было введено не верное значение, повторите ввод.");
                }
                catch
                {
                    Console.WriteLine("Было введено не верное значение, повторите ввод.");
                }

            }
            return value;
        }

    }
}
