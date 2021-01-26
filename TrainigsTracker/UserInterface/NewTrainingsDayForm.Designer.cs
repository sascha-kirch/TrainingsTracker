namespace TrainigsTracker
{
    partial class NewTrainingsDayForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.addTrainingsDayButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dayComboBox = new System.Windows.Forms.ComboBox();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.trainingsDayDataGridView = new System.Windows.Forms.DataGridView();
            this.exerciseColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trainingsInfoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exerciseSelectionCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trainingsDayDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(929, 517);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(91, 26);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addTrainingsDayButton
            // 
            this.addTrainingsDayButton.Enabled = false;
            this.addTrainingsDayButton.Location = new System.Drawing.Point(815, 517);
            this.addTrainingsDayButton.Name = "addTrainingsDayButton";
            this.addTrainingsDayButton.Size = new System.Drawing.Size(108, 26);
            this.addTrainingsDayButton.TabIndex = 4;
            this.addTrainingsDayButton.Text = "Add Trainingsday";
            this.addTrainingsDayButton.UseVisualStyleBackColor = true;
            this.addTrainingsDayButton.Click += new System.EventHandler(this.addTrainingsDayButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Date";
            // 
            // dayComboBox
            // 
            this.dayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dayComboBox.FormattingEnabled = true;
            this.dayComboBox.Items.AddRange(new object[] {
            "<Day>",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.dayComboBox.Location = new System.Drawing.Point(283, 17);
            this.dayComboBox.Name = "dayComboBox";
            this.dayComboBox.Size = new System.Drawing.Size(72, 21);
            this.dayComboBox.TabIndex = 1;
            this.dayComboBox.SelectedIndexChanged += new System.EventHandler(this.dayComboBox_SelectedIndexChanged);
            // 
            // monthComboBox
            // 
            this.monthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Items.AddRange(new object[] {
            "<Month>",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.monthComboBox.Location = new System.Drawing.Point(361, 17);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(75, 21);
            this.monthComboBox.TabIndex = 2;
            this.monthComboBox.SelectedIndexChanged += new System.EventHandler(this.monthComboBox_SelectedIndexChanged);
            // 
            // yearComboBox
            // 
            this.yearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Items.AddRange(new object[] {
            "<Year>",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.yearComboBox.Location = new System.Drawing.Point(442, 17);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(73, 21);
            this.yearComboBox.TabIndex = 3;
            this.yearComboBox.SelectedIndexChanged += new System.EventHandler(this.yearComboBox_SelectedIndexChanged);
            // 
            // trainingsDayDataGridView
            // 
            this.trainingsDayDataGridView.AllowUserToAddRows = false;
            this.trainingsDayDataGridView.AllowUserToDeleteRows = false;
            this.trainingsDayDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.trainingsDayDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.trainingsDayDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.trainingsDayDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.trainingsDayDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.exerciseColumn,
            this.type_Column,
            this.trainingsInfoColumn,
            this.commentColumn});
            this.trainingsDayDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.trainingsDayDataGridView.Location = new System.Drawing.Point(245, 47);
            this.trainingsDayDataGridView.Name = "trainingsDayDataGridView";
            this.trainingsDayDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.trainingsDayDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.trainingsDayDataGridView.Size = new System.Drawing.Size(777, 454);
            this.trainingsDayDataGridView.TabIndex = 8;
            this.trainingsDayDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trainingsDayDataGridView_KeyDown);
            // 
            // exerciseColumn
            // 
            this.exerciseColumn.FillWeight = 41.61824F;
            this.exerciseColumn.HeaderText = "Exercise";
            this.exerciseColumn.Name = "exerciseColumn";
            this.exerciseColumn.ReadOnly = true;
            // 
            // type_Column
            // 
            this.type_Column.FillWeight = 56.62346F;
            this.type_Column.HeaderText = "Type";
            this.type_Column.Name = "type_Column";
            this.type_Column.ReadOnly = true;
            // 
            // trainingsInfoColumn
            // 
            this.trainingsInfoColumn.FillWeight = 83.23649F;
            this.trainingsInfoColumn.HeaderText = "Trainings Info";
            this.trainingsInfoColumn.Name = "trainingsInfoColumn";
            // 
            // commentColumn
            // 
            this.commentColumn.FillWeight = 41.61824F;
            this.commentColumn.HeaderText = "Comment";
            this.commentColumn.Name = "commentColumn";
            // 
            // exerciseSelectionCheckedListBox
            // 
            this.exerciseSelectionCheckedListBox.CheckOnClick = true;
            this.exerciseSelectionCheckedListBox.FormattingEnabled = true;
            this.exerciseSelectionCheckedListBox.Location = new System.Drawing.Point(15, 47);
            this.exerciseSelectionCheckedListBox.Name = "exerciseSelectionCheckedListBox";
            this.exerciseSelectionCheckedListBox.Size = new System.Drawing.Size(206, 454);
            this.exerciseSelectionCheckedListBox.TabIndex = 0;
            this.exerciseSelectionCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.exerciseSelectionCheckedListBox_ItemCheck);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Available Exercises";
            // 
            // NewTrainingsDayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 557);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.exerciseSelectionCheckedListBox);
            this.Controls.Add(this.trainingsDayDataGridView);
            this.Controls.Add(this.yearComboBox);
            this.Controls.Add(this.monthComboBox);
            this.Controls.Add(this.dayComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addTrainingsDayButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NewTrainingsDayForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Training";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NewTrainingsDayForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.trainingsDayDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addTrainingsDayButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dayComboBox;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.DataGridView trainingsDayDataGridView;
        private System.Windows.Forms.CheckedListBox exerciseSelectionCheckedListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn exerciseColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn type_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn trainingsInfoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentColumn;
    }
}