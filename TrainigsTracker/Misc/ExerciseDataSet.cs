using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace TrainigsTracker.Misc
{
    public class ExerciseDataSet
    {
        public ExerciseDataSet()
        {
            //TODO Raw series muss berechnet werden.
            m_dataSeries_Average = CalculateAverageSeries();
            m_dataSeries_Trend = CalculateTrendSeries();
        }

        private List<double> m_XValues;
        private List<DateTime> m_YValues;

        private Series m_dataSeries_Raw;
        private Series m_dataSeries_Average;
        private Series m_dataSeries_Trend;

        private Series CalculateAverageSeries()
        {
            Series averageDataSeries = new Series();
            double averageData = 0;

            for (int it = 0; it < m_dataSeries_Raw.Points.Count; it++)
            {
                averageData += m_dataSeries_Raw.Points[it].YValues[0];
            }
            averageData /= m_dataSeries_Raw.Points.Count;
            for (int it = 0; it < m_dataSeries_Raw.Points.Count; it++)
            {
                averageDataSeries.Points.AddXY(it, averageData);
            }

            return averageDataSeries;
        }

        private Series CalculateTrendSeries()
        {
            Series trendSeries = new Series();

            for (int i = 0; i < m_dataSeries_Raw.Points.Count; i++)
            {
                if (i < 6)
                {
                    trendSeries.Points.AddXY(m_dataSeries_Raw.Points[i].XValue, 0);
                    continue;
                }
                double temp = 0;

                for (int k = 0; k < 6; k++)
                {
                    temp += m_dataSeries_Raw.Points[i - k].YValues[0];
                }
                temp /= 6;
                trendSeries.Points.AddXY(m_dataSeries_Raw.Points[i].XValue, temp);
            }

            return trendSeries;
        }
    }
}