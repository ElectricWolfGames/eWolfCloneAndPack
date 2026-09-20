using eWolfCloneAndPack.Configuration;
using eWolfCloneAndPack.Helpers;

namespace eWolfCloneAndPack.Clone
{
    internal class CloneFolder
    {
        public CloneFolder(string folder, string name, ProjectType projectType)
        {
            Name = name;
            Folder = folder;
            ProjectType = projectType;
        }

        public string Folder { get; set; }

        public string Name { get; set; }

        public ProjectType ProjectType { get; set; }

        internal string Destination
        {
            get
            {
                return $"{Settings.CloneStore}\\{ProjectType}\\{Name}";
            }
        }

        internal string From
        {
            get
            {
                return $"{Folder}\\{Name}";
            }
        }

        private IProjectTypeDetails ProjectTypeDetails => ProjectType switch
        {
            ProjectType.VSProject => new ProjectTypeVSProject(),
            ProjectType.Data => new ProjectTypeData(),
            _ => new ProjectTypeUnity3D(),
        };

        internal void Clone()
        {
            Console.WriteLine($"=============================================");
            Console.WriteLine($"Starting Cloning {From} to {Destination}");

            Directory.CreateDirectory(Destination);

            bool updated = SynchronizeFolders.Do(From, Destination, ProjectTypeDetails);
            Console.WriteLine($"Finished Cloning {From} to {Destination}");

            if (updated)
            {
                ZipHelper.CreateZip(this);
                ZipHelper.RemoveZipDups(this);
                DrivesHelper.TrimBackUps(this);
                DrivesHelper.CopyBackUps(this);
            }
        }

        // True if Clone() would copy or delete anything. Does not modify the backup.
        internal bool IsOutOfDate()
        {
            return SynchronizeFolders.IsOutOfDate(From, Destination, ProjectTypeDetails);
        }
    }
}