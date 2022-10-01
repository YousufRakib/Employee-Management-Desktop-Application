
namespace SkyTree
{
    partial class Jobcard
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
            this.components = new System.ComponentModel.Container();
            this.tbl_production_infoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1Production = new SkyTree.DataSet1Production();
            this.cardnoTxt = new System.Windows.Forms.TextBox();
            this.loadBtn = new System.Windows.Forms.Button();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbl_production_infoTableAdapter = new SkyTree.DataSet1ProductionTableAdapters.tbl_production_infoTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sectionCombo = new System.Windows.Forms.ComboBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_production_infoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1Production)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_production_infoBindingSource
            // 
            this.tbl_production_infoBindingSource.DataMember = "tbl_production_info";
            this.tbl_production_infoBindingSource.DataSource = this.DataSet1Production;
            // 
            // DataSet1Production
            // 
            this.DataSet1Production.DataSetName = "DataSet1Production";
            this.DataSet1Production.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cardnoTxt
            // 
            this.cardnoTxt.Location = new System.Drawing.Point(101, 162);
            this.cardnoTxt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cardnoTxt.Name = "cardnoTxt";
            this.cardnoTxt.Size = new System.Drawing.Size(121, 26);
            this.cardnoTxt.TabIndex = 1;
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(31, 294);
            this.loadBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(191, 35);
            this.loadBtn.TabIndex = 2;
            this.loadBtn.Text = "Report";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // fromDate
            // 
            this.fromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDate.Location = new System.Drawing.Point(100, 23);
            this.fromDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(121, 26);
            this.fromDate.TabIndex = 3;
            // 
            // toDate
            // 
            this.toDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDate.Location = new System.Drawing.Point(100, 65);
            this.toDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(121, 26);
            this.toDate.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "To";
            // 
            // tbl_production_infoTableAdapter
            // 
            this.tbl_production_infoTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 165);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cardno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 125);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Section";
            // 
            // sectionCombo
            // 
            this.sectionCombo.FormattingEnabled = true;
            this.sectionCombo.Location = new System.Drawing.Point(101, 122);
            this.sectionCombo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sectionCombo.Name = "sectionCombo";
            this.sectionCombo.Size = new System.Drawing.Size(121, 28);
            this.sectionCombo.TabIndex = 9;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(284, 23);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1314, 616);
            this.crystalReportViewer1.TabIndex = 10;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(35, 210);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(157, 24);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Production Sheet";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(35, 249);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(196, 24);
            this.radioButton2.TabIndex = 12;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Production Wise Sheet";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // Jobcard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1610, 674);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.sectionCombo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toDate);
            this.Controls.Add(this.fromDate);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.cardnoTxt);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Jobcard";
            this.Text = "Jobcard";
            this.Load += new System.EventHandler(this.Jobcard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_production_infoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1Production)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource tbl_production_infoBindingSource;
        private DataSet1Production DataSet1Production;
        private DataSet1ProductionTableAdapters.tbl_production_infoTableAdapter tbl_production_infoTableAdapter;
        private System.Windows.Forms.TextBox cardnoTxt;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.DateTimePicker fromDate;
        private System.Windows.Forms.DateTimePicker toDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox sectionCombo;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}