using System;
using System.Text;

namespace TrainigsTracker
{
    public class ExerciseSet
    {
        public ExerciseSet(double weight, int repetitions)
        {
            m_weight = Math.Round(weight, 2);
            m_repetitions = repetitions;
        }

        public ExerciseSet()
        {
        }

        #region member

        private double m_weight = 0;
        private int m_repetitions = 0;

        #endregion member

        #region properties

        public double Weight
        {
            get
            {
                return m_weight;
            }
            set
            {
                m_weight = value;
            }
        }

        public int Repetitions
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

        #endregion properties

        public string createSaveString()
        {
            StringBuilder savedString = new StringBuilder();
            savedString.AppendLine("\t \t \t <Set>");
            savedString.AppendLine("\t \t \t \t <Weight>" + m_weight + "</Weight>");
            savedString.AppendLine("\t \t \t \t <Repetitions>" + m_repetitions + "</Repetitions>");
            savedString.AppendLine("\t \t \t </Set>");

            return savedString.ToString();
        }
    }
}