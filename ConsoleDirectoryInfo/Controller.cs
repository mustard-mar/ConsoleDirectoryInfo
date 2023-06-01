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
            List<string[]> data = model.GetData();
            View.PrintNewData(data);
        }
    }
}
