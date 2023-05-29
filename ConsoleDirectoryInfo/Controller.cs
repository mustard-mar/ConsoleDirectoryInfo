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
            while(true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.F1:
                        model.ChangeF1();
                        break;
                    case ConsoleKey.F2:
                        model.ChangeF2();
                        break;
                    case ConsoleKey.F3:
                        model.ChangeF3();
                        break;
                    case ConsoleKey.F4:
                        model.ChangeF4();
                        break;


                    case ConsoleKey.DownArrow:
                        model.ChangeDownArrow();
                        break;
                    case ConsoleKey.UpArrow:
                        model.ChangeUpArrow();
                        break;
                    case ConsoleKey.Enter:
                        model.ChangeEnter();
                        break;
                    case ConsoleKey.Escape:
                        model.ChangeEscape();
                        break;
                    default:
                        continue;
                    
                }
                Console.Clear();
                View.printData(model);
            }

        }
    }
}
