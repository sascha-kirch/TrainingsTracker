using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TrainigsTracker
{
    public partial class GraphViewerForm : Form
    {
        public GraphViewerForm(string text, MainForm mainFormInstance)
        {
            InitializeComponent();
            m_chartArray = new Chart[] { chart1, chart2, chart3, chart4 };
            Text = text;
            m_mainFormInstance = mainFormInstance;
            m_selectedIndex = mainFormInstance.exerciseDataGridView.SelectedRows[0].Index;
            m_exerciseName = mainFormInstance.ExerciseRegister.RegisteredExercises[m_selectedIndex].ExerciseName;
            m_exerciseType = mainFormInstance.ExerciseRegister.RegisteredExercises[m_selectedIndex].TypeOfExcercise;
            m_exercise = mainFormInstance.TrainingDayRegister.getSpecificExercise(m_exerciseName);
            m_dateString = mainFormInstance.TrainingDayRegister.getSpecificDateOfExercise(m_exerciseName);
            m_dataGraph = new ExerciseGraph(this);
            PrepareAndShowDataGraph();
            showDataSet();
        }

        private MainForm m_mainFormInstance;
        private ExerciseGraph m_dataGraph;
        private List<Exercise> m_exercise;
        private Chart[] m_chartArray;
        private List<string> m_dateString;
        private int m_selectedIndex;
        private string m_exerciseName;
        private EtypeOfExercise m_exerciseType;

        public void PrepareAndShowDataGraph()
        {
            m_dataGraph.prepareExerciseGraph(m_exercise, m_dateString, showByNumberRadioButton.Checked);
            m_dataGraph.showExerciseGraph(m_chartArray, showByNumberRadioButton.Checked);
        }

        public void showDataSet()
        {
            m_dataGraph.prepareDataSet(m_exercise, m_dateString);
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            //    double[] axisBoundary_X = new double[] {
            //        (chart1.ChartAreas[0].InnerPlotPosition.X * chart1.Size.Width) /100,
            //        (chart1.ChartAreas[0].InnerPlotPosition.X  + chart1.ChartAreas[0].InnerPlotPosition.Width* chart1.Size.Width) /100 };

            //    double[] axisBoundary_Y = new double[] {
            //        (chart1.ChartAreas[0].InnerPlotPosition.Y * chart1.Size.Height)/100,
            //        (chart1.ChartAreas[0].InnerPlotPosition.Y + chart1.ChartAreas[0].InnerPlotPosition.Height* chart1.Size.Height)/100 };

            //    if ((e.Location.X >= axisBoundary_X[0] && e.Location.X <= axisBoundary_X[1]) &&
            //        (e.Location.Y >= axisBoundary_Y[0] && e.Location.Y <= axisBoundary_Y[1]))
            //    {
            //        dataGraph.showDataCourser(chart1, e.Location.X, e.Location.Y);
            //    }
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("PositionX = " + e.Location.X + "\n PositionY = " + e.Location.Y);
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (showCursor_checkBox.Checked && dataGridView.SelectedRows.Count == 1)
                m_dataGraph.showDataCourser(m_chartArray, e.RowIndex);
        }

        private void showAverage_checkBox_CheckedChanged(object sender, System.EventArgs e)
        {
            if (showAverage_checkBox.Checked)
                m_dataGraph.showAverageOfSeries(m_chartArray);
            else
                m_dataGraph.removeAverageOfSeries(m_chartArray);
        }

        private void showTrend_checkBox_CheckedChanged(object sender, System.EventArgs e)
        {
            if (showTrend_checkBox.Checked)
                m_dataGraph.showTrendOfSeries(m_chartArray);
            else
                m_dataGraph.removeTrendOfSeries(m_chartArray);
        }

        private void showGrid_checkBox_CheckedChanged(object sender, System.EventArgs e)
        {
            m_dataGraph.setGridVisibility(m_chartArray, showGrid_checkBox.Checked);
        }

        private void showCursor_checkBox_CheckedChanged(object sender, System.EventArgs e)
        {
            if (showCursor_checkBox.Checked)
            {
                if (dataGridView.SelectedRows.Count == 1)
                {
                    m_dataGraph.showDataCourser(m_chartArray, dataGridView.SelectedRows[0].Index);
                }
                else if (dataGridView.SelectedRows.Count >= 1)
                {
                    int x_lower = dataGridView.SelectedRows[0].Index;
                    int x_upper = dataGridView.SelectedRows[dataGridView.SelectedRows.Count - 1].Index;

                    m_dataGraph.showDataCourserSelection(m_chartArray, x_lower, x_upper);
                }
            }
            else
            {
                m_dataGraph.disableCursorVisibility(m_chartArray, showCursor_checkBox.Checked);
            }
        }

        private void dataGridView_SelectionChanged(object sender, System.EventArgs e)
        {
            if (showCursor_checkBox.Checked && dataGridView.SelectedRows.Count > 1)
            {
                int x_lower = dataGridView.SelectedRows[0].Index;
                int x_upper = dataGridView.SelectedRows[dataGridView.SelectedRows.Count - 1].Index;

                m_dataGraph.showDataCourserSelection(m_chartArray, x_lower, x_upper);
            }
        }

        private void showByNumberRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            showTrend_checkBox.Checked = false;
            showAverage_checkBox.Checked = false;
            showCursor_checkBox.Checked = false;
            m_dataGraph.ClearDataSeries(m_chartArray);
            PrepareAndShowDataGraph();
        }
    }
}