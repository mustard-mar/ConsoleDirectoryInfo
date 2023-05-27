

namespace Program
{
    class Program
    {
        private static void DrawMenu(FileSystemInfo[] items,int row,int col,int index)
        {
            Console.SetCursorPosition(col, row);
            for (int i = 0; i < items.Length; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                if(((items[i].Attributes & FileAttributes.Directory) != FileAttributes.Directory)) 
                    Console.WriteLine("|{0,-40}|{1,30}|", items[i].Name, ((FileInfo)items[i]).Length / 1024 + " Кб");
                else Console.WriteLine("|{0,-40}|{1,30}|", items[i].Name, "Directory");
                Console.ResetColor();
            }
            Console.WriteLine();
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
            FileSystemInfo[] menuItems = GetMenuItems(path);
            int row = Console.CursorTop;
            int col = Console.CursorLeft;
            int index = 0;
            while (true)
            {
                DrawMenu(menuItems, row, col, index);

                switch (Console.ReadKey(true).Key)
                {
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
                Console.WriteLine(b[i].Name);
            }*/


        }
    }
}