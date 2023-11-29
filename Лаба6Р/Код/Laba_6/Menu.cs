using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6
{
    internal static class Menu
    {
        static public void CallMenu()
        {
            bool isNonExit = true;
            int choice = 0;
            string msg = "", errorMsg = "\nТакого пункта меню не существует!\n";

            do
            {
                Console.Clear();
                Console.WriteLine("----- Добро пожаловать в МЕНЮ программы! -----\n");
                msg = "1. Удалить все строки, в которых есть не менее двух нулей.\n" +
                      "2. Удалить из строки все слова, которые начинаются и заканчиваются на один и тот же символ.\n" +
                      "3. Завершить работу программы.\n-> ";

                choice = CheckAndInput.InputIntNumber(msg);
                switch (choice)
                {
                    case 1:
                        Console.Clear(); Ragged ragged = new Ragged(); choiceFill(ragged); ragged.ShowRagged(); ragged.DeleteRows(); ragged.ShowRagged(); Console.WriteLine(); break;
                    case 2:
                        Console.Clear(); Str str = new Str(); choiceFill(str); str.ShowStr(); str.DeleteWords(); str.ShowStr(); break;
                    case 3:
                        isNonExit = false; break;
                    default:
                        Console.WriteLine(errorMsg); break;
                }

                if (isNonExit)
                {
                    Console.Write("Нажмите любую клавишу для продолжения. . .");
                    Console.ReadKey();
                }

            } while (isNonExit);
        }
        static public void choiceFill(Ragged ragged)
        {
            string msg = "\tВыберите как заполнить рваный массив\n1.Вручную\n2.Рандомно\n-> ", errorMsg = "\nТакого пункта меню не существует!\n";
            bool notExit = true;

            do
            {
                int choice = CheckAndInput.InputIntNumber(msg);

                if (choice == 1)
                {
                    Console.WriteLine();
                    ragged.ManualFill();
                    notExit = false;
                }
                else if (choice == 2)
                {
                    Console.WriteLine();
                    ragged.RandomFill();
                    notExit = false;
                }
                else
                    Console.WriteLine(errorMsg);
            } while (notExit);
        }
        static public void choiceFill(Str str)
        {
            string msg = "\tВыберите как заполнить строку\n1.Вручную\n2.Выбрать заготовленную\n-> ", errorMsg = "\nТакого пункта меню не существует!\n";
            bool notExit = true;

            do
            {
                int choice = CheckAndInput.InputIntNumber(msg);

                if (choice == 1)
                {
                    Console.WriteLine();
                    str.ManualFill();
                    notExit = false;
                }
                else if (choice == 2)
                {
                    Console.WriteLine();
                    str.PreparedLines();
                    notExit = false;
                }
                else
                    Console.WriteLine(errorMsg);
            } while (notExit);
        }
    }
}
