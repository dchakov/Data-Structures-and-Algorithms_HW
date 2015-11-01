namespace _03.FoldersTree
{
    using System;
    using System.IO;

    //Define classes File { string name, int size }
    //and Folder { string name, File[] files, Folder[] childFolders }
    //and using them build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS.
    //Implement a method that calculates the sum of the file sizes in given subtree of the tree and test it accordingly.Use recursive DFS traversal.

    public class StartUp
    {
        public static void Main()
        {
            string directoryPath = "C:\\WINDOWS";

            Folder newFolder = new Folder(new DirectoryInfo(directoryPath).Name);
            TraverseDir(new DirectoryInfo(directoryPath), newFolder);

            double folderSize = TraverseSizeDir(new DirectoryInfo(directoryPath)) / (1024 * 1024);
            Console.WriteLine("Folder C files size: {0}", folderSize);

            TraverseFolder(newFolder);
        }

        private static void TraverseFolder(Folder newFolder)
        {
            try
            {
                var files = newFolder.Files;
                foreach (var file in files)
                {
                    Console.WriteLine("{0}=>{1}", file.Name, file.Size);
                }

                var children = newFolder.ChildFolders;
                foreach (var child in children)
                {
                    TraverseFolder(child);
                }
            }
            catch (Exception)
            {
            }
        }

        private static double TraverseSizeDir(DirectoryInfo directoryInfo)
        {
            double sum = 0;
            try
            {
                DirectoryInfo[] children = directoryInfo.GetDirectories();
                FileInfo[] files = directoryInfo.GetFiles();
                foreach (FileInfo file in files)
                {
                    sum += (file.Length);
                }
                foreach (DirectoryInfo child in children)
                {
                    sum += TraverseSizeDir(child);
                }
            }
            catch (Exception)
            {
            }
            return sum;
        }

        private static void TraverseDir(DirectoryInfo dir, Folder newFolder)
        {
            try
            {
                DirectoryInfo[] children = dir.GetDirectories();
                FileInfo[] files = dir.GetFiles();
                newFolder.Name = dir.FullName;
                foreach (var file in files)
                {
                    newFolder.Files.Add(new File(file.Name, file.Length));
                }
                foreach (var child in children)
                {
                    Folder folder = new Folder(child.Name);
                    TraverseDir(child, folder);
                    newFolder.ChildFolders.Add(folder);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
