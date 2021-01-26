using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace TrainigsTracker
{
    public class ExerciseGraph
    {
        public ExerciseGraph(GraphViewerForm graphViewerForm)
        {
            m_graphViewerForm = graphViewerForm;
        }

        private GraphViewerForm m_graphViewerForm;
        private Series[] m_dataSeries;
        private Series[] m_averageOfDataSeries;
        private Series[] m_trendOfDataSeries;
        private Title[] m_titel;

        private System.Drawing.Color m_dataColor = System.Drawing.Color.Orange;
        private System.Drawing.Color m_trendColor = System.Drawing.Color.Blue;
        private System.Drawing.Color m_averageColor = System.Drawing.Color.Red;
        private System.Drawing.Color m_cursorColor = System.Drawing.Color.Black;
        private System.Drawing.Color m_cursorSelectionColor = System.Drawing.Color.DarkBlue;

        public void prepareDataSet(List<Exercise> exercise, List<string> dateString)
        {
            StringBuilder dataSetString = new StringBuilder();
            object[] data;

            if (exercise[0].TypeOfExcercise == EtypeOfExercise.MachineExercise)
            {
                m_graphViewerForm.dataGridView.Columns.Add("numberColumn", "#");
                m_graphViewerForm.dataGridView.Columns.Add("dateColumn", "Date");
                m_graphViewerForm.dataGridView.Columns.Add("set1RepsColumn", "Set1");
                m_graphViewerForm.dataGridView.Columns.Add("set1WeightColumn", "");
                m_graphViewerForm.dataGridView.Columns.Add("set2RepsColumn", "Set2");
                m_graphViewerForm.dataGridView.Columns.Add("set2WeightColumn", "");
                m_graphViewerForm.dataGridView.Columns.Add("set3RepsColumn", "Set3");
                m_graphViewerForm.dataGridView.Columns.Add("set3WeightColumn", "");
                m_graphViewerForm.dataGridView.Columns.Add("set4RepsColumn", "Set4");
                m_graphViewerForm.dataGridView.Columns.Add("set4WeightColumn", "");
                m_graphViewerForm.dataGridView.Columns.Add("set5RepsColumn", "Set5");
                m_graphViewerForm.dataGridView.Columns.Add("set5WeightColumn", "");

                for (int it = 0; it < exercise.Count; it++)
                {
                    data = exercise[it].getTrainingData();
                    object[] dataSet = new object[10];

                    for (int inner_it = 0; inner_it < 5; inner_it++)
                    {
                        if (data.Length >= 2 * (inner_it + 1))
                        {
                            dataSet[2 * inner_it] = data[2 * inner_it] + " Reps";
                            dataSet[2 * inner_it + 1] = Convert.ToDouble(data[2 * inner_it + 1]).ToString("0.0") + " kg";
                        }
                        else
                        {
                            dataSet[2 * inner_it] = "-";
                            dataSet[2 * inner_it + 1] = "-";
                        }
                    }
                    m_graphViewerForm.dataGridView.Rows.Add(
                        it,
                        dateString[it],
                        dataSet[0],
                        dataSet[1],
                        dataSet[2],
                        dataSet[3],
                        dataSet[4],
                        dataSet[5],
                        dataSet[6],
                        dataSet[7],
                        dataSet[8],
                        dataSet[9]);
                }
                m_graphViewerForm.dataGridView.Columns[0].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            }
            else if (exercise[0].TypeOfExcercise == EtypeOfExercise.CardioExercise)
            {
                m_graphViewerForm.dataGridView.Columns.Add("numberColumn", "#");
                m_graphViewerForm.dataGridView.Columns.Add("dateColumn", "Date");
                m_graphViewerForm.dataGridView.Columns.Add("durationColumn", "Duration");
                m_graphViewerForm.dataGridView.Columns.Add("distanceColumn", "Distance");

                for (int it = 0; it < exercise.Count; it++)
                {
                    data = exercise[it].getTrainingData();
                    string distanceString = "";
                    int distance = Convert.ToInt32(data[0]);

                    if (distance > 1000)
                        distanceString = Convert.ToString(Math.Round((double)(distance / 1000), 0, MidpointRounding.ToEven)) + " km  " + distance % 1000 + " m";
                    else
                        distanceString = distance + " m";

                    string duration = data[1] + " h   " + data[2] + " min   " + data[3] + " sec";
                    m_graphViewerForm.dataGridView.Rows.Add(
                            it,
                            dateString[it],
                            duration,
                            distanceString
                            );
                }
            }
            else if (exercise[0].TypeOfExcercise == EtypeOfExercise.BodyWeightExercise)
            {
                m_graphViewerForm.dataGridView.Columns.Add("numberColumn", "#");
                m_graphViewerForm.dataGridView.Columns.Add("dateColumn", "Date");
                m_graphViewerForm.dataGridView.Columns.Add("set1RepsColumn", "Set1");
                m_graphViewerForm.dataGridView.Columns.Add("set2RepsColumn", "Set2");
                m_graphViewerForm.dataGridView.Columns.Add("set3RepsColumn", "Set3");
                m_graphViewerForm.dataGridView.Columns.Add("set4RepsColumn", "Set4");
                m_graphViewerForm.dataGridView.Columns.Add("set5RepsColumn", "Set5");

                for (int it = 0; it < exercise.Count; it++)
                {
                    data = exercise[it].getTrainingData();
                    object[] dataSet = new object[5];

                    for (int inner_it = 0; inner_it < 5; inner_it++)
                    {
                        if (data.Length >= (inner_it + 1))
                            dataSet[inner_it] = data[inner_it] + " Reps";
                        else
                            dataSet[inner_it] = "-";
                    }
                    m_graphViewerForm.dataGridView.Rows.Add(
                            it,
                            dateString[it],
                            dataSet[0],
                            dataSet[1],
                            dataSet[2],
                            dataSet[3],
                            dataSet[4]
                            );
                }
            }
            if (exercise[0].TypeOfExcercise == EtypeOfExercise.SpecialExercise)
            {
                throw new NotImplementedException();
            }

            for (int it = 0; it < m_graphViewerForm.dataGridView.Columns.Count; it++)
            {
                m_graphViewerForm.dataGridView.Columns[it].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
                if (it > 2)
                    m_graphViewerForm.dataGridView.Columns[it].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public void showExerciseGraph(Chart[] chartArray, bool showByNumber)
        {
            //Showing the Data
            for (int it = 0; it < chartArray.Length; it++)
            {
                chartArray[it].Titles.Add(m_titel[it]);
                chartArray[it].Series.Add(m_dataSeries[it]);

                if (showByNumber)
                {
                    chartArray[it].ChartAreas[0].AxisY.Minimum = Math.Round((m_dataSeries[it].Points.FindMinByValue().YValues[0]) * 0.9, 0) - 1;
                    chartArray[it].ChartAreas[0].AxisY.Maximum = Math.Round((m_dataSeries[it].Points.FindMaxByValue().YValues[0]) * 1.1, 0) + 1;
                    chartArray[it].ChartAreas[0].AxisX.Minimum = 0;
                    chartArray[it].ChartAreas[0].AxisX.Maximum = m_dataSeries[it].Points[m_dataSeries[it].Points.Count - 1].XValue;
                }
                else
                {
                    
                    chartArray[it].ChartAreas[0].AxisY.Minimum = 0;
                    chartArray[it].ChartAreas[0].AxisY.Maximum = Math.Round((m_dataSeries[it].Points.FindMaxByValue().YValues[0])*1.1, 0) + 1;
                    chartArray[it].ChartAreas[0].AxisX.Minimum = m_dataSeries[it].Points[0].XValue;
                    chartArray[it].ChartAreas[0].AxisX.Maximum = DateTime.Today.ToOADate();
                }
            }
        }

        public void ClearDataSeries(Chart[] chartArray)
        {
            for (int it = 0; it < chartArray.Length; it++)
            {
                chartArray[it].ResetAutoValues();
                chartArray[it].Series.Remove(m_dataSeries[it]);
                chartArray[it].Titles.Remove(m_titel[it]);
            }
            m_dataSeries = null;
            m_titel = null;
        }

        //TODO implementierung, dass die x achse das datum anzeigt
        public void prepareExerciseGraph(List<Exercise> exercise, List<string> dateString, bool showByNumber)
        {
            if (exercise[0].TypeOfExcercise == EtypeOfExercise.MachineExercise)
                m_titel = new Title[] { new Title("Moved Weight [kg]"), new Title("Average Weight [kg]"), new Title("Min Weight [kg]"), new Title("Max Weight [kg]") };
            else if (exercise[0].TypeOfExcercise == EtypeOfExercise.CardioExercise)
                m_titel = new Title[] { new Title("Distance [m]"), new Title("Duration [min]"), new Title("Average Speed [m/s]"), new Title("Average Speed [km/h]") };
            else if (exercise[0].TypeOfExcercise == EtypeOfExercise.BodyWeightExercise)
                m_titel = new Title[] { new Title("Total Repetitions"), new Title("Average Repetitions"), new Title("Min Repetitions"), new Title("Max Repetitions") };
            else if (exercise[0].TypeOfExcercise == EtypeOfExercise.SpecialExercise)
                throw new NotImplementedException();

            m_dataSeries = new Series[] { new Series(), new Series(), new Series(), new Series() };

            if (showByNumber)
            {
                for (int it = 0; it < exercise.Count; it++)
                {
                    string[] tempDate = dateString[it].Split('.');
                    DateTime dateTemp = new DateTime(Convert.ToInt32(tempDate[2]), Convert.ToInt32(tempDate[1]), Convert.ToInt32(tempDate[0]), 0, 0, 0);

                    object[] y_data = exercise[it].GetExerciseMember();
                    m_dataSeries[0].Points.AddXY(it, y_data[0]);
                    m_dataSeries[1].Points.AddXY(it, y_data[1]);
                    m_dataSeries[2].Points.AddXY(it, y_data[2]);
                    m_dataSeries[3].Points.AddXY(it, y_data[3]);
                }
            }
            else //show by date
            {
                for (int it = 0; it < exercise.Count; it++)
                {
                    string[] tempDate = dateString[it].Split('.');
                    DateTime dateTemp = new DateTime(Convert.ToInt32(tempDate[2]), Convert.ToInt32(tempDate[1]), Convert.ToInt32(tempDate[0]), 0, 0, 0);

                    object[] y_data = exercise[it].GetExerciseMember();
                    m_dataSeries[0].Points.AddXY(dateTemp, y_data[0]);
                    m_dataSeries[1].Points.AddXY(dateTemp, y_data[1]);
                    m_dataSeries[2].Points.AddXY(dateTemp, y_data[2]);
                    m_dataSeries[3].Points.AddXY(dateTemp, y_data[3]);
                }
            }
            foreach (Series dataSeriesElement in m_dataSeries)
            {
                if (showByNumber)
                {
                    dataSeriesElement.ChartType = SeriesChartType.Line;
                    dataSeriesElement.XValueType = ChartValueType.Auto;
                }
                else
                {
                    dataSeriesElement.ChartType = SeriesChartType.BoxPlot;
                    dataSeriesElement.XValueType = ChartValueType.DateTime;
                }
                dataSeriesElement.YValueType = ChartValueType.Auto;
                dataSeriesElement.BorderWidth = 2;
                dataSeriesElement.Color = m_dataColor;
            }
        }

        public void calculateAverageOfSeries(Series[] seriesArray)
        {
            Series[] averageDataSeriesArray = new Series[seriesArray.Length];
            this.m_averageOfDataSeries = new Series[seriesArray.Length];

            for (int outer_it = 0; outer_it < seriesArray.Length; outer_it++)
            {
                Series averageDataSeries = new Series();
                double averageData = 0;

                for (int it = 0; it < seriesArray[outer_it].Points.Count; it++)
                {
                    averageData += seriesArray[outer_it].Points[it].YValues[0];
                }
                averageData /= seriesArray[outer_it].Points.Count;
                for (int it = 0; it < seriesArray[outer_it].Points.Count; it++)
                {
                    averageDataSeries.Points.AddXY(seriesArray[outer_it].Points[it].XValue, averageData);
                }

                averageDataSeries.Points[averageDataSeries.Points.Count - 1].Label = "Average: " + Math.Round(averageData, 2);
                
                averageDataSeries.ChartType = SeriesChartType.Line;
                averageDataSeries.XValueType = ChartValueType.DateTime;
                averageDataSeries.YValueType = ChartValueType.Auto;
                averageDataSeries.BorderWidth = 2;
                averageDataSeries.BorderDashStyle = ChartDashStyle.Dot;
                averageDataSeries.Color = m_averageColor;

                averageDataSeriesArray[outer_it] = averageDataSeries;
            }
            this.m_averageOfDataSeries = averageDataSeriesArray;
        }

        public void showAverageOfSeries(Chart[] chartArray)
        {
            calculateAverageOfSeries(m_dataSeries);

            for (int it = 0; it < chartArray.Length; it++)
            {
                chartArray[it].Series.Add(m_averageOfDataSeries[it]);
            }
        }

        public void removeAverageOfSeries(Chart[] chartArray)
        {
            for (int it = 0; it < chartArray.Length; it++)
            {
                chartArray[it].Series.Remove(m_averageOfDataSeries[it]);
            }
        }

        public void calculateTrendOfSeries(Series[] seriesArray, int trendValue = 6)
        {
            Series[] trendDataSeriesArray = new Series[seriesArray.Length];
            this.m_trendOfDataSeries = new Series[seriesArray.Length];

            for (int outer_it = 0; outer_it < seriesArray.Length; outer_it++)
            {
                Series trendDataSeries = new Series();

                for (int i = 0; i < seriesArray[outer_it].Points.Count; i++)
                {
                    double temp = 0;
                    if (i < trendValue)
                    {
                        for (int k = 0; k < i+1; k++)
                        {
                            temp += seriesArray[outer_it].Points[i - k].YValues[0];
                        }
                        temp /= i + 1;
                        trendDataSeries.Points.AddXY(seriesArray[outer_it].Points[i].XValue, temp);
                        continue;
                    }
                    

                    for (int k = 0; k < trendValue; k++)
                    {
                        temp += seriesArray[outer_it].Points[i - k].YValues[0];
                    }
                    temp /= trendValue;
                    trendDataSeries.Points.AddXY(seriesArray[outer_it].Points[i].XValue, temp);
                }
                trendDataSeries.ChartType = SeriesChartType.Line;
                trendDataSeries.BorderWidth = 2;
                trendDataSeries.Color = m_trendColor;

                trendDataSeriesArray[outer_it] = trendDataSeries;
            }
            this.m_trendOfDataSeries = trendDataSeriesArray;
        }

        public void showTrendOfSeries(Chart[] chartArray)
        {
            calculateTrendOfSeries(m_dataSeries);

            for (int it = 0; it < chartArray.Length; it++)
            {
                chartArray[it].Series.Add(m_trendOfDataSeries[it]);
            }
        }

        public void removeTrendOfSeries(Chart[] chartArray)
        {
            for (int it = 0; it < chartArray.Length; it++)
            {
                chartArray[it].Series.Remove(m_trendOfDataSeries[it]);
            }
        }

        public void showDataCourser(Chart[] chartArray, int x)
        {
            foreach (Chart chart in chartArray)
            {
                chart.ChartAreas[0].CursorX.SetSelectionPosition(-10, -11);
                chart.ChartAreas[0].CursorX.SetCursorPosition(x);
                chart.ChartAreas[0].CursorY.SetCursorPosition(chart.Series[0].Points[x].YValues[0]);
                chart.ChartAreas[0].CursorY.LineColor = m_cursorColor;
                chart.ChartAreas[0].CursorX.LineColor = m_cursorColor;
                chart.ChartAreas[0].CursorX.SelectionColor = m_cursorSelectionColor;
            }
        }

        public void setGridVisibility(Chart[] chartArray, bool enableGrid)
        {
            foreach (Chart chart in chartArray)
            {
                chart.ChartAreas[0].Axes[0].MajorGrid.Enabled = enableGrid;
                chart.ChartAreas[0].Axes[1].MajorGrid.Enabled = enableGrid;
            }
        }

        public void disableCursorVisibility(Chart[] chartArray, bool enableCurser)
        {
            foreach (Chart chart in chartArray)
            {
                chart.ChartAreas[0].CursorX.SetSelectionPosition(-10, -11);
                chart.ChartAreas[0].CursorX.SetCursorPosition(-10);
                chart.ChartAreas[0].CursorY.SetCursorPosition(-10);
            }
        }

        public void showDataCourserSelection(Chart[] chartArray, int x_lower, int x_upper)
        {
            foreach (Chart chart in chartArray)
            {
                double y_lower = chart.ChartAreas[0].AxisY.Minimum;
                double y_upper = chart.ChartAreas[0].AxisY.Maximum;
                chart.ChartAreas[0].CursorX.SetCursorPosition(x_upper);
                chart.ChartAreas[0].CursorX.SetSelectionPosition(x_lower, x_upper);
                chart.ChartAreas[0].CursorY.SetSelectionPosition(y_lower, y_upper);
                chart.ChartAreas[0].CursorY.LineColor = m_cursorColor;
                chart.ChartAreas[0].CursorX.LineColor = m_cursorColor;
                chart.ChartAreas[0].CursorX.SelectionColor = m_cursorSelectionColor;
            }
        }
    }
}