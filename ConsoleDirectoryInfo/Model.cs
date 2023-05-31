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
        public int index = 0;
        public string path;
        

        public Model(string path)
        {
            flags =new bool[4]{ true, true, true, true };
            folder = (new DirectoryInfo(path)).GetFileSystemInfos();
            this.path = path;

        }

        int ChangeIndex()
        {
            return index;
        }

        List<string[]> ChangeData(int isMess=0)
        {
            List<string[]> colums = new List<string[]>();
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
            return colums;
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
        public (List<string[]>,int) GetData()
        {
            return (ChangeData(),ChangeIndex());
        }
        public List<string[]> ChangeF1()
        {
            flags[0] = !flags[0];
            return ChangeData();
        }
        public List<string[]> ChangeF2()
        {
            flags[1] = !flags[1];
            return ChangeData();
        }
        public List<string[]> ChangeF3()
        {
            flags[2] = !flags[2];
            return ChangeData();
        }
        public List<string[]> ChangeF4()
        {
            flags[3] = !flags[3];
            return ChangeData();
        }
        public int ChangeUpArrow()
        {
            if (index > 0) index--;
            return ChangeIndex();
        }
        public int ChangeDownArrow()
        {
            if (index < folder.Length - 1) index++;
            return ChangeIndex();
        }
        public (List<string[]>,int,int) ChangeEnter()
        {
            int mess = 0;
            List<string[]> data = null;
            if (folder[index].Extension != "") mess = 1;
            else if (TryGetDirectory(path + "\\" + folder[index].Name))
            {
                    path += "\\" + folder[index].Name;
                    NewPathModel(path);
                    index = 0;
                    data = ChangeData();
            }
            else mess = 2;
            return (data, mess,index);
        }
        public (List<string[]>,int) ChangeEscape()
        {
            List<string[]> data = null;
            if (path != "C:\\")
            {
                DirectoryInfo pathInfo = new DirectoryInfo(path);
                path = pathInfo.Parent.FullName;
                NewPathModel(path);
                data = ChangeData();
            }
            else data = null;
            index = 0;
            return (data,index);
        }
        private static bool TryGetDirectory(string path)
        {
            try
            {
                DirectoryInfo test = new(path);
                var b = test.GetDirectories();
            }
            catch (UnauthorizedAccessException ex)
            {
                return false;
            }
            return true;
        }
    }
}
