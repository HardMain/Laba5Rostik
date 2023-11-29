using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laba_6
{
    internal class Str
    {
        string? str;
        public Str() 
        {
            str = null;
        }
        public Str(string str)
        {
            this.str = str;
        }
        public void ManualFill()
        {
            Console.WriteLine("\tВведите строку");
            str = Console.ReadLine();
            Console.WriteLine();
        }
        public void PreparedLines()
        {
            string str1 = "gkeog mqlk g;gig adw; gkdi dja, gj,g oqt gotg.";
            string str2 = "gkr ggg wirg wotkdow vmdn a;ptkw fg,dj qwtt qritwq.";
            string str3 = "tigkawg,wp gjrw sq[wa gitkv fqwit fksaw fj;gr,aj.";

            string msg = $"\tВыберите строку из заготовленных\n1. {str1}\n\n2. {str2}\n\n3. {str3}\n\n-> ", errorMsg = "\nТакого пункта меню не существует!\n";
            bool notExit = true;
            
            do
            {
                int choice = CheckAndInput.InputIntNumber(msg);

                if (choice == 1)
                {
                    Console.WriteLine();
                    str = str1;
                    notExit = false;
                }
                else if (choice == 2)
                {
                    Console.WriteLine();
                    str = str2;
                    notExit = false;
                }
                else if (choice == 3)
                {
                    Console.WriteLine();
                    str = str3;
                    notExit = false;
                }
                else
                    Console.WriteLine(errorMsg);
            } while (notExit);
        }
        public void ShowStr()
        {
            Console.WriteLine("----- Строка -----");

            if (str == null || str.Length == 0)
            {
                Console.WriteLine("Пустая строка!\n");
                return;
            }    

            Console.WriteLine(str + '\n');
        }
        public void DeleteWords()
        {   
            if (str == null || str.Length == 0)
            {
                Console.WriteLine("Нет слов для удаления!");
                return;
            }

            string tempStr = "";
            int numberWord = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int firstLetter = -1;
                if (char.IsLetter(str[i]))
                {
                    firstLetter = i;
                    int lastLetter = -1;

                    int j = i + 1;
                    for (; j < str.Length; j++)
                    {
                        if (!char.IsLetter(str[j]))
                            break;

                        lastLetter = j;
                    }

                    if (lastLetter != -1 && (str[firstLetter] != str[lastLetter]))
                    {
                        for (int z = firstLetter; z <= lastLetter; z++)
                            tempStr += str[z];
                    }
                    else if (lastLetter == -1)
                        tempStr += str[firstLetter];

                    i = j - 1;
                }
                else
                    tempStr += str[i];
            }
            str = tempStr;
        }
    }
}
