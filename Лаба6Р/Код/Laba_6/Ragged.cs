using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laba_6
{
    internal class Ragged
    {
        static Random random = new Random();

        int[][] ragged;

        public Ragged()
        {
            int countRows = 0, countCols = 0;
            string msg = "";
            string errorMsg = "";

            msg = "Введите количество строк в рваном массиве: ";
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
        public void RandomFill()
        {
            for (int i = 0; i < ragged.Length; i++)
            {
                for (int j = 0; j < ragged[i].Length; j++)
                    ragged[i][j] = random.Next(-50, 50);
            }
        }
        public void ManualFill()
        {
            string? msg;

            for (int i = 0; i < ragged.Length; i++)
            {
                for (int j = 0; j < ragged[i].Length; j++)
                {
                    msg = $"Введите элемент для {i + 1}-й строки {j + 1}-го столбца: ";
                    ragged[i][j] = CheckAndInput.InputIntNumber(msg);
                }
            }
            Console.WriteLine();
        }
        public void ShowRagged()
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
        public void DeleteRows()
        {
            Console.WriteLine("\tСтроки после удаления:");

            List<int> indexRowsToDelete = new List<int>();
            for (int i = 0; i < ragged.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < ragged[i].Length; j++)
                {
                    if (ragged[i][j] == 0)
                        count++;

                    if (count == 2)
                        break;
                }
                if (count == 2)
                    indexRowsToDelete.Add(i);
            }

            if (indexRowsToDelete.Count == 0)
            {
                Console.WriteLine("Не нашлось строк для удаления!\n");
                return;
            }

            int[][] temp = new int[ragged.Length - indexRowsToDelete.Count][];
            for (int i = 0, j = 0; i < ragged.Length; i++)
            {
                if (!indexRowsToDelete.Contains(i))
                    temp[j++] = ragged[i];
            }
            ragged = temp;
        }
    }
}
