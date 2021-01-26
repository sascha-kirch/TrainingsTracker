using System;
using System.Text;

namespace TrainigsTracker
{
    public class Duration
    {
        public Duration()
        {
            H = 0;
            Min = 0;
            Sec = 0;
        }

        public Duration(int h, int min, int sec)
        {
            H = h;
            Min = min;
            Sec = sec;
        }

        private int m_h;
        private int m_min;
        private int m_sec;

        public int H
        {
            get
            {
                return m_h;
            }
            set
            {
                m_h = value;
            }
        }

        public int Min
        {
            get
            {
                return m_min;
            }
            set
            {
                m_min = value;
                if (m_min > 59)
                    correctOverflow();
            }
        }

        public int Sec
        {
            get
            {
                return m_sec;
            }
            set
            {
                m_sec = value;
                if (m_sec > 59)
                    correctOverflow();
            }
        }

        public void correctOverflow()
        {
            if (Sec > 59)
            {
                Sec = Sec - 60;
                Min++;
            }

            if (Min > 59)
            {
                Min = Min - 60;
                H++;
            }
        }

        public string toSaveString()
        {
            StringBuilder durationString = new StringBuilder();
            durationString.AppendLine("\t \t \t <Hour>" + m_h + "</Hour>");
            durationString.AppendLine("\t \t \t <Minute>" + m_min + "</Minute>");
            durationString.AppendLine("\t \t \t <Seconds>" + m_sec + "</Seconds>");
            return durationString.ToString();
        }

        public string DurationToString()
        {
            StringBuilder durationString = new StringBuilder();
            durationString.Append(m_h + ":" + m_min + ":" + m_sec);
            return durationString.ToString();
        }

        public string DurationToDimensionString()
        {
            StringBuilder durationString = new StringBuilder();
            durationString.Append(m_h + " h   " + m_min + " min   " + m_sec + " sec");
            return durationString.ToString();
        }

        public int DurationInSeconds()
        {
            return m_sec + 60 * m_min + 3600 * m_h;
        }

        public double DurationInMinutes()
        {
            double durationInMin = Math.Round((double)((double)m_sec / 60 + m_min + 60 * m_h), 2);
            return durationInMin;
        }

        public static Duration operator +(Duration a, Duration b)
        {
            return new Duration(a.H + b.H, a.Min + b.Min, a.m_sec + b.m_sec);
        }
    }
}