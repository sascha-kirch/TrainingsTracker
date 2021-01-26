namespace TrainigsTracker
{
    partial class GraphViewerForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.showByNumberRadioButton = new System.Windows.Forms.RadioButton();
            this.showByDateRadioButton = new System.Windows.Forms.RadioButton();
            this.showGrid_checkBox = new System.Windows.Forms.CheckBox();
            this.showCursor_checkBox = new System.Windows.Forms.CheckBox();
            this.showAverage_checkBox = new System.Windows.Forms.CheckBox();
            this.showTrend_checkBox = new System.Windows.Forms.CheckBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.chart1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chart3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chart4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chart2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1012, 621);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(500, 304);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseClick);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // chart3
            // 
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea2);
            this.chart3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart3.Location = new System.Drawing.Point(3, 313);
            this.chart3.Name = "chart3";
            this.chart3.Size = new System.Drawing.Size(500, 305);
            this.chart3.TabIndex = 1;
            this.chart3.Text = "chart2";
            // 
            // chart4
            // 
            chartArea3.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea3.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea3.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea3);
            this.chart4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart4.Location = new System.Drawing.Point(509, 313);
            this.chart4.Name = "chart4";
            this.chart4.Size = new System.Drawing.Size(500, 305);
            this.chart4.TabIndex = 3;
            this.chart4.Text = "chart4";
            // 
            // chart2
            // 
            chartArea4.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea4.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea4.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea4);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart2.Location = new System.Drawing.Point(509, 3);
            this.chart2.Name = "chart2";
            this.chart2.Size = new System.Drawing.Size(500, 304);
            this.chart2.TabIndex = 2;
            this.chart2.Text = "chart3";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.showByNumberRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.showByDateRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.showGrid_checkBox);
            this.flowLayoutPanel1.Controls.Add(this.showCursor_checkBox);
            this.flowLayoutPanel1.Controls.Add(this.showAverage_checkBox);
            this.flowLayoutPanel1.Controls.Add(this.showTrend_checkBox);
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel1.Controls.Add(this.dataGridView);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1019, 881);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // showByNumberRadioButton
            // 
            this.showByNumberRadioButton.AutoSize = true;
            this.showByNumberRadioButton.Checked = true;
            this.showByNumberRadioButton.Location = new System.Drawing.Point(3, 3);
            this.showByNumberRadioButton.Name = "showByNumberRadioButton";
            this.showByNumberRadioButton.Size = new System.Drawing.Size(106, 17);
            this.showByNumberRadioButton.TabIndex = 3;
            this.showByNumberRadioButton.TabStop = true;
            this.showByNumberRadioButton.Text = "Show by Number";
            this.showByNumberRadioButton.UseVisualStyleBackColor = true;
            this.showByNumberRadioButton.CheckedChanged += new System.EventHandler(this.showByNumberRadioButton_CheckedChanged);
            // 
            // showByDateRadioButton
            // 
            this.showByDateRadioButton.AutoSize = true;
            this.showByDateRadioButton.Location = new System.Drawing.Point(115, 3);
            this.showByDateRadioButton.Name = "showByDateRadioButton";
            this.showByDateRadioButton.Size = new System.Drawing.Size(92, 17);
            this.showByDateRadioButton.TabIndex = 4;
            this.showByDateRadioButton.Text = "Show by Date";
            this.showByDateRadioButton.UseVisualStyleBackColor = true;
            // 
            // showGrid_checkBox
            // 
            this.showGrid_checkBox.AutoSize = true;
            this.showGrid_checkBox.Checked = true;
            this.showGrid_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showGrid_checkBox.Location = new System.Drawing.Point(213, 3);
            this.showGrid_checkBox.Name = "showGrid_checkBox";
            this.showGrid_checkBox.Size = new System.Drawing.Size(75, 17);
            this.showGrid_checkBox.TabIndex = 8;
            this.showGrid_checkBox.Text = "Show Grid";
            this.showGrid_checkBox.UseVisualStyleBackColor = true;
            this.showGrid_checkBox.CheckedChanged += new System.EventHandler(this.showGrid_checkBox_CheckedChanged);
            // 
            // showCursor_checkBox
            // 
            this.showCursor_checkBox.AutoSize = true;
            this.showCursor_checkBox.Location = new System.Drawing.Point(294, 3);
            this.showCursor_checkBox.Name = "showCursor_checkBox";
            this.showCursor_checkBox.Size = new System.Drawing.Size(86, 17);
            this.showCursor_checkBox.TabIndex = 9;
            this.showCursor_checkBox.Text = "Show Cursor";
            this.showCursor_checkBox.UseVisualStyleBackColor = true;
            this.showCursor_checkBox.CheckedChanged += new System.EventHandler(this.showCursor_checkBox_CheckedChanged);
            // 
            // showAverage_checkBox
            // 
            this.showAverage_checkBox.AutoSize = true;
            this.showAverage_checkBox.Location = new System.Drawing.Point(386, 3);
            this.showAverage_checkBox.Name = "showAverage_checkBox";
            this.showAverage_checkBox.Size = new System.Drawing.Size(96, 17);
            this.showAverage_checkBox.TabIndex = 5;
            this.showAverage_checkBox.Text = "Show Average";
            this.showAverage_checkBox.UseVisualStyleBackColor = true;
            this.showAverage_checkBox.CheckedChanged += new System.EventHandler(this.showAverage_checkBox_CheckedChanged);
            // 
            // showTrend_checkBox
            // 
            this.showTrend_checkBox.AutoSize = true;
            this.showTrend_checkBox.Location = new System.Drawing.Point(488, 3);
            this.showTrend_checkBox.Name = "showTrend_checkBox";
            this.showTrend_checkBox.Size = new System.Drawing.Size(84, 17);
            this.showTrend_checkBox.TabIndex = 7;
            this.showTrend_checkBox.Text = "Show Trend";
            this.showTrend_checkBox.UseVisualStyleBackColor = true;
            this.showTrend_checkBox.CheckedChanged += new System.EventHandler(this.showTrend_checkBox_CheckedChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(3, 653);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1012, 220);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RowEnter);
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // GraphViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 881);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "GraphViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GraphViewerForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.RadioButton showByNumberRadioButton;
        private System.Windows.Forms.RadioButton showByDateRadioButton;
        public System.Windows.Forms.CheckBox showAverage_checkBox;
        private System.Windows.Forms.CheckBox showTrend_checkBox;
        public System.Windows.Forms.CheckBox showGrid_checkBox;
        public System.Windows.Forms.CheckBox showCursor_checkBox;



    }
}