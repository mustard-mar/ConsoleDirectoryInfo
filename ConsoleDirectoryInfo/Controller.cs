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
                        data = model.ChangeF1();
                        break;
                    case ConsoleKey.F2:
                        data = model.ChangeF2();
                        break;
                    case ConsoleKey.F3:
                        data = model.ChangeF3();
                        break;
                    case ConsoleKey.F4:
                        data = model.ChangeF4();
                        break;
                    case ConsoleKey.DownArrow:
                        data = model.ChangeDownArrow();
                        break;
                    case ConsoleKey.UpArrow:
                        data = model.ChangeUpArrow();
                        break;
                    case ConsoleKey.Enter:
                        data = model.ChangeEnter();
                        break;
                    case ConsoleKey.Escape:
                        data = model.ChangeEscape();
                        break;
                    default:
                        continue;
                }
                View.printData(data.Item1,data.Item2);
            }
        }
    }
}
