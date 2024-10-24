namespace xrmtoolbox_SetDefaultView
{
    partial class MyPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyPluginControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbLoadEntities = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSetDefaultView = new System.Windows.Forms.ToolStripButton();
            this.listViewEntities = new System.Windows.Forms.ListView();
            this.displayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvSystemView = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewSystemUsers = new System.Windows.Forms.ListView();
            this.fullname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbSearchUser = new System.Windows.Forms.TextBox();
            this.lbSearchUser = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSyncUser = new System.Windows.Forms.ToolStripButton();
            this.gbEntities = new System.Windows.Forms.GroupBox();
            this.gbViews = new System.Windows.Forms.GroupBox();
            this.gbUsers = new System.Windows.Forms.GroupBox();
            this.toolStripMenu.SuspendLayout();
            this.gbEntities.SuspendLayout();
            this.gbViews.SuspendLayout();
            this.gbUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLoadEntities,
            this.tssSeparator1,
            this.tsbSetDefaultView,
            this.toolStripSeparator1,
            this.tsbSyncUser});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(2017, 31);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbLoadEntities
            // 
            this.tsbLoadEntities.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadEntities.Image")));
            this.tsbLoadEntities.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tsbLoadEntities.Name = "tsbLoadEntities";
            this.tsbLoadEntities.Size = new System.Drawing.Size(122, 28);
            this.tsbLoadEntities.Text = "Load entities";
            this.tsbLoadEntities.Click += new System.EventHandler(this.tsbLoadEntities_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbSetDefaultView
            // 
            this.tsbSetDefaultView.Image = ((System.Drawing.Image)(resources.GetObject("tsbSetDefaultView.Image")));
            this.tsbSetDefaultView.Name = "tsbSetDefaultView";
            this.tsbSetDefaultView.Size = new System.Drawing.Size(147, 28);
            this.tsbSetDefaultView.Text = "Set Default View";
            this.tsbSetDefaultView.Click += new System.EventHandler(this.tsb_SetDefaultView_Click);
            // 
            // listViewEntities
            // 
            this.listViewEntities.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewEntities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.displayName,
            this.logicalName});
            this.listViewEntities.FullRowSelect = true;
            this.listViewEntities.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewEntities.HideSelection = false;
            this.listViewEntities.Location = new System.Drawing.Point(36, 93);
            this.listViewEntities.Name = "listViewEntities";
            this.listViewEntities.Size = new System.Drawing.Size(523, 964);
            this.listViewEntities.TabIndex = 6;
            this.listViewEntities.UseCompatibleStateImageBehavior = false;
            this.listViewEntities.View = System.Windows.Forms.View.Details;
            this.listViewEntities.SelectedIndexChanged += new System.EventHandler(this.listViewEntities_SelectedIndexChanged);
            // 
            // displayName
            // 
            this.displayName.Text = "Display Name";
            this.displayName.Width = 250;
            // 
            // logicalName
            // 
            this.logicalName.Text = "Logical Name";
            this.logicalName.Width = 100;
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(78, 43);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(472, 22);
            this.tbSearch.TabIndex = 7;
            this.tbSearch.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Search";
            // 
            // lvSystemView
            // 
            this.lvSystemView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lvSystemView.CheckBoxes = true;
            this.lvSystemView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name});
            this.lvSystemView.HideSelection = false;
            this.lvSystemView.Location = new System.Drawing.Point(37, 99);
            this.lvSystemView.Name = "lvSystemView";
            this.lvSystemView.Size = new System.Drawing.Size(403, 964);
            this.lvSystemView.TabIndex = 9;
            this.lvSystemView.UseCompatibleStateImageBehavior = false;
            this.lvSystemView.View = System.Windows.Forms.View.Details;
            this.lvSystemView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewSystemView_ItemChecked);
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 300;
            // 
            // listViewSystemUsers
            // 
            this.listViewSystemUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewSystemUsers.CheckBoxes = true;
            this.listViewSystemUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fullname,
            this.email});
            this.listViewSystemUsers.HideSelection = false;
            this.listViewSystemUsers.Location = new System.Drawing.Point(42, 110);
            this.listViewSystemUsers.Name = "listViewSystemUsers";
            this.listViewSystemUsers.Size = new System.Drawing.Size(739, 953);
            this.listViewSystemUsers.TabIndex = 10;
            this.listViewSystemUsers.UseCompatibleStateImageBehavior = false;
            this.listViewSystemUsers.View = System.Windows.Forms.View.Details;
            this.listViewSystemUsers.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewSystemUsers_ItemChecked);
            // 
            // fullname
            // 
            this.fullname.Text = "Full name";
            this.fullname.Width = 300;
            // 
            // email
            // 
            this.email.Text = "Email";
            this.email.Width = 300;
            // 
            // tbSearchUser
            // 
            this.tbSearchUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearchUser.Location = new System.Drawing.Point(191, 57);
            this.tbSearchUser.Name = "tbSearchUser";
            this.tbSearchUser.Size = new System.Drawing.Size(590, 22);
            this.tbSearchUser.TabIndex = 11;
            this.tbSearchUser.TextChanged += new System.EventHandler(this.txtFilterUser_TextChanged);
            // 
            // lbSearchUser
            // 
            this.lbSearchUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbSearchUser.AutoSize = true;
            this.lbSearchUser.Location = new System.Drawing.Point(39, 60);
            this.lbSearchUser.Name = "lbSearchUser";
            this.lbSearchUser.Size = new System.Drawing.Size(50, 16);
            this.lbSearchUser.TabIndex = 12;
            this.lbSearchUser.Text = "Search";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbSyncUser
            // 
            this.tsbSyncUser.Image = ((System.Drawing.Image)(resources.GetObject("tsbSyncUser.Image")));
            this.tsbSyncUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSyncUser.Name = "tsbSyncUser";
            this.tsbSyncUser.Size = new System.Drawing.Size(157, 28);
            this.tsbSyncUser.Text = "Sync Entra ID User";
            this.tsbSyncUser.Click += new System.EventHandler(this.tsbSyncUser_Click);
            // 
            // gbEntities
            // 
            this.gbEntities.Controls.Add(this.listViewEntities);
            this.gbEntities.Controls.Add(this.tbSearch);
            this.gbEntities.Controls.Add(this.label1);
            this.gbEntities.Location = new System.Drawing.Point(29, 50);
            this.gbEntities.Name = "gbEntities";
            this.gbEntities.Size = new System.Drawing.Size(596, 1095);
            this.gbEntities.TabIndex = 13;
            this.gbEntities.TabStop = false;
            this.gbEntities.Text = "Entities";
            // 
            // gbViews
            // 
            this.gbViews.Controls.Add(this.lvSystemView);
            this.gbViews.Location = new System.Drawing.Point(654, 50);
            this.gbViews.Name = "gbViews";
            this.gbViews.Size = new System.Drawing.Size(478, 1095);
            this.gbViews.TabIndex = 14;
            this.gbViews.TabStop = false;
            this.gbViews.Text = "Views";
            // 
            // gbUsers
            // 
            this.gbUsers.Controls.Add(this.lbSearchUser);
            this.gbUsers.Controls.Add(this.listViewSystemUsers);
            this.gbUsers.Controls.Add(this.tbSearchUser);
            this.gbUsers.Location = new System.Drawing.Point(1162, 50);
            this.gbUsers.Name = "gbUsers";
            this.gbUsers.Size = new System.Drawing.Size(823, 1095);
            this.gbUsers.TabIndex = 15;
            this.gbUsers.TabStop = false;
            this.gbUsers.Text = "Users";
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.gbEntities);
            this.Controls.Add(this.gbViews);
            this.Controls.Add(this.gbUsers);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(2017, 1169);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.gbEntities.ResumeLayout(false);
            this.gbEntities.PerformLayout();
            this.gbViews.ResumeLayout(false);
            this.gbUsers.ResumeLayout(false);
            this.gbUsers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbLoadEntities;
        private System.Windows.Forms.ToolStripButton tsbSetDefaultView;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.ListView listViewEntities;
        private System.Windows.Forms.ColumnHeader displayName;
        private System.Windows.Forms.ColumnHeader logicalName;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvSystemView;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ListView listViewSystemUsers;
        private System.Windows.Forms.ColumnHeader fullname;
        private System.Windows.Forms.ColumnHeader email;
        private System.Windows.Forms.TextBox tbSearchUser;
        private System.Windows.Forms.Label lbSearchUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSyncUser;
        private System.Windows.Forms.GroupBox gbEntities;
        private System.Windows.Forms.GroupBox gbViews;
        private System.Windows.Forms.GroupBox gbUsers;
    }
}
