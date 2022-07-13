namespace DSAL_CA2_Yr2
{
    partial class ReplaceEmployeeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEmployee = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.treeViewEmployee = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSwap = new System.Windows.Forms.Button();
            this.tbProject = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbRole = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSalary = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbReportingOfficer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.UUID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(51, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "You are replacing";
            // 
            // tbEmployee
            // 
            this.tbEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEmployee.Enabled = false;
            this.tbEmployee.Location = new System.Drawing.Point(181, 69);
            this.tbEmployee.Name = "tbEmployee";
            this.tbEmployee.Size = new System.Drawing.Size(219, 27);
            this.tbEmployee.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(266, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Select Employee Node to replace with:";
            // 
            // treeViewEmployee
            // 
            this.treeViewEmployee.Location = new System.Drawing.Point(51, 151);
            this.treeViewEmployee.Name = "treeViewEmployee";
            this.treeViewEmployee.Size = new System.Drawing.Size(379, 420);
            this.treeViewEmployee.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSwap);
            this.groupBox1.Controls.Add(this.tbProject);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbRole);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbSalary);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbReportingOfficer);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbId);
            this.groupBox1.Controls.Add(this.UUID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(455, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 420);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btnSwap
            // 
            this.btnSwap.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnSwap.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSwap.Location = new System.Drawing.Point(138, 372);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(156, 29);
            this.btnSwap.TabIndex = 14;
            this.btnSwap.Text = "Swap";
            this.btnSwap.UseVisualStyleBackColor = false;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // tbProject
            // 
            this.tbProject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbProject.Enabled = false;
            this.tbProject.Location = new System.Drawing.Point(199, 327);
            this.tbProject.Name = "tbProject";
            this.tbProject.Size = new System.Drawing.Size(193, 27);
            this.tbProject.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(44, 328);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 23);
            this.label9.TabIndex = 12;
            this.label9.Text = "Projects";
            // 
            // tbRole
            // 
            this.tbRole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRole.Enabled = false;
            this.tbRole.Location = new System.Drawing.Point(199, 279);
            this.tbRole.Name = "tbRole";
            this.tbRole.Size = new System.Drawing.Size(193, 27);
            this.tbRole.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(44, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "Role";
            // 
            // tbSalary
            // 
            this.tbSalary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSalary.Enabled = false;
            this.tbSalary.Location = new System.Drawing.Point(199, 234);
            this.tbSalary.Name = "tbSalary";
            this.tbSalary.Size = new System.Drawing.Size(193, 27);
            this.tbSalary.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(44, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 23);
            this.label7.TabIndex = 8;
            this.label7.Text = "Salary ($$)";
            // 
            // tbName
            // 
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbName.Enabled = false;
            this.tbName.Location = new System.Drawing.Point(199, 190);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(193, 27);
            this.tbName.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(44, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Name";
            // 
            // tbReportingOfficer
            // 
            this.tbReportingOfficer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbReportingOfficer.Enabled = false;
            this.tbReportingOfficer.Location = new System.Drawing.Point(199, 146);
            this.tbReportingOfficer.Name = "tbReportingOfficer";
            this.tbReportingOfficer.Size = new System.Drawing.Size(193, 27);
            this.tbReportingOfficer.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(44, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Reporting Officer";
            // 
            // tbId
            // 
            this.tbId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbId.Enabled = false;
            this.tbId.Location = new System.Drawing.Point(199, 97);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(193, 27);
            this.tbId.TabIndex = 3;
            // 
            // UUID
            // 
            this.UUID.AutoSize = true;
            this.UUID.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UUID.Location = new System.Drawing.Point(44, 98);
            this.UUID.Name = "UUID";
            this.UUID.Size = new System.Drawing.Size(52, 23);
            this.UUID.TabIndex = 2;
            this.UUID.Text = "UUID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(155, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Replace With";
            // 
            // ReplaceEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 599);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeViewEmployee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbEmployee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ReplaceEmployeeForm";
            this.Text = "ReplaceEmployeeForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbEmployee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView treeViewEmployee;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSwap;
        private System.Windows.Forms.TextBox tbProject;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbRole;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbSalary;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbReportingOfficer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label UUID;
        private System.Windows.Forms.Label label4;
    }
}