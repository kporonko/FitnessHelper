namespace Backend.Infrastructure.Models
{
    public class ExerciseMuscles
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
        public int MuscleId { get; set; }
        public virtual Muscle Muscle { get; set; }
    }
}