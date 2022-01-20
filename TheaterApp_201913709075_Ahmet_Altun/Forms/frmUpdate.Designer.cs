namespace TheaterApp.Forms
{
    partial class frmUpdate
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
            this.label15 = new System.Windows.Forms.Label();
            this.rtbxRules = new System.Windows.Forms.RichTextBox();
            this.dtgTicketPrices = new System.Windows.Forms.DataGridView();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.rtbxDescription = new System.Windows.Forms.RichTextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.tbxDirectedBy = new System.Windows.Forms.TextBox();
            this.tbxAdabtedBy = new System.Windows.Forms.TextBox();
            this.tbxTranslater = new System.Windows.Forms.TextBox();
            this.tbxWriter = new System.Windows.Forms.TextBox();
            this.tbxScene = new System.Windows.Forms.TextBox();
            this.tbxTheater = new System.Windows.Forms.TextBox();
            this.tbxCity = new System.Windows.Forms.TextBox();
            this.tbxTime = new System.Windows.Forms.TextBox();
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTicketPrices)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.Location = new System.Drawing.Point(34, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(427, 29);
            this.label15.TabIndex = 72;
            this.label15.Text = "Tiyatro Oyunu Güncelle";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // rtbxRules
            // 
            this.rtbxRules.Location = new System.Drawing.Point(117, 421);
            this.rtbxRules.Name = "rtbxRules";
            this.rtbxRules.Size = new System.Drawing.Size(344, 141);
            this.rtbxRules.TabIndex = 69;
            this.rtbxRules.Text = "";
            // 
            // dtgTicketPrices
            // 
            this.dtgTicketPrices.AllowUserToOrderColumns = true;
            this.dtgTicketPrices.AllowUserToResizeColumns = false;
            this.dtgTicketPrices.AllowUserToResizeRows = false;
            this.dtgTicketPrices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgTicketPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTicketPrices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Level,
            this.Price});
            this.dtgTicketPrices.Location = new System.Drawing.Point(117, 568);
            this.dtgTicketPrices.Name = "dtgTicketPrices";
            this.dtgTicketPrices.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgTicketPrices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTicketPrices.Size = new System.Drawing.Size(344, 141);
            this.dtgTicketPrices.TabIndex = 70;
            // 
            // Level
            // 
            this.Level.DataPropertyName = "Level";
            this.Level.HeaderText = "Seviye";
            this.Level.Name = "Level";
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Bedel";
            this.Price.Name = "Price";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(28, 568);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 64;
            this.label14.Text = "Ticket Prices";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(335, 740);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(126, 45);
            this.btnAdd.TabIndex = 71;
            this.btnAdd.Text = "Güncelle";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // rtbxDescription
            // 
            this.rtbxDescription.Location = new System.Drawing.Point(117, 343);
            this.rtbxDescription.Name = "rtbxDescription";
            this.rtbxDescription.Size = new System.Drawing.Size(344, 71);
            this.rtbxDescription.TabIndex = 68;
            this.rtbxDescription.Text = "";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(117, 106);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(344, 20);
            this.dtpDate.TabIndex = 58;
            // 
            // tbxDirectedBy
            // 
            this.tbxDirectedBy.Location = new System.Drawing.Point(117, 314);
            this.tbxDirectedBy.Name = "tbxDirectedBy";
            this.tbxDirectedBy.Size = new System.Drawing.Size(344, 20);
            this.tbxDirectedBy.TabIndex = 67;
            // 
            // tbxAdabtedBy
            // 
            this.tbxAdabtedBy.Location = new System.Drawing.Point(117, 288);
            this.tbxAdabtedBy.Name = "tbxAdabtedBy";
            this.tbxAdabtedBy.Size = new System.Drawing.Size(344, 20);
            this.tbxAdabtedBy.TabIndex = 66;
            // 
            // tbxTranslater
            // 
            this.tbxTranslater.Location = new System.Drawing.Point(117, 262);
            this.tbxTranslater.Name = "tbxTranslater";
            this.tbxTranslater.Size = new System.Drawing.Size(344, 20);
            this.tbxTranslater.TabIndex = 65;
            // 
            // tbxWriter
            // 
            this.tbxWriter.Location = new System.Drawing.Point(117, 236);
            this.tbxWriter.Name = "tbxWriter";
            this.tbxWriter.Size = new System.Drawing.Size(344, 20);
            this.tbxWriter.TabIndex = 63;
            // 
            // tbxScene
            // 
            this.tbxScene.Location = new System.Drawing.Point(117, 210);
            this.tbxScene.Name = "tbxScene";
            this.tbxScene.Size = new System.Drawing.Size(344, 20);
            this.tbxScene.TabIndex = 62;
            // 
            // tbxTheater
            // 
            this.tbxTheater.Location = new System.Drawing.Point(117, 183);
            this.tbxTheater.Name = "tbxTheater";
            this.tbxTheater.Size = new System.Drawing.Size(344, 20);
            this.tbxTheater.TabIndex = 61;
            // 
            // tbxCity
            // 
            this.tbxCity.Location = new System.Drawing.Point(117, 158);
            this.tbxCity.Name = "tbxCity";
            this.tbxCity.Size = new System.Drawing.Size(344, 20);
            this.tbxCity.TabIndex = 60;
            // 
            // tbxTime
            // 
            this.tbxTime.Location = new System.Drawing.Point(117, 130);
            this.tbxTime.Name = "tbxTime";
            this.tbxTime.Size = new System.Drawing.Size(344, 20);
            this.tbxTime.TabIndex = 59;
            // 
            // tbxTitle
            // 
            this.tbxTitle.Location = new System.Drawing.Point(117, 80);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(344, 20);
            this.tbxTitle.TabIndex = 57;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(117, 53);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(344, 21);
            this.cmbStatus.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Status";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(63, 421);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 53;
            this.label13.Text = "Rules";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(37, 343);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 52;
            this.label12.Text = "Description";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 317);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 51;
            this.label11.Text = "Directed By";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 291);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 50;
            this.label10.Text = "Adapted By";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Translater";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(62, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "Writer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Scene";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Theater";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "City";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Title";
            // 
            // frmUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 800);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.rtbxRules);
            this.Controls.Add(this.dtgTicketPrices);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rtbxDescription);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.tbxDirectedBy);
            this.Controls.Add(this.tbxAdabtedBy);
            this.Controls.Add(this.tbxTranslater);
            this.Controls.Add(this.tbxWriter);
            this.Controls.Add(this.tbxScene);
            this.Controls.Add(this.tbxTheater);
            this.Controls.Add(this.tbxCity);
            this.Controls.Add(this.tbxTime);
            this.Controls.Add(this.tbxTitle);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frmUpdate";
            this.Text = "Tiyatro Oyunu Güncelle";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTicketPrices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RichTextBox rtbxRules;
        private System.Windows.Forms.DataGridView dtgTicketPrices;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RichTextBox rtbxDescription;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox tbxDirectedBy;
        private System.Windows.Forms.TextBox tbxAdabtedBy;
        private System.Windows.Forms.TextBox tbxTranslater;
        private System.Windows.Forms.TextBox tbxWriter;
        private System.Windows.Forms.TextBox tbxScene;
        private System.Windows.Forms.TextBox tbxTheater;
        private System.Windows.Forms.TextBox tbxCity;
        private System.Windows.Forms.TextBox tbxTime;
        private System.Windows.Forms.TextBox tbxTitle;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}