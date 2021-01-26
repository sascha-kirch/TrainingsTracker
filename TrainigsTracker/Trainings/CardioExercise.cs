using System;
using System.Text;

namespace TrainigsTracker
{
    public class CardioExercise : Exercise
    {
        public CardioExercise(string exerciseName, string comment, int distance, Duration exerciseDuration) :
            base(exerciseName, comment, EtypeOfExercise.CardioExercise)
        {
            m_distance = distance;
            m_exerciseDuration = exerciseDuration;
            calculateAverageSpeed();
        }

        #region member

        private int m_distance;

        //TODO ergebnisse Stimmen noch nicht für den average speed..
        private Duration m_exerciseDuration;

        private double m_averageSpeed;

        #endregion member

        #region properties

        public double AverageSpeed
        {
            get
            {
                return m_averageSpeed;
            }
            set
            {
                this.m_averageSpeed = value;
            }
        }

        public int Distance
        {
            get
            {
                return m_distance;
            }
            set
            {
                m_distance = value;
            }
        }

        public Duration ExerciseDuration
        {
            get
            {
                return m_exerciseDuration;
            }
            set
            {
                m_exerciseDuration = value;
            }
        }

        #endregion properties

        #region methods

        public string DistanceToString()
        {
            if (m_distance > 1000)
                return m_distance / 1000 + " km" + m_distance % 1000 + " m";
            else
                return m_distance + " m";
        }

        public override object[] getTrainingData()
        {
            object[] data = new object[] { m_distance, m_exerciseDuration.H, m_exerciseDuration.Min, m_exerciseDuration.Sec };
            return data;
        }

        public override string[] getInfoForEditMode()
        {
            string[] informationStringArray = new string[] {
                "CardioExercise",
                m_exerciseName,
                m_comment,
                Convert.ToString(m_exerciseDuration.H),
                Convert.ToString(m_exerciseDuration.Min),
                Convert.ToString(m_exerciseDuration.Sec),
                Convert.ToString(m_distance)
            };

            return informationStringArray;
        }

        public override string createSaveString()
        {
            StringBuilder savedString = new StringBuilder();

            savedString.AppendLine("\t\t\t <Distance>" + m_distance + "</Distance>");
            savedString.Append(m_exerciseDuration.toSaveString());

            return base.createSaveString() + savedString.ToString();
        }

        public override object[] GetExerciseMember()
        {
            object[] y_values = new object[] { m_distance, m_exerciseDuration.DurationInMinutes(), m_averageSpeed, Math.Round(m_averageSpeed * 3.6, 2) };
            return y_values;
        }

        /// <summary>
        /// Calculate average speed. distance must be in meter and excercise duration in sec
        /// </summary>
        public void calculateAverageSpeed()
        {
            //Duration is double because if not the devision is not a double but an integer
            double duration = m_exerciseDuration.DurationInSeconds();
            double averageSpeed = m_distance / duration;
            this.m_averageSpeed = Math.Round(averageSpeed, 2);
        }

        public override object[] getExerciseInfo()
        {
            object[] exerciseInfo = new object[]{
                m_distance + " m",
                m_exerciseDuration.DurationToDimensionString()
            };

            return exerciseInfo;
        }

        public override object[] getExerciseStatistic()
        {
            object[] exerciseInfo = new object[] {
                m_averageSpeed + " m/s",
                Math.Round(m_averageSpeed * 3.6, 2) + " km/h"
            };

            return exerciseInfo;
        }

        #endregion methods
    }
}