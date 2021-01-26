using System.Text;

namespace TrainigsTracker
{
    public class Exercise
    {
        public Exercise(string exerciseName, string comment, EtypeOfExercise typeOfExcercise)
        {
            m_exerciseName = exerciseName;
            m_comment = comment;
            m_description = "";
            m_typeOfExercise = typeOfExcercise;
        }

        public Exercise(string exerciseName, EtypeOfExercise typeOfExcercise, string description)
        {
            m_exerciseName = exerciseName;
            m_comment = "";
            m_description = description;
            m_typeOfExercise = typeOfExcercise;
        }

        public Exercise()
        {
        }

        protected EtypeOfExercise m_typeOfExercise;
        protected string m_exerciseName;
        protected string m_comment;
        protected string m_description;

        #region properties

        public string ExerciseName
        {
            get
            {
                return m_exerciseName;
            }
            set
            {
                m_exerciseName = value;
            }
        }

        public string Description
        {
            get
            {
                return m_description;
            }
            set
            {
                m_description = value;
            }
        }

        public string Comment
        {
            get
            {
                return m_comment;
            }
            set
            {
                m_comment = value;
            }
        }

        public EtypeOfExercise TypeOfExcercise
        {
            get
            {
                return this.m_typeOfExercise;
            }
            set
            {
                this.m_typeOfExercise = value;
            }
        }

        #endregion properties

        public virtual string[] getInfoForEditMode()
        {
            return null;
        }

        public virtual object[] GetExerciseMember()
        {
            object[] y_value = new object[] { };
            return y_value;
        }

        public virtual string createSaveString()
        {
            StringBuilder savedString = new StringBuilder();

            // the element of the xml file needs to be add before this funtion is called
            savedString.Append("\t \t \t <TypeOfExercise>" + this.m_typeOfExercise.ToString() + "</TypeOfExercise> \n");
            savedString.Append("\t \t \t <ExerciseName>" + this.m_exerciseName + "</ExerciseName> \n");
            savedString.Append("\t \t \t <Comment>" + this.m_comment + "</Comment> \n");

            return savedString.ToString();
        }

        public virtual string getExerciseInformation()
        {
            StringBuilder excerciseInformation = new StringBuilder();

            excerciseInformation.AppendLine(m_exerciseName + " (" + m_typeOfExercise.ToString() + ")");
            excerciseInformation.AppendLine("");

            return excerciseInformation.ToString();
        }

        public virtual object[] getTrainingData()
        {
            object[] data = new object[] { };
            return data;
        }

        public virtual object[] getExerciseInfo()
        {
            return null;
        }

        public virtual object[] getExerciseStatistic()
        {
            return null;
        }

        public string getComment()
        {
            return m_comment;
        }
    }
}