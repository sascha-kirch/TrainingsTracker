using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TrainigsTracker
{
    public partial class NewTrainingsDayForm : Form
    {
        /// <summary>
        /// For adding a new Trainingsday
        /// </summary>
        /// <param name="mainFormInstance"></param>
        public NewTrainingsDayForm(MainForm mainFormInstance)
        {
            InitializeComponent();
            m_mainFormInstance = mainFormInstance;
            dayComboBox.SelectedItem = DateTime.Today.Day < 10 ? "0" + DateTime.Today.Day.ToString() : DateTime.Today.Day.ToString();
            monthComboBox.SelectedItem = DateTime.Today.Month < 10 ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString(); ;
            yearComboBox.SelectedItem = DateTime.Today.Year.ToString();
            //m_trainingsDay = new TrainingsDay(mainFormInstance);
            m_isEditMode = false;
            for (int it = 0; it < mainFormInstance.ExerciseRegister.RegisteredExercises.Count; it++)
            {
                exerciseSelectionCheckedListBox.Items.Add(mainFormInstance.ExerciseRegister.RegisteredExercises[it].ExerciseName);
            }
            m_exerciseRowList = new List<object>();
        }

        /// <summary>
        /// For editing an existing Trainingsday
        /// </summary>
        /// <param name="mainFormInstance"></param>
        /// <param name="trainingsDay"></param>
        public NewTrainingsDayForm(MainForm mainFormInstance, TrainingsDay trainingsDay)
        {
            InitializeComponent();
            m_mainFormInstance = mainFormInstance;
            m_trainingsDay = trainingsDay;
            string[] dateString = trainingsDay.Date.Split('.');
            dayComboBox.SelectedItem = dateString[0];
            monthComboBox.SelectedItem = dateString[1];
            yearComboBox.SelectedItem = dateString[2];
            for (int it = 0; it < mainFormInstance.ExerciseRegister.RegisteredExercises.Count; it++)
            {
                exerciseSelectionCheckedListBox.Items.Add(mainFormInstance.ExerciseRegister.RegisteredExercises[it].ExerciseName);
            }
            m_exerciseRowList = new List<object>();
            refillDataGrid(trainingsDay);
            m_isEditMode = true;
        }
        ~NewTrainingsDayForm()
        {
            InitializeComponent();
        }

        private MainForm m_mainFormInstance;
        public TrainingsDay m_trainingsDay;
        private bool m_isEditMode;
        private List<object> m_exerciseRowList;

        private void refillDataGrid(TrainingsDay trainingsDay)
        {
            foreach (Exercise exercise in trainingsDay.ExercisesOfTheDay)
            {
                string trainingsInfo = "";
                if (exercise is MachineExcercise)
                {
                    ExerciseSet[] exerciseSet = ((MachineExcercise)exercise).GymTrainingExercise;

                    trainingsInfo = Convert.ToString(
                        exerciseSet[0].Repetitions
                        + "x"
                        + exerciseSet[0].Weight
                        );
                    for (int i = 1; i < exerciseSet.Length; i++)
                    {
                        trainingsInfo = trainingsInfo + ";" + exerciseSet[i].Repetitions + "x" + exerciseSet[i].Weight;
                    }
                }
                if (exercise is CardioExercise)
                {
                    Duration duration = ((CardioExercise)exercise).ExerciseDuration;
                    int distance = ((CardioExercise)exercise).Distance;
                    trainingsInfo = Convert.ToString(duration.H + ";" + duration.Min + ";" + duration.Sec + ";" + distance);
                }
                if (exercise is BodyWeightExercise)
                {
                    int[] repetitions = ((BodyWeightExercise)exercise).Repetitions;
                    trainingsInfo = Convert.ToString(repetitions[0]);
                    for (int i = 1; i < repetitions.Length; i++)
                    {
                        trainingsInfo = trainingsInfo + ";" + repetitions[i];
                    }
                }
                if (exercise is SpecialExercise)
                {
                    trainingsInfo = "";
                }
                trainingsDayDataGridView.Rows.Add(exercise.ExerciseName, exercise.TypeOfExcercise.ToString(), trainingsInfo, exercise.Comment);

                int checkItemIndex = exerciseSelectionCheckedListBox.Items.IndexOf(trainingsDayDataGridView.Rows[trainingsDayDataGridView.Rows.Count - 1].Cells[0].Value);
                this.exerciseSelectionCheckedListBox.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.exerciseSelectionCheckedListBox_ItemCheck);
                exerciseSelectionCheckedListBox.SetItemCheckState(checkItemIndex, CheckState.Checked);
                m_exerciseRowList.Add(exerciseSelectionCheckedListBox.Items[checkItemIndex]);
                this.exerciseSelectionCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.exerciseSelectionCheckedListBox_ItemCheck);
            }
        }

        private void NewTrainingsDayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_mainFormInstance.addTrainingButton.Enabled = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addTrainingsDayButton_Click(object sender, EventArgs e)
        {
            if (trainingsDayDataGridView.Rows.Count > 0)
            {
                if (m_isEditMode)
                    m_mainFormInstance.TrainingDayRegister.RegisteredTrainingsDays.RemoveAt(m_mainFormInstance.TrainingDayRegister.getTrainingsDayIndex(m_trainingsDay.Date));
                m_trainingsDay = new TrainingsDay(m_mainFormInstance);

                try
                {
                    parseTraningsDayDataGridView();
                }
                catch
                {
                    //TODO behandlung und erkennung von Syntax errors implementieren
                }
                StringBuilder dateString = new StringBuilder();
                dateString.Append(dayComboBox.Text + "." + monthComboBox.Text + "." + yearComboBox.Text);
                m_trainingsDay.Date = dateString.ToString();
                if (m_mainFormInstance.TrainingDayRegister.trainingsDayExist(dateString.ToString()))
                {
                    m_mainFormInstance.TrainingDayRegister.RegisteredTrainingsDays[m_mainFormInstance.TrainingDayRegister.getTrainingsDayIndex(dateString.ToString())].ExercisesOfTheDay.AddRange(m_trainingsDay.ExercisesOfTheDay);
                    MessageBox.Show("There is allready a Training on the " + dateString.ToString() + "\nThe Exercises will be added to the existing Trainingsday", "Info");
                }
                else
                {
                    m_mainFormInstance.TrainingDayRegister.RegisteredTrainingsDays.Add(m_trainingsDay);
                }

                m_mainFormInstance.updateGui();
                this.Close();
            }
            else
            {
                MessageBox.Show("You need to add Exercises first", "Warning");
            }
        }

        private void parseTraningsDayDataGridView()
        {
            foreach (DataGridViewRow row in trainingsDayDataGridView.Rows)
            {
                string exerciseName = Convert.ToString(row.Cells[0].Value);
                string trainingsInfo = Convert.ToString(row.Cells[2].Value);
                string comment = Convert.ToString(row.Cells[3].Value);
                EtypeOfExercise type = m_mainFormInstance.ExerciseRegister.getTypeOfExercise(exerciseName);

                switch (type)
                {
                    case EtypeOfExercise.MachineExercise:
                        {
                            string[] sets = trainingsInfo.Split(';');
                            int numberOfSets = sets.Length;
                            ExerciseSet[] exerciseSet = new ExerciseSet[numberOfSets];
                            for (int it = 0; it < numberOfSets; it++)
                            {
                                string repetition = sets[it].Split('x')[0];
                                string weigtht = sets[it].Split('x')[1];
                                if (Convert.ToInt32(repetition) < 0 || Convert.ToDouble(weigtht) < 0)
                                    throw new ArgumentOutOfRangeException("\nNo negativ values allowed!");
                                exerciseSet[it] = new ExerciseSet(Convert.ToDouble(weigtht), Convert.ToInt32(repetition));
                            }
                            m_trainingsDay.addMachineExcercise(exerciseName, comment, exerciseSet);

                            break;
                        }
                    case EtypeOfExercise.CardioExercise:
                        {
                            string[] parameter = trainingsInfo.Split(';');

                            int h = Convert.ToInt32(parameter[0]);
                            int min = Convert.ToInt32(parameter[1]);
                            int sec = Convert.ToInt32(parameter[2]);
                            int distance = Convert.ToInt32(parameter[3]);

                            if (min > 59 || sec > 59)
                                throw new ArgumentOutOfRangeException("\n Values for min and sec needs to be between 0 and 59!");
                            if (distance < 0)
                                throw new ArgumentOutOfRangeException("\n- No negativ values allowed!");
                            Duration duration = new Duration(h, min, sec);
                            m_trainingsDay.addCardioExcercise(exerciseName, comment, distance, duration);

                            break;
                        }
                    case EtypeOfExercise.BodyWeightExercise:
                        {
                            string[] sets = trainingsInfo.Split(';');
                            int numberOfSets = sets.Length;
                            int[] repetitions = new int[numberOfSets];
                            for (int it = 0; it < numberOfSets; it++)
                            {
                                string repetition = sets[it];
                                if (Convert.ToInt32(repetition) < 0)
                                    throw new ArgumentOutOfRangeException("\nNo negativ values allowed!");
                                repetitions[it] = Convert.ToInt32(repetition);
                            }
                            m_trainingsDay.addBodyWeightExcercise(exerciseName, comment, repetitions);
                            break;
                        }
                    case EtypeOfExercise.SpecialExercise:
                        {
                            m_trainingsDay.addSpecialExcercise(exerciseName, comment);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        private void dayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dayComboBox.SelectedIndex != 0 && monthComboBox.SelectedIndex != 0 && yearComboBox.SelectedIndex != 0)
                addTrainingsDayButton.Enabled = true;
            else
                addTrainingsDayButton.Enabled = false;
        }

        private void monthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dayComboBox.SelectedIndex != 0 && monthComboBox.SelectedIndex != 0 && yearComboBox.SelectedIndex != 0)
                addTrainingsDayButton.Enabled = true;
            else
                addTrainingsDayButton.Enabled = false;
        }

        private void yearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dayComboBox.SelectedIndex != 0 && monthComboBox.SelectedIndex != 0 && yearComboBox.SelectedIndex != 0)
                addTrainingsDayButton.Enabled = true;
            else
                addTrainingsDayButton.Enabled = false;
        }

        private void exerciseSelectionCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                m_exerciseRowList.Add(exerciseSelectionCheckedListBox.SelectedItem);
                EtypeOfExercise type = m_mainFormInstance.ExerciseRegister.getTypeOfExercise(exerciseSelectionCheckedListBox.SelectedItem.ToString());
                trainingsDayDataGridView.Rows.Add(exerciseSelectionCheckedListBox.SelectedItem, type.ToString());
            }
            else
            {
                int indexToRemove = m_exerciseRowList.IndexOf(exerciseSelectionCheckedListBox.SelectedItem);
                trainingsDayDataGridView.Rows.RemoveAt(indexToRemove);
                m_exerciseRowList.Remove(exerciseSelectionCheckedListBox.SelectedItem);
            }
        }

        private void trainingsDayDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            //ENTF-Taste
            if (e.KeyValue == 46)
            {
                if (trainingsDayDataGridView.SelectedCells.Count != 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to remove all the selected Exercises?", "Warning!", MessageBoxButtons.OKCancel);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        foreach (DataGridViewCell cell in trainingsDayDataGridView.SelectedCells)
                        {
                            DataGridViewRow row = trainingsDayDataGridView.Rows[cell.RowIndex];

                            int indexToRemove = m_exerciseRowList.IndexOf(row.Cells[0].Value);
                            m_exerciseRowList.RemoveAt(indexToRemove);
                            trainingsDayDataGridView.Rows.Remove(row);

                            int unCheckItem = exerciseSelectionCheckedListBox.Items.IndexOf(row.Cells[0].Value);
                            this.exerciseSelectionCheckedListBox.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.exerciseSelectionCheckedListBox_ItemCheck);
                            exerciseSelectionCheckedListBox.SetItemCheckState(unCheckItem, CheckState.Unchecked);
                            this.exerciseSelectionCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.exerciseSelectionCheckedListBox_ItemCheck);
                        }
                    }
                }
            }
        }
    }
}