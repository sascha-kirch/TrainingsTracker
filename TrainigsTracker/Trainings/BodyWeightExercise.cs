using System;
using System.Text;

namespace TrainigsTracker
{
    public class BodyWeightExercise : Exercise
    {
        public BodyWeightExercise(string exerciseName, string comment, int[] repetitions) :
            base(exerciseName, comment, EtypeOfExercise.BodyWeightExercise)
        {
            m_amountOfSets = repetitions.Length;
            m_repetitions = new int[this.m_amountOfSets];
            m_repetitions = repetitions;
            calculateAverageRepetitions();
            calculateTotalRepetitions();
            calculateMinRepetition();
            calculateMaxRepetition();
        }

        #region member

        private int[] m_repetitions;
        private int m_totalRepetitions;
        private int m_amountOfSets;
        private double m_averageRepetitions;

        private int m_minRepetition;
        private int m_maxRepetition;

        #endregion member

        #region properties

        public int TotalRepetitions
        {
            get
            {
                return m_totalRepetitions;
            }
            set
            {
                m_totalRepetitions = value;
            }
        }

        public double AverageRepetitions
        {
            get
            {
                return m_averageRepetitions;
            }
            set
            {
                m_averageRepetitions = value;
            }
        }

        public int[] Repetitions
        {
            get
            {
                return m_repetitions;
            }
            set
            {
                m_repetitions = value;
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

        #endregion properties

        #region methods

        public override string[] getInfoForEditMode()
        {
            string[] informationStringArray = new string[4 + m_repetitions.Length];
            informationStringArray[0] = "BodyweightExercise";
            informationStringArray[1] = m_exerciseName;
            informationStringArray[2] = m_comment;
            informationStringArray[3] = Convert.ToString(m_repetitions.Length);

            for (int it = 0; it < m_repetitions.Length; it++)
            {
                informationStringArray[it + 4] = Convert.ToString(m_repetitions[it]);
            }

            return informationStringArray;
        }

        public override object[] GetExerciseMember()
        {
            object[] y_values = new object[] { m_totalRepetitions, m_averageRepetitions, m_minRepetition, m_maxRepetition, m_amountOfSets };
            return y_values;
        }

        public void calculateTotalRepetitions()
        {
            int totalRepetitions = 0;

            foreach (int rep in m_repetitions)
            {
                totalRepetitions += rep;
            }

            this.m_totalRepetitions = totalRepetitions;
        }

        public void calculateMinRepetition()
        {
            int minRepetition = m_repetitions[0];
            for (int it = 0; it < m_repetitions.Length; it++)
            {
                if (m_repetitions[it] < minRepetition)
                    minRepetition = m_repetitions[it];
            }
            this.m_minRepetition = minRepetition;
        }

        public void calculateMaxRepetition()
        {
            int maxRepetition = m_repetitions[0]; ;
            for (int it = 0; it < m_repetitions.Length; it++)
            {
                if (m_repetitions[it] > maxRepetition)
                    maxRepetition = m_repetitions[it];
            }
            this.m_maxRepetition = maxRepetition;
        }

        public override string createSaveString()
        {
            StringBuilder savedString = new StringBuilder();
            for (int it = 0; it < m_repetitions.Length; it++)
            {
                savedString.AppendLine("\t \t <Repetition>" + m_repetitions[it] + "</Repetition>");
            }

            return base.createSaveString() + savedString.ToString();
        }

        public void calculateAverageRepetitions()
        {
            double averageRepetitions = 0;

            for (int it = 0; it < m_repetitions.Length; it++)
            {
                averageRepetitions += m_repetitions[it];
            }
            averageRepetitions /= m_repetitions.Length;
            this.m_averageRepetitions = Math.Round(averageRepetitions, 2);
        }

        public override object[] getExerciseInfo()
        {
            object[] exerciseInfo = new object[m_amountOfSets];

            for (int it = 0; it < m_amountOfSets; it++)
            {
                exerciseInfo[it] = m_repetitions[it] + " Reps";
            }
            return exerciseInfo;
        }

        public override object[] getExerciseStatistic()
        {
            object[] exerciseInfo = new object[] {
                m_totalRepetitions + " Reps",
                m_averageRepetitions + " Reps/Set"
            };

            return exerciseInfo;
        }

        public override object[] getTrainingData()
        {
            object[] data = new object[m_repetitions.Length];
            for (int it = 0; it < m_repetitions.Length; it++)
            {
                data[it] = m_repetitions[it];
            }
            return data;
        }

        #endregion methods
    }
}