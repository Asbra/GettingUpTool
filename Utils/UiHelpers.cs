using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GettingUpTool
{
    static class UI
    {
        public const string GithubUrl = "https://github.com/Asbra/GettingUpTool";
        public const string HelpUrl = "https://github.com/Asbra/GettingUpTool/wiki/Replacing-textures-graffiti-in-Marc-Ecko%27s-Getting-Up";

        public static void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection nodes, string[] fileExtensions, bool flat = false)
        {
            TreeNode curNode = null;
            if (flat && nodes.Count > 0)
            {
                curNode = nodes[0];
            }
            else
            {
                curNode = nodes.Add(directoryInfo.Name);
            }

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                string filext = file.Extension.ToLower();
                // if (filext == ".st" || filext == ".bir" || filext == ".dds" || filext == ".st2")
                // if (filext == ".st" || filext == ".dds")
                if (Array.IndexOf(fileExtensions, filext) > -1)
                {
                    curNode.Nodes.Add(file.FullName, file.Name);
                }
            }

            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
            {
                BuildTree(subdir, flat ? nodes : curNode.Nodes, fileExtensions, flat);
            }
        }

        private static void ClearEmptyNodes(TreeNodeCollection tv, TreeNode tn)
        {
            if (tn.Nodes.Count > 0)
            {
                for (int iNode = 0; iNode < tn.Nodes.Count; iNode++)
                {
                    ClearEmptyNodes(tv, tn.Nodes[iNode]);
                }
            }
            else if (string.IsNullOrWhiteSpace(tn.Name))
            {
                tv.Remove(tn);
            }
        }

        public static void RebuildFileTree(DirectoryInfo directoryInfo, TreeNodeCollection nodes, string[] fileExtensions, bool flat = false)
        {
            nodes.Clear();

            BuildTree(directoryInfo, nodes, fileExtensions, flat);

            if (nodes.Count > 0)
            {
                for (int i = 0; i < 30; i++)
                    ClearEmptyNodes(nodes, nodes[0]);

                // Recursively delete empty nodes
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (nodes[i].Nodes.Count == 0)
                    {
                        nodes.Remove(nodes[i]);

                        if (string.IsNullOrWhiteSpace(nodes[i].Name) || Directory.Exists(nodes[i].Name))
                        {
                            nodes.Remove(nodes[i]);
                        }
                    }
                }

                // Open the first node by default
                nodes[0].Expand();
                if (nodes[0].Nodes.Count > 0)
                    nodes[0].Nodes[0].Expand();
            }
        }
    }
}
