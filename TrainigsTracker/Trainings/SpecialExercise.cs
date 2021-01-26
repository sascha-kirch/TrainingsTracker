namespace TrainigsTracker
{
    public class SpecialExercise : Exercise
    {
        public SpecialExercise(string exerciseName, string comment) :
            base(exerciseName, comment, EtypeOfExercise.SpecialExercise)
        {
        }
    }
}