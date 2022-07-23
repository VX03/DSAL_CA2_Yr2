namespace DSAL_CA2_Yr2
{
    partial class parentForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.formToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roleFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1752, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // formToolStripMenuItem
            // 
            this.formToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roleFormToolStripMenuItem,
            this.employeeFormToolStripMenuItem,
            this.projectFormToolStripMenuItem});
            this.formToolStripMenuItem.Name = "formToolStripMenuItem";
            this.formToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.formToolStripMenuItem.Text = "Form";
            // 
            // roleFormToolStripMenuItem
            // 
            this.roleFormToolStripMenuItem.Name = "roleFormToolStripMenuItem";
            this.roleFormToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.roleFormToolStripMenuItem.Text = "Role Form";
            this.roleFormToolStripMenuItem.Click += new System.EventHandler(this.RoleFormToolStripMenuItem_Click);
            // 
            // employeeFormToolStripMenuItem
            // 
            this.employeeFormToolStripMenuItem.Name = "employeeFormToolStripMenuItem";
            this.employeeFormToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.employeeFormToolStripMenuItem.Text = "Employee Form";
            this.employeeFormToolStripMenuItem.Click += new System.EventHandler(this.EmployeeFormToolStripMenuItem_Click);
            // 
            // projectFormToolStripMenuItem
            // 
            this.projectFormToolStripMenuItem.Name = "projectFormToolStripMenuItem";
            this.projectFormToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.projectFormToolStripMenuItem.Text = "Project Form";
            this.projectFormToolStripMenuItem.Click += new System.EventHandler(this.ProjectFormToolStripMenuItem_Click);
            // 
            // parentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1752, 1084);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "parentForm";
            this.Text = "parentForm";
            this.Load += new System.EventHandler(this.parentForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem formToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roleFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectFormToolStripMenuItem;
    }
}