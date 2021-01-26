using System;
using System.Collections.Generic;

namespace TrainigsTracker
{
    public class TrainingsdayRegister
    {
        public TrainingsdayRegister()
        {
            m_registeredTrainingsDays = new List<TrainingsDay>();
        }

        #region member

        private List<TrainingsDay> m_registeredTrainingsDays;

        #endregion member

        #region properties

        public List<TrainingsDay> RegisteredTrainingsDays
        {
            get
            {
                return m_registeredTrainingsDays;
            }
            set
            {
                m_registeredTrainingsDays = value;
            }
        }

        #endregion properties

        public int getHowManyTimesTrained(string exerciseName)
        {
            int timesTrained = 0;
            for (int it0 = 0; it0 < m_registeredTrainingsDays.Count; it0++)
            {
                for (int it1 = 0; it1 < m_registeredTrainingsDays[it0].ExercisesOfTheDay.Count; it1++)
                {
                    if (m_registeredTrainingsDays[it0].ExercisesOfTheDay[it1].ExerciseName == exerciseName)
                        timesTrained++;
                }
            }

            return timesTrained;
        }

        private double CalculateMaschineExerciseTotalMovedWeight()
        {
            double totalMovedWeight = 0;

            for (int outer_it = 0; outer_it < m_registeredTrainingsDays.Count; outer_it++)
            {
                for (int inner_it = 0; inner_it < m_registeredTrainingsDays[outer_it].ExercisesOfTheDay.Count; inner_it++)
                {
                    if (m_registeredTrainingsDays[outer_it].ExercisesOfTheDay[inner_it] is MachineExcercise)
                    {
                        //detects overflow
                        checked
                        {
                            totalMovedWeight += Convert.ToDouble(m_registeredTrainingsDays[outer_it].ExercisesOfTheDay[inner_it].GetExerciseMember()[0]);
                        }
                    }
                }
            }

            return totalMovedWeight;
        }

        private int CalculateExerciseTotalSets(EtypeOfExercise exerciseType)
        {
            int totalSets = 0;
            if (exerciseType == EtypeOfExercise.MachineExercise)
            {
                for (int outer_it = 0; outer_it < m_registeredTrainingsDays.Count; outer_it++)
                {
                    for (int inner_it = 0; inner_it < m_registeredTrainingsDays[outer_it].ExercisesOfTheDay.Count; inner_it++)
                    {
                        if (m_registeredTrainingsDays[outer_it].ExercisesOfTheDay[inner_it] is MachineExcercise)
                        {
                            MachineExcercise tempExercise = m_registeredTrainingsDays[outer_it].ExercisesOfTheDay[inner_it] as MachineExcercise;

                            if (tempExercise != null)
                            {
                                //detects overflow
                                checked
                                {
                                    totalSets += tempExercise.AmountOfSets;
                                }
                            }
                        }
                    }
                }
            }
            else if (exerciseType == EtypeOfExercise.BodyWeightExercise)
            {
                for (int outer_it = 0; outer_it < m_registeredTrainingsDays.Count; outer_it++)
                {
                    for (int inner_it = 0; inner_it < m_registeredTrainingsDays[outer_it].ExercisesOfTheDay.Count; inner_it++)
                    {
                        if (m_registeredTrainingsDays[outer_it].ExercisesOfTheDay[inner_it] is BodyWeightExercise)
                        {
                            BodyWeightExercise tempExercise = m_registeredTrainingsDays[outer_it].ExercisesOfTheDay[inner_it] as BodyWeightExercise;

                            if (tempExercise != null)
                            {
                                //detects overflow
                                checked
                                {
                                    totalSets += tempExercise.AmountOfSets;
                                }
                            }
                        }
                    }
                }
            }

            return totalSets;
        }

        private string FindMostTrainedExercise(EtypeOfExercise exerciseType)
        {
            string mostTrainedExercise = "Not trained yet";
            int timesTrained = 0;
            int temp = 0;
            if (exerciseType == EtypeOfExercise.MachineExercise)
            {
                for (int outer_it = 0; outer_it < m_registeredTrainingsDays.Count; outer_it++)
                {
                    for (int inner_it = 0; inner_it < m_registeredTrainingsDays[outer_it].ExercisesOfTheDay.Count; inner_it++)
                    {
                        if (m_registeredTrainingsDays[outer_it].ExercisesOfTheDay[inner_it] is MachineExcercise)
                        {
                            MachineExcercise tempExercise = m_registeredTrainingsDays[outer_it].ExercisesOfTheDay[inner_it] as MachineExcercise;

                            if (tempExercise != null)
                            {
                                timesTrained = getHowManyTimesTrained(tempExercise.ExerciseName);
                                if (timesTrained > temp)
                                {
                                    mostTrainedExercise = tempExercise.ExerciseName;
                                    temp = timesTrained;
                                }
                            }
                        }
                    }
                }
            }
            else if (exerciseType == EtypeOfExercise.CardioExercise)
            {
                for (int outer_it = 0; outer_it < m_registeredTrainingsDays.Count; outer_it++)
                {
                    for (int inner_it = 0; inner_it < m_registeredTrainingsDays[outer_it].ExercisesOfTheDay.Count; inner_it++)
                    {
                        if (m_registeredTrainingsDays[outer_it].ExercisesOfTheDay[inner_it] is CardioExercise)
                        {
                            CardioExercise tempExercise = m_registeredTrainingsDays[outer_it].ExercisesOfTheDay[inner_it] as CardioExercise;

                            if (tempExercise != null)
                            {
                                timesTrained = getHowManyTimesTrained(tempExercise.ExerciseName);
                                if (timesTrained > temp)
                                {
                                    mostTrainedExercise = tempExercise.ExerciseName;
                                    temp = timesTrained;
                                }
                            }
                        }
                    }
                }
            }
            else if (exerciseType == EtypeOfExercise.BodyWeightExercise)
            {
                for (int outer_it = 0; outer_it < m_registeredTrainingsDays.Count; outer_it++)
                {
                    for (int inner_it = 0; inner_it < m_registeredTrainingsDays[outer_it].ExercisesOfTheDay.Count; inner_it++)
                    {
                        if (m_registeredTrainingsDays[outer_it].ExercisesOfTheDay[inner_it] is BodyWeightExercise)
                        {
                            BodyWeightExercise tempExercise = m_registeredTrainingsDays[outer_it].ExercisesOfTheDay[inner_it] as BodyWeightExercise;

                            if (tempExercise != null)
                            {
                                timesTrained = getHowManyTimesTrained(tempExercise.ExerciseName);
                                if (timesTrained > temp)
                                {
                                    mostTrainedExercise = tempExercise.ExerciseName;
                                    temp = timesTrained;
                                }
                            }
                        }
                    }
                }
            }
            else if (exerciseType == EtypeOfExercise.BodyWeightExercise)
            {
                throw new NotImplementedException();
            }

            return mostTrainedExercise;
        }

        public Exercise getExerciseFromListTree(string parent, int index)
        {
            for (int it = 0; it < m_registeredTrainingsDays.Count; it++)
            {
                if (m_registeredTrainingsDays[it].Date == parent)
                {
                    return m_registeredTrainingsDays[it].ExercisesOfTheDay[index];
                }
            }
            return null;
        }

        private void swapTrainingsDayElement(int index1, int index2)
        {
            TrainingsDay tempTrainingsDay = m_registeredTrainingsDays[index1];
            m_registeredTrainingsDays[index1] = m_registeredTrainingsDays[index2];
            m_registeredTrainingsDays[index2] = tempTrainingsDay;
        }

        public List<Exercise> getSpecificExercise(string exerciseName)
        {
            List<Exercise> exercise = new List<Exercise>();

            for (int it0 = m_registeredTrainingsDays.Count; it0 > 0; it0--)
            {
                for (int it1 = 0; it1 < m_registeredTrainingsDays[it0 - 1].ExercisesOfTheDay.Count; it1++)
                {
                    if (m_registeredTrainingsDays[it0 - 1].ExercisesOfTheDay[it1].ExerciseName == exerciseName)
                        exercise.Add(m_registeredTrainingsDays[it0 - 1].ExercisesOfTheDay[it1]);
                }
            }

            return exercise;
        }

        public List<string> getSpecificDateOfExercise(string exerciseName)
        {
            List<string> dates = new List<string>();

            for (int it0 = m_registeredTrainingsDays.Count; it0 > 0; it0--)
            {
                for (int it1 = 0; it1 < m_registeredTrainingsDays[it0 - 1].ExercisesOfTheDay.Count; it1++)
                {
                    if (m_registeredTrainingsDays[it0 - 1].ExercisesOfTheDay[it1].ExerciseName == exerciseName)
                        dates.Add(m_registeredTrainingsDays[it0 - 1].Date);
                }
            }

            return dates;
        }

        private string GetTotalCardioDistance()
        {
            int totalDistance = 0;
            for (int outer_it = 0; outer_it < m_registeredTrainingsDays.Count; outer_it++)
            {
                for (int inner_it = 0; inner_it < m_registeredTrainingsDays[outer_it].ExercisesOfTheDay.Count; inner_it++)
                {
                    if (m_registeredTrainingsDays[outer_it].ExercisesOfTheDay[inner_it] is CardioExercise)
                    {
                        CardioExercise temp = m_registeredTrainingsDays[outer_it].ExercisesOfTheDay[inner_it] as CardioExercise;
                        if (temp != null)
                            totalDistance += temp.Distance;
                    }
                }
            }

            if (totalDistance > 1000)
                return Convert.ToString(Math.Round((double)(totalDistance / 1000), 0, MidpointRounding.ToEven)) + " km  " + totalDistance % 1000 + " m";
            else
                return totalDistance + " m";
        }

        private string GetTotalCardioDuration()
        {
            Duration totalDuration = new Duration();

            for (int outer_it = 0; outer_it < m_registeredTrainingsDays.Count; outer_it++)
            {
                for (int inner_it = 0; inner_it < m_registeredTrainingsDays[outer_it].ExercisesOfTheDay.Count; inner_it++)
                {
                    if (m_registeredTrainingsDays[outer_it].ExercisesOfTheDay[inner_it] is CardioExercise)
                    {
                        CardioExercise temp = m_registeredTrainingsDays[outer_it].ExercisesOfTheDay[inner_it] as CardioExercise;
                        if (temp != null)
                            totalDuration += temp.ExerciseDuration;
                    }
                }
            }
            return totalDuration.DurationToDimensionString();
        }

        private string GetTotalBodyweightRepetitions()
        {
            int totalRepetitions = 0;
            for (int outer_it = 0; outer_it < m_registeredTrainingsDays.Count; outer_it++)
            {
                for (int inner_it = 0; inner_it < m_registeredTrainingsDays[outer_it].ExercisesOfTheDay.Count; inner_it++)
                {
                    if (m_registeredTrainingsDays[outer_it].ExercisesOfTheDay[inner_it] is BodyWeightExercise)
                    {
                        BodyWeightExercise tempExercise = m_registeredTrainingsDays[outer_it].ExercisesOfTheDay[inner_it] as BodyWeightExercise;

                        if (tempExercise != null)
                        {
                            //detects overflow
                            checked
                            {
                                totalRepetitions += tempExercise.TotalRepetitions;
                            }
                        }
                    }
                }
            }

            return totalRepetitions.ToString() + " Reps";
        }

        public int getTrainingsDayIndex(string date)
        {
            for (int it = 0; it < m_registeredTrainingsDays.Count; it++)
            {
                if (date == m_registeredTrainingsDays[it].Date)
                    return it;
            }
            return -1;
        }

        public bool trainingsDayExist(string date)
        {
            for (int it = 0; it < m_registeredTrainingsDays.Count; it++)
            {
                if (date == m_registeredTrainingsDays[it].Date)
                    return true;
            }
            return false;
        }

        public void sortTrainingsDayList()
        {
            //BubbleSort Algorithm
            for (int outer_it = m_registeredTrainingsDays.Count; outer_it > 1; outer_it--)
            {
                for (int inner_it = 0; inner_it < (outer_it - 1); inner_it++)
                {
                    //[0] -> day     [1] -> month     [2] -> year
                    string[] date1_String = m_registeredTrainingsDays[inner_it].Date.Split('.');
                    int[] date1_Int = new int[] { Convert.ToInt32(date1_String[0]), Convert.ToInt32(date1_String[1]), Convert.ToInt32(date1_String[2]) };
                    string[] date2_String = m_registeredTrainingsDays[inner_it + 1].Date.Split('.');
                    int[] date2_Int = new int[] { Convert.ToInt32(date2_String[0]), Convert.ToInt32(date2_String[1]), Convert.ToInt32(date2_String[2]) };

                    if (date2_Int[2] > date1_Int[2])
                    {
                        swapTrainingsDayElement(inner_it, inner_it + 1);
                        continue;
                    }
                    else if (date2_Int[1] > date1_Int[1] && date2_Int[2] >= date1_Int[2])
                    {
                        swapTrainingsDayElement(inner_it, inner_it + 1);
                        continue;
                    }
                    else if (date2_Int[0] > date1_Int[0] && date2_Int[1] >= date1_Int[1] && date2_Int[2] >= date1_Int[2])
                    {
                        swapTrainingsDayElement(inner_it, inner_it + 1);
                        continue;
                    }
                }
            }
        }
    }
}