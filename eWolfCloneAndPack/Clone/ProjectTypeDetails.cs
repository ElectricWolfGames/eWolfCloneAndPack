namespace eWolfCloneAndPack.Clone
{
    internal class ProjectTypeUnity3D : IProjectTypeDetails
    {
        private List<string> _excludedFolders = new List<string>();

        public ProjectTypeUnity3D()
        {
            _excludedFolders.Add(@"\Library\");
            _excludedFolders.Add(@"\Logs\");
            _excludedFolders.Add(@"\Temp\");

            _excludedFolders.Add(@"\bin\Debug\");
            _excludedFolders.Add(@"\obj\");
            _excludedFolders.Add(@"\.vs\");
            _excludedFolders.Add(@"\.svn\");
        }

        public List<string> GetExcludedFolders
        {
            get
            {
                return _excludedFolders;
            }
        }
    }

    internal class ProjectTypeVSProject : IProjectTypeDetails
    {
        private List<string> _excludedFolders = new List<string>
        {
            @"\bin\",
            @"\obj\",
            @"\.vs\",
            @"\.svn\",
        };

        public List<string> GetExcludedFolders => _excludedFolders;
    }

    internal class ProjectTypeData : IProjectTypeDetails
    {
        public List<string> GetExcludedFolders => new List<string>();
    }
}