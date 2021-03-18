using System;
using System.IO;

namespace Database.Controller
{
    public class RouteManager
    {
        private readonly string _appPath;
        private readonly static string _images = "Images";
        private readonly static string _temp = "TempFiles";

        public RouteManager(string appPath)
        {
            _appPath = appPath;
        }

        #region PDF Manager

        private string CreateTemporaryRoute
        {
            get { return Path.Combine(_appPath, _temp); }
        }

        public Tuple<string, bool> RemoveTemporaryFile(string fileName)
        {
            var result = "";
            var excecution = false;

            var combinedTempPath = Path.Combine(CreateTemporaryRoute, fileName);
            var fileInfo = new FileInfo(combinedTempPath);
            try
            {
                if (fileInfo.Exists)
                {
                    using (var fileStream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        fileStream.Close();
                        fileInfo.Delete();
                    }
                }
            }
            catch (IOException iException)
            {
                if (iException.HResult.ToString() != "-2147024894")
                {
                    result = "The cards PDF must be closed before this app closes";
                    excecution = false;
                }
            }

            return Tuple.Create(result, excecution);
        }

        public bool CheckIfOpen(string fileName)
        {
            bool isOpen = false;
            var temporaryRoute = Path.Combine(CreateTemporaryRoute, fileName);
            var fileInfo = new FileInfo(temporaryRoute);

            try
            {
                if (fileInfo.Exists)
                {
                    using (var fileStream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        fileStream.Close();
                    }
                }
            }
            catch (IOException)
            {
                isOpen = true;
            }

            return isOpen;
        }

        #endregion PDF Manager

        #region Image manager

        public string GenerateImageRoute
        {
            get { return Path.Combine(_appPath, _images); }
        }

        public void CreateImageStorage()
        {
            if (!Directory.Exists(GenerateImageRoute))
            {
                Directory.CreateDirectory(GenerateImageRoute);
            }
        }

        public void CreateImageStoragePerEmployee(string employeeNo)
        {
            CreateImageStorage();
            string route = Path.Combine(GenerateImageRoute, employeeNo);

            if (!Directory.Exists(route))
            {
                Directory.CreateDirectory(route);
            }
        }

        #endregion Image manager
    }
}