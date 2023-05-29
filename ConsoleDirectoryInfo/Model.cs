using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDirectoryInfo
{
    public class Model
    {
        public bool[] flags;
        public FileSystemInfo[] folder;
        public List<string[]> colums;
        public int index;
        public string path;
        

        public Model(string path)
        {
            flags =new bool[4]{ false, false, false, false };
            folder = (new DirectoryInfo(path)).GetFileSystemInfos();
            colums = new List<string[]>();
            this.path = path;

        }

        (List<string[]>,int) ChangeData()
        {
            colums.Clear();
            var files = folder;

            for (int i = 0; i < flags.Length+1; i++)
            {

                if (i == 0 || flags[i - 1])
                {
                    colums.Add(new string[files.Length]);

                    for (int j = 0; j < files.Length; j++)
                    {
                        colums[i][j] = SetData(i, files[j]);
                    }
                }
                else colums.Add(null);
            }
            return (colums,index);
        }
        string SetData(int param, FileSystemInfo file)
        {
            switch(param){
                case 0:
                    return file.Name;
                case 1:
                    return  ((file.Attributes & FileAttributes.Directory) != FileAttributes.Directory)?
                       ((FileInfo)file).Length / 1024 + " Кб":"Directory";
                case 2:
                    return file.CreationTime.ToString();
                case 3:
                    return file.Attributes.ToString();
                case 4:
                    return file.Extension.ToString();
            }
            return "Error";
        }
        
        public void NewPathModel(string path)
        {
            folder = (new DirectoryInfo(path)).GetFileSystemInfos();
            this.path = path;
        }
        public (List<string[]>, int) GetData()
        {
            return ChangeData();
        }
        public (List<string[]>, int) ChangeF1()
        {
            flags[0] = !flags[0];
            return ChangeData();
        }
        public (List<string[]>, int) ChangeF2()
        {
            flags[1] = !flags[1];
            return ChangeData();
        }
        public (List<string[]>, int) ChangeF3()
        {
            flags[2] = !flags[2];
            return ChangeData();
        }
        public (List<string[]>, int) ChangeF4()
        {
            flags[3] = !flags[3];
            return ChangeData();
        }
        public (List<string[]>, int) ChangeUpArrow()
        {
            if (index > 0) index--;
            return ChangeData();
        }
        public (List<string[]>, int) ChangeDownArrow()
        {
            if (index < folder.Length - 1) index++;
            return ChangeData();
        }
        public (List<string[]>, int) ChangeEnter()
        {
            path += "\\" + folder[index].Name;
            NewPathModel(path);
            index = 0;
            return ChangeData();
        }
        public (List<string[]>, int) ChangeEscape()
        {
            if (path != "C:\\")
            {
                DirectoryInfo pathInfo = new DirectoryInfo(path);
                path = pathInfo.Parent.FullName;
                NewPathModel(path);
                index = 0;
            }
            return ChangeData();
        }
    }
}
