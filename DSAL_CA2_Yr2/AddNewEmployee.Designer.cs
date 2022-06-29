namespace DSAL_CA2_Yr2
{
    partial class AddNewEmployee
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
            this.label5 = new System.Windows.Forms.Label();
            this.comboRole = new System.Windows.Forms.ComboBox();
            this.cbSalryAccountable = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbSalary
            // 
            this.tbSalary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSalary.Location = new System.Drawing.Point(236, 172);
            this.tbSalary.Name = "tbSalary";
            this.tbSalary.Size = new System.Drawing.Size(216, 27);
            this.tbSalary.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(23, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 23);
            this.label4.TabIndex = 26;
            this.label4.Text = "Salary ($$)";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(255, 328);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(151, 42);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAdd.Location = new System.Drawing.Point(55, 328);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(151, 42);
            this.btnAdd.TabIndex = 24;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbDummyData
            // 
            this.cbDummyData.AutoSize = true;
            this.cbDummyData.Location = new System.Drawing.Point(55, 278);
            this.cbDummyData.Name = "cbDummyData";
            this.cbDummyData.Size = new System.Drawing.Size(126, 24);
            this.cbDummyData.TabIndex = 23;
            this.cbDummyData.Text = "Dummy Data?";
            this.cbDummyData.UseVisualStyleBackColor = true;
            this.cbDummyData.CheckedChanged += new System.EventHandler(this.cbDummyData_CheckedChanged);
            // 
            // tbReportingOfficer
            // 
            this.tbReportingOfficer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbReportingOfficer.Enabled = false;
            this.tbReportingOfficer.Location = new System.Drawing.Point(236, 82);
            this.tbReportingOfficer.Name = "tbReportingOfficer";
            this.tbReportingOfficer.Size = new System.Drawing.Size(216, 27);
            this.tbReportingOfficer.TabIndex = 22;
            // 
            // tbName
            // 
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbName.Location = new System.Drawing.Point(236, 129);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(216, 27);
            this.tbName.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(23, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 23);
            this.label3.TabIndex = 20;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(23, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 23);
            this.label2.TabIndex = 19;
            this.label2.Text = "Reporting Officer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(154, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Add New Employee";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(23, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "Role";
            // 
            // comboRole
            // 
            this.comboRole.FormattingEnabled = true;
            this.comboRole.Location = new System.Drawing.Point(236, 219);
            this.comboRole.Name = "comboRole";
            this.comboRole.Size = new System.Drawing.Size(216, 28);
            this.comboRole.TabIndex = 29;
            // 
            // cbSalryAccountable
            // 
            this.cbSalryAccountable.AutoSize = true;
            this.cbSalryAccountable.Enabled = false;
            this.cbSalryAccountable.Location = new System.Drawing.Point(280, 278);
            this.cbSalryAccountable.Name = "cbSalryAccountable";
            this.cbSalryAccountable.Size = new System.Drawing.Size(165, 24);
            this.cbSalryAccountable.TabIndex = 30;
            this.cbSalryAccountable.Text = "Salary Accountable?";
            this.cbSalryAccountable.UseVisualStyleBackColor = true;
            // 
            // AddNewEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 404);
            this.Controls.Add(this.cbSalryAccountable);
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
            this.Name = "AddNewEmployee";
            this.Text = "AddNewEmployee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboRole;
        private System.Windows.Forms.CheckBox cbSalryAccountable;
    }
}