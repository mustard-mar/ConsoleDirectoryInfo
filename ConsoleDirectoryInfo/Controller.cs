using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDirectoryInfo
{
    public class Controller
    {


        public Controller()
        {
            Model model = new("C:\\");
            (List<string[]>, int) data = model.GetData();
            int isDopMess = 0;//0 - нет сообщений, 1 - сообщение о попытке открытия файла, 2 - сообщение о недоступе
            View.PrintData(data.Item1, data.Item2);
            
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.F1:
                        data.Item1 = model.ChangeF1();
                        break;
                    case ConsoleKey.F2:
                        data.Item1 = model.ChangeF2();
                        break;
                    case ConsoleKey.F3:
                        data.Item1 = model.ChangeF3();
                        break;
                    case ConsoleKey.F4:
                        data.Item1 = model.ChangeF4();
                        break;
                    case ConsoleKey.DownArrow:
                        data.Item2 = model.ChangeDownArrow();
                        View.UpdateItemMenu(data.Item2);
                        break;
                    case ConsoleKey.UpArrow:
                        data.Item2 = model.ChangeUpArrow();
                        View.UpdateItemMenu(data.Item2);
                        break;
                    case ConsoleKey.Enter:
                        (data.Item1,isDopMess,data.Item2) = model.ChangeEnter();
                        if (data.Item1 != null) View.PrintData(data.Item1, data.Item2);
                        else View.PrintDopMess(isDopMess);
                        break;
                    case ConsoleKey.Escape:
                        (data.Item1,data.Item2) = model.ChangeEscape();
                        if (data.Item1 != null) View.PrintData(data.Item1,data.Item2);
                        break;
                    default:
                        continue;
                }
                
            }
        }
    }
}
