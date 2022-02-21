using eWolfCloneAndPack.Clone;

namespace eWolfCloneAndPack
{
    internal static class DrivesHelper
    {
        private static List<string> _backUpDrives = new List<string>() { "RiskyStore" };

        internal static void CopyBackUps(CloneFolder cloneFolder)
        {
            List<string> drivesLetters = GetUsableDrives();

            foreach (var letter in drivesLetters)
            {
                ZipHelper.CopyZips(cloneFolder, letter);
            }
        }

        internal static void GetDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            Console.WriteLine("Detected Drives: ");
            for (int i = 0; i < drives.Length; i++)
            {
                try
                {
                    Console.WriteLine($"Drive {i} {drives[i].Name} {drives[i].VolumeLabel}");
                }
                catch { }
            }

            // return drives;
        }

        private static List<string> GetUsableDrives()
        {
            List<string> drivesLetters = new List<string>();
            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                try
                {
                    string driveName = drives[i].VolumeLabel;
                    if (_backUpDrives.Contains(driveName))
                    {
                        drivesLetters.Add(drives[i].Name);
                    }
                }
                catch { }
            }

            return drivesLetters;
        }
    }
}