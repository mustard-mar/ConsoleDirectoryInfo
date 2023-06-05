﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDirectoryInfo
{
    public static class View
    {
        public static (List<string[]>, int) prevView;
        public static int[] sizeColum = { -30, 15, 20, 60, 10 };
        public static int index = 0;
        public static bool messExists = false;

        public static void PrintNewData(List<string[]> model)//вызывать только при первом запуске, Enter, Escape 
        {

            Console.ResetColor();
            Console.Clear();
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            int row = Console.CursorTop;
            int col = Console.CursorLeft;
            Console.SetCursorPosition(col, row);

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
                if (i == 0)
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
        public static void PrintAddMess(int isMess)
        {

            //0 - нет сообщений, 1 - сообщение о попытке открытия файла, 2 - сообщение о недоступе
            
            Console.WriteLine("");
            if (isMess == 1)
            {
                Console.WriteLine("Невозможно открыть файл");
            }
            else if (isMess == 2)
                Console.WriteLine("Отказано в доступе");

        }

        public static void PrintCurRow(int newIndex,int prevIndex,int r)
        {
            Console.ResetColor();
            int row = Console.CursorTop;
            int col = Console.CursorLeft;
            Console.SetCursorPosition(0, newIndex+r);
            Console.BackgroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Black;
            for (int j = 0; j < sizeColum.Length; j++)
            {
                if (prevView.Item1[j] != null)
                    Console.Write("|{0," + sizeColum[j] + "}",
                        prevView.Item1[j][newIndex].Length > Math.Abs(sizeColum[j]) ?
                        prevView.Item1[j][newIndex].Substring(0, Math.Abs(sizeColum[j])) :
                        prevView.Item1[j][newIndex]);
            }
            Console.Write("|\n");
            Console.ResetColor();
            Console.SetCursorPosition(0, prevIndex+r);
            for (int j = 0; j < sizeColum.Length; j++)
            {
                if (prevView.Item1[j] != null)
                    Console.Write("|{0," + sizeColum[j] + "}",
                        prevView.Item1[j][prevIndex].Length > Math.Abs(sizeColum[j]) ?
                        prevView.Item1[j][prevIndex].Substring(0, Math.Abs(sizeColum[j])) :
                        prevView.Item1[j][prevIndex]);
            }
            Console.Write("|\n");
            Console.ResetColor();
        }

        public static void ClearAdditionalMessage()
        {
            int row = prevView.Item1[0].Length + 4;
            Console.SetCursorPosition(0, row);
            Console.Write("                                            ");
        }
        

    }
}
