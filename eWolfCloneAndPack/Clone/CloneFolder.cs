using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWolfCloneAndPack.Clone
{
    internal class CloneFolder
    {
        public CloneFolder(string folder, string name)
        {
            Name = name;
            Folder = folder;    
        }

        internal void Clone()
        {
            //
        }

        public string Name { get; set; }
        public string Folder { get; set; }

    }
}
