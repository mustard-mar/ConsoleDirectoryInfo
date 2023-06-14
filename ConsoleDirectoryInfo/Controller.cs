
namespace ConsoleDirectoryInfo
{
    public class Controller
    {
        private Model model;
        private View view;

        public Controller()
        {
            model = new("C:\\");
            view = new View();
            int index = 0;
            List<string[]> data = model.GetData();
            view.PrintNewData(data);
            List<string[]> tmp;
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        {
                            tmp = model.NewPath(index, out int error);
                            switch (error)
                            {
                                case 0:
                                    data = tmp;
                                    view.PrintNewData(data);
                                    index = 0;
                                    break;
                                case 1:
                                case 2:
                                    view.PrintAddMess(error);
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
                        Environment.Exit(0);
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
                        if (index < data[0].Length - 1)
                        {
                            int prev = index;
                            index++;
                            view.PrintCurRow(index,prev);  
                        }
                        break;
                    default:
                        continue;
                }
                
            }
        }
    }
}
