namespace MCC_Mod_Brancher
{
    partial class browse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip = new DarkUI.Controls.DarkStatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.search = new DarkUI.Controls.DarkTextBox();
            this.tree = new System.Windows.Forms.TreeView();
            this.icons_tree = new System.Windows.Forms.ImageList(this.components);
            this.files = new System.Windows.Forms.TreeView();
            this.icons_files = new System.Windows.Forms.ImageList(this.components);
            this.menu = new System.Windows.Forms.TableLayoutPanel();
            this.filter = new DarkUI.Controls.DarkTextBox();
            this.filter_mod = new DarkUI.Controls.DarkRadioButton();
            this.filter_onlyMod = new DarkUI.Controls.DarkCheckBox();
            this.filter_alp = new DarkUI.Controls.DarkRadioButton();
            this.filterTimeout = new System.Windows.Forms.Timer(this.components);
            this.ctx = new DarkUI.Controls.DarkContextMenu();
            this.browseInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tempBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreFromBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hoverTimeout = new System.Windows.Forms.Timer(this.components);
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreFromOriginalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editInAssemblyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editInZetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editInTextEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.tblMain.SuspendLayout();
            this.menu.SuspendLayout();
            this.ctx.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.statusStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip.Location = new System.Drawing.Point(0, 496);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(0, 5, 0, 3);
            this.statusStrip.Size = new System.Drawing.Size(953, 35);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 0;
            // 
            // status
            // 
            this.status.ForeColor = System.Drawing.Color.DarkGray;
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 0);
            // 
            // tblMain
            // 
            this.tblMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblMain.Controls.Add(this.search, 0, 0);
            this.tblMain.Controls.Add(this.tree, 0, 1);
            this.tblMain.Controls.Add(this.files, 1, 1);
            this.tblMain.Controls.Add(this.menu, 1, 0);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 2;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.Size = new System.Drawing.Size(953, 496);
            this.tblMain.TabIndex = 1;
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.search.ForeColor = System.Drawing.Color.Gray;
            this.search.Location = new System.Drawing.Point(4, 4);
            this.search.Margin = new System.Windows.Forms.Padding(4);
            this.search.Multiline = true;
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(242, 22);
            this.search.TabIndex = 10;
            this.search.Text = "search...";
            this.search.KeyUp += new System.Windows.Forms.KeyEventHandler(this.filter_KeyUp);
            this.search.Leave += new System.EventHandler(this.search_Leave);
            this.search.MouseDown += new System.Windows.Forms.MouseEventHandler(this.search_MouseDown);
            // 
            // tree
            // 
            this.tree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tree.ImageIndex = 0;
            this.tree.ImageList = this.icons_tree;
            this.tree.Location = new System.Drawing.Point(0, 30);
            this.tree.Margin = new System.Windows.Forms.Padding(0);
            this.tree.Name = "tree";
            this.tree.SelectedImageIndex = 0;
            this.tree.Size = new System.Drawing.Size(250, 490);
            this.tree.TabIndex = 7;
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            // 
            // icons_tree
            // 
            this.icons_tree.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.icons_tree.ImageSize = new System.Drawing.Size(16, 16);
            this.icons_tree.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // files
            // 
            this.files.AllowDrop = true;
            this.files.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.files.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.files.FullRowSelect = true;
            this.files.ImageIndex = 0;
            this.files.ImageList = this.icons_files;
            this.files.Location = new System.Drawing.Point(250, 30);
            this.files.Margin = new System.Windows.Forms.Padding(0);
            this.files.Name = "files";
            this.files.SelectedImageIndex = 0;
            this.files.Size = new System.Drawing.Size(703, 490);
            this.files.TabIndex = 9;
            this.files.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.files_AfterSelect);
            this.files.DragDrop += new System.Windows.Forms.DragEventHandler(this.files_DragDrop);
            this.files.DragEnter += new System.Windows.Forms.DragEventHandler(this.files_DragEnter);
            this.files.MouseMove += new System.Windows.Forms.MouseEventHandler(this.files_MouseMove);
            this.files.MouseUp += new System.Windows.Forms.MouseEventHandler(this.files_MouseUp);
            // 
            // icons_files
            // 
            this.icons_files.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.icons_files.ImageSize = new System.Drawing.Size(16, 16);
            this.icons_files.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // menu
            // 
            this.menu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.menu.ColumnCount = 5;
            this.menu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.menu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.menu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.menu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.menu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.menu.Controls.Add(this.filter, 4, 0);
            this.menu.Controls.Add(this.filter_mod, 2, 0);
            this.menu.Controls.Add(this.filter_onlyMod, 0, 0);
            this.menu.Controls.Add(this.filter_alp, 1, 0);
            this.menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menu.Location = new System.Drawing.Point(253, 3);
            this.menu.Name = "menu";
            this.menu.RowCount = 1;
            this.menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menu.Size = new System.Drawing.Size(697, 24);
            this.menu.TabIndex = 2;
            // 
            // filter
            // 
            this.filter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.filter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filter.ForeColor = System.Drawing.Color.Gray;
            this.filter.Location = new System.Drawing.Point(519, 0);
            this.filter.Margin = new System.Windows.Forms.Padding(0);
            this.filter.Multiline = true;
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(178, 24);
            this.filter.TabIndex = 11;
            this.filter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.filter_KeyUp);
            this.filter.Leave += new System.EventHandler(this.filter_Leave);
            this.filter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.filter_MouseDown);
            // 
            // filter_mod
            // 
            this.filter_mod.AutoSize = true;
            this.filter_mod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filter_mod.Location = new System.Drawing.Point(343, 3);
            this.filter_mod.Name = "filter_mod";
            this.filter_mod.Size = new System.Drawing.Size(114, 18);
            this.filter_mod.TabIndex = 6;
            this.filter_mod.Text = "Modified";
            this.filter_mod.CheckedChanged += new System.EventHandler(this.filter_onlyMod_CheckedChanged);
            // 
            // filter_onlyMod
            // 
            this.filter_onlyMod.AutoSize = true;
            this.filter_onlyMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.filter_onlyMod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filter_onlyMod.Location = new System.Drawing.Point(3, 3);
            this.filter_onlyMod.Name = "filter_onlyMod";
            this.filter_onlyMod.Size = new System.Drawing.Size(214, 18);
            this.filter_onlyMod.TabIndex = 4;
            this.filter_onlyMod.Text = "Only show modified files";
            this.filter_onlyMod.CheckedChanged += new System.EventHandler(this.filter_onlyMod_CheckedChanged);
            // 
            // filter_alp
            // 
            this.filter_alp.AutoSize = true;
            this.filter_alp.Checked = true;
            this.filter_alp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filter_alp.Location = new System.Drawing.Point(223, 3);
            this.filter_alp.Name = "filter_alp";
            this.filter_alp.Size = new System.Drawing.Size(114, 18);
            this.filter_alp.TabIndex = 5;
            this.filter_alp.TabStop = true;
            this.filter_alp.Text = "Alphabetical";
            this.filter_alp.CheckedChanged += new System.EventHandler(this.filter_onlyMod_CheckedChanged);
            // 
            // filterTimeout
            // 
            this.filterTimeout.Interval = 500;
            this.filterTimeout.Tick += new System.EventHandler(this.filterTimeout_Tick);
            // 
            // ctx
            // 
            this.ctx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ctx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ctx.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctx.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editInAssemblyToolStripMenuItem,
            this.editInZetaToolStripMenuItem,
            this.editInTextEditorToolStripMenuItem,
            this.browseInExplorerToolStripMenuItem,
            this.tempBackupToolStripMenuItem,
            this.restoreFromBackupToolStripMenuItem,
            this.restoreFromOriginalToolStripMenuItem});
            this.ctx.Name = "ctx";
            this.ctx.Size = new System.Drawing.Size(185, 180);
            this.ctx.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.ctx_Closed);
            // 
            // browseInExplorerToolStripMenuItem
            // 
            this.browseInExplorerToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.browseInExplorerToolStripMenuItem.Name = "browseInExplorerToolStripMenuItem";
            this.browseInExplorerToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.browseInExplorerToolStripMenuItem.Text = "Open in &Explorer";
            this.browseInExplorerToolStripMenuItem.Click += new System.EventHandler(this.browseInExplorerToolStripMenuItem_Click);
            // 
            // tempBackupToolStripMenuItem
            // 
            this.tempBackupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.tempBackupToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.tempBackupToolStripMenuItem.Name = "tempBackupToolStripMenuItem";
            this.tempBackupToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.tempBackupToolStripMenuItem.Text = "&Backups";
            // 
            // restoreFromBackupToolStripMenuItem
            // 
            this.restoreFromBackupToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.restoreFromBackupToolStripMenuItem.Name = "restoreFromBackupToolStripMenuItem";
            this.restoreFromBackupToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.restoreFromBackupToolStripMenuItem.Text = "&Restore from Backup";
            // 
            // hoverTimeout
            // 
            this.hoverTimeout.Interval = 2000;
            this.hoverTimeout.Tick += new System.EventHandler(this.hoverTimeout_Tick);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.createToolStripMenuItem.Text = "&Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.clearToolStripMenuItem.Text = "C&lear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // restoreFromOriginalToolStripMenuItem
            // 
            this.restoreFromOriginalToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.restoreFromOriginalToolStripMenuItem.Name = "restoreFromOriginalToolStripMenuItem";
            this.restoreFromOriginalToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.restoreFromOriginalToolStripMenuItem.Text = "Restore to &Original";
            this.restoreFromOriginalToolStripMenuItem.Click += new System.EventHandler(this.restoreFromOriginalToolStripMenuItem_Click);
            // 
            // editInAssemblyToolStripMenuItem
            // 
            this.editInAssemblyToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.editInAssemblyToolStripMenuItem.Name = "editInAssemblyToolStripMenuItem";
            this.editInAssemblyToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.editInAssemblyToolStripMenuItem.Text = "Edit in Assembly";
            this.editInAssemblyToolStripMenuItem.Click += new System.EventHandler(this.editInAssemblyToolStripMenuItem_Click);
            // 
            // editInZetaToolStripMenuItem
            // 
            this.editInZetaToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.editInZetaToolStripMenuItem.Name = "editInZetaToolStripMenuItem";
            this.editInZetaToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.editInZetaToolStripMenuItem.Text = "Edit in Zeta";
            this.editInZetaToolStripMenuItem.Click += new System.EventHandler(this.editInZetaToolStripMenuItem_Click);
            // 
            // editInTextEditorToolStripMenuItem
            // 
            this.editInTextEditorToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.editInTextEditorToolStripMenuItem.Name = "editInTextEditorToolStripMenuItem";
            this.editInTextEditorToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.editInTextEditorToolStripMenuItem.Text = "Edit in &Text Editor";
            this.editInTextEditorToolStripMenuItem.Click += new System.EventHandler(this.editInTextEditorToolStripMenuItem_Click);
            // 
            // browse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 531);
            this.Controls.Add(this.tblMain);
            this.Controls.Add(this.statusStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::MCC_Mod_Brancher.Properties.Resources.tree;
            this.Name = "browse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "browse";
            this.Load += new System.EventHandler(this.explore_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ctx.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        //DarkUISystem.Windows.Forms.TreeView
        private DarkUI.Controls.DarkStatusStrip statusStrip;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.TreeView files;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.TableLayoutPanel menu;
        private DarkUI.Controls.DarkCheckBox filter_onlyMod;
        private DarkUI.Controls.DarkRadioButton filter_mod;
        private DarkUI.Controls.DarkRadioButton filter_alp;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.Timer filterTimeout;
        private DarkUI.Controls.DarkContextMenu ctx;
        private System.Windows.Forms.ToolStripMenuItem browseInExplorerToolStripMenuItem;
        private DarkUI.Controls.DarkTextBox search;
        private DarkUI.Controls.DarkTextBox filter;
        private System.Windows.Forms.Timer hoverTimeout;
        private System.Windows.Forms.ToolStripMenuItem tempBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreFromBackupToolStripMenuItem;
        private System.Windows.Forms.ImageList icons_files;
        private System.Windows.Forms.ImageList icons_tree;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreFromOriginalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editInAssemblyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editInZetaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editInTextEditorToolStripMenuItem;
    }
}