using System;
using System.Windows.Forms;

namespace TrainigsTracker
{
    public partial class NewAthleteForm : Form
    {
        public NewAthleteForm(MainForm mainFormInstance)
        {
            InitializeComponent();
            genderComboBox.SelectedIndex = 0;
            m_mainForminstance = mainFormInstance;
        }

        private MainForm m_mainForminstance;

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void createProjectButton_Click(object sender, EventArgs e)
        {
            try
            {
                string name = NameTextBox.Text;
                int height = Convert.ToInt32(heightTextBox.Text);
                int age = Convert.ToInt32(ageTextBox.Text);
                Gender gender;
                if (genderComboBox.SelectedText == "Male")
                    gender = Gender.Male;
                else
                    gender = Gender.Female;

                if (height < 0 || age < 0)
                    throw new ArgumentOutOfRangeException("\n- No negativ values allowed!");

                m_mainForminstance.m_athlete = new Athlete(name, height, age, m_mainForminstance, gender);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch
            {
                MessageBox.Show("Check your input something seems to be unvalid! \n\n- All fields contain a value\n- Only numbers are allowed except for the name \n- No negativ values are allowed", "Error");
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NameTextBox.Text != "" && ageTextBox.Text != "" && heightTextBox.Text != "")
                createProjectButton.Enabled = true;
            else
                createProjectButton.Enabled = false;
        }

        private void ageTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NameTextBox.Text != "" && ageTextBox.Text != "" && heightTextBox.Text != "")
                createProjectButton.Enabled = true;
            else
                createProjectButton.Enabled = false;
        }

        private void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NameTextBox.Text != "" && ageTextBox.Text != "" && heightTextBox.Text != "")
                createProjectButton.Enabled = true;
            else
                createProjectButton.Enabled = false;
        }
    }
}