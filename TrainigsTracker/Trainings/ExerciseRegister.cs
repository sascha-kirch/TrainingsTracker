using System;
using System.Collections.Generic;
using System.Text;

namespace TrainigsTracker
{
    public class ExerciseRegister
    {
        public ExerciseRegister()
        {
            m_registeredExercises = new List<Exercise>();
        }

        #region member

        private List<Exercise> m_registeredExercises;

        #endregion member

        #region properties

        public List<Exercise> RegisteredExercises
        {
            get
            {
                return m_registeredExercises;
            }
            set
            {
                m_registeredExercises = value;
            }
        }

        #endregion properties

        public EtypeOfExercise getTypeOfExercise(string exerciseName)
        {
            //nur ein hack... wird immer gefunden da ich funktion nur mit werten aus dem register aufrufe
            EtypeOfExercise type = EtypeOfExercise.SpecialExercise;
            foreach (Exercise exercise in m_registeredExercises)
            {
                if (exercise.ExerciseName == exerciseName)
                {
                    type = exercise.TypeOfExcercise;
                    break;
                }
            }

            return type;
        }

        public void swapElement(int index1, int index2)
        {
            Exercise tempExercise = m_registeredExercises[index1];
            this.m_registeredExercises[index1] = this.m_registeredExercises[index2];
            this.m_registeredExercises[index2] = tempExercise;
        }

        public void sortElements()
        {
            //BubbleSort Algorithm
            for (int outer_it = m_registeredExercises.Count; outer_it > 1; outer_it--)
            {
                for (int inner_it = 0; inner_it < (outer_it - 1); inner_it++)
                {
                    string name1 = m_registeredExercises[inner_it].ExerciseName.ToLower();
                    string name2 = m_registeredExercises[inner_it + 1].ExerciseName.ToLower();

                    // loop in order to compare the single characters
                    for (int it = 0; it < Math.Min(name1.Length, name2.Length); it++)
                    {
                        //swap condition compares the single chars
                        if (name1[it] > name2[it])
                        {
                            swapElement(inner_it, inner_it + 1);
                            break;
                        }
                        else if (name1[it] < name2[it])
                            break;
                        else if (name1[it] == name2[it])
                            continue;

                        //no difference until the first string was compared to its end -> the longer one needs to come at the seccond place
                        if (it == (Math.Min(name1.Length, name2.Length) - 1))
                        {
                            if (name2.Length >= name1.Length)
                                break;
                            else
                                swapElement(inner_it, inner_it + 1);
                        }
                    }
                }
            }
        }

        public string createSaveString()
        {
            StringBuilder savedString = new StringBuilder();

            savedString.AppendLine("<ExerciseRegister>");
            foreach (Exercise exercise in m_registeredExercises)
            {
                savedString.AppendLine("\t <Exercise>");
                savedString.AppendLine("\t \t <Name>" + exercise.ExerciseName + "</Name>");
                savedString.AppendLine("\t \t <Type>" + exercise.TypeOfExcercise + "</Type>");
                savedString.AppendLine("\t \t <Description>" + exercise.Description + "</Description>");
                savedString.AppendLine("\t </Exercise>");
            }
            savedString.AppendLine("</ExerciseRegister>");

            return savedString.ToString();
        }
    }
}