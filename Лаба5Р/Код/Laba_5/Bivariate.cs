using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
    internal class Bivariate : ArrayBase
    {
        int[,] matrix;
        public Bivariate()
        {
            int countRows = 0, countCols = 0;
            string msg = "";
            string errorMsg = "";

            msg = "Введите количество строк в матрице: ";
            errorMsg = "\nКоличество строк должно быть положительным числом!\n";
            countRows = CheckAndInput.InputPositiveNumber(msg, errorMsg);

            msg = "Введите количество столбцов в матрице: ";
            errorMsg = "\nКоличество колонок должно быть положительным числом!\n";
            countCols = CheckAndInput.InputPositiveNumber(msg, errorMsg); 

            matrix = new int[countRows, countCols];
            Console.WriteLine();
        }
        public override void RandomFill()
        {
            Random random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = random.Next(-50, 50);
            }
        }
        public override void ManualFill()
        {
            string? msg;

            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    msg = $"Введите элемент для {i + 1}-й строки {j + 1}-го столбца: ";
                    matrix[i, j] = CheckAndInput.InputIntNumber(msg);
                }
            }
        }
        public void ShowMatrix()
        {
            if (matrix.Length == 0)
            {
                Console.WriteLine("Матрица: <пустая>\n");
                return;
            }

            Console.WriteLine("----- Матрица -----");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j], -4} ");
                Console.WriteLine('\n');
            }
        }
        public void DeleteEvenRows()
        {
            int count = 0;
            if (matrix.GetLength(0) % 2 == 0)
                count = matrix.GetLength(0) / 2;
            else
                count = matrix.GetLength(0) / 2 + 1
                    ;
            int[,] tempArray = new int[count, matrix.GetLength(1)];

            for (int i = 0, z = 0; i < matrix.GetLength(0); i++)
            {
                if ((i + 1) % 2 != 0)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        tempArray[z, j] = matrix[i, j];
                    z++;
                }
            }
            matrix = tempArray;

            Console.WriteLine();
        }
    }
}
