using eWolfCloneAndPack.Clone;
using eWolfCloneAndPack.Helpers;

namespace eWolfCloneAndPack
{
    internal class SyncFolders
    {
        private string _folder;
        private string _fromDrive;
        private string _fromDriveLetter;

        private string _toDrive;
        private string _toDriveLetter;

        public SyncFolders(string fromDrive, string toDrive, string folder)
        {
            _fromDrive = fromDrive;
            _toDrive = toDrive;
            _folder = folder;
        }

        internal void Sync()
        {
            if (!DrivesHelper.TryGetDrive(ref _fromDriveLetter, _fromDrive))
            {
                Console.WriteLine($"Can't find drive letter for {_fromDrive}");
                return;
            }
            if (!DrivesHelper.TryGetDrive(ref _toDriveLetter, _toDrive))
            {
                Console.WriteLine($"Can't find drive letter for {_toDrive}");
                return;
            }

            Console.WriteLine($"{_fromDriveLetter} {_fromDrive}");
            Console.WriteLine($"{_toDriveLetter} {_toDrive}");

            string folder = $"{_fromDriveLetter}{_folder}";
            string destination = $"{_toDriveLetter}{_folder}";

            Console.WriteLine($"Starting Cloning {folder} to {destination}");

            IProjectTypeDetails projectTypeUnity3D = new ProjectTypeUnity3D();

            Directory.CreateDirectory(destination);

            bool updated = SynchronizeFolders.Do(folder, destination, projectTypeUnity3D);

            int i = 0;
            i++;
        }
    }
}