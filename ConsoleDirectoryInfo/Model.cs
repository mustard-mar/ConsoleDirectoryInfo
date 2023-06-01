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
        public string path;
        

        public Model(string path)
        {
            flags =new bool[4]{ true, true, false, true };
            folder = (new DirectoryInfo(path)).GetFileSystemInfos();
            this.path = path;

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
        
        public List<string[]> GetData()
        {
            return ChangeData();
        }
    }
}
