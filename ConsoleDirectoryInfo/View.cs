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
        public static (List<string[]>, int) prevView;
        public static int[] sizeColum = { -30, 15, 20, 60, 15 };
        public static void printData(List<string[]> model,int index)
        {
            
            Console.Clear();
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.SetCursorPosition(0, 0);

            Console.Write("|{0," + sizeColum[0] +"}", "Name");
            if (model[1]!=null)
            {
                Console.Write("|{0," + sizeColum[1] +"}", "Size");
            }
            if (model[2] != null)
            {
                Console.Write("|{0," + sizeColum[2] +"}", "Creation Time");
            }
            if (model[3] != null)
            {
                Console.Write("|{0," + sizeColum[3] +"}", "Attributes");
            }
            if (model[4] != null)
            {
                Console.Write("|{0," + sizeColum[4] +"}", "Extension");
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
                        Console.Write("|{0," + sizeColum[j] +"}", 
                            model[j][i].Length > Math.Abs(sizeColum[j])?
                            model[j][i].Substring(0, Math.Abs(sizeColum[j])) :
                            model[j][i]);
                }
                Console.Write("|\n");
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.WriteLine("Press f1,f2,f3,f4 to change colums");
            prevView = (model, index);
        }


    }
}
