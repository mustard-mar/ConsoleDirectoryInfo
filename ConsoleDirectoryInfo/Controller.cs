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
            View.printData(data.Item1, data.Item2);
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
                        break;
                    case ConsoleKey.UpArrow:
                        data.Item2 = model.ChangeUpArrow();
                        break;
                    case ConsoleKey.Enter:
                        data.Item1 = model.ChangeEnter();
                        break;
                    case ConsoleKey.Escape:
                        data.Item1 = model.ChangeEscape();
                        break;
                    default:
                        continue;
                }
                View.printData(data.Item1,data.Item2);
            }
        }
    }
}
