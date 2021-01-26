using System;
using System.Collections.Generic;
using System.Text;

namespace TrainigsTracker
{
    public class BodyPartRegister
    {
        public BodyPartRegister(string name, string description)
        {
            m_name = name;
            m_description = description;
            m_date = new List<string>();
            m_diameter = new List<double>();
        }

        public BodyPartRegister(string name)
        {
            m_name = name;
            m_description = "";
            m_date = new List<string>();
            m_diameter = new List<double>();
        }

        #region member

        private string m_name;
        private string m_description; //for example how to measure
        private List<string> m_date;
        private List<double> m_diameter;
        private List<double> m_bodyFat;

        #endregion member

        #region properties

        public List<string> Date
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

        public List<double> Diameter
        {
            get
            {
                return this.m_diameter;
            }
            set
            {
                this.m_diameter = value;
            }
        }

        public string Name
        {
            get
            {
                return this.m_name;
            }
            set
            {
                this.m_name = value;
            }
        }

        public string Description
        {
            get
            {
                return this.m_description;
            }
            set
            {
                this.m_description = value;
            }
        }

        #endregion properties

        public string createSaveString()
        {
            StringBuilder savedString = new StringBuilder();
            savedString.AppendLine("\t <Bodypart>");
            savedString.AppendLine("\t \t <Name>" + m_name + "</Name>");
            savedString.AppendLine("\t \t <Description>" + m_description + "</Description>");

            for (int it = 0; it < m_date.Count; it++)
            {
                savedString.AppendLine("\t \t <Measurement>");
                savedString.AppendLine("\t \t \t <Date>" + m_date[it] + "</Date>");
                savedString.AppendLine("\t \t \t <Diameter>" + Math.Round(m_diameter[it], 1) + "</Diameter>");
                savedString.AppendLine("\t \t </Measurement>");
            }

            savedString.AppendLine("\t </Bodypart>");

            return savedString.ToString();
        }
    }
}