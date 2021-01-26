namespace TrainigsTracker
{
    partial class StartUpProjectForm
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
            this.createNewProjectButton = new System.Windows.Forms.Button();
            this.loadProjectButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // createNewProjectButton
            // 
            this.createNewProjectButton.Location = new System.Drawing.Point(187, 105);
            this.createNewProjectButton.Name = "createNewProjectButton";
            this.createNewProjectButton.Size = new System.Drawing.Size(107, 23);
            this.createNewProjectButton.TabIndex = 1;
            this.createNewProjectButton.Text = "Create New Project";
            this.createNewProjectButton.UseVisualStyleBackColor = true;
            this.createNewProjectButton.Click += new System.EventHandler(this.createNewProjectButton_Click);
            // 
            // loadProjectButton
            // 
            this.loadProjectButton.Location = new System.Drawing.Point(50, 105);
            this.loadProjectButton.Name = "loadProjectButton";
            this.loadProjectButton.Size = new System.Drawing.Size(107, 23);
            this.loadProjectButton.TabIndex = 0;
            this.loadProjectButton.Text = "Load Project";
            this.loadProjectButton.UseVisualStyleBackColor = true;
            this.loadProjectButton.Click += new System.EventHandler(this.loadProjectButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(319, 52);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Welcome to the TrainingsTracker Application!\r\n\r\nBefore you can start with the tra" +
    "cking you need to create a new project or load an existing one.";
            // 
            // StartUpProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 140);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.loadProjectButton);
            this.Controls.Add(this.createNewProjectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StartUpProjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to Trainings Tracker";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.StartUpProjectForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createNewProjectButton;
        private System.Windows.Forms.Button loadProjectButton;
        private System.Windows.Forms.TextBox textBox1;
    }
}