namespace TrainigsTracker
{
    partial class RegisterExerciseForm
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
            this.registerExerciseButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.exerciseTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.exerciseNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // registerExerciseButton
            // 
            this.registerExerciseButton.Enabled = false;
            this.registerExerciseButton.Location = new System.Drawing.Point(135, 222);
            this.registerExerciseButton.Name = "registerExerciseButton";
            this.registerExerciseButton.Size = new System.Drawing.Size(105, 23);
            this.registerExerciseButton.TabIndex = 4;
            this.registerExerciseButton.Text = "Register Exercise";
            this.registerExerciseButton.UseVisualStyleBackColor = true;
            this.registerExerciseButton.Click += new System.EventHandler(this.registerExerciseButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(246, 222);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(105, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // exerciseTypeComboBox
            // 
            this.exerciseTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exerciseTypeComboBox.FormattingEnabled = true;
            this.exerciseTypeComboBox.Items.AddRange(new object[] {
            "<Select Exercise Type>"});
            this.exerciseTypeComboBox.Location = new System.Drawing.Point(135, 62);
            this.exerciseTypeComboBox.Name = "exerciseTypeComboBox";
            this.exerciseTypeComboBox.Size = new System.Drawing.Size(215, 21);
            this.exerciseTypeComboBox.TabIndex = 2;
            this.exerciseTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.exerciseTypeComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Exercise Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Exercise Type";
            // 
            // exerciseNameTextBox
            // 
            this.exerciseNameTextBox.Location = new System.Drawing.Point(135, 23);
            this.exerciseNameTextBox.Name = "exerciseNameTextBox";
            this.exerciseNameTextBox.Size = new System.Drawing.Size(215, 20);
            this.exerciseNameTextBox.TabIndex = 1;
            this.exerciseNameTextBox.TextChanged += new System.EventHandler(this.exerciseNameTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Description";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(135, 106);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(215, 79);
            this.descriptionTextBox.TabIndex = 3;
            // 
            // RegisterExerciseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 257);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.exerciseNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exerciseTypeComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.registerExerciseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RegisterExerciseForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register Exercise";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registerExerciseButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox exerciseTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox exerciseNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox descriptionTextBox;
    }
}