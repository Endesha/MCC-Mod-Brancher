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

namespace MCC_Mod_Version_Manager
{

    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        // Global vars
        string home = Directory.GetCurrentDirectory() + "\\";
        ArrayList _backups = new ArrayList();
        bool treeLoading = false;

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
                throw new IOException("Path not found");
            }

            SafeFileHandle directoryHandle = CreateFile(path, 0, 2, IntPtr.Zero, CREATION_DISPOSITION_OPEN_EXISTING, FILE_FLAG_BACKUP_SEMANTICS, IntPtr.Zero); //Handle file / folder

            if (directoryHandle.IsInvalid)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
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
                Form prompt = new Form()
                {
                    Width = 400,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedToolWindow,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top = 15, Height = 50,Width = 300, Text = text };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 300 };
                Button confirmation = new Button() { Text = "Ok", Left = 250, Width = 100, Top = 75, DialogResult = DialogResult.OK };
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
                res.ForeColor = Color.DarkGreen;
                if (!md) _backups.Add(dir);
            }
            else
            {
                res.Text = "✗";
                res.ForeColor = Color.DarkRed;
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
            if (tabControl1.SelectedIndex==0) status.Text = "Checking mod backups";
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
            string logfile = " >>mods/logs/" + ts(DateTime.Now) + ".txt";
            cmd("echo Move ./" + folder + logfile
                            + " && move " + folder + " mods/originals/" + folder + logfile
                            + " && echo." + logfile + " && echo Symlinking " + folder + logfile
                            + " && mklink /d " + folder + " \\\"" + home + "originals\\" + folder + "\\\"" + logfile
                      , true, true);
            check_mod_backups();
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

                int nc = treeView1.Nodes.Count - 1;
                string real = GetRealPath(home + "../" + dir);
                if (real.Contains("originals")) treeView1.Nodes[nc].Checked = true;

                treeView1.Nodes[nc].ContextMenuStrip = branch_root_ctx;
                foreach (string br in Directory.GetDirectories(home + "branches/" + dir + "/"))
                {
                    treeView1.Nodes[nc].Nodes.Add(br.Replace(home + "branches/" + dir + "/", ""));
                    int snc = treeView1.Nodes[nc].Nodes.Count - 1;
                    treeView1.Nodes[nc].Nodes[snc].ContextMenuStrip = branch_ctx;
                    if (real.Contains(dir) && treeView1.Nodes[nc].Checked==false) treeView1.Nodes[nc].Nodes[snc].Checked = true;
                }
                treeView1.ExpandAll();
                if (tabControl1.SelectedIndex == 1) status.Text = "Idle";
            }
            treeLoading = false;
        }
        void branch(string source, string newname)
        {
            string logfile = " >>logs/" + ts(DateTime.Now) + ".txt";

            cmd("cd mods && echo Clone folder structure " + source + logfile
                            + " && xcopy \\\"originals/" + source + "\\\" \\\"branches/" + source + "/" + newname + "\\\" /T /E /I /Y" + logfile
                      );

            DirectoryInfo objDirectoryInfo = new DirectoryInfo(home + "originals\\"+source);
            FileInfo[] files = objDirectoryInfo.GetFiles("*.*", SearchOption.AllDirectories);

            string batchfile = "syslink_" + ts(DateTime.Now) + ".bat";
            string batchlocation = home + batchfile;
            string cmds = "@echo off\ncd /d \"" + home + "\"\necho Starting symlink process" + logfile + "\n";
            foreach (var file in files)
            {
                string sf = file.FullName.Replace(home + @"originals\"+source, "");
                cmds += "mklink \"" + home + "branches\\" + source + "\\" + newname + sf + "\" \"" + home + "originals\\" + source + sf + "\"" + logfile + "\n";
            }
            cmds += "DEL \"%~f0\"";
            File.WriteAllText(batchlocation, cmds);

            cmd("cd mods &&  call \\\"" + batchfile + "\\\"", true);
        }

        void assignCurrent(string source, string path)
        {
            string logfile = " >>mods/logs/" + ts(DateTime.Now) + ".txt";
            cmd("echo Assigning new branch for " + source + ", deleting symlink and adding new" + logfile
                            + " && rmdir " + source + logfile
                            + " && mklink /d " + source + " \\\"" + path + "\\\"" + logfile
                      , true, true);
        }

        // end dan's crappy functions

        private void main_Load(object sender, EventArgs e)
        {
            checkall();
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

            if (newname.Length > 0 && !newname.Contains(" ") && !Directory.Exists(home + "branches\\" + source + "\\" + newname))
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

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Endesha/MCC-Mod-Version-Manager");
        }
    }
}
