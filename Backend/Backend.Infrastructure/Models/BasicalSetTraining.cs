namespace Backend.Infrastructure.Models
{
    public class BasicalSetTraining
    {
        public int TrainingId { get; set; }
        public DateTime Date { get; set; }
        public int SetId { get; set; }
        public virtual UserSetOfExercises UserSetOfExercises { get; set; }
    }
}