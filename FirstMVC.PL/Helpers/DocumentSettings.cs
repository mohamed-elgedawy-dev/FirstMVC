using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using static System.Net.WebRequestMethods;

namespace FirstMVC.PL.Helpers
{
    public static class DocumentSettings
    {


        public static string UploadFile(IFormFile file , string folderName)
        {



            //string folderPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\files\\{folderName}";


            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);

            string fileName =  $"{Guid.NewGuid()}{file.FileName}" ;


            string filePath=Path.Combine(folderPath, fileName);


            using var fileStream = new FileStream(filePath, FileMode.Create);

            file.CopyTo(fileStream);

            return fileName;
        }



    }
}
