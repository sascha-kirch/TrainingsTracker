using System;
using System.Windows.Forms;

namespace TrainigsTracker
{
    public partial class StartUpProjectForm : Form
    {
        public StartUpProjectForm(MainForm mainFormInstance)
        {
            InitializeComponent();
            m_mainFormInstance = mainFormInstance;
        }

        private MainForm m_mainFormInstance;

        private void createNewProjectButton_Click(object sender, EventArgs e)
        {
            this.Close();
            m_mainFormInstance.newProjekt();
        }

        private void loadProjectButton_Click(object sender, EventArgs e)
        {
            this.Close();
            m_mainFormInstance.loadProjekt();
        }

        private void StartUpProjectForm_Shown(object sender, EventArgs e)
        {
            this.Focus();
        }
    }
}