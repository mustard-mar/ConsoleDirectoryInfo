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
            View view = new View();
            int index = 0;
            int error = 0;
            List<string[]> data = model.GetData();
            view.PrintNewData(data);
            List<string[]> tmp = null;
            ConsoleKey key;
            while (true)
            {

                switch (key=Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        {
                            tmp = model.NewPath(index, out error);
                            switch (error)
                            {
                                case 0:

                                    data = tmp;
                                    view.PrintNewData(data);
                                    index = 0;
                                    break;
                                case 1:
                                    view.PrintAddMess(1);
                                    break;
                                case 2:
                                    view.PrintAddMess(2);
                                    break;
                            };

                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            tmp = model.BackNewPath();
                            if (tmp != null)
                            {
                                data = tmp;
                                index = 0;
                                view.PrintNewData(data);
                            }
                            else view.ClearAdditionalMessage();
                            break;
                        }
                    case ConsoleKey.Q:
                        view.CloseWindow();
                        break;
                    case ConsoleKey.F1:
                    case ConsoleKey.F2:
                    case ConsoleKey.F3:
                    case ConsoleKey.F4:
                        data = model.ChangeColums(key);
                        view.PrintNewData(data);
                        break;


                    case ConsoleKey.UpArrow:
                        if (index > 0)
                        {
                            int prev = index;
                            index--;
                            view.PrintCurRow(index,prev);
                            
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (index < data[0].Length-1)
                        {
                            int prev = index;
                            index++;
                            view.PrintCurRow(index,prev);
                            
                        }
                        break;
                }
            }
        }
    }
}
