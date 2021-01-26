using System.Collections.Generic;
using System.Windows.Forms;

namespace TrainigsTracker
{
    public partial class AthleteGraphForm : Form
    {
        public AthleteGraphForm(string text, MainForm mainFormInstance, Measurement measurementMethod)
        {
            InitializeComponent();
            this.Text = text;
            this.m_mainFormInstance = mainFormInstance;
            m_dataGraph = new AthleteGraph(this);
            this.m_measurementMethod = measurementMethod;
            this.m_data = new List<double>();
            this.m_date = new List<string>();
            showGraph();
            showDataSet();
        }

        private MainForm m_mainFormInstance;
        private AthleteGraph m_dataGraph;
        private List<double> m_data;
        private List<string> m_date;
        private Measurement m_measurementMethod;

        public void showGraph()
        {
            if (m_measurementMethod == Measurement.Weight)
            {
                m_data = m_mainFormInstance.m_athlete.WeightRegister.WeightList;
                m_date = m_mainFormInstance.m_athlete.WeightRegister.DateList; ;
            }
            else if (m_measurementMethod == Measurement.BoodyPart)
            {
                m_data = m_mainFormInstance.m_athlete.BodyPartRegister[m_mainFormInstance.bodyPartGridView.SelectedRows[0].Index].Diameter;
                m_date = m_mainFormInstance.m_athlete.BodyPartRegister[m_mainFormInstance.bodyPartGridView.SelectedRows[0].Index].Date;
            }
            else if (m_measurementMethod == Measurement.Fat)
            {
                m_data = m_mainFormInstance.m_athlete.BodyFatRegister[m_mainFormInstance.bodyFatDataGridView.SelectedRows[0].Index].Diameter;
                m_date = m_mainFormInstance.m_athlete.BodyFatRegister[m_mainFormInstance.bodyFatDataGridView.SelectedRows[0].Index].Date;
            }

            m_dataGraph.prepareExerciseGraph(m_data, m_date, this.Text);
            m_dataGraph.showExerciseGraph();
        }

        public void showDataSet()
        {
            if (m_measurementMethod == Measurement.Weight)
            {
                m_data = m_mainFormInstance.m_athlete.WeightRegister.WeightList;
                m_date = m_mainFormInstance.m_athlete.WeightRegister.DateList;
            }
            else if (m_measurementMethod == Measurement.BoodyPart)
            {
                m_data = m_mainFormInstance.m_athlete.BodyPartRegister[m_mainFormInstance.bodyPartGridView.SelectedRows[0].Index].Diameter;
                m_date = m_mainFormInstance.m_athlete.BodyPartRegister[m_mainFormInstance.bodyPartGridView.SelectedRows[0].Index].Date;
            }
            else if (m_measurementMethod == Measurement.Fat)
            {
                m_data = m_mainFormInstance.m_athlete.BodyFatRegister[m_mainFormInstance.bodyFatDataGridView.SelectedRows[0].Index].Diameter;
                m_date = m_mainFormInstance.m_athlete.BodyFatRegister[m_mainFormInstance.bodyFatDataGridView.SelectedRows[0].Index].Date;
            }

            m_dataGraph.prepareDataSet(m_data, m_date, m_measurementMethod);
            m_dataGraph.prepareDataStatistic(m_data, m_date, m_measurementMethod);
        }
    }
}