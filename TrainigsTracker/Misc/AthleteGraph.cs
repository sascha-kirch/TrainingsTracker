using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace TrainigsTracker
{
    public class AthleteGraph
    {
        public AthleteGraph(AthleteGraphForm athleteGraphForm)
        {
            m_athleteGraphForm = athleteGraphForm;
        }

        private AthleteGraphForm m_athleteGraphForm;
        private Series m_dataSeries;
        private Title m_graphTitel;
        private string m_dimension = "";

        public void prepareDataSet(List<double> measuredValue, List<string> dateString, Measurement measurementMethod)
        {
            if (measurementMethod == Measurement.Weight)
                m_dimension = " kg";
            else if (measurementMethod == Measurement.BoodyPart)
                m_dimension = " cm";
            else if (measurementMethod == Measurement.Fat)
                m_dimension = " mm";

            for (int it = 0; it < measuredValue.Count; it++)
            {
                m_athleteGraphForm.dataGridView.Rows.Add(
                    it,
                    dateString[it],
                    measuredValue[it].ToString("0.0") + m_dimension
                    );
            }
        }

        public void prepareDataStatistic(List<double> measuredValue, List<string> dateString, Measurement measurementMethod)
        {
            double min = Math.Round((m_dataSeries.Points.FindMinByValue().YValues[0]), 2);
            double max = Math.Round((m_dataSeries.Points.FindMaxByValue().YValues[0]), 2);
            double first = measuredValue[0];
            double latest = measuredValue[measuredValue.Count - 1];
            double last = measuredValue.Count < 2 ? latest : measuredValue[measuredValue.Count - 2];
            //improvement in percent
            double increasedInPercentStart = Math.Round(((latest / first) - 1) * 100, 2);
            double increasedInPercentLast = Math.Round(((latest / last) - 1) * 100, 2);
            if (measurementMethod == Measurement.Weight)
                m_dimension = " kg";
            else if (measurementMethod == Measurement.BoodyPart)
                m_dimension = " cm";
            else if (measurementMethod == Measurement.Fat)
                m_dimension = " mm";

            m_athleteGraphForm.exerciseStatisticDataGridView.Rows.Add(
                "Start Value",
                first + m_dimension
                );
            m_athleteGraphForm.exerciseStatisticDataGridView.Rows.Add(
                    "Latest Value",
                    latest + m_dimension
                    );
            m_athleteGraphForm.exerciseStatisticDataGridView.Rows.Add(
                        "Increased compared to previous value",
                        increasedInPercentLast + " %"
                        );
            m_athleteGraphForm.exerciseStatisticDataGridView.Rows.Add(
                    "Min Value",
                    min + m_dimension
                    );
            m_athleteGraphForm.exerciseStatisticDataGridView.Rows.Add(
                    "Max Value",
                    max + m_dimension
                    );

            m_athleteGraphForm.exerciseStatisticDataGridView.Rows.Add(
                    "Increased compared to start",
                    increasedInPercentStart + " %"
                    );
        }

        public void showExerciseGraph()
        {
            m_athleteGraphForm.dataChart.Titles.Add(m_graphTitel);
            m_athleteGraphForm.dataChart.Series.Add(m_dataSeries);
            m_athleteGraphForm.dataChart.Series.Add(calculateAverageOfSeries(m_dataSeries));
            double min = Math.Round((m_dataSeries.Points.FindMinByValue().YValues[0]), 0) - 1;
            m_athleteGraphForm.dataChart.ChartAreas[0].AxisY.Minimum = (min < 1 ? 0 : min);
            double max = Math.Round((m_dataSeries.Points.FindMaxByValue().YValues[0]), 0) + 1;
            m_athleteGraphForm.dataChart.ChartAreas[0].AxisY.Maximum = max;
            m_athleteGraphForm.dataChart.ChartAreas[0].AxisX.Minimum = 0;

            Series averageDataSeries = m_dataSeries;
        }

        public Series calculateAverageOfSeries(Series data)
        {
            Series averageDataSeries = new Series();
            double averageData = 0;

            for (int it = 0; it < data.Points.Count; it++)
            {
                averageData += data.Points[it].YValues[0];
            }
            averageData /= data.Points.Count;
            for (int it = 0; it < data.Points.Count; it++)
            {
                averageDataSeries.Points.AddXY(it, averageData);
            }

            averageDataSeries.Points[averageDataSeries.Points.Count - 1].Label = "Average: " + Math.Round(averageData, 2);

            averageDataSeries.ChartType = SeriesChartType.Line;
            averageDataSeries.XValueType = ChartValueType.Auto;
            averageDataSeries.YValueType = ChartValueType.Auto;
            averageDataSeries.BorderWidth = 2;

            return averageDataSeries;
        }

        //TODO implementierung, dass die x achse das datum anzeigt
        public void prepareExerciseGraph(List<double> measuredValue, List<string> dateString, string titel)
        {
            m_graphTitel = new Title(titel);

            m_dataSeries = new Series();
            for (int it = 0; it < measuredValue.Count; it++)
            {
                m_dataSeries.Points.AddXY(it, measuredValue[it]);
            }

            m_dataSeries.ChartType = SeriesChartType.Line;
            m_dataSeries.XValueType = ChartValueType.Auto;
            m_dataSeries.YValueType = ChartValueType.Auto;
            m_dataSeries.BorderWidth = 3;
        }
    }
}