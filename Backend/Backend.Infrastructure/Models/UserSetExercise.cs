namespace Backend.Infrastructure.Models
{
    public class UserSetExercise
    {
        public int Id { get; set; }
        public int UserSetId { get; set; }
        public virtual UserSetOfExercises UserSetOfExercises { get; set; }
        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}