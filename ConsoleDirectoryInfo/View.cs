using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDirectoryInfo
{
    public static class View
    {
        public static void printData(List<string[]> model,int index)
        {
            Console.Clear();
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.SetCursorPosition(0, 0);

            Console.Write("|{0,-30}", "Name");
            if (model[1]!=null)
            {
                Console.Write("|{0,15}", "Size");
            }
            if (model[2] != null)
            {
                Console.Write("|{0,20}", "Creation Time");
            }
            if (model[3] != null)
            {
                Console.Write("|{0,60}", "Attributes");
            }
            if (model[4] != null)
            {
                Console.Write("|{0,15}", "Extension");
            }
            Console.Write("|\n");

            for (int i = 0; i < model[0].Length; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                for (int j = 0; j < model.Count; j++)
                {
                    if (model[j]!=null)
                        Console.Write("|{0,-30}", model[j][i].Length > 30 ? model[j][i].Substring(0, 30) : model[j][i]);
                }
                Console.Write("|\n");
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.WriteLine("Press f1,f2,f3,f4 to change colums");
        }


    }
}
