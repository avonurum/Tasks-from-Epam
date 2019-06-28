using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace item4
{

    /*   ---Задание 4---
     Написать функцию нахождения факториала числа n.
         */



    /* факториал -  функция, определённая на множестве неотрицательных целых чисел.
     соответственно, числа должны быть неотрицательными и целыми
     поэтому я выбрала типы данных uint для числа, для которого выполняется вычисление факториала 
     изначально при попытке вычисления факториала числа, которое было большего чем 60, я столкнулась с переполнением
     изначально я хранила значение в переменной типа ulong.
     При поиске решения я выбрала тип данных BigInteger, принадлежащий библиотеке Numerics, для хранения результата*/

    class Program
    {
        static void Main(string[] args)
        {
            
            uint n = GetN();
            ulong res = 1;
            Console.WriteLine("Результат: "+TreeRoot(n));
            Console.ReadKey();
        }



 //метод, который запрашивает у пользователя число и проверяет удовлетворяет ли число всем заданным условиям.
 //если число допустимо, то метод возвращает это число.
        static uint GetN() 
        {
           bool isCorrect = false;
           uint res=0;
           while(isCorrect==false)
            {
                Console.WriteLine("Введите целое неотрицательное число:");
                string input = Console.ReadLine();
                try
                {
                    res = uint.Parse(input);
                    isCorrect = true;
                }
                catch
                {
                    Console.WriteLine("Введены неверные данные, повторите ввод.");
                }
                    
            }
            return res;
        }
       
//в связи с тем, что при большом значении n приходится столкнутся с длинной арифметикой я решила 
//рекурсивно разбить вычисление факториала до той степени, чтобы умножаемые числа были примерно одинаковой длины.

        static BigInteger TreeRoot(uint n)
        {
            if (n < 0)return 0;
            if (n == 0)return 1;
            if (n == 1 || n == 2)return n;
            return BranchTree(2, n);
        }  


        static BigInteger BranchTree(uint lBorder, uint rBorder)
        {
            if (lBorder > rBorder)
            {
                return 1;
            }
            if (lBorder == rBorder)
            {
                return lBorder;
            }
         
            if (rBorder - lBorder == 1)
            {
                return (BigInteger)lBorder * rBorder;
            }
        
            uint middle = (lBorder + rBorder) / 2;
            return BranchTree(lBorder, middle) * BranchTree(middle + 1, rBorder);
        }
        

    }
}
