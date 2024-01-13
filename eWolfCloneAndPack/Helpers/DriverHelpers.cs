using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWolfCloneAndPack.Helpers
{
    internal class DriverHelpers
    {
        public static bool TryGetDrive(ref string riskyDrive, string driveNameToGet)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                try
                {
                    string driveName = drives[i].VolumeLabel;
                    if (driveName == driveNameToGet)
                    {
                        riskyDrive = drives[i].Name;
                        return true;
                    }
                }
                catch
                {
                }
            }
            return false;
        }
    }
}
