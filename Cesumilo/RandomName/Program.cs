using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomName
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cesumilo";
            string name, lastName;
            Console.Write("Enter your first name : ");
            name = Console.ReadLine();
            Console.Write("\nEnter your last name : ");
            lastName = Console.ReadLine();
            Console.Write("\n");

            while (Console.ReadLine() != "yes")
            {
                Console.WriteLine(RandomName(name, lastName) + "\nAre you satisfied ?");
            }
        }

        static string RandomName(string name, string lastName)
        {
            Random rand = new Random();
            int length = (name.Length + lastName.Length) - 2;
            string text = name + lastName;
            string textFinal = "";

            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine("{0}/8", i+1);
                int rando = rand.Next(0, length);

                if (i > 0 && (textFinal[i - 1] == 'a' || textFinal[i - 1] == 'o' || textFinal[i - 1] == 'e' || textFinal[i - 1] == 'i' || textFinal[i - 1] == 'u' || textFinal[i - 1] == 'y'))
                {
                    while (text[rando] == 'a' && text[rando] == 'o' && text[rando] == 'e' && text[rando] == 'i' && text[rando] == 'u' && text[rando] == 'y')
                    {
                        rando = rand.Next(0, length);
                    }
                }
                else if (i > 0 && (textFinal[i - 1] != 'a' || textFinal[i - 1] != 'o' || textFinal[i - 1] != 'e' || textFinal[i - 1] != 'i' || textFinal[i - 1] != 'u' || textFinal[i - 1] != 'y'))
                {
                    while (text[rando] != 'a' && text[rando] != 'o' && text[rando] != 'e' && text[rando] != 'i' && text[rando] != 'u' && text[rando] != 'y')
                    {
                        rando = rand.Next(0, length);
                    }
                }
                
                textFinal += text[rando];
            }

            return textFinal;
        }
    }
}
