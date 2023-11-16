using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
    internal class Univariate : ArrayBase
    {
        int[] array;
        public Univariate()
        {
            string msg = "Введите размер одномерного массива(>0): ";
            string errorMsg = "\nКоличество элементов должно быть положительным!\n";

            array = new int[CheckAndInput.InputPositiveNumber(msg, errorMsg)];
            Console.WriteLine();
        }
        public override void RandomFill()
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(-50, 50);
        }
        public override void ManualFill()
        {
            string? msg;

            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                msg = $"Введите {i + 1}-й элемент: ";
                array[i] = CheckAndInput.InputIntNumber(msg);
            }
        }
        public void ShowArrayObj()
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Массив: <пустой>\n");
                return;
            }

            Console.WriteLine("----- Одномерный массив -----");
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
            Console.WriteLine('\n');
        }
        public void ShowArray(int[] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Массив: <пустой>\n");
                return;
            }

            Console.WriteLine("----- Одномерный массив -----");
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
            Console.WriteLine('\n');
        }

        public void AddElements()
        {
            int countElements = 0, itemNumber = 0;
            string msg = ""; 
            string errorMsg = "";

            msg = "Введите количество элементов для добавления: ";
            errorMsg = "\nКоличество элементов для добавление должно быть положительным числом!\n";
            countElements = CheckAndInput.InputPositiveNumber(msg, errorMsg);

            msg = "Введите с какого номера начать добавление: ";
            errorMsg = "\nНевозможно начать добавление элементов с этого номера!\n";
            itemNumber = CheckAndInput.InputWithinBoundariesArray(array, msg, errorMsg);

            msg = "1. Продолжить добавление\n2. Перейти к другому заданию\n-> ";
            errorMsg = "\nТакого пункта меню не существует!\n";

            int[] tempArray = new int[array.Length + countElements];
            AddToTemp(itemNumber, countElements, tempArray);
            array = tempArray;
            Console.WriteLine();
            ShowArray(array);

            do
            {
                int choice = CheckAndInput.InputIntNumber(msg);
                Console.WriteLine();
                if (choice == 1)
                {
                    AddElements();
                    break;
                }
                else if (choice == 2)
                    break;
                else
                    Console.WriteLine(errorMsg);
            } while (true);
        }
        public void AddToTemp(int itemNumber, int countElements, int[] tempArray)
        {
            Console.WriteLine();
            string msg = "Введите элемент для добавления: ";
            for (int i = 0, j = 0; i < tempArray.Length; i++)
            {
                if (i < itemNumber - 1)
                    tempArray[i] = array[j++];
                else if (i < itemNumber + countElements - 1)
                    tempArray[i] = CheckAndInput.InputIntNumber(msg);
                else
                    tempArray[i] = array[j++];
            }
        }
    }
}
