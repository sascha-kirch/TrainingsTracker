using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TrainigsTracker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            StartUpProjectForm startUpProjectForm = new StartUpProjectForm(this);
            startUpProjectForm.Show();
            m_exerciseRegister = new ExerciseRegister();
            m_trainingDayRegister = new TrainingsdayRegister();
            m_trainingsStatistic = new TrainingStatistics(this);
        }

        #region member

        //TODO Klasse Trainingstracker erzeugen welche den Athleten, die register und die statistik beinhaltet, dammit nicht alle in der Mainform erledigt wird!
        public Athlete m_athlete;

        private ExerciseRegister m_exerciseRegister;
        private TrainingsdayRegister m_trainingDayRegister;
        private TrainingStatistics m_trainingsStatistic;
        private bool m_projectOpen = false;
        private NewTrainingsDayForm m_newTrainingsDayForm;
        private RegisterExerciseForm m_registerExerciseForm;

        #endregion member

        #region Properties

        public ExerciseRegister ExerciseRegister
        {
            get
            {
                return this.m_exerciseRegister;
            }
            set
            {
                this.m_exerciseRegister = value;
            }
        }

        //sorted by type of training and date
        public TrainingsdayRegister TrainingDayRegister
        {
            get
            {
                return m_trainingDayRegister;
            }
            set
            {
                m_trainingDayRegister = value;
            }
        }

        #endregion Properties

        #region events

        private void weightDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (weightDataGridView.SelectedRows[0].Index != -1)
            {
                if (m_athlete.WeightRegister.WeightList.Count != 0)
                {
                    AthleteGraphForm athleteGraphForm = new AthleteGraphForm("Weight", this, Measurement.Weight);
                    athleteGraphForm.Show();
                }
                else
                    MessageBox.Show("You need to measure in order to see your results", "Info");
            }
        }

        private void bodyPartGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (bodyPartGridView.SelectedRows.Count != 0)
            {
                if (bodyPartGridView.SelectedRows[0].Index != -1)
                {
                    string measuredPart = m_athlete.BodyPartRegister[bodyPartGridView.SelectedRows[0].Index].Name;
                    if (m_athlete.BodyPartRegister[bodyPartGridView.SelectedRows[0].Index].Diameter.Count != 0)
                    {
                        AthleteGraphForm athleteGraphForm = new AthleteGraphForm(measuredPart, this, Measurement.BoodyPart);
                        athleteGraphForm.Show();
                    }
                    else
                        MessageBox.Show("You need to measure in order to see your results", "Info");
                }
            }
        }

        private void bodyFatDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (bodyFatDataGridView.SelectedRows.Count != 0)
            {
                if (bodyFatDataGridView.SelectedRows[0].Index != -1)
                {
                    string measuredPart = m_athlete.BodyFatRegister[bodyFatDataGridView.SelectedRows[0].Index].Name;
                    if (m_athlete.BodyFatRegister[bodyFatDataGridView.SelectedRows[0].Index].Diameter.Count != 0)
                    {
                        AthleteGraphForm athleteGraphForm = new AthleteGraphForm(measuredPart, this, Measurement.Fat);
                        athleteGraphForm.Show();
                    }
                    else
                        MessageBox.Show("You need to measure in order to see your results", "Info");
                }
            }
        }

        private void updateWeightButton_Click(object sender, EventArgs e)
        {
            NewMeasurementForm newMeasurementForm = new NewMeasurementForm(this, null, Measurement.Weight);
            newMeasurementForm.ShowDialog();
        }

        private void saveProjectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            StreamWriter dataStream;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "TrainingsTracker Project Files(*.ttp)|*.ttp";
            saveDialog.FilterIndex = 1;
            saveDialog.RestoreDirectory = true;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                //using schließt den stream automatisch
                using (dataStream = File.CreateText(saveDialog.FileName))
                {
                    dataStream.Write(saveProject());
                }
            }
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadProjekt();
        }

        private void addBodyPartButton_Click(object sender, EventArgs e)
        {
            NewBodyPartForm newBodyPartForm = new NewBodyPartForm(this);
            newBodyPartForm.ShowDialog();
        }

        private void removeBodypartButton_Click(object sender, EventArgs e)
        {
            string name = m_athlete.BodyPartRegister[bodyPartGridView.SelectedRows[0].Index].Name;
            if (m_athlete.BodyPartRegister[bodyPartGridView.SelectedRows[0].Index].Diameter.Count > 0)
            {
                MessageBox.Show("You allready have Measurements for the bodypart \"" + name + "\". If you really want to delete this bodypart do it in the project File!", "Warning");
            }
            else
            {
                m_athlete.BodyPartRegister.RemoveAt(bodyPartGridView.SelectedRows[0].Index);
                bodyPartGridView.Rows.RemoveAt(bodyPartGridView.SelectedRows[0].Index);
            }
        }

        private void exerciseDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (exerciseDataGridView.SelectedRows.Count != 0)
            {
                if (exerciseDataGridView.SelectedRows[0].Index != -1)
                    removeExerciseButton.Enabled = true;
                else
                    removeExerciseButton.Enabled = false;
            }
        }

        private void bodyPartGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (bodyPartGridView.SelectedRows.Count != 0)
            {
                if (bodyPartGridView.SelectedRows[0].Index != -1)
                {
                    removeBodypartButton.Enabled = true;
                    newMeasurementButton.Enabled = true;
                }
            }
            else
            {
                removeBodypartButton.Enabled = false;
                newMeasurementButton.Enabled = false;
            }
        }

        private void removeExerciseButton_Click(object sender, EventArgs e)
        {
            if (m_trainingDayRegister.getHowManyTimesTrained(ExerciseRegister.RegisteredExercises[exerciseDataGridView.SelectedRows[0].Index].ExerciseName) == 0)
            {
                ExerciseRegister.RegisteredExercises.RemoveAt(exerciseDataGridView.SelectedRows[0].Index);
                exerciseDataGridView.Rows.RemoveAt(exerciseDataGridView.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("You allready Trained this Exercise. If you really want to remove it talk to Sascha!", "Warning");
            }
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newProjekt();
        }

        private void showExerciseInfo_MouseEvent(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                editButton.Enabled = false;
                string parent = e.Node.Parent.Text.ToString();
                int index = e.Node.Index;

                showExerciseInfo(parent, index);
            }
            else if (e.Node.Parent == null && e.Node.Index >= 0)
            {
                editButton.Enabled = true;
            }
        }

        private void addTrainingButton_Click(object sender, EventArgs e)
        {
            m_newTrainingsDayForm = new NewTrainingsDayForm(this);
            m_newTrainingsDayForm.Show();
            addTrainingButton.Enabled = false;
        }

        private void registerExerciseButton_Click(object sender, EventArgs e)
        {
            m_registerExerciseForm = new RegisterExerciseForm(this);
            m_registerExerciseForm.ShowDialog();
        }

        private void newMeasurementButton_Click(object sender, EventArgs e)
        {
            NewMeasurementForm newMeasurementForm = new NewMeasurementForm(this, m_athlete.BodyPartRegister[bodyPartGridView.SelectedRows[0].Index], Measurement.BoodyPart);
            newMeasurementForm.ShowDialog();
        }

        private void newBodyFatMeasurementButton_Click(object sender, EventArgs e)
        {
            NewFatMeasurementForm newFatMeasurementForm = new NewFatMeasurementForm(this);
            newFatMeasurementForm.ShowDialog();
        }

        private void exerciseDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (exerciseDataGridView.SelectedRows.Count != 0)
            {
                if (exerciseDataGridView.SelectedRows[0].Index != -1)
                {
                    string exerciseName = ExerciseRegister.RegisteredExercises[exerciseDataGridView.SelectedRows[0].Index].ExerciseName;
                    if (m_trainingDayRegister.getHowManyTimesTrained(exerciseName) != 0)
                    {
                        GraphViewerForm graphViewerForm = new GraphViewerForm(exerciseName, this);
                        graphViewerForm.Show();
                    }
                    else
                        MessageBox.Show("You need to train in order to see your results", "Info");
                }
            }
        }

        private void listOfTrainingsTreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            exerciseGenericLabel.Text = "";
            typeGenericLabel.Text = "";
            exerciseInfoDataGridView.Rows.Clear();
            exerciseInfoDataGridView.Columns.Clear();
            exerciseStatisticDataGridView.Rows.Clear();
            commentTextBox.Text = "";
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            //TODO method implementation.
            if (listOfTrainingsTreeView.SelectedNode != null)
            {
                string date = listOfTrainingsTreeView.SelectedNode.Text;
                NewTrainingsDayForm newTrainingsDayForm = new NewTrainingsDayForm(this, TrainingDayRegister.RegisteredTrainingsDays[TrainingDayRegister.getTrainingsDayIndex(date)]);
                newTrainingsDayForm.Show();
            }
        }

        private void bodyFatDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (bodyFatDataGridView.SelectedRows.Count != 0)
            {
                if (bodyFatDataGridView.SelectedRows[0].Index != -1)
                {
                    newBodyFatMeasurementButton.Enabled = true;
                }
            }
            else
            {
                newBodyFatMeasurementButton.Enabled = false;
            }
        }

        #endregion events

        #region helperMethods

        //public int FindMaximumTrainingsInRow()
        //{
        //    int maxInARow = 0;
        //    for (int it = 0; it < calendar.BoldedDates.Length; it++)
        //    {
        //        if(calendar.BoldedDates[it].Date.Day+1 == calendar.BoldedDates[it+1].Date.Day)
        //        {
        //        }
        //        else
        //        {
        //        }
        //    }
        //    return maxInARow;
        //}

        public void showRegisteredExercises()
        {
            m_exerciseRegister.sortElements();
            exerciseDataGridView.Rows.Clear();
            for (int it = 0; it < m_exerciseRegister.RegisteredExercises.Count; it++)
            {
                exerciseDataGridView.Rows.Add(m_exerciseRegister.RegisteredExercises[it].ExerciseName, m_exerciseRegister.RegisteredExercises[it].TypeOfExcercise, m_trainingDayRegister.getHowManyTimesTrained(m_exerciseRegister.RegisteredExercises[it].ExerciseName));
            }
        }

        public string saveProject()
        {
            StringBuilder savedString = new StringBuilder();
            savedString.AppendLine("<Athlete>");
            savedString.AppendLine("\t <Name>" + m_athlete.Name + "</Name>");
            savedString.AppendLine("\t <Height>" + m_athlete.Height + "</Height>");
            savedString.Append(m_athlete.WeightRegister.createSaveString());
            savedString.AppendLine("\t <Age>" + m_athlete.Age + "</Age>");
            savedString.AppendLine("\t <Gender>" + m_athlete.AthleteGender.ToString() + "</Gender>");
            savedString.AppendLine("</Athlete>");
            savedString.AppendLine("<BodypartsRegister>");
            for (int it = 0; it < m_athlete.BodyPartRegister.Count; it++)
            {
                savedString.Append(m_athlete.BodyPartRegister[it].createSaveString());
            }
            savedString.AppendLine("</BodypartsRegister>");

            savedString.AppendLine("<BodyFatRegister>");
            for (int it = 0; it < m_athlete.BodyFatRegister.Count; it++)
            {
                savedString.Append(m_athlete.BodyFatRegister[it].createSaveString());
            }
            savedString.AppendLine("</BodyFatRegister>");

            savedString.Append(m_exerciseRegister.createSaveString());

            savedString.AppendLine("<TrainingsdayList>");
            for (int it = 0; it < TrainingDayRegister.RegisteredTrainingsDays.Count; it++)
            {
                savedString.Append(TrainingDayRegister.RegisteredTrainingsDays[it].createSaveString());
            }
            savedString.AppendLine("</TrainingsdayList>");

            return savedString.ToString();
        }

        public void loadProjekt()
        {
            string dataFile = "";
            string fileContent = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TrainingsTracker Project Files(*.ttp)|*.ttp";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dataFile = openFileDialog.FileName;
                    fileContent = System.IO.File.ReadAllText(dataFile);
                    fileContent = fileContent.Replace("\r", "");
                    fileContent = fileContent.Replace("\t", "");
                    fileContent = fileContent.Replace("\n", "");
                    parseLoadString(Convert.ToString(fileContent));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            else
            {
                return;
            }

            m_projectOpen = true;
            exerciseDetailsGroupBox.Visible = true;
            trainingsDaysGroupBox.Visible = true;
            mainFrameTabControl.Visible = true;
            updateGui();
        }

        private DateTime stringToDateTime(string dateString)
        {
            int day = 1;
            int month = 1;
            int year = 2000;
            string[] subString = new string[3];

            try
            {
                subString = dateString.Split('.');
                day = Convert.ToInt32(subString[0]);

                month = Convert.ToInt32(subString[1]);

                year = Convert.ToInt32(subString[2]);
            }
            catch
            {
                MessageBox.Show("could not read the inserted date. Make sure the format is dd.mm.yyyy");
            }

            DateTime date = new DateTime(year, month, day);
            return date;
        }

        private void showExerciseInfo(string parent, int index)
        {
            exerciseInfoDataGridView.Columns.Clear();
            exerciseInfoDataGridView.Rows.Clear();
            exerciseStatisticDataGridView.Rows.Clear();

            exerciseGenericLabel.Text = (TrainingDayRegister.getExerciseFromListTree(parent, index)).ExerciseName;
            exerciseGenericLabel.Visible = true;
            EtypeOfExercise type = (TrainingDayRegister.getExerciseFromListTree(parent, index)).TypeOfExcercise;
            typeGenericLabel.Text = type.ToString();
            typeGenericLabel.Visible = true;
            object[] exerciseInfo = (TrainingDayRegister.getExerciseFromListTree(parent, index)).getExerciseInfo();
            object[] exerciseStatistic = (TrainingDayRegister.getExerciseFromListTree(parent, index)).getExerciseStatistic();
            commentTextBox.Text = (TrainingDayRegister.getExerciseFromListTree(parent, index)).getComment();

            if (type == EtypeOfExercise.MachineExercise)
            {
                exerciseInfoDataGridView.Columns.Add("setColumn", "Set");
                exerciseInfoDataGridView.Columns.Add("weightColumn", "Weight");
                exerciseInfoDataGridView.Columns.Add("repetitionsColumn", "Repetition");
                for (int it = 0; it < (exerciseInfo.Length) / 2; it++)
                {
                    exerciseInfoDataGridView.Rows.Add(
                                it + 1,
                                exerciseInfo[2 * it],
                                exerciseInfo[2 * it + 1]
                                );
                }

                exerciseStatisticDataGridView.Rows.Add("Average Weight", exerciseStatistic[0]);
                exerciseStatisticDataGridView.Rows.Add("Moved Weight", exerciseStatistic[1]);
                exerciseStatisticDataGridView.Rows.Add("Min Weight", exerciseStatistic[2]);
                exerciseStatisticDataGridView.Rows.Add("Max Weight", exerciseStatistic[3]);
                exerciseStatisticDataGridView.Rows.Add("Average Repetitions", exerciseStatistic[4]);
            }
            else if (type == EtypeOfExercise.CardioExercise)
            {
                exerciseInfoDataGridView.Columns.Add("distanceColumn", "Exercise Property");
                exerciseInfoDataGridView.Columns.Add("durationColumn", "Value");

                exerciseInfoDataGridView.Rows.Add(
                            "Distance",
                            exerciseInfo[0]
                            );

                exerciseInfoDataGridView.Rows.Add(
                            "Duration",
                            exerciseInfo[1]
                            );

                exerciseStatisticDataGridView.Rows.Add("Average Speed", exerciseStatistic[0]);
                exerciseStatisticDataGridView.Rows.Add("Average Speed", exerciseStatistic[1]);
            }
            else if (type == EtypeOfExercise.BodyWeightExercise)
            {
                exerciseInfoDataGridView.Columns.Add("setColumn", "Set");
                exerciseInfoDataGridView.Columns.Add("repetitionsColumn", "Repetition");
                for (int it = 0; it < (exerciseInfo.Length); it++)
                {
                    exerciseInfoDataGridView.Rows.Add(
                                it + 1,
                                exerciseInfo[it]
                                );
                }

                exerciseStatisticDataGridView.Rows.Add("Total Repetitions", exerciseStatistic[0]);
                exerciseStatisticDataGridView.Rows.Add("Average Repetitions", exerciseStatistic[1]);
            }
            else if (type == EtypeOfExercise.SpecialExercise)
            {
                throw new NotImplementedException();
            }

            for (int it = 0; it < exerciseInfoDataGridView.Columns.Count; it++)
            {
                exerciseInfoDataGridView.Columns[it].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

                if (type == EtypeOfExercise.CardioExercise)
                    exerciseInfoDataGridView.Columns[it].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                else
                    exerciseInfoDataGridView.Columns[it].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public void updateGui()
        {
            m_athlete.showAthlete();
            m_athlete.showRegisteredBodyParts();
            m_athlete.showRegisteredFatMeasurements();
            showRegisteredExercises();
            showTraining();
            updateStatisticTab();
            calendar.UpdateBoldedDates();
        }

        public void updateStatisticTab()
        {
            statisticTotalTrainingsGenericLabel.Text = Convert.ToString(m_trainingDayRegister.RegisteredTrainingsDays.Count);
            m_trainingsStatistic.updateMonthlyTrainingStats();
        }

        public void showTraining()
        {
            calendar.RemoveAllBoldedDates();
            m_trainingDayRegister.sortTrainingsDayList();
            listOfTrainingsTreeView.Nodes.Clear();
            string[] dateString;
            for (int it = 0; it < m_trainingDayRegister.RegisteredTrainingsDays.Count; it++)
            {
                m_trainingDayRegister.RegisteredTrainingsDays[it].showTrainingsDay();
                dateString = m_trainingDayRegister.RegisteredTrainingsDays[it].Date.Split('.');
                calendar.AddBoldedDate(new DateTime(Convert.ToInt32(dateString[2]), Convert.ToInt32(dateString[1]), Convert.ToInt32(dateString[0])));
            }
        }

        public void newProjekt()
        {
            NewAthleteForm newAthleteForm = new NewAthleteForm(this);
            newAthleteForm.ShowDialog();
            if (newAthleteForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                m_projectOpen = true;
                exerciseDetailsGroupBox.Visible = true;
                trainingsDaysGroupBox.Visible = true;
                mainFrameTabControl.Visible = true;
                updateGui();
            }
            else
            {
                m_projectOpen = false;
                exerciseDetailsGroupBox.Visible = false;
                trainingsDaysGroupBox.Visible = false;
                mainFrameTabControl.Visible = false;
            }
        }

        private void parseLoadString(string loadString)
        {
            try
            {
                if (m_athlete.BodyPartRegister != null)
                    m_athlete.BodyPartRegister = null;
                if (m_athlete.WeightRegister != null)
                    m_athlete.WeightRegister = null;
                if (ExerciseRegister != null)
                    ExerciseRegister = null;
                if (TrainingDayRegister != null)
                    TrainingDayRegister = null;
                if (m_athlete != null)
                    m_athlete = null;
            }
            catch
            {
            }

            List<TrainingsDay> trainingsDaylist = new List<TrainingsDay>();
            string[] athleteString = getInfoFromXMLFile(loadString, "Athlete");
            string[] bodyPartsRegisterString = getInfoFromXMLFile(loadString, "BodypartsRegister");
            string[] bodyFatRegisterString = getInfoFromXMLFile(loadString, "BodyFatRegister");
            string[] exerciseRegisterString = getInfoFromXMLFile(loadString, "ExerciseRegister");
            string[] trainingsDayListString = getInfoFromXMLFile(loadString, "TrainingsdayList");

            string[] bodyPartsString = getInfoFromXMLFile(bodyPartsRegisterString[0], "Bodypart");
            string[] bodyFatString = getInfoFromXMLFile(bodyFatRegisterString[0], "Bodypart");
            string[] registeredExercisesString = getInfoFromXMLFile(exerciseRegisterString[0], "Exercise");
            string[] trainingsDayString = getInfoFromXMLFile(trainingsDayListString[0], "Trainingsday");

            string[] exerciseOfTheDay;

            #region Restore the Athlete

            Gender gender;
            if (getInfoFromXMLFile(athleteString[0], "Gender")[0] == Gender.Male.ToString())
                gender = Gender.Male;
            else
                gender = Gender.Female;

            string weightString = getInfoFromXMLFile(athleteString[0], "WeightRegister")[0];

            this.m_athlete = new Athlete(
            getInfoFromXMLFile(athleteString[0], "Name")[0],
           Convert.ToInt32(getInfoFromXMLFile(athleteString[0], "Height")[0]),
           Convert.ToInt32(getInfoFromXMLFile(athleteString[0], "Age")[0]),
           this,
           gender);

            //Damit bleibt measurementString lokal
            if (weightString != " ")
            {
                string[] measurementString = getInfoFromXMLFile(weightString, "Measurement");

                for (int it = 0; it < measurementString.Length; it++)
                {
                    m_athlete.WeightRegister.addMeasurement(
                        getInfoFromXMLFile(measurementString[it], "Date")[0],
                        Math.Round(Convert.ToDouble(getInfoFromXMLFile(measurementString[it], "Weight")[0]), 1)
                        );
                }
            }

            #endregion Restore the Athlete

            #region Restore the Bodyparts

            for (int outer_it = 0; outer_it < bodyPartsString.Length; outer_it++)
            {
                string[] measurementString = getInfoFromXMLFile(bodyPartsString[outer_it], "Measurement");

                m_athlete.addBodyPart(
                   getInfoFromXMLFile(bodyPartsString[outer_it], "Name")[0],
                   getInfoFromXMLFile(bodyPartsString[outer_it], "Description")[0]);

                for (int inner_it = 0; inner_it < measurementString.Length; inner_it++)
                {
                    m_athlete.BodyPartRegister[outer_it].Date.Add(getInfoFromXMLFile(measurementString[inner_it], "Date")[0]);
                    m_athlete.BodyPartRegister[outer_it].Diameter.Add(Math.Round(Convert.ToDouble(getInfoFromXMLFile(measurementString[inner_it], "Diameter")[0]), 2));
                }
            }

            #endregion Restore the Bodyparts

            #region Restore the Body Fat Measurements

            for (int outer_it = 0; outer_it < bodyFatString.Length; outer_it++)
            {
                string[] measurementString = getInfoFromXMLFile(bodyFatString[outer_it], "Measurement");

                for (int inner_it = 0; inner_it < measurementString.Length; inner_it++)
                {
                    m_athlete.BodyFatRegister[outer_it].Date.Add(getInfoFromXMLFile(measurementString[inner_it], "Date")[0]);
                    m_athlete.BodyFatRegister[outer_it].Diameter.Add(Math.Round(Convert.ToDouble(getInfoFromXMLFile(measurementString[inner_it], "Diameter")[0]), 2));
                }
            }

            #endregion Restore the Body Fat Measurements

            #region Restore the Exercises

            for (int it = 0; it < registeredExercisesString.Length; it++)
            {
                m_exerciseRegister.RegisteredExercises.Add(new Exercise(
                    getInfoFromXMLFile(registeredExercisesString[it], "Name")[0],
                    (EtypeOfExercise)Enum.Parse(typeof(EtypeOfExercise), getInfoFromXMLFile(registeredExercisesString[it], "Type")[0]),
                   getInfoFromXMLFile(registeredExercisesString[it], "Description")[0]
                    ));
            }

            #endregion Restore the Exercises

            #region Restore the Trainingsdays

            for (int outer_it = 0; outer_it < trainingsDayString.Length; outer_it++)
            {
                m_trainingDayRegister.RegisteredTrainingsDays.Add(new TrainingsDay(this, getInfoFromXMLFile(trainingsDayString[outer_it], "Date")[0]));
                exerciseOfTheDay = getInfoFromXMLFile(trainingsDayString[outer_it], "Exercise");
                for (int inner_it = 0; inner_it < exerciseOfTheDay.Length; inner_it++)
                {
                    string[] type = getInfoFromXMLFile(exerciseOfTheDay[inner_it], "TypeOfExercise");
                    if (type[0] == "MachineExercise")
                    {
                        string[] exerciseSetString = getInfoFromXMLFile(exerciseOfTheDay[inner_it], "Set");
                        ExerciseSet[] exerciseSet = new ExerciseSet[exerciseSetString.Length];
                        for (int it = 0; it < exerciseSetString.Length; it++)
                        {
                            exerciseSet[it] = new ExerciseSet(
                                Convert.ToDouble(getInfoFromXMLFile(exerciseSetString[it], "Weight")[0]),
                                Convert.ToInt32(getInfoFromXMLFile(exerciseSetString[it], "Repetitions")[0])
                                );
                        }

                        TrainingDayRegister.RegisteredTrainingsDays[outer_it].addMachineExcercise(
                            getInfoFromXMLFile(exerciseOfTheDay[inner_it], "ExerciseName")[0],
                            getInfoFromXMLFile(exerciseOfTheDay[inner_it], "Comment")[0],
                            exerciseSet
                            );
                    }
                    else if (type[0] == "BodyWeightExercise")
                    {
                        string[] repetitionsString = getInfoFromXMLFile(exerciseOfTheDay[inner_it], "Repetition");
                        int[] repetitions = new int[repetitionsString.Length];
                        for (int it = 0; it < repetitionsString.Length; it++)
                        {
                            repetitions[it] = Convert.ToInt32(repetitionsString[it]);
                        }

                        TrainingDayRegister.RegisteredTrainingsDays[outer_it].addBodyWeightExcercise(
                            getInfoFromXMLFile(exerciseOfTheDay[inner_it], "ExerciseName")[0],
                            getInfoFromXMLFile(exerciseOfTheDay[inner_it], "Comment")[0],
                            repetitions
                            );
                    }
                    else if (type[0] == "CardioExercise")
                    {
                        Duration duration = new Duration(
                            Convert.ToInt32(getInfoFromXMLFile(exerciseOfTheDay[inner_it], "Hour")[0]),
                            Convert.ToInt32(getInfoFromXMLFile(exerciseOfTheDay[inner_it], "Minute")[0]),
                            Convert.ToInt32(getInfoFromXMLFile(exerciseOfTheDay[inner_it], "Seconds")[0])
                            );

                        TrainingDayRegister.RegisteredTrainingsDays[outer_it].addCardioExcercise(
                            getInfoFromXMLFile(exerciseOfTheDay[inner_it], "ExerciseName")[0],
                            getInfoFromXMLFile(exerciseOfTheDay[inner_it], "Comment")[0],
                            Convert.ToInt32(getInfoFromXMLFile(exerciseOfTheDay[inner_it], "Distance")[0]),
                            duration
                            );
                    }
                    else if (type[0] == "SpecialExercise")
                    {
                        TrainingDayRegister.RegisteredTrainingsDays[outer_it].addSpecialExcercise(
                            getInfoFromXMLFile(exerciseOfTheDay[inner_it], "ExerciseName")[0],
                            getInfoFromXMLFile(exerciseOfTheDay[inner_it], "Comment")[0]
                            );
                    }
                }
            }

            #endregion Restore the Trainingsdays
        }

        public string[] getInfoFromXMLFile(string xmlString, string element)
        {
            string temp = xmlString;
            string info = "";
            string startString = "<" + element + ">";
            string endString = "</" + element + ">";

            int numberOfMatches = 0;
            //stupid hack in order to find the number of matches
            while (temp.IndexOf(startString) != -1)
            {
                numberOfMatches++;
                temp = temp.Remove(0, temp.IndexOf(endString) + 1);
            }

            string[] returnString = new string[numberOfMatches];

            temp = xmlString;

            for (int it = 0; it < numberOfMatches; it++)
            {
                temp = xmlString;
                info = temp.Remove(0, temp.IndexOf(startString));
                info = info.Replace(startString, "");
                info = info.Remove(info.IndexOf(endString));
                returnString[it] = info;
                xmlString = xmlString.Remove(0, xmlString.IndexOf(endString) + 1);
            }

            return returnString;
        }

        #endregion helperMethods
    }
}