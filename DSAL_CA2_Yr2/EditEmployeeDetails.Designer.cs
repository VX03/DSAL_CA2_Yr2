namespace DSAL_CA2_Yr2
{
    partial class EditEmployeeDetails
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
            this.cbSalaryAccountable = new System.Windows.Forms.CheckBox();
            this.comboRole = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSalary = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbDummyData = new System.Windows.Forms.CheckBox();
            this.tbReportingOfficer = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbSalaryAccountable
            // 
            this.cbSalaryAccountable.AutoSize = true;
            this.cbSalaryAccountable.Enabled = false;
            this.cbSalaryAccountable.Location = new System.Drawing.Point(320, 282);
            this.cbSalaryAccountable.Name = "cbSalaryAccountable";
            this.cbSalaryAccountable.Size = new System.Drawing.Size(165, 24);
            this.cbSalaryAccountable.TabIndex = 43;
            this.cbSalaryAccountable.Text = "Salary Accountable?";
            this.cbSalaryAccountable.UseVisualStyleBackColor = true;
            // 
            // comboRole
            // 
            this.comboRole.Enabled = false;
            this.comboRole.FormattingEnabled = true;
            this.comboRole.Location = new System.Drawing.Point(287, 239);
            this.comboRole.Name = "comboRole";
            this.comboRole.Size = new System.Drawing.Size(216, 28);
            this.comboRole.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(74, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 23);
            this.label5.TabIndex = 41;
            this.label5.Text = "Role";
            // 
            // tbSalary
            // 
            this.tbSalary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSalary.Location = new System.Drawing.Point(287, 192);
            this.tbSalary.Name = "tbSalary";
            this.tbSalary.Size = new System.Drawing.Size(216, 27);
            this.tbSalary.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(74, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 23);
            this.label4.TabIndex = 39;
            this.label4.Text = "Salary ($$)";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(297, 323);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(151, 29);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAdd.Location = new System.Drawing.Point(97, 323);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(151, 29);
            this.btnAdd.TabIndex = 37;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbDummyData
            // 
            this.cbDummyData.AutoSize = true;
            this.cbDummyData.Location = new System.Drawing.Point(95, 282);
            this.cbDummyData.Name = "cbDummyData";
            this.cbDummyData.Size = new System.Drawing.Size(126, 24);
            this.cbDummyData.TabIndex = 36;
            this.cbDummyData.Text = "Dummy Data?";
            this.cbDummyData.UseVisualStyleBackColor = true;
            this.cbDummyData.CheckedChanged += new System.EventHandler(this.cbDummyData_CheckedChanged);
            // 
            // tbReportingOfficer
            // 
            this.tbReportingOfficer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbReportingOfficer.Enabled = false;
            this.tbReportingOfficer.Location = new System.Drawing.Point(287, 102);
            this.tbReportingOfficer.Name = "tbReportingOfficer";
            this.tbReportingOfficer.Size = new System.Drawing.Size(216, 27);
            this.tbReportingOfficer.TabIndex = 35;
            // 
            // tbName
            // 
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbName.Location = new System.Drawing.Point(287, 149);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(216, 27);
            this.tbName.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(74, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 23);
            this.label3.TabIndex = 33;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(74, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 23);
            this.label2.TabIndex = 32;
            this.label2.Text = "Reporting Officer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(196, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 23);
            this.label1.TabIndex = 31;
            this.label1.Text = "Edit Employee Details";
            // 
            // tbId
            // 
            this.tbId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbId.Enabled = false;
            this.tbId.Location = new System.Drawing.Point(287, 60);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(216, 27);
            this.tbId.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(74, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 23);
            this.label6.TabIndex = 44;
            this.label6.Text = "UUID";
            // 
            // EditEmployeeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 385);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbSalaryAccountable);
            this.Controls.Add(this.comboRole);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSalary);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbDummyData);
            this.Controls.Add(this.tbReportingOfficer);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditEmployeeDetails";
            this.Text = "EditEmployeeDetails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbSalaryAccountable;
        private System.Windows.Forms.ComboBox comboRole;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSalary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckBox cbDummyData;
        private System.Windows.Forms.TextBox tbReportingOfficer;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label label6;
    }
}