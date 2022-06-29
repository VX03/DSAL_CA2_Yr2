namespace DSAL_CA2_Yr2
{
    partial class ManageEmployee
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
            this.btnCollapseAll = new System.Windows.Forms.Button();
            this.btnExpandAll = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.treeViewEmployee = new System.Windows.Forms.TreeView();
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbSalaryAccountable = new System.Windows.Forms.CheckBox();
            this.tbProject = new System.Windows.Forms.TextBox();
            this.tbRole = new System.Windows.Forms.TextBox();
            this.tbSalary = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDummyData = new System.Windows.Forms.CheckBox();
            this.tbReportingOfficer = new System.Windows.Forms.TextBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.Reporting = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCollapseAll
            // 
            this.btnCollapseAll.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCollapseAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCollapseAll.Location = new System.Drawing.Point(1248, 45);
            this.btnCollapseAll.Name = "btnCollapseAll";
            this.btnCollapseAll.Size = new System.Drawing.Size(123, 29);
            this.btnCollapseAll.TabIndex = 24;
            this.btnCollapseAll.Text = "Collapse All";
            this.btnCollapseAll.UseVisualStyleBackColor = false;
            this.btnCollapseAll.Click += new System.EventHandler(this.btnCollapseAll_Click);
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnExpandAll.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExpandAll.Location = new System.Drawing.Point(1099, 45);
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(123, 29);
            this.btnExpandAll.TabIndex = 23;
            this.btnExpandAll.Text = "Expand All";
            this.btnExpandAll.UseVisualStyleBackColor = false;
            this.btnExpandAll.Click += new System.EventHandler(this.btnExpandAll_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(410, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(450, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Right Click to perform actions such as edit, delete, or remove roles.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(410, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Employee Node Tree View";
            // 
            // treeViewEmployee
            // 
            this.treeViewEmployee.Location = new System.Drawing.Point(410, 95);
            this.treeViewEmployee.Name = "treeViewEmployee";
            this.treeViewEmployee.Size = new System.Drawing.Size(982, 705);
            this.treeViewEmployee.TabIndex = 20;
            // 
            // tbConsole
            // 
            this.tbConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbConsole.Enabled = false;
            this.tbConsole.Location = new System.Drawing.Point(12, 529);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.Size = new System.Drawing.Size(381, 271);
            this.tbConsole.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(12, 506);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Console";
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnLoad.Location = new System.Drawing.Point(285, 454);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(108, 29);
            this.btnLoad.TabIndex = 17;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSave.Location = new System.Drawing.Point(153, 454);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 29);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnReset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReset.Location = new System.Drawing.Point(12, 454);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(123, 29);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbSalaryAccountable);
            this.groupBox1.Controls.Add(this.tbProject);
            this.groupBox1.Controls.Add(this.tbRole);
            this.groupBox1.Controls.Add(this.tbSalary);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbDummyData);
            this.groupBox1.Controls.Add(this.tbReportingOfficer);
            this.groupBox1.Controls.Add(this.tbId);
            this.groupBox1.Controls.Add(this.Reporting);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 426);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // cbSalaryAccountable
            // 
            this.cbSalaryAccountable.AutoSize = true;
            this.cbSalaryAccountable.Enabled = false;
            this.cbSalaryAccountable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbSalaryAccountable.Location = new System.Drawing.Point(189, 342);
            this.cbSalaryAccountable.Name = "cbSalaryAccountable";
            this.cbSalaryAccountable.Size = new System.Drawing.Size(172, 24);
            this.cbSalaryAccountable.TabIndex = 15;
            this.cbSalaryAccountable.Text = "Salary Accountable?";
            this.cbSalaryAccountable.UseVisualStyleBackColor = true;
            // 
            // tbProject
            // 
            this.tbProject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbProject.Enabled = false;
            this.tbProject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbProject.Location = new System.Drawing.Point(181, 289);
            this.tbProject.Name = "tbProject";
            this.tbProject.Size = new System.Drawing.Size(180, 27);
            this.tbProject.TabIndex = 14;
            // 
            // tbRole
            // 
            this.tbRole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRole.Enabled = false;
            this.tbRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbRole.Location = new System.Drawing.Point(181, 246);
            this.tbRole.Name = "tbRole";
            this.tbRole.Size = new System.Drawing.Size(180, 27);
            this.tbRole.TabIndex = 13;
            // 
            // tbSalary
            // 
            this.tbSalary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSalary.Enabled = false;
            this.tbSalary.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbSalary.Location = new System.Drawing.Point(181, 207);
            this.tbSalary.Name = "tbSalary";
            this.tbSalary.Size = new System.Drawing.Size(180, 27);
            this.tbSalary.TabIndex = 12;
            // 
            // tbName
            // 
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbName.Enabled = false;
            this.tbName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbName.Location = new System.Drawing.Point(181, 164);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(180, 27);
            this.tbName.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(39, 291);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "Projects";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(39, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Role";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(39, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Salary ($$)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(39, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(141, 390);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Read-Only";
            // 
            // cbDummyData
            // 
            this.cbDummyData.AutoSize = true;
            this.cbDummyData.Enabled = false;
            this.cbDummyData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbDummyData.Location = new System.Drawing.Point(24, 342);
            this.cbDummyData.Name = "cbDummyData";
            this.cbDummyData.Size = new System.Drawing.Size(131, 24);
            this.cbDummyData.TabIndex = 5;
            this.cbDummyData.Text = "Dummy Data?";
            this.cbDummyData.UseVisualStyleBackColor = true;
            // 
            // tbReportingOfficer
            // 
            this.tbReportingOfficer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbReportingOfficer.Enabled = false;
            this.tbReportingOfficer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbReportingOfficer.Location = new System.Drawing.Point(181, 119);
            this.tbReportingOfficer.Name = "tbReportingOfficer";
            this.tbReportingOfficer.Size = new System.Drawing.Size(180, 27);
            this.tbReportingOfficer.TabIndex = 4;
            // 
            // tbId
            // 
            this.tbId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbId.Enabled = false;
            this.tbId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbId.Location = new System.Drawing.Point(181, 81);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(180, 27);
            this.tbId.TabIndex = 3;
            // 
            // Reporting
            // 
            this.Reporting.AutoSize = true;
            this.Reporting.Enabled = false;
            this.Reporting.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Reporting.Location = new System.Drawing.Point(39, 121);
            this.Reporting.Name = "Reporting";
            this.Reporting.Size = new System.Drawing.Size(131, 20);
            this.Reporting.TabIndex = 2;
            this.Reporting.Text = "Reporting Officer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(39, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "UUID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(69, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected Employee Node Information";
            // 
            // ManageEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 816);
            this.Controls.Add(this.btnCollapseAll);
            this.Controls.Add(this.btnExpandAll);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.treeViewEmployee);
            this.Controls.Add(this.tbConsole);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.groupBox1);
            this.Name = "ManageEmployee";
            this.Text = "ManageEmployee";
            this.Load += new System.EventHandler(this.ManageEmployee_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCollapseAll;
        private System.Windows.Forms.Button btnExpandAll;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TreeView treeViewEmployee;
        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbSalaryAccountable;
        private System.Windows.Forms.TextBox tbProject;
        private System.Windows.Forms.TextBox tbRole;
        private System.Windows.Forms.TextBox tbSalary;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbDummyData;
        private System.Windows.Forms.TextBox tbReportingOfficer;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label Reporting;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}