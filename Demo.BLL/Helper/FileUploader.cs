using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Helper
{
    public static class FileUploader
    {
        public static string UploadFile(string _folderPath, IFormFile _file)
        {
            try
            {
                //    1 )  Get Directory

                string FolderPath = Directory.GetCurrentDirectory() + "/wwwroot/" + _folderPath;

                //    2)   Get File Name
                string FileName = Guid.NewGuid() + Path.GetFileName(_file.FileName);

                //    3)   Merge Path with File Name
                string FinalPath = Path.Combine(FolderPath, FileName);

                //    4)   Save File As Streams "Data Overtime"
                using (var Stream = new FileStream(FinalPath, FileMode.Create))
                {
                    _file.CopyTo(Stream);
                }

                return FileName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public static void RemoveFile(string FolderName, string FileName)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/" + FolderName + FileName))
            {
                File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/" + FolderName + FileName);
            }
        }
    }
}
