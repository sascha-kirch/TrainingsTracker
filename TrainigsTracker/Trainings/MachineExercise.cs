using System;
using System.Text;

//TODO ne funktion zum schreiben der einzelnen Sätze
namespace TrainigsTracker
{
    public class MachineExcercise : Exercise
    {
        public MachineExcercise(string excerciseName, string comment, ExerciseSet[] excerciseSet) :
            base(excerciseName, comment, EtypeOfExercise.MachineExercise)
        {
            m_amountOfSets = excerciseSet.Length;
            m_gymTrainingExercise = new ExerciseSet[m_amountOfSets];

            for (int it = 0; it < m_amountOfSets; it++)
            {
                m_gymTrainingExercise[it] = new ExerciseSet();
            }

            m_gymTrainingExercise = excerciseSet;

            calculateAverageWeight();
            calculateMovedWeight();
            calculateMinWeight();
            calculateMaxWeight();
            calculateAverageRepetitions();
        }

        #region member

        private ExerciseSet[] m_gymTrainingExercise;
        private int m_amountOfSets;
        private int m_totalRepetition;
        private double m_maxWeight;
        private double m_minWeight;
        private double m_averageWeight;
        private double m_movedWeight;
        private double m_averageRepetition;

        #endregion member

        #region properties

        public int TotalRepetition
        {
            get
            {
                return m_totalRepetition;
            }
            set
            {
                m_totalRepetition = value;
            }
        }

        public ExerciseSet[] GymTrainingExercise
        {
            get
            {
                return m_gymTrainingExercise;
            }
            set
            {
                m_gymTrainingExercise = value;
            }
        }

        public double AverageRepetition
        {
            get
            {
                return m_averageRepetition;
            }
            set
            {
                m_averageRepetition = value;
            }
        }

        public double MaxWeight
        {
            get
            {
                return m_maxWeight;
            }
            set
            {
                m_maxWeight = value;
            }
        }

        public double MinWeight
        {
            get
            {
                return m_minWeight;
            }
            set
            {
                m_minWeight = value;
            }
        }

        public int AmountOfSets
        {
            get
            {
                return m_amountOfSets;
            }
            set
            {
                m_amountOfSets = value;
            }
        }

        public double AverageWeight
        {
            get
            {
                return m_averageWeight;
            }
            set
            {
                m_averageWeight = value;
            }
        }

        public double MovedWeight
        {
            get
            {
                return m_movedWeight;
            }
            set
            {
                m_movedWeight = value;
            }
        }

        #endregion properties

        #region methods

        public double GetMovedWeight()
        {
            return m_movedWeight;
        }

        private void calculateAverageRepetitions()
        {
            int totalRepetitions = 0;

            for (int it = 0; it < this.m_gymTrainingExercise.Length; it++)
            {
                totalRepetitions += m_gymTrainingExercise[it].Repetitions;
            }
            this.m_totalRepetition = totalRepetitions;
            this.m_averageRepetition = Math.Round((double)totalRepetitions / m_gymTrainingExercise.Length, 2);
        }

        public override object[] getTrainingData()
        {
            object[] data = new object[2 * m_gymTrainingExercise.Length];
            for (int it = 0; it < m_gymTrainingExercise.Length; it++)
            {
                data[2 * it] = m_gymTrainingExercise[it].Repetitions;
                data[2 * it + 1] = m_gymTrainingExercise[it].Weight;
            }

            return data;
        }

        public override string[] getInfoForEditMode()
        {
            string[] informationStringArray = new string[4 + 2 * m_amountOfSets];
            informationStringArray[0] = "MachineExercise";
            informationStringArray[1] = m_exerciseName;
            informationStringArray[2] = m_comment;
            informationStringArray[3] = Convert.ToString(m_amountOfSets);

            for (int it = 0; it < m_amountOfSets; it++)
            {
                informationStringArray[(2 * it) + 4] = Convert.ToString(m_gymTrainingExercise[it].Repetitions);
                informationStringArray[(2 * it + 1) + 4] = Convert.ToString(m_gymTrainingExercise[it].Weight);
            }

            return informationStringArray;
        }

        public override object[] GetExerciseMember()
        {
            object[] y_values = new object[] { m_movedWeight, m_averageWeight, m_minWeight, m_maxWeight, m_averageRepetition * m_amountOfSets };
            return y_values;
        }

        public void calculateMinWeight()
        {
            double minWeight = m_gymTrainingExercise[0].Weight;
            for (int it = 0; it < m_gymTrainingExercise.Length; it++)
            {
                if (m_gymTrainingExercise[it].Weight < minWeight)
                    minWeight = m_gymTrainingExercise[it].Weight;
            }
            this.m_minWeight = minWeight;
        }

        public void calculateMaxWeight()
        {
            double maxWeight = m_gymTrainingExercise[0].Weight; ;
            for (int it = 0; it < m_gymTrainingExercise.Length; it++)
            {
                if (m_gymTrainingExercise[it].Weight > maxWeight)
                    maxWeight = m_gymTrainingExercise[it].Weight;
            }
            this.m_maxWeight = maxWeight;
        }

        public void calculateAverageWeight()
        {
            double averageWeight = 0;
            int totalRepetitions = 0;

            for (int it = 0; it < this.m_gymTrainingExercise.Length; it++)
            {
                averageWeight += (m_gymTrainingExercise[it].Weight * m_gymTrainingExercise[it].Repetitions);
                totalRepetitions += m_gymTrainingExercise[it].Repetitions;
            }
            averageWeight /= totalRepetitions;
            this.m_averageWeight = Math.Round(averageWeight, 2);
        }

        public void calculateMovedWeight()
        {
            double movedWeight = 0;

            for (int it = 0; it < this.m_gymTrainingExercise.Length; it++)
            {
                movedWeight += m_gymTrainingExercise[it].Weight * m_gymTrainingExercise[it].Repetitions;
            }
            this.m_movedWeight = movedWeight;
        }

        public override string createSaveString()
        {
            StringBuilder savedString = new StringBuilder();

            for (int it = 0; it < m_gymTrainingExercise.Length; it++)
            {
                savedString.Append(m_gymTrainingExercise[it].createSaveString());
            }

            return base.createSaveString() + savedString.ToString();
        }

        public override object[] getExerciseInfo()
        {
            object[] exerciseInfo = new object[2 * m_amountOfSets];

            for (int it = 0; it < m_amountOfSets; it++)
            {
                exerciseInfo[2 * it] = m_gymTrainingExercise[it].Weight + " kg";
                exerciseInfo[2 * it + 1] = m_gymTrainingExercise[it].Repetitions + " Reps";
            }
            return exerciseInfo;
        }

        public override object[] getExerciseStatistic()
        {
            object[] exerciseInfo = new object[] {
                m_averageWeight + " kg/Set",
                m_movedWeight + " kg",
                m_minWeight + " kg" ,
                m_maxWeight + " kg",
                m_averageRepetition + " Reps/Set"
            };

            return exerciseInfo;
        }

        #endregion methods
    }
}