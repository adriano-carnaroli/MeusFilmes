using System;
using Xamarin.Forms;
using MeusFilmes.Droid;
using System.IO;

[assembly: Dependency(typeof(FileHelper))]
namespace MeusFilmes.Droid
{
    public class FileHelper : IFileHelper
    {
        public String GetLocalFilePath(String FileName)
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, FileName);
        }

        public FileHelper()
        {
        }
    }
}
