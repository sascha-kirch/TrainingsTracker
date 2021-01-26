using System;
using System.Collections.Generic;

namespace TrainigsTracker
{
    public class Athlete
    {
        public Athlete(string name, int height, int age, MainForm mainFormInstance, Gender gender = Gender.Male)
        {
            m_name = name;
            m_height = height;
            m_age = age;
            m_mainFormInstance = mainFormInstance;
            m_athleteGender = gender;
            m_bodyPartRegister = new List<BodyPartRegister>();
            m_bodyFatRegister = new List<BodyPartRegister>() {
                new BodyPartRegister("Brust"),
                new BodyPartRegister("Bauch"),
                new BodyPartRegister("Oberschenkel"),
                new BodyPartRegister("Hüfte"),
                new BodyPartRegister("Achsel"),
                new BodyPartRegister("Trizeps"),
                new BodyPartRegister("Schulterblatt"),
                new BodyPartRegister("Bodyfat")
            };
            m_weightRegister = new WeightRegister();

            //calculateCurrentBmi();
            //getBMIStatus();
        }

        #region member

        private List<Exercise> m_allExercisesList;

        private List<BodyPartRegister> m_bodyPartRegister;
        private List<BodyPartRegister> m_bodyFatRegister;
        private List<double> m_bodyFat;
        private WeightRegister m_weightRegister;

        private string m_name;
        private int m_height;
        private int m_age;

        //TODO BMI kann man berechnen muss kein member sein!
        private double m_bmi = 0;

        private MainForm m_mainFormInstance;
        private string m_bmiStatus = "No Weight measured";
        private Gender m_athleteGender;

        #endregion member

        #region properties

        public Gender AthleteGender
        {
            get
            {
                return m_athleteGender;
            }
            set
            {
                m_athleteGender = value;
            }
        }

        public List<double> BodyFat
        {
            get
            {
                return m_bodyFat;
            }
            set
            {
                m_bodyFat = value;
            }
        }

        public List<BodyPartRegister> BodyFatRegister
        {
            get
            {
                return m_bodyFatRegister;
            }
            set
            {
                m_bodyFatRegister = value;
            }
        }

        public WeightRegister WeightRegister
        {
            get
            {
                return m_weightRegister;
            }
            set
            {
                m_weightRegister = value;
            }
        }

        public string BMIStatus
        {
            get
            {
                return m_bmiStatus;
            }
            set
            {
                m_bmiStatus = value;
            }
        }

        public List<BodyPartRegister> BodyPartRegister
        {
            get
            {
                return m_bodyPartRegister;
            }
            set
            {
                m_bodyPartRegister = value;
            }
        }

        public double BMI
        {
            get
            {
                return m_bmi;
            }
            set
            {
                m_bmi = value;
            }
        }

        public int Age
        {
            get
            {
                return m_age;
            }
            set
            {
                m_age = value;
            }
        }

        public int Height
        {
            get
            {
                return m_height;
            }
            set
            {
                m_height = value;
            }
        }

        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }

        public List<Exercise> AllExercisesList
        {
            get
            {
                return m_allExercisesList;
            }
            set
            {
                m_allExercisesList = value;
            }
        }

        #endregion properties

        #region helperMethods

        private void sortBodyPartRegister()
        {
            //BubbleSort Algorithm
            for (int outer_it = m_bodyPartRegister.Count; outer_it > 1; outer_it--)
            {
                for (int inner_it = 0; inner_it < (outer_it - 1); inner_it++)
                {
                    string name1 = m_bodyPartRegister[inner_it].Name.ToLower();
                    string name2 = m_bodyPartRegister[inner_it + 1].Name.ToLower();

                    // loop in order to compare the single characters
                    for (int it = 0; it < Math.Min(name1.Length, name2.Length); it++)
                    {
                        //swap condition compares the single chars
                        if (name1[it] > name2[it])
                        {
                            swapBodyPartRegisterElement(inner_it, inner_it + 1);
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
                                swapBodyPartRegisterElement(inner_it, inner_it + 1);
                        }
                    }
                }
            }
        }

        private void swapBodyPartRegisterElement(int index1, int index2)
        {
            BodyPartRegister tempBodyPartRegister = this.m_bodyPartRegister[index1];
            this.m_bodyPartRegister[index1] = this.m_bodyPartRegister[index2];
            this.m_bodyPartRegister[index2] = tempBodyPartRegister;
        }

        public void getBMIStatus()
        {
            if (m_bmi < 18.5)
            {
                m_bmiStatus = "Underweight";
            }
            else if (m_bmi >= 18.5 && m_bmi < 25)
            {
                m_bmiStatus = "Normal Weight";
            }
            else if (m_bmi >= 25 && m_bmi < 30)
            {
                m_bmiStatus = "Overweight";
            }
            else
            {
                m_bmiStatus = "Obese";
            }
        }

        public void calculateCurrentBmi()
        {
            double bmi;
            double weight = m_weightRegister.WeightList[m_weightRegister.WeightList.Count - 1];
            double height = Convert.ToDouble(this.m_height) / 100;
            bmi = weight / (height * height);
            this.m_bmi = Math.Round(bmi, 2);
        }

        public void showRegisteredBodyParts()
        {
            sortBodyPartRegister();
            m_mainFormInstance.bodyPartGridView.Rows.Clear();
            for (int it = 0; it < m_bodyPartRegister.Count; it++)
            {
                if (m_bodyPartRegister[it].Date.Count != 0 && m_bodyPartRegister[it].Diameter.Count != 0)
                    m_mainFormInstance.bodyPartGridView.Rows.Add(m_bodyPartRegister[it].Name, m_bodyPartRegister[it].Date[m_bodyPartRegister[it].Date.Count - 1], m_bodyPartRegister[it].Diameter[m_bodyPartRegister[it].Diameter.Count - 1].ToString("0.0") + " cm");
                else
                    m_mainFormInstance.bodyPartGridView.Rows.Add(m_bodyPartRegister[it].Name, "-", "-");
            }
        }

        public void showRegisteredFatMeasurements()
        {
            m_mainFormInstance.bodyFatDataGridView.Rows.Clear();
            for (int it = 0; it < m_bodyFatRegister.Count - 1; it++)
            {
                if (m_bodyFatRegister[it].Date.Count != 0 && m_bodyFatRegister[it].Diameter.Count != 0)
                    m_mainFormInstance.bodyFatDataGridView.Rows.Add(m_bodyFatRegister[it].Name, m_bodyFatRegister[it].Date[m_bodyFatRegister[it].Date.Count - 1], m_bodyFatRegister[it].Diameter[m_bodyFatRegister[it].Diameter.Count - 1].ToString() + " mm");
                else
                    m_mainFormInstance.bodyFatDataGridView.Rows.Add(m_bodyFatRegister[it].Name, "-", "-");
            }
            if (m_bodyFatRegister[7].Date.Count != 0 && m_bodyFatRegister[7].Diameter.Count != 0)
                m_mainFormInstance.bodyFatDataGridView.Rows.Add(m_bodyFatRegister[7].Name, m_bodyFatRegister[6].Date[m_bodyFatRegister[7].Date.Count - 1], m_bodyFatRegister[7].Diameter[m_bodyFatRegister[7].Diameter.Count - 1].ToString("0.00") + " %");
            else
                m_mainFormInstance.bodyFatDataGridView.Rows.Add(m_bodyFatRegister[7].Name, "-", "-");
        }

        public void showAthlete()
        {
            m_mainFormInstance.athleteNameGenericLabel.Text = Name;
            m_mainFormInstance.athleteAgeGenericLabel.Text = Convert.ToString(Age + " years");
            m_mainFormInstance.athleteHeightGenericLabel.Text = Convert.ToString(Height + " cm");
            m_mainFormInstance.athleteGenderGenericLabel.Text = m_athleteGender.ToString();
            m_mainFormInstance.weightDataGridView.Rows.Clear();
            if (m_mainFormInstance.m_athlete.m_weightRegister.WeightList.Count != 0)
            {
                m_mainFormInstance.weightDataGridView.Rows.Add(
                    m_weightRegister.DateList[m_weightRegister.WeightList.Count - 1],
                    m_weightRegister.WeightList[m_weightRegister.WeightList.Count - 1] + " kg"

                    );
                calculateCurrentBmi();
                getBMIStatus();
            }
            else
            {
                m_mainFormInstance.weightDataGridView.Rows.Add(
                    "-",
                    "-"
                    );
            }
            m_mainFormInstance.athleteCurrentBMIGenericLabel.Text = Convert.ToString(BMI);
            m_mainFormInstance.athleteBmiStatusGenericLabel.Text = m_bmiStatus;
        }

        public void addBodyPart(string name, string description)
        {
            BodyPartRegister bodyPart = new BodyPartRegister(name, description);
            m_bodyPartRegister.Add(bodyPart);
        }

        #endregion helperMethods
    }
}