namespace ParseExcelPostalCode
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRead = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dgvIndustry = new System.Windows.Forms.DataGridView();
            this.btnGenerateIndustryRecords = new System.Windows.Forms.Button();
            this.btnGenerateJobRecords = new System.Windows.Forms.Button();
            this.dgvJob = new System.Windows.Forms.DataGridView();
            this.btnExportIndustry = new System.Windows.Forms.Button();
            this.btnExportJob = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIndustry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJob)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(12, 12);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(112, 23);
            this.btnRead.TabIndex = 0;
            this.btnRead.Text = "Choose and Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(231, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 41);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(390, 692);
            this.dataGridView.TabIndex = 2;
            // 
            // dgvIndustry
            // 
            this.dgvIndustry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIndustry.Location = new System.Drawing.Point(473, 40);
            this.dgvIndustry.Name = "dgvIndustry";
            this.dgvIndustry.RowTemplate.Height = 25;
            this.dgvIndustry.Size = new System.Drawing.Size(411, 693);
            this.dgvIndustry.TabIndex = 3;
            // 
            // btnGenerateIndustryRecords
            // 
            this.btnGenerateIndustryRecords.Enabled = false;
            this.btnGenerateIndustryRecords.Location = new System.Drawing.Point(408, 308);
            this.btnGenerateIndustryRecords.Name = "btnGenerateIndustryRecords";
            this.btnGenerateIndustryRecords.Size = new System.Drawing.Size(59, 75);
            this.btnGenerateIndustryRecords.TabIndex = 4;
            this.btnGenerateIndustryRecords.Text = "Industry";
            this.btnGenerateIndustryRecords.UseVisualStyleBackColor = true;
            this.btnGenerateIndustryRecords.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnGenerateJobRecords
            // 
            this.btnGenerateJobRecords.Enabled = false;
            this.btnGenerateJobRecords.Location = new System.Drawing.Point(890, 308);
            this.btnGenerateJobRecords.Name = "btnGenerateJobRecords";
            this.btnGenerateJobRecords.Size = new System.Drawing.Size(59, 75);
            this.btnGenerateJobRecords.TabIndex = 5;
            this.btnGenerateJobRecords.Text = "Job";
            this.btnGenerateJobRecords.UseVisualStyleBackColor = true;
            this.btnGenerateJobRecords.Click += new System.EventHandler(this.button3_Click);
            // 
            // dgvJob
            // 
            this.dgvJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJob.Location = new System.Drawing.Point(955, 41);
            this.dgvJob.Name = "dgvJob";
            this.dgvJob.RowTemplate.Height = 25;
            this.dgvJob.Size = new System.Drawing.Size(411, 693);
            this.dgvJob.TabIndex = 6;
            // 
            // btnExportIndustry
            // 
            this.btnExportIndustry.Enabled = false;
            this.btnExportIndustry.Location = new System.Drawing.Point(628, 739);
            this.btnExportIndustry.Name = "btnExportIndustry";
            this.btnExportIndustry.Size = new System.Drawing.Size(122, 44);
            this.btnExportIndustry.TabIndex = 7;
            this.btnExportIndustry.Text = "Export as Excel file";
            this.btnExportIndustry.UseVisualStyleBackColor = true;
            this.btnExportIndustry.Click += new System.EventHandler(this.btnExportIndustry_Click);
            // 
            // btnExportJob
            // 
            this.btnExportJob.Enabled = false;
            this.btnExportJob.Location = new System.Drawing.Point(1101, 740);
            this.btnExportJob.Name = "btnExportJob";
            this.btnExportJob.Size = new System.Drawing.Size(144, 43);
            this.btnExportJob.TabIndex = 8;
            this.btnExportJob.Text = "Export as Excel file";
            this.btnExportJob.UseVisualStyleBackColor = true;
            this.btnExportJob.Click += new System.EventHandler(this.btnExportJob_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 795);
            this.Controls.Add(this.btnExportJob);
            this.Controls.Add(this.btnExportIndustry);
            this.Controls.Add(this.dgvJob);
            this.Controls.Add(this.btnGenerateJobRecords);
            this.Controls.Add(this.btnGenerateIndustryRecords);
            this.Controls.Add(this.dgvIndustry);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnRead);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIndustry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJob)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnRead;
        private Button button2;
        private DataGridView dataGridView;
        private DataGridView dgvIndustry;
        private Button btnGenerateIndustryRecords;
        private Button btnGenerateJobRecords;
        private DataGridView dgvJob;
        private Button btnExportIndustry;
        private Button btnExportJob;
    }
}