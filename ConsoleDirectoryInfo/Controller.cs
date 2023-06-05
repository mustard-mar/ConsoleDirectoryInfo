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
            int index = 0;
            int error = 0;
            List<string[]> data = model.GetData();
            View.PrintNewData(data);
            List<string[]> tmp = null;
            while (true)
            {

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        {
                            tmp = model.NewPath(index, out error);
                            switch (error)
                            {
                                case 0:

                                    data = tmp;
                                    View.PrintNewData(data);
                                    break;
                                case 1:
                                    View.PrintAddMess(1);
                                    break;
                                case 2:
                                    View.PrintAddMess(2);
                                    break;
                            };//здесь будет обработка

                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            tmp = model.BackNewPath();
                            if (tmp != null)
                            {
                                data = tmp;
                                View.PrintNewData(data);
                            }
                            else View.ClearAdditionalMessage();
                            break;
                        }
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                        {
                            int prev = index;
                            index--;
                            View.PrintCurRow(index,prev,0);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (index < data[0].Length-1)
                        {
                            int prev = index;
                            index++;
                            View.PrintCurRow(index,prev,+1);
                        }
                        break;
                }
            }
            //View.PrintAddMess(1);
            //View.ClearAdditionalMessage();
        }
    }
}
