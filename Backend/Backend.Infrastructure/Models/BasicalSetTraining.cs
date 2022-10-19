namespace Backend.Infrastructure.Models
{
    public class BasicalSetTraining
    {
        public int BasicalTrainingId { get; set; }
        public DateTime Date { get; set; }
        public int BasicalSetId { get; set; }
        public int Time { get; set; }
        public virtual BasicalSetOfExercises BasicalSetOfExercises { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}