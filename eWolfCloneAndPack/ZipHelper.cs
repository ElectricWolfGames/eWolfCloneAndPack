using eWolfCloneAndPack.Clone;
using eWolfCloneAndPack.Configuration;
using System.IO.Compression;

namespace eWolfCloneAndPack
{
    internal static class ZipHelper
    {
        internal static void CreateZip(CloneFolder cloneFolderDetails)
        {
            DateTime dt = DateTime.Now;
            string zipPath = @$"{GetBaseFolder(cloneFolderDetails, dt)}\{dt.Year}-{dt.Month.ToString("00")}-{dt.Day.ToString("00")} {cloneFolderDetails.Name}.zip";
            Console.WriteLine($"Starting Zipping {zipPath}");

            Directory.CreateDirectory(GetBaseFolder(cloneFolderDetails, dt));
            if (!File.Exists(zipPath))
            {
                ZipFile.CreateFromDirectory(cloneFolderDetails.From, zipPath);
            }
            else
            {
                for (int i = 1; i < Settings.MaxBackupsPerDay + 1; i++)
                {
                    zipPath = @$"{GetBaseFolder(cloneFolderDetails, dt)}\{dt.Year}-{dt.Month.ToString("00")}-{dt.Day.ToString("00")}.{i} {cloneFolderDetails.Name}.zip";
                    if (!File.Exists(zipPath))
                    {
                        ZipFile.CreateFromDirectory(cloneFolderDetails.From, zipPath);
                        return;
                    }
                }
                File.Delete(zipPath);
                ZipFile.CreateFromDirectory(cloneFolderDetails.From, zipPath);
            }
        }

        internal static void RemoveZipDups(CloneFolder cloneFolderDetails)
        {
            DateTime dt = DateTime.Now;
            string zipPath = GetBaseFolder(cloneFolderDetails, dt);
            string[] files = Directory.GetFiles(zipPath, $"*{cloneFolderDetails.Name}*", SearchOption.AllDirectories);

            Dictionary<long, List<string>> fileList = new Dictionary<long, List<string>>();

            foreach (string fileName in files)
            {
                long fileLength = new FileInfo(fileName).Length;

                List<string> currentfiles;
                if (fileList.TryGetValue(fileLength, out currentfiles))
                {
                    currentfiles.Add(fileName);
                }
                else
                {
                    fileList.Add(fileLength, new List<string>() { fileName });
                }
            }

            foreach (var kvp in fileList)
            {
                if (kvp.Value.Count > 1)
                {
                    RemoveAllButLatest(kvp.Value);
                }
            }
        }

        private static string GetBaseFolder(CloneFolder cloneFolderDetails, DateTime dt)
        {
            return @$"{Settings.ZipStore}\{cloneFolderDetails.ProjectType}\{cloneFolderDetails.Name}\{dt.Year}\";
        }

        private static void RemoveAllButLatest(List<string> files)
        {
            Dictionary<DateTime, string> storeDate = new Dictionary<DateTime, string>();

            foreach (var file in files)
            {
                DateTime fileDetailsFrom = File.GetLastWriteTime(file);
                storeDate.Add(fileDetailsFrom, file);
            }

            var ordered = storeDate.OrderByDescending(kvp => kvp.Key);
            bool kept = false;
            foreach (var filekv in ordered)
            {
                Console.WriteLine($"{filekv.Key} {filekv.Value}");
                if (!kept)
                {
                    kept = true;
                    continue;
                }
                File.Delete(filekv.Value);
            }
        }
    }
}