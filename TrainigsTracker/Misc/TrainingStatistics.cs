using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace TrainigsTracker
{
    public class TrainingStatistics
    {
        public TrainingStatistics(MainForm mainFormInstance)
        {
            m_mainFormInstance = mainFormInstance;
            mainFormInstance.monthlyTrainingStatsChart.Titles.Add("Monthly Training Stats");
        }

        private Series m_dataSeries = new Series();
        private Series m_trendSeries = new Series();
        private MainForm m_mainFormInstance;
        private bool isExisting = false;

        public void updateMonthlyTrainingStats()
        {
            if (!isExisting)
            {
                prepareDataSeries();
                prepareTrendSeries(6);
                m_mainFormInstance.monthlyTrainingStatsChart.Series.Add(m_dataSeries);
                m_mainFormInstance.monthlyTrainingStatsChart.Series.Add(m_trendSeries);
                isExisting = true;
            }
            else
            {
                m_mainFormInstance.monthlyTrainingStatsChart.Series.Remove(m_dataSeries);
                m_mainFormInstance.monthlyTrainingStatsChart.Series.Remove(m_trendSeries);
                m_dataSeries.Points.Clear();
                m_trendSeries.Points.Clear();
                prepareDataSeries();
                prepareTrendSeries(6);
                m_mainFormInstance.monthlyTrainingStatsChart.Series.Add(m_dataSeries);
                m_mainFormInstance.monthlyTrainingStatsChart.Series.Add(m_trendSeries);
            }
        }

        private void prepareDataSeries()
        {
            DateTime[] dateTime = reverseDateTimeArray(m_mainFormInstance.calendar.BoldedDates);
            int currentYear = 0;
            int currentMonth = 0;
            int timesTrainedPerMonth = 0;

            if (dateTime.Length > 0)
            {
                currentYear = dateTime[0].Year;
                currentMonth = dateTime[0].Month;
            }

            for (int it = 0; it < dateTime.Length; it++)
            {
                if ((dateTime[it].Month != currentMonth) || (currentYear != dateTime[it].Year))
                {
                    m_dataSeries.Points.AddXY(currentMonth.ToString("00") + "." + currentYear.ToString(), timesTrainedPerMonth);
                    currentMonth++;
                    if (currentMonth > 12)
                    {
                        currentMonth = 1;
                        currentYear++;
                    }

                    while ((currentMonth != dateTime[it].Month) || (currentYear != dateTime[it].Year))
                    {
                        m_dataSeries.Points.AddXY(currentMonth.ToString("00") + "." + currentYear.ToString(), 0);
                        currentMonth++;
                        if (currentMonth > 12)
                        {
                            currentMonth = 1;
                            currentYear++;
                        }
                    }
                    timesTrainedPerMonth = 0;
                }

                timesTrainedPerMonth++;

                //Adding the most recent month
                if (it == dateTime.Length - 1)
                {
                    m_dataSeries.Points.AddXY(currentMonth.ToString("00") + "." + currentYear.ToString(), timesTrainedPerMonth);
                }
            }
            m_dataSeries.IsValueShownAsLabel = true;
        }

        private void prepareTrendSeries(int trendValue = 6)
        {
            for (int outer_it = 0; outer_it < m_dataSeries.Points.Count; outer_it++)
            {
                double temp = 0;
                if (outer_it < trendValue)
                {
                    for (int k = 0; k < outer_it + 1; k++)
                    {
                        temp += m_dataSeries.Points[outer_it - k].YValues[0];
                    }
                    temp /= outer_it + 1;
                    m_trendSeries.Points.AddXY(m_dataSeries.Points[outer_it].XValue, temp);
                    continue;
                }
                
                for (int k = 0; k < trendValue; k++)
                {
                    temp += m_dataSeries.Points[outer_it - k].YValues[0];
                }
                temp /= trendValue;
                m_trendSeries.Points.AddXY(m_dataSeries.Points[outer_it].XValue, temp);
            }
            m_trendSeries.ChartType = SeriesChartType.Line;
            m_trendSeries.BorderDashStyle = ChartDashStyle.Dot;
            m_trendSeries.BorderWidth = 2;
        }

        private DateTime[] reverseDateTimeArray(DateTime[] dateTime)
        {
            DateTime[] reversedDateTime = new DateTime[dateTime.Length];

            for (int it = 0; it < dateTime.Length; it++)
            {
                reversedDateTime[it] = dateTime[(dateTime.Length - it) - 1];
            }

            return reversedDateTime;
        }
    }
}