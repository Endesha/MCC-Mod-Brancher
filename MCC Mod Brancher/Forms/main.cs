using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Dynamic;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using DarkUI.Forms;
using DarkUI.Controls;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Net;


namespace MCC_Mod_Brancher
{
    public partial class main : DarkForm
    {
        public main()
        {
            InitializeComponent();
            version.Text += Application.ProductVersion;
            assemblyPath.Text = Properties.Settings.Default.assemblyPath;
            zetaPath.Text = Properties.Settings.Default.zetaPath;
            notepadPath.Text = Properties.Settings.Default.notepadPath;
            if (Properties.Settings.Default.dragMove == true)
            {
                set_move.Checked = true;
            }
        }

        // Global vars
        string home = Directory.GetCurrentDirectory() + "\\";
        ArrayList _backups = new ArrayList();
        bool formLoaded = false;
        bool treeLoading = false;
        bool debug = false;

        // start 3rd pty
        // bits for realising symlinks
        [DllImport("kernel32.dll", EntryPoint = "CreateFileW", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern SafeFileHandle CreateFile(string lpFileName, int dwDesiredAccess, int dwShareMode, IntPtr securityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, IntPtr hTemplateFile);
        [DllImport("kernel32.dll", EntryPoint = "GetFinalPathNameByHandleW", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int GetFinalPathNameByHandle([In] SafeFileHandle hFile, [Out] StringBuilder lpszFilePath, [In] int cchFilePath, [In] int dwFlags);
        private const int CREATION_DISPOSITION_OPEN_EXISTING = 3;
        private const int FILE_FLAG_BACKUP_SEMANTICS = 0x02000000;
        public static string GetRealPath(string path)
        {
            if (!Directory.Exists(path) && !File.Exists(path))
            {
                Console.WriteLine(new IOException("Path not found"));
            }

            SafeFileHandle directoryHandle = CreateFile(path, 0, 2, IntPtr.Zero, CREATION_DISPOSITION_OPEN_EXISTING, FILE_FLAG_BACKUP_SEMANTICS, IntPtr.Zero); //Handle file / folder

            if (directoryHandle.IsInvalid)
            {
                Console.WriteLine(new Win32Exception(Marshal.GetLastWin32Error()));
            }

            StringBuilder result = new StringBuilder(512);
            int mResult = GetFinalPathNameByHandle(directoryHandle, result, result.Capacity, 0);

            if (mResult < 0)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            if (result.Length >= 4 && result[0] == '\\' && result[1] == '\\' && result[2] == '?' && result[3] == '\\')
            {
                return result.ToString().Substring(4); // "\\?\" remove
            }
            return result.ToString();
        }

        // resolve dlls from /bin
        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            // Ignore missing resources
            if (args.Name.Contains(".resources"))
                return null;

            // check for assemblies already loaded
            Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName == args.Name);
            if (assembly != null)
                return assembly;

            string filename = args.Name.Split(',')[0] + ".dll".ToLower();

            string asmFile = Path.Combine(@".\", "bin", filename);
            try
            {
                return System.Reflection.Assembly.LoadFrom(asmFile);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        // no dbl click on treeview
        public class NoClickTree : TreeView
        {
            protected override void WndProc(ref Message m)
            {
                // Suppress WM_LBUTTONDBLCLK
                if (m.Msg == 0x203) { m.Result = IntPtr.Zero; }
                else base.WndProc(ref m);
            }
        }

        // easy popup rather than new form
        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new DarkForm
                {
                    Width = 400,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedToolWindow,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                DarkLabel textLabel = new DarkLabel() { Left = 50, Top = 15, Height = 50, Width = 300, Text = text };
                DarkTextBox textBox = new DarkTextBox() { Left = 50, Top = 50, Width = 300 };
                DarkButton confirmation = new DarkButton() { Text = "Ok", Left = 250, Width = 100, Top = 80, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }

        // end 3rd pty

        // start dan's crappy functions

        public static String ts(DateTime value)
        {
            return value.ToString("yyyy.MM.dd_HH.mm.ss");
        }

        // kinda convoluted way of doing it, could just make program admin from start
        // but started this way as the "explore branch" side shouldn't need admin (i think? ;/)
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

        // check game directory , (last term is "mod directory") - I know this whole bit is painful
        private void cgd(string dir, Label res, bool md = true)
        {
            if (Directory.Exists(home + (md ? "../" : "") + dir))
            {
                res.Text = "✓";
                res.ForeColor = Color.LawnGreen;
                if (!md) _backups.Add(dir);
            }
            else
            {
                res.Text = "✗";
                res.ForeColor = Color.OrangeRed;
            }
        }
        private void check_directories()
        {
            if (tabControl1.SelectedIndex == 0) status.Text = "Checking game directories";
            cgd("data", dir_data_tick);
            cgd("MCC", dir_mcc_tick);
            cgd("haloce", dir_ce_tick);
            cgd("halo2", dir_2_tick);
            cgd("halo3", dir_3_tick);
            cgd("halo3odst", dir_odst_tick);
            cgd("halo4", dir_4_tick);
            cgd("haloreach", dir_reach_tick);
            if (tabControl1.SelectedIndex == 0) status.Text = "Idle";
        }
        private void check_mod_backups()
        {
            _backups.Clear();
            if (tabControl1.SelectedIndex == 0) status.Text = "Checking mod backups";
            cgd("originals/data", dir_mod_orig_data, false);
            cgd("originals/MCC", dir_mod_orig_mcc, false);
            cgd("originals/haloce", dir_mod_orig_ce, false);
            cgd("originals/halo2", dir_mod_orig_2, false);
            cgd("originals/halo3", dir_mod_orig_3, false);
            cgd("originals/halo3odst", dir_mod_orig_odst, false);
            cgd("originals/halo4", dir_mod_orig_4, false);
            cgd("originals/haloreach", dir_mod_orig_reach, false);
            if (tabControl1.SelectedIndex == 0) status.Text = "Idle";
        }
        private void checkall()
        {
            check_directories();
            check_mod_backups();
        }

        // err does what it says on the tin boyoh!
        private void backupFolder(string folder)
        {
            status.Text = "Backing up " + folder;
            string logfile = debug ? " >>mods/logs/" + ts(DateTime.Now) + ".txt" : "";
            cmd("echo Move ./" + folder + logfile
                            + " && move " + folder + " mods/originals/" + folder + logfile
                            + " && echo." + logfile + " && echo Symlinking " + folder + logfile
                            + " && mklink /d " + folder + " \\\"" + home + "originals\\" + folder + "\\\"" + logfile
                      , true, true);
            check_mod_backups();
            status.Text = "Idle";
        }

        private void loadBranches()
        {
            treeLoading = true;
            if (tabControl1.SelectedIndex == 1) status.Text = "Loading branches";
            treeView1.Nodes.Clear();
            foreach (string _dir in _backups)
            {
                string dir = _dir.Replace("originals/", "");
                treeView1.Nodes.Add(dir);

                if (!Directory.Exists(home + "branches\\" + dir)) Directory.CreateDirectory(home + "branches\\" + dir);

                TreeNode root = treeView1.Nodes[treeView1.Nodes.Count-1];
                string real = GetRealPath(home + "../" + dir);

                if (real.Contains("originals\\")) root.Checked = true;

                root.ContextMenuStrip = branch_root_ctx;
                foreach (string br in Directory.GetDirectories(home + "branches/" + dir + "/"))
                {
                    root.Nodes.Add(br.Replace(home + "branches/" + dir + "/", ""));
                    TreeNode subNode = root.Nodes[root.Nodes.Count - 1];
                    subNode.ContextMenuStrip = branch_ctx;

                    if (real.Split('\\').Last() == subNode.Text) subNode.Checked = true;
                }
                treeView1.ExpandAll();
            }
            status.Text = "Idle";
            treeLoading = false;
        }
        void branch(string source, string newname, string sourcedir = "")
        {
            status.Text = "Creating branch " + newname;
            string logfile = debug ? " >>logs/" + ts(DateTime.Now) + ".txt" : "";

            string branchdir = (sourcedir.Length > 0 ? sourcedir : "originals\\" + source);

            cmd("cd mods && echo Clone folder structure " + source + logfile
                            + " && xcopy \\\""+branchdir + "\\\" \\\"branches\\" + source.Split('\\')[0] + "\\" + newname + "\\\" /T /E /I /Y" + logfile
                      );

            DirectoryInfo objDirectoryInfo = new DirectoryInfo(home + branchdir);
            FileInfo[] files = objDirectoryInfo.GetFiles("*.*", SearchOption.AllDirectories);

            string batchfile = "syslink_" + ts(DateTime.Now) + ".bat";
            string batchlocation = home + batchfile;
            string cmds = "@echo off\ncd /d \"" + home + "\"\necho Starting symlink process" + logfile + "\n";
            foreach (var file in files)
            {
                string sf = file.FullName.Replace(home + branchdir, ""); //has backslash at start
                cmds += "mklink \"" + home + "branches\\" + source.Split('\\')[0] + "\\" + newname + sf + "\" \"" + home + branchdir + sf + "\"" + logfile + "\n";
            }
            cmds += "DEL \"%~f0\"";
            File.WriteAllText(batchlocation, cmds);

            cmd("cd mods &&  call \\\"" + batchfile + "\\\"", true);
            status.Text = "Idle";
        }

        void assignCurrent(string source, string path)
        {
            status.Text = "Assigning new branch for " + source;
            string logfile = debug ? " >>mods/logs/" + ts(DateTime.Now) + ".txt" : "";
            cmd("echo Assigning new branch for " + source + ", deleting symlink and adding new" + logfile
                            + " && rmdir " + source + logfile
                            + " && mklink /d " + source + " \\\"" + path + "\\\"" + logfile
                      , true, true);
            status.Text = "Idle";
        }
      
        // end dan's crappy functions

        private void main_Load(object sender, EventArgs e)
        {
            debug = Directory.Exists(home + "logs");
            checkall();
            formLoaded = true;
        }

        void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            status.Text = "Idle";
            TabPage tp = (sender as TabControl).SelectedTab;

            if (tp.Text == "Branches") {
                loadBranches();
            }
        }

        private void backupFolderCall(object sender, EventArgs e)
        {
            string dir = (sender as Label).Text;
            if (!Directory.Exists(home + "originals/" + dir) && Directory.Exists(home + "../" + dir))
                backupFolder(dir);
        }

        private void addNewBranchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContextMenuStrip cms = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            TreeView treeView = (TreeView)cms.SourceControl;
            TreeNode node = treeView.GetNodeAt(treeView.PointToClient(cms.Location));
            string source = node.Text;

            string newname = Prompt.ShowDialog("Please enter a name for the new branch\nNote - No spaces!", "Input Required");
            if (newname.Contains(" ")) newname = Regex.Replace(newname, " ", "_");
            if (newname.Length > 0 && !Directory.Exists(home + "branches\\" + source + "\\" + newname))
            {
                branch(source, newname);
                node.Nodes.Add(newname);
                node.Nodes[node.Nodes.Count - 1].ContextMenuStrip = branch_ctx;
                treeView.ExpandAll();
            }
        }

        private void treeView1_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (treeLoading==true) return;
            if (e.Node.Checked == true)
            {
                e.Cancel = true;
                return;
            }
            e.Cancel = true;
            
            string txt = e.Node.Text;
            TreeNode root = (e.Node.Parent == null ? e.Node : e.Node.Parent);
            string source = root.Text;
            string path = home + (e.Node.Parent == null ? "originals\\" : "branches\\" + source + "\\") + txt;
            
            assignCurrent(source, path);
            loadBranches();
        }

        private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContextMenuStrip cms = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            TreeView treeView = (TreeView)cms.SourceControl;
            TreeNode node = treeView.GetNodeAt(treeView.PointToClient(cms.Location));
            string source = node.Parent.Text + "\\" + node.Text;

            string newname = Prompt.ShowDialog("Please enter a name for the cloned branch\nNote - No spaces!", "Input Required");
            if (newname.Contains(" ")) newname = Regex.Replace(newname, " ", "_");
            if (newname.Length > 0 && !Directory.Exists(home + "branches\\" + source + "\\" + newname))
            {
                branch(source, newname, "branches\\"+source);
                node.Nodes.Add(newname);
                node.Nodes[node.Nodes.Count - 1].ContextMenuStrip = branch_ctx;
                treeView.ExpandAll();
                DarkMessageBox.ShowInformation("Please note; the cloned symlink against the clonee.\n"
                                                + "1. Damage to the original branch will transmit to clones (unless already modified)\n"
                                                + "2. New branch won't display 'modified' files as modified\n", "Information");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Endesha/MCC-Mod-Brancher");
        }

        private void openInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContextMenuStrip cms = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            TreeView treeView = (TreeView)cms.SourceControl;
            TreeNode node = treeView.GetNodeAt(treeView.PointToClient(cms.Location));

            Process.Start(home + "branches\\" + node.Parent.Text + "\\" + node.Text);
        }

        private void openInExplorerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ContextMenuStrip cms = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            TreeView treeView = (TreeView)cms.SourceControl;
            TreeNode node = treeView.GetNodeAt(treeView.PointToClient(cms.Location));

            Process.Start(home + "originals\\" + node.Text);
        }

        private void backup_MouseEnter(object sender, EventArgs e)
        {
            string dir = ((Label)sender).Text;
            if (!Directory.Exists(home + "originals/" + dir) && Directory.Exists(home + "../" + dir))
            {
                ((Label)sender).Cursor = Cursors.Hand;
                if (status.Text == "Idle") status.Text = "Double click to backup";
            }
        }

        private void backup_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).Cursor = Cursors.Default;
            status.Text = "Idle";
        }

        private void browseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContextMenuStrip cms = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            TreeView treeView = (TreeView)cms.SourceControl;
            TreeNode node = treeView.GetNodeAt(treeView.PointToClient(cms.Location));

            browse expl = new browse();
            expl.source = node.Parent.Text;
            expl.branch = node.Text;
            expl.Text = "Browsing branch " + node.Parent.Text + "/" + node.Text;
            expl.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DarkMessageBox.ShowWarning("Are you sure?\nThis operation cannot be undone!", "Confirm Delete", DarkDialogButton.YesNo) == DialogResult.Yes)
            {
                status.Text = "Deleting branch :'( #savethetrees";
                ContextMenuStrip cms = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
                TreeView treeView = (TreeView)cms.SourceControl;
                TreeNode node = treeView.GetNodeAt(treeView.PointToClient(cms.Location));
                TreeNode parent = node.Parent;
                
                string source = node.Text;
                string root = parent.Text;

                string logfile = debug ? " >>mods/logs/" + ts(DateTime.Now) + ".txt" : "";
                cmd("echo Deleting " + source + logfile
                                + " && rmdir mods\\branches\\"+ root + "\\" + source  +" /Q /S"+ logfile
                          , false, true);

                node.Remove();

                if (node.Checked == true)
                {
                    treeLoading = true;
                    node.Checked = false;
                    parent.Checked = true;
                    treeLoading = false;
                }
                status.Text = "";

                //deleteTimeout.Enabled = true;
            }
        }

        private void browse_Click(object sender, EventArgs e)
        {
            string path = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = home;
                openFileDialog.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                }
            }

            Button me = (Button)sender;
            if (me.Name.EndsWith("1")) assemblyPath.Text = path;
            if (me.Name.EndsWith("2")) zetaPath.Text = path;
            if (me.Name.EndsWith("3")) notepadPath.Text = path;
        }

        private void assemblyPath_TextChanged(object sender, EventArgs e)
        {
            if (formLoaded == false) return;
            Properties.Settings.Default.assemblyPath = assemblyPath.Text;
            Properties.Settings.Default.Save();
        }
        private void assemblyPath_Leave(object sender, EventArgs e)
        {;
            Properties.Settings.Default.assemblyPath = assemblyPath.Text;
            Properties.Settings.Default.Save();
        }

        private void zetaPath_TextChanged(object sender, EventArgs e)
        {
            if (formLoaded == false) return;
            Properties.Settings.Default.assemblyPath = assemblyPath.Text;
            Properties.Settings.Default.Save();
        }

        private void notepadPath_TextChanged(object sender, EventArgs e)
        {
            if (formLoaded == false) return;
            Properties.Settings.Default.assemblyPath = assemblyPath.Text;
            Properties.Settings.Default.Save();
        }

        private void update_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string current = update.Document.Body.InnerText.Trim();
            if (current != Application.ProductVersion && current != Properties.Settings.Default.ignoredVersion)
            {
                var warn = DarkMessageBox.ShowWarning("You're not running the most up to date version\n"
                                            + "Would you like to open the release page?", "Update Available", DarkDialogButton.YesNo);
                if (warn == DialogResult.Yes)
                {
                    Process pro = new Process();
                    pro.StartInfo.FileName = "https://github.com/Endesha/MCC-Mod-Brancher/releases";
                    pro.Start();
                } else
                {
                    Properties.Settings.Default.ignoredVersion = current;
                    Properties.Settings.Default.Save();
                }
            }

        }

        private void set_copy_CheckedChanged(object sender, EventArgs e)
        {
            if (formLoaded == false) return;
            Properties.Settings.Default.dragMove = set_move.Checked;
            Properties.Settings.Default.Save();
        }

        private void deleteTimeout_Tick(object sender, EventArgs e)
        {
            //loadBranches();
            //treecurrent.Checked = true;
            deleteTimeout.Enabled = false;
        }
    }
}
