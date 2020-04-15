namespace ListEditor
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvBookList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.pictureBoxFilter = new System.Windows.Forms.PictureBox();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.buttonSaveAs = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookList)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBookList
            // 
            this.dgvBookList.BackgroundColor = System.Drawing.Color.White;
            this.dgvBookList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBookList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvBookList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBookList.Location = new System.Drawing.Point(0, 45);
            this.dgvBookList.Margin = new System.Windows.Forms.Padding(10);
            this.dgvBookList.Name = "dgvBookList";
            this.dgvBookList.RowHeadersWidth = 40;
            this.dgvBookList.Size = new System.Drawing.Size(664, 296);
            this.dgvBookList.TabIndex = 0;
            this.dgvBookList.TabStop = false;
            this.dgvBookList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBookList_CellEndEdit);
            this.dgvBookList.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvBookList_CellParsing);
            this.dgvBookList.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvBookList_CellValidating);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Author Name";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Title";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle25.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle25;
            this.Column3.HeaderText = "Year of Publishing";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle26;
            this.Column4.HeaderText = "Number of Pages";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle27;
            this.Column5.HeaderText = "Price";
            this.Column5.Name = "Column5";
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.panelFilter);
            this.panelMenu.Controls.Add(this.buttonSaveAs);
            this.panelMenu.Controls.Add(this.buttonSave);
            this.panelMenu.Controls.Add(this.buttonOpen);
            this.panelMenu.Controls.Add(this.buttonNew);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(664, 45);
            this.panelMenu.TabIndex = 4;
            // 
            // panelFilter
            // 
            this.panelFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFilter.BackColor = System.Drawing.SystemColors.Window;
            this.panelFilter.Controls.Add(this.pictureBoxFilter);
            this.panelFilter.Controls.Add(this.textBoxFilter);
            this.panelFilter.Location = new System.Drawing.Point(480, 10);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(176, 26);
            this.panelFilter.TabIndex = 10;
            this.toolTip.SetToolTip(this.panelFilter, "Filter");
            this.panelFilter.Click += new System.EventHandler(this.panelFilter_Click);
            // 
            // pictureBoxFilter
            // 
            this.pictureBoxFilter.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxFilter.Image = global::ListEditor.Properties.Resources.icons8_filter_32;
            this.pictureBoxFilter.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxFilter.Name = "pictureBoxFilter";
            this.pictureBoxFilter.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFilter.TabIndex = 6;
            this.pictureBoxFilter.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBoxFilter, "Filter");
            this.pictureBoxFilter.Click += new System.EventHandler(this.pictureBoxFilter_Click);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFilter.Location = new System.Drawing.Point(29, 6);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(144, 13);
            this.textBoxFilter.TabIndex = 5;
            this.toolTip.SetToolTip(this.textBoxFilter, "Filter");
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
            // 
            // buttonSaveAs
            // 
            this.buttonSaveAs.BackgroundImage = global::ListEditor.Properties.Resources.icons8_save_as_32;
            this.buttonSaveAs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSaveAs.Location = new System.Drawing.Point(124, 6);
            this.buttonSaveAs.Name = "buttonSaveAs";
            this.buttonSaveAs.Size = new System.Drawing.Size(32, 32);
            this.buttonSaveAs.TabIndex = 9;
            this.toolTip.SetToolTip(this.buttonSaveAs, "Save File As...");
            this.buttonSaveAs.UseVisualStyleBackColor = true;
            this.buttonSaveAs.Click += new System.EventHandler(this.buttonSaveAs_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackgroundImage = global::ListEditor.Properties.Resources.icons8_save_32;
            this.buttonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSave.Location = new System.Drawing.Point(86, 6);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(32, 32);
            this.buttonSave.TabIndex = 8;
            this.toolTip.SetToolTip(this.buttonSave, "Save File");
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.BackgroundImage = global::ListEditor.Properties.Resources.icons8_opened_folder_32;
            this.buttonOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonOpen.Location = new System.Drawing.Point(48, 6);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(32, 32);
            this.buttonOpen.TabIndex = 7;
            this.toolTip.SetToolTip(this.buttonOpen, "Open File...");
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.BackgroundImage = global::ListEditor.Properties.Resources.icons8_file_32;
            this.buttonNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNew.Location = new System.Drawing.Point(10, 6);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(32, 32);
            this.buttonNew.TabIndex = 6;
            this.toolTip.SetToolTip(this.buttonNew, "New File");
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 341);
            this.Controls.Add(this.dgvBookList);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(450, 380);
            this.Name = "MainForm";
            this.Text = "List Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookList)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFilter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBookList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Button buttonSaveAs;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.PictureBox pictureBoxFilter;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

