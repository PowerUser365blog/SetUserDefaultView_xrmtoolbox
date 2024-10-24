namespace xrmtoolbox_SetDefaultView
{
    partial class Form1
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
            this.tbEntraID = new System.Windows.Forms.TextBox();
            this.lbAddId = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbEntraID
            // 
            this.tbEntraID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEntraID.Location = new System.Drawing.Point(137, 138);
            this.tbEntraID.Name = "tbEntraID";
            this.tbEntraID.Size = new System.Drawing.Size(312, 22);
            this.tbEntraID.TabIndex = 0;
            // 
            // lbAddId
            // 
            this.lbAddId.AutoSize = true;
            this.lbAddId.Location = new System.Drawing.Point(134, 106);
            this.lbAddId.Name = "lbAddId";
            this.lbAddId.Size = new System.Drawing.Size(111, 16);
            this.lbAddId.TabIndex = 1;
            this.lbAddId.Text = "Add user Entra ID";
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(231, 204);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(103, 34);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 346);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lbAddId);
            this.Controls.Add(this.tbEntraID);
            this.Name = "Form1";
            this.Text = "Entra ID GUID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbEntraID;
        private System.Windows.Forms.Label lbAddId;
        private System.Windows.Forms.Button btnAccept;
    }
}