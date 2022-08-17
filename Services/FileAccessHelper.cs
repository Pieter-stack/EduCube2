using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.Services
{
    public class FileAccessHelper
    {

        public static string GetLocalFilePath(string filename)
        {
            //helper function to get our local file 's path db related
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
        }



    }
}
