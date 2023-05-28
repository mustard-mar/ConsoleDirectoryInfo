

namespace Program
{
    class Program
    {
        private static void DrawMenu(FileSystemInfo[] items,int row,int col,int index, bool[] flags)
        {
            
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.SetCursorPosition(col, row);
            Console.SetWindowPosition(0, 0);
            Console.Write("|{0,-40}", "Name");
            if (flags[0])
            {
                Console.Write("|{0,15}", "Size");
            }
            if (flags[1])
            {
                Console.Write("|{0,20}", "Creation Time");
            }
            if (flags[2])
            {
                Console.Write("|{0,60}", "Attributes");
            }
            if (flags[3])
            {
                Console.Write("|{0,15}","Extension");
            }
            Console.Write("|\n");

            for (int i = 0; i < items.Length; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                
                Console.Write("|{0,-40}", items[i].Name.Length>40?items[i].Name.Substring(0,40): items[i].Name);

                if (flags[0])
                {

                    if ((items[i].Attributes & FileAttributes.Directory) != FileAttributes.Directory)
                        Console.Write("|{0,15}", ((FileInfo)items[i]).Length / 1024 + " Кб");
                    else Console.Write("|{0,15}",  "Directory");
                }
                if (flags[1])
                {
                    Console.Write("|{0,20}", items[i].CreationTime);
                }
                if (flags[2])
                {
                    Console.Write("|{0,60}", items[i].Attributes);
                }
                if (flags[3])
                {
                    Console.Write("|{0,15}", items[i].Extension);
                }
                Console.Write("|\n");
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.WriteLine("Press f1,f2,f3,f4 to change colums");
        }
        private static FileSystemInfo[] GetMenuItems(string path)
        {
            DirectoryInfo test = new(path);
            FileSystemInfo[] b = test.GetFileSystemInfos();
            return b;
        }
        private static bool TryGetDirectory(string path) {
            try 
            {
                DirectoryInfo test = new(path);
                var b = test.GetDirectories();
            }
            catch(UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Доступ запрещен");
                return false;
            }
            return true;
        }

        
        static void DirectoryMenu(string path)
        {
            bool[] flags = new bool[4] { false,false,false,false};
            FileSystemInfo[] menuItems = GetMenuItems(path);
            int row = Console.CursorTop;
            int col = Console.CursorLeft;
            int index = 0;
            while (true)
            {
                DrawMenu(menuItems, row, col, index,flags);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.F1:
                        flags[0] = (flags[0]==true?false:true);
                        Console.Clear();
                        break;
                    case ConsoleKey.F2:
                        flags[1] = (flags[1] == true ? false : true);
                        Console.Clear();
                        break;
                    case ConsoleKey.F3:
                        flags[2] = (flags[2] == true ? false : true);
                        Console.Clear();
                        break;
                    case ConsoleKey.F4:
                        flags[3] = (flags[3] == true ? false : true);
                        Console.Clear();
                        break;
                    

                    case ConsoleKey.DownArrow:
                        if (index < menuItems.Length - 1) index++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0) index--;
                        break;
                    case ConsoleKey.Enter:
                        if (menuItems[index].Extension != "") Console.WriteLine("Открыть можно только директорию");
                        else if (TryGetDirectory(path + "\\" + menuItems[index].Name))
                        {
                            
                            path += "\\" + menuItems[index].Name;
                            menuItems = GetMenuItems(path);
                            index = 0;
                            Console.Clear();
                        }
                        break;
                    case ConsoleKey.Escape:
                        if (path != "C:\\")
                        {
                            DirectoryInfo pathInfo = new DirectoryInfo(path);
                            path = pathInfo.Parent.FullName;
                            menuItems = GetMenuItems(path);
                            index = 0;
                            Console.Clear();
                        }
                        break;

                }
            }
        }
        static void Main(string[] args)
        {
            string path = "C:\\";
            DirectoryMenu(path);

            /*DirectoryInfo test = new(path);
            var b = test.GetFileSystemInfos();
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write("|{0,-40}|{1,30}", b[i].Name, b[i].Name);
                Console.Write("|{0,-40}|", b[i].CreationTime);
            }*/


        }
    }
}