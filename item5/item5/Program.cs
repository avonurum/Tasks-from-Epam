using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace item5
{

    /*---Задача 5---
            Дана строка состоящая из скобок “{},(),[]”, определить является ли данная строка
            правильно скобочной последовательность. Например (()) – псп, а ((() нет.
         
         */
    class Program
    {
        static void Main(string[] args)
        {
            String sequence = "";
            AddString(ref sequence);
            int len = sequence.Length;
            char[] brackets = new char[len];
            int k = 0;
            int count = 0, count2 = 0, count3 = 0;
            for (int i = 0; i < len; i++) // проверка баланса
            {
                if (sequence[i] == '(')
                {
                    count++;
                    brackets[k] = sequence[i];
                    k++;
                }
                if (sequence[i] == ')')
                {
                    count--;
                    brackets[k] = sequence[i];
                    k++;
                }
                if (sequence[i] == '[')
                {
                    count2++;
                    brackets[k] = sequence[i];
                    k++;
                }
                if (sequence[i] == ']')
                {
                    count2--;
                    brackets[k] = sequence[i];
                    k++;
                }
                if (sequence[i] == '{')
                {
                    count3++;
                    brackets[k] = sequence[i];
                    k++;
                }
                if (sequence[i] == '}')
                {
                    count3--;
                    brackets[k] = sequence[i];
                    k++;
                }


            }
            if (count == 0 && count2 == 0 && count3 == 0)
            {
                for (int i = 0; i < k; i++) Console.Write(brackets[i]);
                for (int i = 1; i < k; i++)  // определение правильности порядка следования скобок
                {
                    if (brackets[i] == ')' && (brackets[i - 1] == '[' || brackets[i - 1] == '{'))
                    {
                        Console.Write(false);
                        break;
                    }
                    if (brackets[i] == ']' && (brackets[i - 1] == '(' || brackets[i - 1] == '{'))
                    {
                        Console.Write(false);
                        break;
                    }
                    if (brackets[i] == '}' && (brackets[i - 1] == '[' || brackets[i - 1] == '('))
                    {
                        Console.Write(false);
                        break;
                    }
                    if (i == k - 1) Console.WriteLine("result:"+true);
                }

            }
            else Console.WriteLine("result:"+false);
            Console.ReadKey();
        }
        static void AddString(ref string str)//ввод строки
        {
            while (true)
            {
                Console.WriteLine("Введите строку:");
                string s = Console.ReadLine();
                if (s.Length > 0)
                {
                    str = s; break;
                }
                else
                {
                    Console.WriteLine("Введена пустая строка. Повторите ввод");
                }
            }
        }
    }
}




