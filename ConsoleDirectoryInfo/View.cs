using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDirectoryInfo
{
    public class View
    {
        List<string[]> prevView;
        static readonly int[] sizeColum = { -30, 15, 20, 60, 10 };
        int index = 0;
        public void PrintNewData(List<string[]>? data)
        {
            Console.ResetColor();
            Console.Clear();
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            int row = Console.CursorTop;
            int col = Console.CursorLeft;
            Console.SetCursorPosition(col, row);

            Console.Write("|{0," + sizeColum[0] +"}", "Name");
            if (data[1]!=null)
            {
                Console.Write("|{0," + sizeColum[1] +"}", "Size");
            }
            if (data[2] != null)
            {
                Console.Write("|{0," + sizeColum[2] +"}", "Creation Time");
            }
            if (data[3] != null)
            {
                Console.Write("|{0," + sizeColum[3] +"}", "Attributes");
            }
            if (data[4] != null)
            {
                Console.Write("|{0," + sizeColum[4] +"}", "Extension");
            }
            Console.Write("|\n");

            for (int i = 0; i < data[0].Length; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                for (int j = 0; j < data.Count; j++)
                {
                    if (data[j]!=null)
                        Console.Write("|{0," + sizeColum[j] +"}", 
                            data[j][i].Length > Math.Abs(sizeColum[j])?
                            data[j][i][..Math.Abs(sizeColum[j])] :
                            data[j][i]);
                }
                Console.Write("|\n");
                Console.ResetColor();
            }
            Console.WriteLine();
            //if (isMess != 0) PrintDopMess();
            Console.WriteLine("Press f1,f2,f3,f4 to change colums");
            prevView = data;
        }
        public void PrintAddMess(int isMess)
        {
            int row = prevView[0].Length + 4;
            Console.SetCursorPosition(0, row);
            if (isMess == 1)
            {

                Console.WriteLine("Невозможно открыть файл");
            }
            else if (isMess == 2)
                Console.WriteLine("Отказано в доступе");
        }
        public void PrintCurRow(int newIndex,int prevIndex)
        {
            ClearAdditionalMessage();
            Console.ResetColor();
            Console.SetCursorPosition(0, newIndex + 1);
            Console.BackgroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Black;
            for (int j = 0; j < sizeColum.Length; j++)
            {
                if (prevView[j] != null)
                    Console.Write("|{0," + sizeColum[j] + "}",
                        prevView[j][newIndex].Length > Math.Abs(sizeColum[j]) ?
                        prevView[j][newIndex][..Math.Abs(sizeColum[j])] :
                        prevView[j][newIndex]);
            }
            Console.Write("|");
            Console.ResetColor();
            Console.SetCursorPosition(0, prevIndex+1);
            for (int j = 0; j < sizeColum.Length; j++)
            {
                if (prevView[j] != null)
                    Console.Write("|{0," + sizeColum[j] + "}",
                        prevView[j][prevIndex].Length > Math.Abs(sizeColum[j]) ?
                        prevView[j][prevIndex][..Math.Abs(sizeColum[j])] :
                        prevView[j][prevIndex]);
            }
            Console.Write("|");
            Console.SetCursorPosition(0, newIndex + 1);
            Console.ResetColor();
        }
        public void ClearAdditionalMessage()
        {
            int row = prevView[0].Length + 4;
            Console.SetCursorPosition(0, row);
            Console.Write("                                            ");
        }
    }
}
