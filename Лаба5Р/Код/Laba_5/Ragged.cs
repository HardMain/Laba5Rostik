using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
    internal class Ragged : ArrayBase
    {
        int[][] ragged;
        public Ragged()
        {
            int countRows = 0, countCols = 0;
            string msg = "";
            string errorMsg = "";

            msg = "Введите количество строк в матрице: ";
            errorMsg = "\nКоличество строк должно быть положительным числом!\n";
            countRows = CheckAndInput.InputPositiveNumber(msg, errorMsg);

            ragged = new int[countRows][];

            errorMsg = "\nКоличество колонок должно быть положительным числом!\n";
            for (int i = 0; i < countRows; i++)
            {
                msg = $"Введите количество столбцов для {i + 1} строки: ";
                countCols = CheckAndInput.InputPositiveNumber(msg, errorMsg);

                ragged[i] = new int[countCols];
            }
            Console.WriteLine();
        }
        public override void RandomFill()
        {
            Random random = new Random();
            for (int i = 0; i < ragged.Length; i++)
            {
                for (int j = 0; j < ragged[i].Length; j++)
                    ragged[i][j] = random.Next(-50, 50);
            }
        }
        public override void ManualFill()
        {
            string? msg;

            Console.WriteLine();
            for (int i = 0; i < ragged.Length; i++)
            {
                for (int j = 0; j < ragged[i].Length; j++)
                {
                    msg = $"Введите элемент для {i + 1}-й строки {j + 1}-го столбца: ";
                    ragged[i][j] = CheckAndInput.InputIntNumber(msg);
                }
            }
        }
        public void ShowRaggedObj()
        {
            if (ragged.Length == 0)
            {
                Console.WriteLine("Рваный массив: <пустой>\n");
                return;
            }

            Console.WriteLine("----- Рваный массив -----");
            for (int i = 0; i < ragged.Length; i++)
            {
                for (int j = 0; j < ragged[i].Length; j++)
                    Console.Write($"{ragged[i][j],-4} ");
                Console.WriteLine('\n');
            }
        }
        public void ShowRagged(int[][] ragged)
        {
            if (ragged.Length == 0)
            {
                Console.WriteLine("Рваный массив: <пустой>\n");
                return;
            }

            Console.WriteLine("----- Рваный массив -----");
            for (int i = 0; i < ragged.Length; i++)
            {
                for (int j = 0; j < ragged[i].Length; j++)
                    Console.Write($"{ragged[i][j],-4} ");
                Console.WriteLine('\n');
            }
        }
        public void AddRowToEnd()
        {
            int[][] tempArray = new int[ragged.Length + 1][];
            for (int i = 0, j = 0; i < ragged.Length; i++)
                tempArray[j++] = new int[ragged[i].Length];

            string msg = "Введите количество столбцов для последней строки: ";
            string errorMsg = "\nКоличество столбцов должно быть положительным числом!\n";

            int countCols = CheckAndInput.InputPositiveNumber(msg, errorMsg);

            tempArray[tempArray.GetLength(0) - 1] = new int[countCols];

            for (int i = 0; i < ragged.Length; i++)
            {
                for (int j = 0; j < ragged[i].Length; j++)
                    tempArray[i][j] = ragged[i][j];
            }

            Console.WriteLine();
            msg = "Введите элемент для добавления: ";
            for (int j = 0; j < countCols; j++)
                tempArray[tempArray.GetLength(0) - 1][j] = CheckAndInput.InputIntNumber(msg);

            ragged = tempArray;

            Console.WriteLine();
            ShowRagged(ragged);

            msg = "1. Продолжить добавление\n2. Перейти к другому заданию\n-> ";
            errorMsg = "Такого пункта меню не существует!\n";

            do
            {
                int choice = CheckAndInput.InputIntNumber(msg);
                Console.WriteLine();
                if (choice == 1)
                {
                    AddRowToEnd();
                    break;
                }
                else if (choice == 2)
                    break;
                else
                    Console.WriteLine(errorMsg);
            } while (true);
        }
    }
}
