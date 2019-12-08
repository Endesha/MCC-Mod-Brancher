﻿using DarkUI.Controls;
using DarkUI.Docking;
namespace MCC_Mod_Version_Manager
{
    partial class main
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
            this.branch_root_ctx = new DarkUI.Controls.DarkContextMenu();
            this.addNewBranchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInExplorerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.branch_ctx = new DarkUI.Controls.DarkContextMenu();
            this.browseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new DarkUI.Controls.DarkStatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.version = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new MCC_Mod_Version_Manager.VisualStudioTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dir_reach_tick = new DarkUI.Controls.DarkLabel();
            this.dir_4_tick = new DarkUI.Controls.DarkLabel();
            this.dir_odst_tick = new DarkUI.Controls.DarkLabel();
            this.dir_3_tick = new DarkUI.Controls.DarkLabel();
            this.dir_2_tick = new DarkUI.Controls.DarkLabel();
            this.dir_ce_tick = new DarkUI.Controls.DarkLabel();
            this.dir_mcc_tick = new DarkUI.Controls.DarkLabel();
            this.dir_data_tick = new DarkUI.Controls.DarkLabel();
            this.label8 = new DarkUI.Controls.DarkLabel();
            this.label7 = new DarkUI.Controls.DarkLabel();
            this.label6 = new DarkUI.Controls.DarkLabel();
            this.label5 = new DarkUI.Controls.DarkLabel();
            this.label4 = new DarkUI.Controls.DarkLabel();
            this.label3 = new DarkUI.Controls.DarkLabel();
            this.label2 = new DarkUI.Controls.DarkLabel();
            this.label1 = new DarkUI.Controls.DarkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dir_mod_orig_reach = new DarkUI.Controls.DarkLabel();
            this.dir_mod_orig_4 = new DarkUI.Controls.DarkLabel();
            this.dir_mod_orig_odst = new DarkUI.Controls.DarkLabel();
            this.dir_mod_orig_3 = new DarkUI.Controls.DarkLabel();
            this.dir_mod_orig_2 = new DarkUI.Controls.DarkLabel();
            this.dir_mod_orig_ce = new DarkUI.Controls.DarkLabel();
            this.dir_mod_orig_mcc = new DarkUI.Controls.DarkLabel();
            this.dir_mod_orig_data = new DarkUI.Controls.DarkLabel();
            this.label17 = new DarkUI.Controls.DarkLabel();
            this.label18 = new DarkUI.Controls.DarkLabel();
            this.label19 = new DarkUI.Controls.DarkLabel();
            this.label20 = new DarkUI.Controls.DarkLabel();
            this.label21 = new DarkUI.Controls.DarkLabel();
            this.label22 = new DarkUI.Controls.DarkLabel();
            this.label23 = new DarkUI.Controls.DarkLabel();
            this.label24 = new DarkUI.Controls.DarkLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.treeView1 = new MCC_Mod_Version_Manager.main.NoClickTree();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label9 = new DarkUI.Controls.DarkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.branch_root_ctx.SuspendLayout();
            this.branch_ctx.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // branch_root_ctx
            // 
            this.branch_root_ctx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.branch_root_ctx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.branch_root_ctx.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.branch_root_ctx.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewBranchToolStripMenuItem,
            this.openInExplorerToolStripMenuItem1});
            this.branch_root_ctx.Name = "branch_root_ctx";
            this.branch_root_ctx.Size = new System.Drawing.Size(190, 52);
            // 
            // addNewBranchToolStripMenuItem
            // 
            this.addNewBranchToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewBranchToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.addNewBranchToolStripMenuItem.Name = "addNewBranchToolStripMenuItem";
            this.addNewBranchToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.addNewBranchToolStripMenuItem.Text = "&Add new branch";
            this.addNewBranchToolStripMenuItem.Click += new System.EventHandler(this.addNewBranchToolStripMenuItem_Click);
            // 
            // openInExplorerToolStripMenuItem1
            // 
            this.openInExplorerToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.openInExplorerToolStripMenuItem1.Name = "openInExplorerToolStripMenuItem1";
            this.openInExplorerToolStripMenuItem1.Size = new System.Drawing.Size(189, 24);
            this.openInExplorerToolStripMenuItem1.Text = "&Open in Explorer";
            this.openInExplorerToolStripMenuItem1.Click += new System.EventHandler(this.openInExplorerToolStripMenuItem1_Click);
            // 
            // branch_ctx
            // 
            this.branch_ctx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.branch_ctx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.branch_ctx.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.branch_ctx.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseToolStripMenuItem,
            this.cloneToolStripMenuItem,
            this.openInExplorerToolStripMenuItem});
            this.branch_ctx.Name = "brnch_root_ctx";
            this.branch_ctx.Size = new System.Drawing.Size(211, 104);
            // 
            // browseToolStripMenuItem
            // 
            this.browseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.browseToolStripMenuItem.Name = "browseToolStripMenuItem";
            this.browseToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.browseToolStripMenuItem.Text = "&Browse";
            // 
            // cloneToolStripMenuItem
            // 
            this.cloneToolStripMenuItem.Enabled = false;
            this.cloneToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            this.cloneToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.cloneToolStripMenuItem.Text = "&Clone";
            this.cloneToolStripMenuItem.Click += new System.EventHandler(this.cloneToolStripMenuItem_Click);
            // 
            // openInExplorerToolStripMenuItem
            // 
            this.openInExplorerToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.openInExplorerToolStripMenuItem.Name = "openInExplorerToolStripMenuItem";
            this.openInExplorerToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.openInExplorerToolStripMenuItem.Text = "&Open In Explorer";
            this.openInExplorerToolStripMenuItem.Click += new System.EventHandler(this.openInExplorerToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.statusStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status,
            this.toolStripStatusLabel3,
            this.version});
            this.statusStrip1.Location = new System.Drawing.Point(0, 335);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 3);
            this.statusStrip1.Size = new System.Drawing.Size(440, 35);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.ForeColor = System.Drawing.Color.DarkGray;
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(72, 21);
            this.status.Text = "Loading...";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(304, 21);
            this.toolStripStatusLabel3.Spring = true;
            // 
            // version
            // 
            this.version.ForeColor = System.Drawing.Color.DarkGray;
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(64, 21);
            this.version.Text = "Version: ";
            // 
            // tabControl1
            // 
            this.tabControl1.ActiveColor = System.Drawing.Color.Green;
            this.tabControl1.AllowDrop = true;
            this.tabControl1.BackTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabControl1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabControl1.ClosingButtonColor = System.Drawing.Color.WhiteSmoke;
            this.tabControl1.ClosingMessage = null;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabControl1.HorizontalLineColor = System.Drawing.Color.Green;
            this.tabControl1.ItemSize = new System.Drawing.Size(240, 16);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabControl1.ShowClosingButton = false;
            this.tabControl1.ShowClosingMessage = false;
            this.tabControl1.Size = new System.Drawing.Size(440, 337);
            this.tabControl1.TabIndex = 17;
            this.tabControl1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 20);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(432, 313);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Directories";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dir_reach_tick);
            this.groupBox1.Controls.Add(this.dir_4_tick);
            this.groupBox1.Controls.Add(this.dir_odst_tick);
            this.groupBox1.Controls.Add(this.dir_3_tick);
            this.groupBox1.Controls.Add(this.dir_2_tick);
            this.groupBox1.Controls.Add(this.dir_ce_tick);
            this.groupBox1.Controls.Add(this.dir_mcc_tick);
            this.groupBox1.Controls.Add(this.dir_data_tick);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.Silver;
            this.groupBox1.Location = new System.Drawing.Point(13, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 302);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Directories";
            // 
            // dir_reach_tick
            // 
            this.dir_reach_tick.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dir_reach_tick.Location = new System.Drawing.Point(16, 265);
            this.dir_reach_tick.Name = "dir_reach_tick";
            this.dir_reach_tick.Size = new System.Drawing.Size(25, 23);
            this.dir_reach_tick.TabIndex = 15;
            this.dir_reach_tick.Text = "...";
            this.dir_reach_tick.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dir_4_tick
            // 
            this.dir_4_tick.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dir_4_tick.Location = new System.Drawing.Point(16, 232);
            this.dir_4_tick.Name = "dir_4_tick";
            this.dir_4_tick.Size = new System.Drawing.Size(25, 23);
            this.dir_4_tick.TabIndex = 14;
            this.dir_4_tick.Text = "...";
            this.dir_4_tick.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dir_odst_tick
            // 
            this.dir_odst_tick.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dir_odst_tick.Location = new System.Drawing.Point(16, 199);
            this.dir_odst_tick.Name = "dir_odst_tick";
            this.dir_odst_tick.Size = new System.Drawing.Size(25, 23);
            this.dir_odst_tick.TabIndex = 13;
            this.dir_odst_tick.Text = "...";
            this.dir_odst_tick.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dir_3_tick
            // 
            this.dir_3_tick.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dir_3_tick.Location = new System.Drawing.Point(16, 166);
            this.dir_3_tick.Name = "dir_3_tick";
            this.dir_3_tick.Size = new System.Drawing.Size(25, 23);
            this.dir_3_tick.TabIndex = 12;
            this.dir_3_tick.Text = "...";
            this.dir_3_tick.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dir_2_tick
            // 
            this.dir_2_tick.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dir_2_tick.Location = new System.Drawing.Point(16, 133);
            this.dir_2_tick.Name = "dir_2_tick";
            this.dir_2_tick.Size = new System.Drawing.Size(25, 23);
            this.dir_2_tick.TabIndex = 11;
            this.dir_2_tick.Text = "...";
            this.dir_2_tick.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dir_ce_tick
            // 
            this.dir_ce_tick.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dir_ce_tick.Location = new System.Drawing.Point(16, 100);
            this.dir_ce_tick.Name = "dir_ce_tick";
            this.dir_ce_tick.Size = new System.Drawing.Size(25, 23);
            this.dir_ce_tick.TabIndex = 10;
            this.dir_ce_tick.Text = "...";
            this.dir_ce_tick.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dir_mcc_tick
            // 
            this.dir_mcc_tick.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dir_mcc_tick.Location = new System.Drawing.Point(16, 67);
            this.dir_mcc_tick.Name = "dir_mcc_tick";
            this.dir_mcc_tick.Size = new System.Drawing.Size(25, 23);
            this.dir_mcc_tick.TabIndex = 9;
            this.dir_mcc_tick.Text = "...";
            this.dir_mcc_tick.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dir_data_tick
            // 
            this.dir_data_tick.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dir_data_tick.Location = new System.Drawing.Point(16, 34);
            this.dir_data_tick.Name = "dir_data_tick";
            this.dir_data_tick.Size = new System.Drawing.Size(25, 23);
            this.dir_data_tick.TabIndex = 8;
            this.dir_data_tick.Text = "...";
            this.dir_data_tick.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label8.Location = new System.Drawing.Point(47, 265);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 23);
            this.label8.TabIndex = 7;
            this.label8.Text = "haloreach";
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(47, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "halo4";
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(47, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "halo3odst";
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(47, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "halo3";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(47, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "halo2";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(47, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "haloce";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(47, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "MCC";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(47, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "data";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dir_mod_orig_reach);
            this.groupBox2.Controls.Add(this.dir_mod_orig_4);
            this.groupBox2.Controls.Add(this.dir_mod_orig_odst);
            this.groupBox2.Controls.Add(this.dir_mod_orig_3);
            this.groupBox2.Controls.Add(this.dir_mod_orig_2);
            this.groupBox2.Controls.Add(this.dir_mod_orig_ce);
            this.groupBox2.Controls.Add(this.dir_mod_orig_mcc);
            this.groupBox2.Controls.Add(this.dir_mod_orig_data);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.ForeColor = System.Drawing.Color.Silver;
            this.groupBox2.Location = new System.Drawing.Point(222, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(197, 302);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mod Backups";
            // 
            // dir_mod_orig_reach
            // 
            this.dir_mod_orig_reach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dir_mod_orig_reach.Location = new System.Drawing.Point(16, 265);
            this.dir_mod_orig_reach.Name = "dir_mod_orig_reach";
            this.dir_mod_orig_reach.Size = new System.Drawing.Size(25, 23);
            this.dir_mod_orig_reach.TabIndex = 15;
            this.dir_mod_orig_reach.Text = "...";
            this.dir_mod_orig_reach.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dir_mod_orig_4
            // 
            this.dir_mod_orig_4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dir_mod_orig_4.Location = new System.Drawing.Point(16, 232);
            this.dir_mod_orig_4.Name = "dir_mod_orig_4";
            this.dir_mod_orig_4.Size = new System.Drawing.Size(25, 23);
            this.dir_mod_orig_4.TabIndex = 14;
            this.dir_mod_orig_4.Text = "...";
            this.dir_mod_orig_4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dir_mod_orig_odst
            // 
            this.dir_mod_orig_odst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dir_mod_orig_odst.Location = new System.Drawing.Point(16, 199);
            this.dir_mod_orig_odst.Name = "dir_mod_orig_odst";
            this.dir_mod_orig_odst.Size = new System.Drawing.Size(25, 23);
            this.dir_mod_orig_odst.TabIndex = 13;
            this.dir_mod_orig_odst.Text = "...";
            this.dir_mod_orig_odst.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dir_mod_orig_3
            // 
            this.dir_mod_orig_3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dir_mod_orig_3.Location = new System.Drawing.Point(16, 166);
            this.dir_mod_orig_3.Name = "dir_mod_orig_3";
            this.dir_mod_orig_3.Size = new System.Drawing.Size(25, 23);
            this.dir_mod_orig_3.TabIndex = 12;
            this.dir_mod_orig_3.Text = "...";
            this.dir_mod_orig_3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dir_mod_orig_2
            // 
            this.dir_mod_orig_2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dir_mod_orig_2.Location = new System.Drawing.Point(16, 133);
            this.dir_mod_orig_2.Name = "dir_mod_orig_2";
            this.dir_mod_orig_2.Size = new System.Drawing.Size(25, 23);
            this.dir_mod_orig_2.TabIndex = 11;
            this.dir_mod_orig_2.Text = "...";
            this.dir_mod_orig_2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dir_mod_orig_ce
            // 
            this.dir_mod_orig_ce.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dir_mod_orig_ce.Location = new System.Drawing.Point(16, 100);
            this.dir_mod_orig_ce.Name = "dir_mod_orig_ce";
            this.dir_mod_orig_ce.Size = new System.Drawing.Size(25, 23);
            this.dir_mod_orig_ce.TabIndex = 10;
            this.dir_mod_orig_ce.Text = "...";
            this.dir_mod_orig_ce.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dir_mod_orig_mcc
            // 
            this.dir_mod_orig_mcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dir_mod_orig_mcc.Location = new System.Drawing.Point(16, 67);
            this.dir_mod_orig_mcc.Name = "dir_mod_orig_mcc";
            this.dir_mod_orig_mcc.Size = new System.Drawing.Size(25, 23);
            this.dir_mod_orig_mcc.TabIndex = 9;
            this.dir_mod_orig_mcc.Text = "...";
            this.dir_mod_orig_mcc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dir_mod_orig_data
            // 
            this.dir_mod_orig_data.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dir_mod_orig_data.Location = new System.Drawing.Point(16, 34);
            this.dir_mod_orig_data.Name = "dir_mod_orig_data";
            this.dir_mod_orig_data.Size = new System.Drawing.Size(25, 23);
            this.dir_mod_orig_data.TabIndex = 8;
            this.dir_mod_orig_data.Text = "...";
            this.dir_mod_orig_data.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label17
            // 
            this.label17.Cursor = System.Windows.Forms.Cursors.Default;
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label17.Location = new System.Drawing.Point(47, 265);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 23);
            this.label17.TabIndex = 7;
            this.label17.Text = "haloreach";
            this.label17.DoubleClick += new System.EventHandler(this.backupFolderCall);
            this.label17.MouseEnter += new System.EventHandler(this.backup_MouseEnter);
            this.label17.MouseLeave += new System.EventHandler(this.backup_MouseLeave);
            // 
            // label18
            // 
            this.label18.Cursor = System.Windows.Forms.Cursors.Default;
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label18.Location = new System.Drawing.Point(47, 232);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 23);
            this.label18.TabIndex = 6;
            this.label18.Text = "halo4";
            this.label18.DoubleClick += new System.EventHandler(this.backupFolderCall);
            this.label18.MouseEnter += new System.EventHandler(this.backup_MouseEnter);
            this.label18.MouseLeave += new System.EventHandler(this.backup_MouseLeave);
            // 
            // label19
            // 
            this.label19.Cursor = System.Windows.Forms.Cursors.Default;
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label19.Location = new System.Drawing.Point(47, 199);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(79, 23);
            this.label19.TabIndex = 5;
            this.label19.Text = "halo3odst";
            this.label19.DoubleClick += new System.EventHandler(this.backupFolderCall);
            this.label19.MouseEnter += new System.EventHandler(this.backup_MouseEnter);
            this.label19.MouseLeave += new System.EventHandler(this.backup_MouseLeave);
            // 
            // label20
            // 
            this.label20.Cursor = System.Windows.Forms.Cursors.Default;
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label20.Location = new System.Drawing.Point(47, 166);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 23);
            this.label20.TabIndex = 4;
            this.label20.Text = "halo3";
            this.label20.DoubleClick += new System.EventHandler(this.backupFolderCall);
            this.label20.MouseEnter += new System.EventHandler(this.backup_MouseEnter);
            this.label20.MouseLeave += new System.EventHandler(this.backup_MouseLeave);
            // 
            // label21
            // 
            this.label21.Cursor = System.Windows.Forms.Cursors.Default;
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label21.Location = new System.Drawing.Point(47, 133);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 23);
            this.label21.TabIndex = 3;
            this.label21.Text = "halo2";
            this.label21.DoubleClick += new System.EventHandler(this.backupFolderCall);
            this.label21.MouseEnter += new System.EventHandler(this.backup_MouseEnter);
            this.label21.MouseLeave += new System.EventHandler(this.backup_MouseLeave);
            // 
            // label22
            // 
            this.label22.Cursor = System.Windows.Forms.Cursors.Default;
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label22.Location = new System.Drawing.Point(47, 100);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 23);
            this.label22.TabIndex = 2;
            this.label22.Text = "haloce";
            this.label22.DoubleClick += new System.EventHandler(this.backupFolderCall);
            this.label22.MouseEnter += new System.EventHandler(this.backup_MouseEnter);
            this.label22.MouseLeave += new System.EventHandler(this.backup_MouseLeave);
            // 
            // label23
            // 
            this.label23.Cursor = System.Windows.Forms.Cursors.Default;
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label23.Location = new System.Drawing.Point(47, 67);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(79, 23);
            this.label23.TabIndex = 1;
            this.label23.Text = "MCC";
            this.label23.DoubleClick += new System.EventHandler(this.backupFolderCall);
            this.label23.MouseEnter += new System.EventHandler(this.backup_MouseEnter);
            this.label23.MouseLeave += new System.EventHandler(this.backup_MouseLeave);
            // 
            // label24
            // 
            this.label24.Cursor = System.Windows.Forms.Cursors.Default;
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label24.Location = new System.Drawing.Point(47, 34);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(79, 23);
            this.label24.TabIndex = 0;
            this.label24.Text = "data";
            this.label24.DoubleClick += new System.EventHandler(this.backupFolderCall);
            this.label24.MouseEnter += new System.EventHandler(this.backup_MouseEnter);
            this.label24.MouseLeave += new System.EventHandler(this.backup_MouseLeave);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabPage2.Controls.Add(this.treeView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 20);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(432, 313);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Branches";
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(426, 307);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeCheck);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.linkLabel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 20);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(432, 313);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Config / About";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label9.Location = new System.Drawing.Point(68, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(253, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "To learn about this tool, please visit it\'s";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel1.Location = new System.Drawing.Point(318, 7);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(47, 17);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "github";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 370);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::MCC_Mod_Version_Manager.Properties.Resources.version;
            this.MaximizeBox = false;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MCC Mod Version Manager";
            this.Load += new System.EventHandler(this.main_Load);
            this.branch_root_ctx.ResumeLayout(false);
            this.branch_ctx.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }
        
        
        #endregion
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private DarkContextMenu branch_root_ctx;
        private System.Windows.Forms.ToolStripMenuItem addNewBranchToolStripMenuItem;
        private DarkContextMenu branch_ctx;
        private System.Windows.Forms.ToolStripMenuItem browseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
        private MCC_Mod_Version_Manager.main.NoClickTree treeView1;
        private System.Windows.Forms.ToolStripMenuItem openInExplorerToolStripMenuItem;
        private DarkLabel label9;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DarkLabel dir_reach_tick;
        private DarkLabel dir_4_tick;
        private DarkLabel dir_odst_tick;
        private DarkLabel dir_3_tick;
        private DarkLabel dir_2_tick;
        private DarkLabel dir_ce_tick;
        private DarkLabel dir_mcc_tick;
        private DarkLabel dir_data_tick;
        private DarkLabel label8;
        private DarkLabel label7;
        private DarkLabel label6;
        private DarkLabel label5;
        private DarkLabel label4;
        private DarkLabel label3;
        private DarkLabel label2;
        private DarkLabel label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DarkLabel dir_mod_orig_reach;
        private DarkLabel dir_mod_orig_4;
        private DarkLabel dir_mod_orig_odst;
        private DarkLabel dir_mod_orig_3;
        private DarkLabel dir_mod_orig_2;
        private DarkLabel dir_mod_orig_ce;
        private DarkLabel dir_mod_orig_mcc;
        private DarkLabel dir_mod_orig_data;
        private DarkLabel label17;
        private DarkLabel label18;
        private DarkLabel label19;
        private DarkLabel label20;
        private DarkLabel label21;
        private DarkLabel label22;
        private DarkLabel label23;
        private DarkLabel label24;
        private VisualStudioTabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem openInExplorerToolStripMenuItem1;
        private DarkStatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel version;
    }
}

