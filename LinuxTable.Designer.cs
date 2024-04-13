namespace LinuxSystemTables
{
    partial class LinuxTable
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinuxTable));
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.filterTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.mainBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.mainListView = new System.Windows.Forms.ListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.secondaryListView = new System.Windows.Forms.ListView();
            this.processMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.terminateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suspendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binrayAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stopServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPermissionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.whatIsThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.processMenuStrip.SuspendLayout();
            this.serviceMenuStrip.SuspendLayout();
            this.usersMenuStrip.SuspendLayout();
            this.logsMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterTextBox,
            this.toolStripButton1});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mainToolStrip.Size = new System.Drawing.Size(777, 27);
            this.mainToolStrip.TabIndex = 0;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // filterTextBox
            // 
            this.filterTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(223, 27);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Checked = true;
            this.toolStripButton1.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // mainBackgroundWorker
            // 
            this.mainBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // mainListView
            // 
            this.mainListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainListView.FullRowSelect = true;
            this.mainListView.HideSelection = false;
            this.mainListView.Location = new System.Drawing.Point(0, 0);
            this.mainListView.MultiSelect = false;
            this.mainListView.Name = "mainListView";
            this.mainListView.Size = new System.Drawing.Size(777, 204);
            this.mainListView.TabIndex = 1;
            this.mainListView.UseCompatibleStateImageBehavior = false;
            this.mainListView.View = System.Windows.Forms.View.Details;
            this.mainListView.SelectedIndexChanged += new System.EventHandler(this.mainListView_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mainListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.secondaryListView);
            this.splitContainer1.Size = new System.Drawing.Size(777, 408);
            this.splitContainer1.SplitterDistance = 204;
            this.splitContainer1.TabIndex = 2;
            // 
            // secondaryListView
            // 
            this.secondaryListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.secondaryListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondaryListView.FullRowSelect = true;
            this.secondaryListView.HideSelection = false;
            this.secondaryListView.Location = new System.Drawing.Point(0, 0);
            this.secondaryListView.MultiSelect = false;
            this.secondaryListView.Name = "secondaryListView";
            this.secondaryListView.Size = new System.Drawing.Size(777, 200);
            this.secondaryListView.TabIndex = 2;
            this.secondaryListView.UseCompatibleStateImageBehavior = false;
            this.secondaryListView.View = System.Windows.Forms.View.Details;
            // 
            // processMenuStrip
            // 
            this.processMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.processMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.terminateToolStripMenuItem,
            this.suspendToolStripMenuItem,
            this.binrayAnalysisToolStripMenuItem});
            this.processMenuStrip.Name = "processMenuStrip";
            this.processMenuStrip.Size = new System.Drawing.Size(177, 76);
            // 
            // terminateToolStripMenuItem
            // 
            this.terminateToolStripMenuItem.Name = "terminateToolStripMenuItem";
            this.terminateToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.terminateToolStripMenuItem.Text = "Terminate";
            // 
            // suspendToolStripMenuItem
            // 
            this.suspendToolStripMenuItem.Name = "suspendToolStripMenuItem";
            this.suspendToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.suspendToolStripMenuItem.Text = "Suspend";
            // 
            // binrayAnalysisToolStripMenuItem
            // 
            this.binrayAnalysisToolStripMenuItem.Name = "binrayAnalysisToolStripMenuItem";
            this.binrayAnalysisToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.binrayAnalysisToolStripMenuItem.Text = "Binray Analysis";
            this.binrayAnalysisToolStripMenuItem.Click += new System.EventHandler(this.binrayAnalysisToolStripMenuItem_Click);
            // 
            // serviceMenuStrip
            // 
            this.serviceMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.serviceMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stopServiceToolStripMenuItem,
            this.restartServiceToolStripMenuItem});
            this.serviceMenuStrip.Name = "serviceMenuStrip";
            this.serviceMenuStrip.Size = new System.Drawing.Size(176, 52);
            // 
            // stopServiceToolStripMenuItem
            // 
            this.stopServiceToolStripMenuItem.Name = "stopServiceToolStripMenuItem";
            this.stopServiceToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.stopServiceToolStripMenuItem.Text = "Stop Service";
            // 
            // restartServiceToolStripMenuItem
            // 
            this.restartServiceToolStripMenuItem.Name = "restartServiceToolStripMenuItem";
            this.restartServiceToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.restartServiceToolStripMenuItem.Text = "Restart Service";
            // 
            // usersMenuStrip
            // 
            this.usersMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.usersMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeUserToolStripMenuItem,
            this.editPermissionsToolStripMenuItem});
            this.usersMenuStrip.Name = "usersMenuStrip";
            this.usersMenuStrip.Size = new System.Drawing.Size(185, 52);
            // 
            // removeUserToolStripMenuItem
            // 
            this.removeUserToolStripMenuItem.Name = "removeUserToolStripMenuItem";
            this.removeUserToolStripMenuItem.Size = new System.Drawing.Size(184, 24);
            this.removeUserToolStripMenuItem.Text = "Remove User";
            // 
            // editPermissionsToolStripMenuItem
            // 
            this.editPermissionsToolStripMenuItem.Name = "editPermissionsToolStripMenuItem";
            this.editPermissionsToolStripMenuItem.Size = new System.Drawing.Size(184, 24);
            this.editPermissionsToolStripMenuItem.Text = "Edit Permissions";
            // 
            // logsMenuStrip
            // 
            this.logsMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.logsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whatIsThisToolStripMenuItem});
            this.logsMenuStrip.Name = "logsMenuStrip";
            this.logsMenuStrip.Size = new System.Drawing.Size(157, 28);
            // 
            // whatIsThisToolStripMenuItem
            // 
            this.whatIsThisToolStripMenuItem.Name = "whatIsThisToolStripMenuItem";
            this.whatIsThisToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.whatIsThisToolStripMenuItem.Text = "Web Search";
            // 
            // LinuxTable
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mainToolStrip);
            this.Name = "LinuxTable";
            this.Size = new System.Drawing.Size(777, 435);
            this.Load += new System.EventHandler(this.LinuxTable_Load);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.processMenuStrip.ResumeLayout(false);
            this.serviceMenuStrip.ResumeLayout(false);
            this.usersMenuStrip.ResumeLayout(false);
            this.logsMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.ComponentModel.BackgroundWorker mainBackgroundWorker;
        private System.Windows.Forms.ListView mainListView;
        private System.Windows.Forms.ToolStripTextBox filterTextBox;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView secondaryListView;
        private System.Windows.Forms.ContextMenuStrip processMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem terminateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suspendToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip serviceMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem stopServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartServiceToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip usersMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editPermissionsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip logsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem whatIsThisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binrayAnalysisToolStripMenuItem;
    }
}
