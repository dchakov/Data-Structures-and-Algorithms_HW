namespace _03.FoldersTree
{
    public class File
    {
        private string name;
        private double size;

        public File(string name, double size)
        {
            this.name = name;
            this.size = size;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public double Size
        {
            get { return this.size; }
            set { this.size = value; }
        }
    }
}
