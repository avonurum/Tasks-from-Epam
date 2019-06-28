using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item3
{
    /* ---Задание 3---
        Дана строка, вывести только те слова, которые встречаются в ней только один
        раз.
        */

    /* Ну вот так... Я пыталась разобрать алгоритм поиска Рабина-Карпа, 
     * но при реализации он кушал символы где хотел, а пофискить я это не смогла.:с 
     */

    class Program
    {
        static void Main(string[] args)
        {
              string str = "";
              AddString(ref str);
              char c = ' ';
              int flag = 0;
              string[] arr = str.Split(c);
              string arr2="";
              for(int i=0; i<arr.Length;i++)
              {
                  for(int j=0;j< arr.Length;j++)
                  {
                      if (arr[i].Equals(arr[j]))
                      {
                          flag++;
                      }
                  }
                  if(flag==1)
                  {
                      arr2+=arr[i]+' ';
                  }
                  flag = 0;
              }
              Console.WriteLine("result: "+arr2);
              Console.ReadKey();
             
        }
        static void AddString(ref string str)
        {
            while(true)
            {
                Console.WriteLine("Введите строку:");
                string s = Console.ReadLine();
                if(s.Length>0)
                {
                    str = s;break;
                }
                else
                {
                    Console.WriteLine("Введена пустая строка. Повторите ввод");
                }
            }

        }

        
    }
}