using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item2
{
    class Program
    {
        /* ---Задание 2---
         Напишите функцию, которая для отсортированного маcсива целых чисел
        определяет, содержится ли в нем заданное значение.
            */


        /* В связи с тем, что массив отсортирован я решила применить бинарную сортировку, т.е. выбирать элемент с "средним" индексом и сравнивать его с нужным элементом
         и в последствии уменьшать диапазон поиска пока массив не кончится или не будет найден нужный элемент. Также массив может быть осортирован в разных направлениях(по убыванию или по возрастанию)
         я решила узнавать данную информацию у пользователя */
        static void Main(string[] args)
        {
            int key=CheckingValue("элемент, который вы ходите найти");
            int length=CheckingValue("размерность массива");
            char direction=' ';
            CheckingDirection(direction);
            int[] arr = new int[length];
            CheckingArr(arr,direction);
            Console.WriteLine("Результат: "+BinarySearch(arr, key,direction));
            Console.ReadKey();
        }
        //метод бинарного поиска по отсортированному массиву. Принимает массив, элемент, который нужно найти, и направление сортировки массива
        static bool BinarySearch(int[] arr, int key,char dir)
        {
            int lBorder = 0;
            int rBorder = arr.Length - 1;
            if(dir=='+')
            {
                while (lBorder <= rBorder)
                {
                    int middle = (rBorder + lBorder) / 2;
                    if (key == arr[middle])
                    {
                        return true;
                    }
                    else if (key > arr[middle])
                    {
                        lBorder = middle + 1;
                    }
                    else
                    {
                        rBorder = middle - 1;
                    }
                }
                return false;
            }
            else
            {
                while (lBorder <= rBorder)
                {
                    int middle = (rBorder + lBorder) / 2;
                    if (key == arr[middle])
                    {
                        return true;
                    }
                    else if (key < arr[middle])
                    {
                        lBorder = middle + 1;
                    }
                    else
                    {
                        rBorder = middle - 1;
                    }
                }
                return false;
            }
            
        }

        //проверка является ли введенное значение числом. Метод принимает строку по которой определяется как именно нужно проверять число. 
        //Ведь размерность массива не может быть меньше нуля.
        static int CheckingValue(string s)
        {
            int value = 0;
            int n;
            bool isNum = false;
            while (isNum == false)
            {
                Console.WriteLine("Введите " + s + ":");
                string answer = Console.ReadLine();
                try
                {
                    value = Int32.Parse(answer);
                    if (s.Equals("размерность массива") && value >= 0) isNum = true;
                    else if (s.Equals("элемент, который вы ходите найти")) isNum = true;
                    else Console.WriteLine("Было введено не верное значение, повторите ввод.");
                }
                catch
                {
                    Console.WriteLine("Было введено не верное значение, повторите ввод.");
                }

            }
            return value;
        }
        //проверка массива на отсортированность. Метод принимает пустой массив и направление сортировки массива.
        //Проверка является ли введенное значение числом и удовлетроряет ли оно направлению сортировки массива.
        static void CheckingArr(int[] array, char dir)
        {
            int i = 0;
            while (i<array.Length)
            {
                Console.Write("Введите знечение элемента [" + i + "]: ");

                try
                {
                    array[i] = Int32.Parse(Console.ReadLine());
                    if (i != 0)
                    {
                        if(dir=='+')
                        {
                            if (array[i] < array[i - 1])Console.WriteLine("Данное число не подходит, оно меньше предыдущего элемента. Повторите ввод.");
                            else i++;
                        }
                        else
                        {
                            if (array[i] > array[i - 1]) Console.WriteLine("Данное число не подходит, оно больше предыдущего элемента. Повторите ввод.");
                            else i++;
                        }
                    }
                    else i++;
                }
                catch
                {
                    Console.WriteLine("Было введено не верное значение, повторите ввод.");
                }
                
            }
        }

        //метод, принимает направление выбранное пользователем и проверяет правильность введения.
        static void CheckingDirection(char direction)
        {
            bool isCorrect = false;
            while(isCorrect == false)
            {
                Console.WriteLine("Выберите направление:Введите '+', если ваш массив отсортирован про возрастанию, и '-',если массив отсортирован по убыванию ");
                try
                {
                    switch(Char.Parse(Console.ReadLine()))
                    {
                        case '+': direction='+'; isCorrect = true; break;
                        case '-': direction='-'; isCorrect = true; break;
                        default: Console.WriteLine("Вы ввели неверное значение");break;
                    }
                }
                catch
                {
                    Console.WriteLine("Вы ввели неверное значение");
                }
            }
        }
    }
}
