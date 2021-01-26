using System;
using System.Windows.Forms;

namespace TrainigsTracker
{
    public partial class NewBodyPartForm : Form
    {
        public NewBodyPartForm(MainForm mainFormInstance)
        {
            InitializeComponent();
            m_mainFormInstance = mainFormInstance;
        }

        private MainForm m_mainFormInstance;

        #region events

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bodyPartNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (bodyPartNameTextBox.Text != "")
                addButton.Enabled = true;
            else
                addButton.Enabled = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            m_mainFormInstance.m_athlete.addBodyPart(bodyPartNameTextBox.Text, descriptionTextBox.Text);
            m_mainFormInstance.m_athlete.showRegisteredBodyParts();
            this.Close();
        }

        #endregion events

        //TODO überlegen was beste strucktur... auch wieder erst nen bodypart registrieren und in der Main form immer den aktuellsten
        //anzeigen mit datum. wenn nur registriert aber noch nicht gemessen muss dass auch da stehen(not measured yet)
    }
}