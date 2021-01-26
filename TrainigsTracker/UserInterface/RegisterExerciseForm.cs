using System;
using System.Windows.Forms;

namespace TrainigsTracker
{
    public partial class RegisterExerciseForm : Form
    {
        public RegisterExerciseForm(MainForm mainFormInstance)
        {
            InitializeComponent();
            m_mainFormInstance = mainFormInstance;
            exerciseTypeComboBox.SelectedIndex = 0;
            fillCombobox();
        }

        private MainForm m_mainFormInstance;

        private void fillCombobox()
        {
            exerciseTypeComboBox.Items.Add(EtypeOfExercise.MachineExercise.ToString());
            exerciseTypeComboBox.Items.Add(EtypeOfExercise.CardioExercise.ToString());
            exerciseTypeComboBox.Items.Add(EtypeOfExercise.BodyWeightExercise.ToString());
            exerciseTypeComboBox.Items.Add(EtypeOfExercise.SpecialExercise.ToString());
        }

        #region events

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registerExerciseButton_Click(object sender, EventArgs e)
        {
            m_mainFormInstance.ExerciseRegister.RegisteredExercises.Add(new Exercise(
                exerciseNameTextBox.Text,
                (EtypeOfExercise)Enum.Parse(typeof(EtypeOfExercise),
                Convert.ToString(exerciseTypeComboBox.SelectedItem)),
                descriptionTextBox.Text));
            m_mainFormInstance.showRegisteredExercises();
            this.Close();
        }

        private void exerciseTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (exerciseTypeComboBox.SelectedIndex != 0 && exerciseNameTextBox.Text != "")
                registerExerciseButton.Enabled = true;
            else
                registerExerciseButton.Enabled = false;
        }

        private void exerciseNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (exerciseTypeComboBox.SelectedIndex != 0 && exerciseNameTextBox.Text != "")
                registerExerciseButton.Enabled = true;
            else
                registerExerciseButton.Enabled = false;
        }

        #endregion events
    }
}