using System;
using System.Text;
using System.Windows.Forms;

namespace TrainigsTracker
{
    public partial class NewMeasurementForm : Form
    {
        public NewMeasurementForm(MainForm mainFormInstance, BodyPartRegister measuredPart, Measurement measurementType)
        {
            InitializeComponent();
            dayComboBox.SelectedItem = DateTime.Today.Day < 10 ? "0" + DateTime.Today.Day.ToString() : DateTime.Today.Day.ToString();
            monthComboBox.SelectedItem = DateTime.Today.Month < 10 ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString(); ;
            yearComboBox.SelectedItem = DateTime.Today.Year.ToString();
            m_mainFormInstance = mainFormInstance;
            m_measurementType = measurementType;
            if (measurementType == Measurement.Weight)
            {
                genericDimensionLabel.Text = "kg";
                measuredGenericLabel.Text = "Weight";
            }
            else if (measurementType == Measurement.BoodyPart)
            {
                genericDimensionLabel.Text = "cm";
                descriptionTextbox.Text = measuredPart.Description;
                measuredGenericLabel.Text = measuredPart.Name;
            }
        }

        private MainForm m_mainFormInstance;
        private Measurement m_measurementType;

        #region events

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_measurementType == Measurement.BoodyPart)
                {
                    double diameter;
                    StringBuilder dateString = new StringBuilder();
                    dateString.Append(dayComboBox.Text + "." + monthComboBox.Text + "." + yearComboBox.Text);

                    m_mainFormInstance.m_athlete.BodyPartRegister[m_mainFormInstance.bodyPartGridView.SelectedRows[0].Index].Date.Add(dateString.ToString());

                    diameter = Math.Round(Convert.ToDouble(diameterTextBox.Text), 2);
                    if (diameter < 0)
                        throw new ArgumentOutOfRangeException("\n- No negativ values allowed!");
                    m_mainFormInstance.m_athlete.BodyPartRegister[m_mainFormInstance.bodyPartGridView.SelectedRows[0].Index].Diameter.Add(diameter);
                    m_mainFormInstance.m_athlete.showRegisteredBodyParts();
                }
                else if (m_measurementType == Measurement.Weight)
                {
                    double weight;
                    StringBuilder dateString = new StringBuilder();
                    dateString.Append(dayComboBox.Text + "." + monthComboBox.Text + "." + yearComboBox.Text);
                    weight = Math.Round(Convert.ToDouble(diameterTextBox.Text), 1);
                    if (weight < 0)
                        throw new ArgumentOutOfRangeException("\n- No negativ values allowed!");

                    m_mainFormInstance.m_athlete.WeightRegister.addMeasurement(dateString.ToString(), weight);

                    m_mainFormInstance.m_athlete.showAthlete();
                }
                this.Close();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dayComboBox.SelectedIndex != 0 && monthComboBox.SelectedIndex != 0 && yearComboBox.SelectedIndex != 0 && diameterTextBox.Text != "")
                addButton.Enabled = true;
            else
                addButton.Enabled = false;
        }

        private void monthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dayComboBox.SelectedIndex != 0 && monthComboBox.SelectedIndex != 0 && yearComboBox.SelectedIndex != 0 && diameterTextBox.Text != "")
                addButton.Enabled = true;
            else
                addButton.Enabled = false;
        }

        private void yearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dayComboBox.SelectedIndex != 0 && monthComboBox.SelectedIndex != 0 && yearComboBox.SelectedIndex != 0 && diameterTextBox.Text != "")
                addButton.Enabled = true;
            else
                addButton.Enabled = false;
        }

        private void diameterTextBox_TextChanged(object sender, EventArgs e)
        {
            if (dayComboBox.SelectedIndex != 0 && monthComboBox.SelectedIndex != 0 && yearComboBox.SelectedIndex != 0 && diameterTextBox.Text != "")
                addButton.Enabled = true;
            else
                addButton.Enabled = false;
        }

        #endregion events
    }
}