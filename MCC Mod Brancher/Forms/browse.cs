using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using DarkUI.Forms;
using DarkUI.Controls;
using System.Text.RegularExpressions;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;

namespace MCC_Mod_Brancher
{
    public partial class browse : DarkForm
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName(
                 [MarshalAs(UnmanagedType.LPTStr)]
                   string path,
                 [MarshalAs(UnmanagedType.LPTStr)]
                   StringBuilder shortPath,
                 int shortPathLength
                 );

        public String source { get; set; }
        public String branch { get; set; }
        private static string __source;
        private static string __branch;
        bool debug = false;

        static string home = Directory.GetCurrentDirectory() + "\\";
        bool treeLoading = false;

        List<_File> _files = new List<_File>();
        class _File
        {
            public string Name { get; set; }
            public string Path { get; set; }
            public string LastModified { get; set; }
            public int Size { get; set; }
            public int Icon { get; set; }
            public bool Symlink { get; set; }
            public string AbsolutePath { get { return home + "branches\\" + __source + "\\" + Path; } }
        }

        List<_tmpFile> _tmpfiles = new List<_tmpFile>();
        class _tmpFile
        {
            public string Name { get; set; }
            public string Date { get; set; }
            public string path { get; set; }
            public string absPath { get; set; }
        }

        string sourcePath;
        string branchPath;

        public browse()
        {
            InitializeComponent();
            // source = "haloreach";
            // branch = "test1";
            icons_files.Images.Add(Properties.Resources.zip);
            icons_files.Images.Add(Properties.Resources.doc);
            icons_files.Images.Add(Properties.Resources.prop);
            icons_tree.Images.Add(Properties.Resources.folder);
            icons_tree.Images.Add(Properties.Resources.folder_open);
            tree.SelectedImageIndex = 1;
            if (Directory.Exists(home + "logs")) debug = true;
        }

        public static String ts(DateTime value, bool ms = false)
        {
            return value.ToString("yyyy.MM.dd_HH.mm.ss" + (ms == true ? ".ffff" : ""));
        }

        private void cmd(string cmd = "dir", bool elevate = false, bool wait = false)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.FileName = @"powershell.exe";
            p.StartInfo.Arguments = "-Command \"Start-Process cmd -ArgumentList '/c cd /d " + home
                                                              + ".. && " + cmd + "'" + (elevate ? " -verb runas" : "") + " -WindowStyle hidden -Wait\"";
            p.StartInfo.WorkingDirectory = home + "../";
            p.StartInfo.Verb = "runas";
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            if (wait) p.WaitForExit();
        }

        string modpath(TreeNode node, string cache = "")
        {
            cache = node.Text + "\\" + cache;
            if (node.Parent != null)
            {
                return modpath(node.Parent, cache);
            }
            return home + "branches\\" + source + "\\" + cache.TrimEnd('\\');
        }
        void loadTree(string path)
        {
            treeLoading = true;
            tree.Nodes.Clear();

            var stack = new Stack<TreeNode>();
            var rootDirectory = new DirectoryInfo(path);
            var node = new TreeNode(rootDirectory.Name) { Tag = rootDirectory };
            stack.Push(node);
            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                var directoryInfo = (DirectoryInfo)currentNode.Tag;
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    var childDirectoryNode = new TreeNode(directory.Name) { Tag = directory };
                    childDirectoryNode.ToolTipText = directory.FullName.Replace(home + "branches\\" + source + "\\", "");
                    currentNode.Nodes.Add(childDirectoryNode);
                    stack.Push(childDirectoryNode);
                }
            }

            tree.Nodes.Add(node);
            tree.ExpandAll();
            treeLoading = false;
            tree.SelectedNode = tree.Nodes[0];
        }
        List<_File> emptyFileList = new List<_File>();

        List<_File> loadFiles()
        {
            _files.Clear();
            DirectoryInfo d = new DirectoryInfo(home + "branches\\" + source + "\\" + branch);
            FileInfo[] Files = d.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (FileInfo file in Files)
            {
                _File add = new _File
                {
                    Name = file.Name,
                    Path = file.FullName.Replace(home + "branches\\" + source + "\\", "").Replace("\\" + file.Name, ""),
                    Size = (int)(file.Length / 1024),
                    LastModified = ts(file.LastWriteTime, true),
                    Icon = 0,
                    Symlink = file.Attributes.HasFlag(FileAttributes.ReparsePoint)
                };
                //Console.WriteLine("\n\n" + add.Name + ", \n" + add.Path + ", \n" + add.AbsolutePath+"\n\n");
                if (add.Name.EndsWith(".xml") || add.Name.EndsWith(".json") || add.Name.EndsWith(".txt") || add.Name.EndsWith(".log")) add.Icon = 1;
                else if (add.Name.EndsWith(".map") || add.Name.EndsWith(".mapinfo") || add.Name.EndsWith(".blf") || add.Name.EndsWith(".campaign") || add.Name.EndsWith(".asmp")) add.Icon = 2;
                _files.Add(add);
            }

            return _files;
        }
        void displayFiles(TreeNode node, string selectfile="")
        {
            status.Text = "Loading files (might be slow for folders with lots of files)";
            files.Nodes.Clear();
            files.SuspendLayout();

            List<_File> Files = new List<_File>(_files);

            string dirPath = modpath(node);
            string path = dirPath.Replace(home + "branches\\" + source + "\\", "");
            List<TreeNode> range = new List<TreeNode>();

            if (search.Text == "search..." || search.Text == "")
                Files = Files.Where(l => (l.Path == path)).ToList();
            else
                Files = Files.Where(l => (l.Name.ToLower().Contains(search.Text.ToLower()))).ToList();

            if (filter_mod.Checked == true) Files = Files.OrderBy(o => o.LastModified).ToList();
            try
            {
                if (filter.Text != "filter..." && filter.Text.Length != 0)
                    Files = Files.Where(o => (new Regex(filter.Text.Replace("\\", @"\\"), RegexOptions.IgnoreCase)).IsMatch(o.Name)).ToList();
                filter.ForeColor = Color.LightGray;
            }
            catch
            {
                filter.ForeColor = Color.Red;
            }

            foreach (_File f in Files)
            {
                if (filter_onlyMod.Checked == true && f.Symlink == true) continue;
                TreeNode itm = new TreeNode(f.Name);
                itm.ImageIndex = itm.SelectedImageIndex = f.Icon;
                itm.Tag = f.Symlink.ToString();
                itm.Checked = f.Symlink;
                itm.ToolTipText = (f.Size > 1024 ? f.Size / 1024 + " mb>" : f.Size + " kb>") + f.LastModified +  ">"  + f.Path;
                range.Add(itm);
            }

            files.Nodes.AddRange(range.ToArray());
            //files.VScrollTo(0);
            if (files.Nodes.Count > 0) files.SelectedNode = files.Nodes[0];
            files.Refresh();
            files.ResumeLayout();
            status.Text = "";

        }
        void reDisplayFiles()
        {
            string name = "";
            if (files.SelectedNode != null) name = files.SelectedNode.Text;
            displayFiles(tree.SelectedNode);
            var match = files.Nodes.Cast<TreeNode>().Where(r => r.Text == name);
            if (match.Count() > 0) files.SelectedNode = match.First();
        }
        void refreshFiles()
        {
            loadFiles();
            reDisplayFiles();
        }
        void startup()
        {
            loadFiles();
            loadTmpFiles();
            loadTree(branchPath);
        }
        List<_tmpFile> loadTmpFiles()
        {
            if (!Directory.Exists(home + "branches\\temp")) Directory.CreateDirectory(home + "\\branches\\temp");
            if (!Directory.Exists(home + "branches\\temp\\" + source)) Directory.CreateDirectory(home + "branches\\temp\\" + source);
            if (!Directory.Exists(home + "branches\\temp\\" + source + "\\" + branch))
            {
                status.Text = "Preparing first load...";
                Directory.CreateDirectory(home + "branches\\temp\\" + source + "\\" + branch);

                string logfile = debug ? " >>logs/" + ts(DateTime.Now) + ".txt" : "";
                cmd("cd mods && echo Clone folder structure " + branch + logfile
                 + " && xcopy \\\"branches\\" + source + "\\" + branch + "\\\" \\\"branches\\temp\\" + source + "\\" + branch + "\\\" /T /E /I /Y" + logfile
                , false, true);
                status.Text = "";
            }
            _tmpfiles.Clear();
            DirectoryInfo d = new DirectoryInfo(home + "branches\\temp\\" + source + "\\" + branch);
            FileInfo[] Files = d.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (var F in Files)
            {
                var file = F.Name.Split('.');
                var date = F.Name.Replace(file[0] + "." + file[1] + ".", "");

                var dest = F.FullName.Replace("branches\\temp\\", "").Replace(home,"").Replace("."+date,"");
                var filename = dest.Split('\\').Last();
                var path = dest.Replace("\\" + filename,"");

                _tmpfiles.Add(new _tmpFile
                {
                    Date = date,
                    Name = filename,
                    path = path,
                    absPath = F.FullName
                });
            }
            return _tmpfiles;
        }
        private void explore_Load(object sender, EventArgs e)
        {
            __source = source;
            __branch = branch;
            sourcePath = home + "branches\\" + source;
            branchPath = sourcePath + "\\" + branch;
            startup();
            this.ActiveControl = tree;
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeLoading == false && (search.Text == "search..." || search.Text == "")) displayFiles(e.Node);
        }

        private void filter_onlyMod_CheckedChanged(object sender, EventArgs e)
        {
            reDisplayFiles();
            this.ActiveControl = files;
        }

        private void filter_Leave(object sender, EventArgs e)
        {
            if (filter.Text == "")
            {
                filter.Text = "filter...";
                filter.ForeColor = Color.Gray;
            }
        }

        private void filter_MouseDown(object sender, MouseEventArgs e)
        {
            if (filter.Text == "filter...")
            {
                filter.Text = "";
                filter.ForeColor = Color.LightGray;
            }
        }
        private void filterTimeout_Tick(object sender, EventArgs e)
        {
            reDisplayFiles();
            filterTimeout.Enabled = false;
            filterTimeout.Stop();
        }


        private void filter_KeyUp(object sender, KeyEventArgs e)
        {
            filterTimeout.Stop();
            filterTimeout.Enabled = true;
        }

        private void files_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                files.SelectedNode = files.GetNodeAt(e.X, e.Y);
                bool noSel = files.SelectedNode == null;

                if ((!File.Exists(Properties.Settings.Default.assemblyPath) || noSel ||
                            (!noSel && files.SelectedNode.ImageIndex != 2))) editInAssemblyToolStripMenuItem.Visible = false;

                if ((!File.Exists(Properties.Settings.Default.zetaPath) || noSel ||
                            (!noSel && files.SelectedNode.ImageIndex != 2))) editInZetaToolStripMenuItem.Visible = false;

                //if (( noSel || (!noSel && files.SelectedNode.ImageIndex != 1))) editInTextEditorToolStripMenuItem.Visible = false;

                
                if ((!noSel && files.SelectedNode.Checked) || noSel) tempBackupToolStripMenuItem.Visible = false;
                if ((!noSel && files.SelectedNode.Checked) || noSel) restoreFromOriginalToolStripMenuItem.Visible = false;
                if (noSel || (!noSel && files.SelectedNode.ImageIndex != 1)) editInTextEditorToolStripMenuItem.Visible = false;

                restoreFromBackupToolStripMenuItem.Visible = false;
                clearToolStripMenuItem.Visible = false;

                if (!noSel)
                {
                    string path = modpath(tree.SelectedNode).Replace(home + "branches\\", "");

                    var match = _tmpfiles.Where(x => x.path == path && x.Name == files.SelectedNode.Text).Reverse();
                    if (match.Count() > 0)
                    {
                        restoreFromBackupToolStripMenuItem.DropDownItems.Clear();
                        restoreFromBackupToolStripMenuItem.Visible = true;
                        clearToolStripMenuItem.Visible = true;
                        foreach (var f in match)
                        {
                            ToolStripMenuItem itm = new ToolStripMenuItem();
                            itm.Text = f.Date;
                            itm.Click += restoreMenu_Click;

                            restoreFromBackupToolStripMenuItem.DropDownItems.Add(itm);
                        }
                    }
                }
                ctx.Show(files, e.Location);
            }
        }
        private void ctx_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            editInAssemblyToolStripMenuItem.Visible = true;
            editInZetaToolStripMenuItem.Visible = true;
            tempBackupToolStripMenuItem.Visible = true;
            editInTextEditorToolStripMenuItem.Visible = true;
            restoreFromBackupToolStripMenuItem.Visible = true;
            restoreFromOriginalToolStripMenuItem.Visible = true;
        }

        void cloneFromOriginals(TreeNode node)
        {
            string tar = (modpath(tree.SelectedNode) + "\\" + node.Text).Replace(home, "");
            string src = "originals\\" + tar.Replace("branches\\", "").Replace(branch + "\\", "");


            string logfile = debug ? ">>\"logs/" + ts(DateTime.Now) + ".txt\"" : "";
            string cmds = "cd mods && echo Starting file replace operation" + logfile
                                    + " && del /Q \"" + tar + "\"" + logfile
                                    + " && echo.>\"" + tar + "\""
                                    + " && xcopy  \"" + src + "\"  \"" + tar + "\"  /H /Y" + logfile;

            cmd(cmds, false, true);
            refreshFiles();
        }

        private void files_DragDrop(object sender, DragEventArgs e)
        {
            status.Text = "Validating & moving files...";
            // String array of input paths
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // Get path prefix (folders etc)
            string prefix = "";
            if (s.Length == 1) prefix = Regex.Replace(s[0], s[0].Split('\\').Last() + "$", "");
            if (s.Length > 1) prefix = new string(s.First().Substring(0, s.Min(n => n.Length)).TakeWhile((c, i) => s.All(n => n[i] == c)).ToArray());
            
            // Setup workflow
            List<string> transfer_folders = new List<string>();
            List<string> transfer_files = new List<string>();
            List<string> transfer_files_valid = new List<string>();

            string logfile = debug ? " >>logs/" + ts(DateTime.Now) + ".txt" : "";
            string outputBatch = "@echo off\ncd /d \"" + home + "\"\necho Starting dragdrop operation" + logfile + "\n\n";

            // Gets folders and inital files
            foreach (var pth in s)
            {
                FileAttributes attr = File.GetAttributes(pth);
                if (attr.HasFlag(FileAttributes.Directory))
                    transfer_folders.Add(pth);
                else
                    transfer_files.Add(pth);
            }
            
            // Get all files in folders
            foreach (var pth in transfer_folders)
            {
                DirectoryInfo d = new DirectoryInfo(pth);
                FileInfo[] Files = d.GetFiles("*.*", SearchOption.AllDirectories);
                foreach (var file in Files)
                {
                    transfer_files.Add(file.FullName);
                }
            }
            
            // Check if valid ifso, then add to batch script, add to valid files list
            foreach(var pth in transfer_files)
            {
                var rootPath = pth.Replace(prefix, "");
                var fname = rootPath.Split('\\').Last();
                var subPath = (branch+"\\"+Regex.Replace(rootPath, fname + "$", "")).TrimEnd('\\');

                var match = _files.Where(x => x.Path == subPath && x.Name == fname).ToList();
                if (match.Count > 0)
                {
                    var dest = "branches\\" + source + "\\" + match[0].Path + "\\" + match[0].Name;

                    outputBatch += "DEL /Q \"" + dest + "\""+logfile+"\necho.>" + dest + "\n";

                    string command = "xcopy \"" + pth + "\" \"" + dest + "\" /H /Y";
                    if (Properties.Settings.Default.dragMove == true) command = "move /Y \"" + pth + "\" \"" + dest + "\"";
                    outputBatch += command + logfile + "\n";
                    transfer_files_valid.Add(pth);
                }
            }
            outputBatch += "DEL \"%~f0\"";

            var missing = transfer_files.Except(transfer_files_valid);

            if (transfer_files_valid.Count()==0)
            {
                DarkMessageBox.ShowError("Failed to transfer any files.\nMake sure you're in the matching directory as instructed.\n\n" 
                                                   + "If I'm wrong, right click on a file, open in explorer and replace there.", "Transfer failed");
                status.Text = "";
                return;
            }
            if (missing.Count() > 0)
            {
                failPopup dia = new failPopup();
                dia.titleText.Text = dia.titleText.Text.Replace("{X}", transfer_files_valid.Count().ToString());

                StringBuilder shortPath = new StringBuilder(300);
                GetShortPathName(prefix, shortPath, shortPath.Capacity);
                dia.dir.Text = shortPath.ToString();

                List<TreeNode> listpop = new List<TreeNode>();
                foreach(var m in missing) dia.list.Nodes.Add(new TreeNode(m.Replace(prefix,"")));

                if (dia.ShowDialog() != DialogResult.Yes) { return; }
            }

            string batchfile = "transfer_" + ts(DateTime.Now) + ".bat";
            string batchlocation = home + batchfile;
            File.WriteAllText(batchlocation, outputBatch);

            cmd("cd mods &&  call \\\"" + batchfile + "\\\"", false, true);

            status.Text = "File move complete";
            hoverTimeout.Enabled = true;
        }

        private void files_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void search_MouseDown(object sender, MouseEventArgs e)
        {
            if (search.Text == "search...")
            {
                search.Text = "";
                search.ForeColor = Color.LightGray;
            }
        }

        private void search_Leave(object sender, EventArgs e)
        {
            if (search.Text == "")
            {
                search.Text = "search...";
                search.ForeColor = Color.Gray;
            }
        }

        private void hoverTimeout_Tick(object sender, EventArgs e)
        {
            status.Text = "";
            hoverTimeout.Enabled = false;
        }

        private void files_MouseMove(object sender, MouseEventArgs e)
        {
            TreeNode node = files.GetNodeAt(e.X, e.Y);
            if (node != null)
            {
                var meta = node.ToolTipText.Split('>');
                hoverTimeout.Stop();
                status.Text = "Size: " + meta[0]+ ", Last modified: " + meta[1].Replace("_"," ");
                if (node.Tag.ToString() == "True") status.Text = "Original File";
                hoverTimeout.Enabled = true;
            }
        }

        private void browseInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var file = "";
            if (files.SelectedNode != null) file = files.SelectedNode.Text;
            Process str = new Process();
            str.StartInfo.FileName = "explorer.exe";
            str.StartInfo.Arguments = "/select,\"" + modpath(tree.SelectedNode) + "\\" + file + "\"";
            str.Start();
        }

        void restoreMenu_Click(object sender, EventArgs e)
        {
            status.Text = "Restoring file";
            string logfile = debug ? ">>\"logs/" + ts(DateTime.Now) + ".txt\"" : "";
            string tar = modpath(tree.SelectedNode) + "\\" + files.SelectedNode.Text;
            string src = tar.Replace("branches\\" + source, "branches\\temp\\" + source) + "." + ((ToolStripMenuItem)sender).Text;

            string cmds = "cd mods && echo Restoring from backup" + logfile
                                    + " && move /Y  \\\"" + src + "\\\"  \\\"" + tar + "\\\"" + logfile;

            cmd(cmds, false, true);
            loadTmpFiles();
            status.Text = "File restored";
            hoverTimeout.Enabled = true;

        }
        public void searchTree(TreeNode tre, string search)
        {
            if (tre.ToolTipText == search)
            {
                tree.SelectedNode = tre;
            }

            foreach (TreeNode node in tre.Nodes)
            {
                searchTree(node,search);
            }
        }
        private void files_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (search.Text == "search..." || search.Text == "") return;
            var path = files.SelectedNode.ToolTipText.Split('>')[2];
            searchTree(tree.Nodes[0], path);
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            status.Text = "Making backup";
            string src = modpath(tree.SelectedNode) + "\\" + files.SelectedNode.Text;
            string tar = home + "branches\\temp\\" + src.Replace(home + "branches\\", "") + "." + ts(DateTime.Now);

            string logfile = debug ? ">>\"logs/" + ts(DateTime.Now) + ".txt\"" : "";

            status.Text = "Backing up file";
            string cmds = "cd mods && echo Starting backup operation" + logfile
                                    + " && echo.>\\\"" + tar + "\\\""
                                    + " && xcopy  \\\"" + src + "\\\"  \\\"" + tar + "\\\"  /H /Y" + logfile;

            cmd(cmds, false, true);
            loadTmpFiles();
            status.Text = "Backup made!";
            hoverTimeout.Enabled = true;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            status.Text = "Deleting files";
            string logfile = debug ? ">>\"mods/logs/" + ts(DateTime.Now) + ".txt\"" : "";
            string tar = (modpath(tree.SelectedNode) + "\\" + files.SelectedNode.Text).Replace("branches\\" + source, "branches\\temp\\" + source) + ".";
            foreach (ToolStripMenuItem x in restoreFromBackupToolStripMenuItem.DropDownItems)
                cmd("echo Deleting backup " + x.Text + logfile + " && DEL /Q  \\\"" + tar + x.Text + "\\\"" + logfile, false, true);

            loadTmpFiles();
            status.Text = "Files cleared";
            hoverTimeout.Enabled = true;
        }

        private void restoreFromOriginalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            status.Text = "Restoring file";
            string logfile = debug ? ">>\"logs/" + ts(DateTime.Now) + ".txt\"" : "";
            string tar = modpath(tree.SelectedNode) + "\\" + files.SelectedNode.Text;
            string src = tar.Replace("branches\\" + source + "\\" + branch, "originals\\" + source);
            Console.WriteLine(tar);
            Console.WriteLine(src);
            /*

            string cmds = "cd mods && echo Restoring from backup" + logfile
                                    + " && move /Y  \\\"" + src + "\\\"  \\\"" + tar + "\\\"" + logfile;

            cmd(cmds, false, true);
            loadTmpFiles();
            status.Text = "File restored";
            hoverTimeout.Enabled = true;*/
        }

        private void editInNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editInAssemblyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = files.SelectedNode;

            if (node.Checked == true) // if is symlink
            {
                status.Text = "Converting symlink to real file first...";
                cloneFromOriginals(node);
                status.Text = "";
            }

            Process str = new Process();
            str.StartInfo.FileName = Properties.Settings.Default.assemblyPath;
            str.StartInfo.Arguments = "open \"" + modpath(tree.SelectedNode) + "\\" + node.Text + "\"";
            str.Start();
        }

        private void editInZetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = files.SelectedNode;

            if (node.Checked == true) // if is symlink
            {
                status.Text = "Converting symlink to real file first...";
                cloneFromOriginals(node);
                status.Text = "";
            }

            Process str = new Process();
            str.StartInfo.FileName = Properties.Settings.Default.zetaPath;
            str.StartInfo.Arguments = " \"" + modpath(tree.SelectedNode) + "\\" + node.Text + "\"";
            str.Start();
        }

        private void editInTextEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = files.SelectedNode;

            if (node.Checked == true) // if is symlink
            {
                status.Text = "Converting symlink to real file first...";
                cloneFromOriginals(node);
                status.Text = "";
            }

            Process str = new Process();
            str.StartInfo.FileName = Properties.Settings.Default.notepadPath;
            str.StartInfo.Arguments = " \"" + modpath(tree.SelectedNode) + "\\" + node.Text + "\"";
            str.Start();
        }
    }
}
