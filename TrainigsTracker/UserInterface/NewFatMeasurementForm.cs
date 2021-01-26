using System;
using System.Text;
using System.Windows.Forms;

namespace TrainigsTracker
{
    public enum FatMeasurementMethodE
    {
        _3_FaltenMethode,
        _7_FaltenMethode
    }

    public partial class NewFatMeasurementForm : Form
    {
        public NewFatMeasurementForm(MainForm mainFormInstance)
        {
            InitializeComponent();
            dayComboBox.SelectedItem = DateTime.Today.Day < 10 ? "0" + DateTime.Today.Day.ToString() : DateTime.Today.Day.ToString();
            monthComboBox.SelectedItem = DateTime.Today.Month < 10 ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString(); ;
            yearComboBox.SelectedItem = DateTime.Today.Year.ToString();
            methodComboBox.SelectedIndex = 0;
            m_mainFormInstance = mainFormInstance;
        }

        private MainForm m_mainFormInstance;
        private FatMeasurementMethodE m_fatMeasurementMethod;
        private string m_3PunktVideoLink = @"https://www.youtube.com/watch?v=FT0O_kWnUcU";
        private string m_7punktVideoLink = @"https://www.youtube.com/watch?v=RnrHw4XCIXM";

        private void methodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (methodComboBox.SelectedIndex == 0)
            {
                bodyFatDataGridView.Rows.Clear();
                m_fatMeasurementMethod = FatMeasurementMethodE._3_FaltenMethode;
                bodyFatDataGridView.Rows.Add("Brust", 0);
                bodyFatDataGridView.Rows.Add("Bauch", 0);
                bodyFatDataGridView.Rows.Add("Oberschenkel", 0);
            }
            else
            {
                bodyFatDataGridView.Rows.Clear();
                m_fatMeasurementMethod = FatMeasurementMethodE._7_FaltenMethode;
                bodyFatDataGridView.Rows.Add("Brust", 0);
                bodyFatDataGridView.Rows.Add("Bauch", 0);
                bodyFatDataGridView.Rows.Add("Oberschenkel", 0);
                bodyFatDataGridView.Rows.Add("Hüfte", 0);
                bodyFatDataGridView.Rows.Add("Achsel", 0);
                bodyFatDataGridView.Rows.Add("Trizeps", 0);
                bodyFatDataGridView.Rows.Add("Schulterblatt", 0);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder dateString = new StringBuilder();
                dateString.Append(dayComboBox.Text + "." + monthComboBox.Text + "." + yearComboBox.Text);
                if (m_fatMeasurementMethod == FatMeasurementMethodE._3_FaltenMethode)
                {
                    for (int it = 0; it < 3; it++)
                    {
                        double value = Convert.ToDouble(bodyFatDataGridView.Rows[it].Cells[1].Value);
                        if (value < 0)
                            throw new ArgumentOutOfRangeException("\n- No negativ values allowed!");

                        m_mainFormInstance.m_athlete.BodyFatRegister[it].Date.Add(dateString.ToString());
                        m_mainFormInstance.m_athlete.BodyFatRegister[it].Diameter.Add(value);
                    }
                }
                else if (m_fatMeasurementMethod == FatMeasurementMethodE._7_FaltenMethode)
                {
                    for (int it = 0; it < 7; it++)
                    {
                        double value = Convert.ToDouble(bodyFatDataGridView.Rows[it].Cells[1].Value);
                        if (value < 0)
                            throw new ArgumentOutOfRangeException("\n- No negativ values allowed!");
                        m_mainFormInstance.m_athlete.BodyFatRegister[it].Date.Add(dateString.ToString());
                        m_mainFormInstance.m_athlete.BodyFatRegister[it].Diameter.Add(value);
                    }
                }
                m_mainFormInstance.m_athlete.BodyFatRegister[7].Date.Add(dateString.ToString());
                m_mainFormInstance.m_athlete.BodyFatRegister[7].Diameter.Add(calculateBodyFat());

                m_mainFormInstance.updateGui();

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

        private double calculateBodyFat()
        {
            double bodyFat = 0;
            double total = 0;

            if (m_fatMeasurementMethod == FatMeasurementMethodE._3_FaltenMethode)
            {
                for (int it = 0; it < 3; it++)
                {
                    total += Convert.ToDouble(bodyFatDataGridView.Rows[it].Cells[1].Value);
                }
                if (m_mainFormInstance.m_athlete.AthleteGender == Gender.Male)
                {
                    bodyFat = 495 / (1.10938 - (0.0008267 * total) + (0.0000016 * total * total) - (0.0002574 * m_mainFormInstance.m_athlete.Age)) - 450;
                }
                else
                {
                    bodyFat = 495 / (1.089733 - (0.0009245 * total) + (0.0000025 * total * total) - (0.0000979 * m_mainFormInstance.m_athlete.Age)) - 450;
                }
            }
            else if (m_fatMeasurementMethod == FatMeasurementMethodE._7_FaltenMethode)
            {
                for (int it = 0; it < 7; it++)
                {
                    total += Convert.ToDouble(bodyFatDataGridView.Rows[it].Cells[1].Value);
                }
                if (m_mainFormInstance.m_athlete.AthleteGender == Gender.Male)
                {
                    bodyFat = 495 / (1.112 - (0.00043499 * total) + (0.00000055 * total * total) - (0.00028826 * m_mainFormInstance.m_athlete.Age)) - 450;
                }
                else
                {
                    bodyFat = 495 / (1.097 - (0.00046971 * total) + (0.00000056 * total * total) - (0.00012828 * m_mainFormInstance.m_athlete.Age)) - 450;
                }
            }

            return Math.Round(bodyFat, 2);
        }

        private void videoLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_fatMeasurementMethod == FatMeasurementMethodE._3_FaltenMethode)
            {
                System.Diagnostics.Process.Start(m_3PunktVideoLink);
            }
            else if (m_fatMeasurementMethod == FatMeasurementMethodE._7_FaltenMethode)
            {
                System.Diagnostics.Process.Start(m_7punktVideoLink);
            }
            else
                throw new Exception("Error");
        }
    }
}