namespace TheaterApp
{
    partial class frmMain
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
            this.dataPanel = new System.Windows.Forms.Panel();
            this.theaterDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Theatre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scene = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpBoxSearch = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grpBoxFilter = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnFilterReset = new System.Windows.Forms.Button();
            this.cmbBoxStatus = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.dataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theaterDataGridView)).BeginInit();
            this.grpBoxSearch.SuspendLayout();
            this.grpBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.theaterDataGridView);
            this.dataPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataPanel.Location = new System.Drawing.Point(0, 118);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(1264, 643);
            this.dataPanel.TabIndex = 0;
            // 
            // theaterDataGridView
            // 
            this.theaterDataGridView.AllowUserToAddRows = false;
            this.theaterDataGridView.AllowUserToDeleteRows = false;
            this.theaterDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.theaterDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.theaterDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.theaterDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.theaterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.theaterDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Status,
            this.Title,
            this.City,
            this.Date,
            this.Time,
            this.Theatre,
            this.Scene});
            this.theaterDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.theaterDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.theaterDataGridView.Location = new System.Drawing.Point(0, 0);
            this.theaterDataGridView.MultiSelect = false;
            this.theaterDataGridView.Name = "theaterDataGridView";
            this.theaterDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.theaterDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.theaterDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.theaterDataGridView.Size = new System.Drawing.Size(1264, 643);
            this.theaterDataGridView.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Durum";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Başlık";
            this.Title.Name = "Title";
            // 
            // City
            // 
            this.City.DataPropertyName = "City";
            this.City.HeaderText = "Şehir";
            this.City.Name = "City";
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Gün";
            this.Date.Name = "Date";
            // 
            // Time
            // 
            this.Time.DataPropertyName = "Time";
            this.Time.HeaderText = "Saat";
            this.Time.Name = "Time";
            // 
            // Theatre
            // 
            this.Theatre.DataPropertyName = "Theater";
            this.Theatre.HeaderText = "Tiyatro";
            this.Theatre.Name = "Theatre";
            // 
            // Scene
            // 
            this.Scene.DataPropertyName = "Scene";
            this.Scene.HeaderText = "Sahne";
            this.Scene.Name = "Scene";
            // 
            // grpBoxSearch
            // 
            this.grpBoxSearch.Controls.Add(this.label1);
            this.grpBoxSearch.Controls.Add(this.textBox1);
            this.grpBoxSearch.Location = new System.Drawing.Point(12, 12);
            this.grpBoxSearch.Name = "grpBoxSearch";
            this.grpBoxSearch.Size = new System.Drawing.Size(470, 100);
            this.grpBoxSearch.TabIndex = 1;
            this.grpBoxSearch.TabStop = false;
            this.grpBoxSearch.Text = "Arama";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Aramak için bir başlık yazınız";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(458, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // grpBoxFilter
            // 
            this.grpBoxFilter.Controls.Add(this.label2);
            this.grpBoxFilter.Controls.Add(this.btnFilter);
            this.grpBoxFilter.Controls.Add(this.btnFilterReset);
            this.grpBoxFilter.Controls.Add(this.cmbBoxStatus);
            this.grpBoxFilter.Location = new System.Drawing.Point(488, 12);
            this.grpBoxFilter.Name = "grpBoxFilter";
            this.grpBoxFilter.Size = new System.Drawing.Size(390, 100);
            this.grpBoxFilter.TabIndex = 1;
            this.grpBoxFilter.TabStop = false;
            this.grpBoxFilter.Text = "Filtreleme";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Filtreleme Seçenekleri";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(276, 33);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(108, 25);
            this.btnFilter.TabIndex = 1;
            this.btnFilter.Text = "Filtrele";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnFilterReset
            // 
            this.btnFilterReset.Location = new System.Drawing.Point(276, 60);
            this.btnFilterReset.Name = "btnFilterReset";
            this.btnFilterReset.Size = new System.Drawing.Size(108, 25);
            this.btnFilterReset.TabIndex = 1;
            this.btnFilterReset.Text = "Temizle";
            this.btnFilterReset.UseVisualStyleBackColor = true;
            this.btnFilterReset.Click += new System.EventHandler(this.btnFilterReset_Click);
            // 
            // cmbBoxStatus
            // 
            this.cmbBoxStatus.FormattingEnabled = true;
            this.cmbBoxStatus.Location = new System.Drawing.Point(6, 64);
            this.cmbBoxStatus.Name = "cmbBoxStatus";
            this.cmbBoxStatus.Size = new System.Drawing.Size(264, 21);
            this.cmbBoxStatus.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(895, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(357, 27);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Ekle";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(895, 43);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(357, 27);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1075, 73);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(177, 27);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(895, 73);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(174, 27);
            this.btnDetails.TabIndex = 2;
            this.btnDetails.Text = "Detaylar";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grpBoxFilter);
            this.Controls.Add(this.grpBoxSearch);
            this.Controls.Add(this.dataPanel);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OOP Tiyatroları Yönetim Otomasyonu";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.dataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.theaterDataGridView)).EndInit();
            this.grpBoxSearch.ResumeLayout(false);
            this.grpBoxSearch.PerformLayout();
            this.grpBoxFilter.ResumeLayout(false);
            this.grpBoxFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.DataGridView theaterDataGridView;
        private System.Windows.Forms.GroupBox grpBoxSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox grpBoxFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFilterReset;
        private System.Windows.Forms.ComboBox cmbBoxStatus;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Theatre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scene;
        private System.Windows.Forms.Button btnDetails;
    }
}

