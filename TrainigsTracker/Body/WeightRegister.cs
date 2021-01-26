using System.Collections.Generic;
using System.Text;

namespace TrainigsTracker
{
    public class WeightRegister
    {
        public WeightRegister()
        {
            m_dateList = new List<string>();
            m_weightList = new List<double>();
        }

        #region member

        private List<string> m_dateList;
        private List<double> m_weightList;

        #endregion member

        #region properties

        public List<double> WeightList
        {
            get
            {
                return m_weightList;
            }
            set
            {
                m_weightList = value;
            }
        }

        public List<string> DateList
        {
            get
            {
                return m_dateList;
            }
            set
            {
                m_dateList = value;
            }
        }

        #endregion properties

        public void addMeasurement(string date, double weight)
        {
            m_dateList.Add(date);
            m_weightList.Add(weight);
        }

        public string createSaveString()
        {
            StringBuilder savedString = new StringBuilder();
            savedString.AppendLine("\t <WeightRegister>");

            for (int it = 0; it < m_dateList.Count; it++)
            {
                savedString.AppendLine("\t \t <Measurement>");
                savedString.AppendLine("\t \t \t <Date>" + m_dateList[it] + "</Date>");
                savedString.AppendLine("\t \t \t <Weight>" + m_weightList[it] + "</Weight>");
                savedString.AppendLine("\t \t </Measurement>");
            }

            savedString.AppendLine("\t </WeightRegister>");

            return savedString.ToString();
        }
    }
}