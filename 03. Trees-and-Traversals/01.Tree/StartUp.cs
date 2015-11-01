namespace _01.Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("Input is in the input.txt");
            int N = int.Parse(Console.ReadLine());
            var nodes = new Node<int>[N];

            for (int i = 0; i < N; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 1; i <= N - 1; i++)
            {
                string edgeAsString = Console.ReadLine();
                var edgeParts = edgeAsString.Split(' ');

                int parentId = int.Parse(edgeParts[0]);
                int childId = int.Parse(edgeParts[1]);

                nodes[parentId].Children.Add(nodes[childId]);
                nodes[childId].HasParent = true;
            }

            // 1.Find the root
            var root = FindRoot(nodes);
            Console.WriteLine("The root is: {0}", root.Value);

            // 2.Find the leafs
            var leafs = FindAllLeafs(nodes);
            var rezult = new List<int>();
            foreach (var leaf in leafs)
            {
                rezult.Add(leaf.Value);
            }
            Console.WriteLine("Leafs: {0}", string.Join(", ", rezult));

            // 3.Find all middle nodes
            var middleNodes = FindAllMiddleNodes(nodes);
            var middle = new List<int>();
            foreach (var node in middleNodes)
            {
                middle.Add(node.Value);
            }
            Console.WriteLine("Middle nodes: {0}", string.Join(", ", middle));

            // 4.Find longest path from root
            var longestPath = FindLongestPath(FindRoot(nodes));
            Console.WriteLine("Longest path from the root: {0}", longestPath);

            // 5.All paths with given sum S.
            var treePaths = new List<List<int>>();
            var currentTreePath = new List<int>();
            currentTreePath.Add(root.Value);
            DFSFindPaths(treePaths, root, currentTreePath);
            Console.WriteLine("Print all paths and Sum");
            foreach (var item in treePaths)
            {
                Console.WriteLine("All paths : {0} SUM => {1}",
                    string.Join(", ", item),
                    item.Sum());
            }

            // 6. All subtrees with given sum `S` of their nodes
            Console.WriteLine("Sum of all subtrees:");
            List<Node<int>> subTrees = new List<Node<int>>();
            subTrees.Add(root);
            FindSubTrees(subTrees, root);

            foreach (var node in subTrees)
            {
                List<int> sum = new List<int>();
                SumElements(node, sum);
                Console.WriteLine(sum.Sum());
            }
        }

        private static void SumElements(Node<int> node, List<int> sum)
        {
            sum.Add(node.Value);
            foreach (var child in node.Children)
            {
                SumElements(child, sum);
            }
        }

        private static void FindSubTrees(List<Node<int>> subTrees, Node<int> root)
        {
            foreach (var child in root.Children)
            {
                if (child.Children.Count > 0)
                {
                    subTrees.Add(child);
                }
                FindSubTrees(subTrees, child);
            }
        }
                
        private static void DFSFindPaths(List<List<int>> treePaths, Node<int> root, List<int> currentTreePath)
        {
            foreach (var child in root.Children)
            {
                currentTreePath.Add(child.Value);
                if (child.Children.Count == 0)
                {
                    treePaths.Add(currentTreePath.GetRange(0, currentTreePath.Count));
                }
                DFSFindPaths(treePaths, child, currentTreePath);
                currentTreePath.RemoveAt(currentTreePath.Count - 1);
            }
        }

        private static int FindLongestPath(Node<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;
            foreach (var node in root.Children)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(node));
            }

            return maxPath + 1;
        }

        private static List<Node<int>> FindAllMiddleNodes(Node<int>[] nodes)
        {
            List<Node<int>> middleNodes = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.HasParent && node.Children.Count > 0)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        private static List<Node<int>> FindAllLeafs(Node<int>[] nodes)
        {
            List<Node<int>> leafs = new List<Node<int>>();
            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }

        public static Node<int> FindRoot(Node<int>[] nodes)
        {
            var hasParent = new bool[nodes.Length];

            foreach (var node in nodes)
            {
                foreach (var child in node.Children)
                {
                    hasParent[child.Value] = true;
                }
            }

            for (int i = 0; i < hasParent.Length; i++)
            {
                if (!hasParent[i])
                {
                    return nodes[i];
                }
            }

            throw new ArgumentException("nodes", "The tree has no root");
        }
    }
}
