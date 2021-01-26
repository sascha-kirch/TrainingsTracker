using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TrainigsTracker
{
    public class TrainingsDay
    {
        public TrainingsDay(MainForm formInstance)
        {
            m_mainformInstance = formInstance;
            m_exercisesOfTheDay = new List<Exercise>();
        }

        public TrainingsDay(MainForm formInstance, string date)
        {
            m_mainformInstance = formInstance;
            m_exercisesOfTheDay = new List<Exercise>();
            m_date = date;
        }

        private List<Exercise> m_exercisesOfTheDay;
        private string m_date;
        private MainForm m_mainformInstance;

        public string Date
        {
            get
            {
                return this.m_date;
            }
            set
            {
                this.m_date = value;
            }
        }

        public List<Exercise> ExercisesOfTheDay
        {
            get
            {
                return this.m_exercisesOfTheDay;
            }
            set
            {
                this.m_exercisesOfTheDay = value;
            }
        }

        //TODO diese add methoden sollten auch die werte der Übung enthalten wie die wiederholungen und gewichte....

        public void addMachineExcercise(string trainingName, string comment, ExerciseSet[] excerciseSet)
        {
            MachineExcercise machineExcercise = new MachineExcercise(trainingName, comment, excerciseSet);
            m_exercisesOfTheDay.Add(machineExcercise);
        }

        public void addCardioExcercise(string trainingName, string comment, int distance, Duration trainingTime)
        {
            CardioExercise cardioExcercise = new CardioExercise(trainingName, comment, distance, trainingTime);
            m_exercisesOfTheDay.Add(cardioExcercise);
        }

        public void addBodyWeightExcercise(string trainingName, string comment, int[] repetitions)
        {
            BodyWeightExercise bodyWeightExcercise = new BodyWeightExercise(trainingName, comment, repetitions);
            m_exercisesOfTheDay.Add(bodyWeightExcercise);
        }

        public void addSpecialExcercise(string trainingName, string comment)
        {
            SpecialExercise specialExcercise = new SpecialExercise(trainingName, comment);
            m_exercisesOfTheDay.Add(specialExcercise);
        }

        /// <summary>
        /// This method shows the Training in the Trainingsdays tree
        /// </summary>
        public void showTrainingsDay()
        {
            StringBuilder currentElement = new StringBuilder();

            TreeNode trainingsDayNode;
            TreeNode[] excerciseNodes = new TreeNode[this.m_exercisesOfTheDay.Count];

            for (int it = 0; it < this.m_exercisesOfTheDay.Count; it++)
            {
                excerciseNodes[it] = new TreeNode(this.m_exercisesOfTheDay[it].ExerciseName);
            }

            trainingsDayNode = new TreeNode(m_date.ToString(), excerciseNodes);

            m_mainformInstance.listOfTrainingsTreeView.Nodes.Add(trainingsDayNode);
        }

        public string createSaveString()
        {
            StringBuilder savedString = new StringBuilder();
            savedString.AppendLine("\t <Trainingsday>");
            savedString.AppendLine("\t \t <Date>" + m_date + "</Date>");
            for (int it = 0; it < m_exercisesOfTheDay.Count; it++)
            {
                //TODO sace exercise implementieren in der exercise klasse
                savedString.AppendLine("\t \t <Exercise>");
                savedString.Append(m_exercisesOfTheDay[it].createSaveString());
                savedString.AppendLine("\t \t </Exercise>");
            }

            savedString.AppendLine("\t </Trainingsday>");

            return savedString.ToString();
        }
    }
}