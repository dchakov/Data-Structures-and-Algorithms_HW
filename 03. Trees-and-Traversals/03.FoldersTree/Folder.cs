namespace _03.FoldersTree
{
    using System.Collections.Generic;

    public class Folder
    {
        private string name;

        public  Folder()
        {

        }      
        public Folder(string name)
        {
            this.name = name;
            this.Files =new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public List<File> Files { get; set; }

        public List<Folder> ChildFolders { get; set; }
    }
}
