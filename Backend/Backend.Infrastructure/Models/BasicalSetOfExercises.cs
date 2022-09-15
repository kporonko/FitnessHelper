namespace Backend.Infrastructure.Models
{
    public class BasicalSetOfExercises
    {
        public int BasicalSetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<BasicalSetExercise> BasicalSetExercises { get; set; } = new List<BasicalSetExercise>();
        public virtual List<BasicalSetTraining> BasicalSetTrainings { get; set; } = new List<BasicalSetTraining>();
        public virtual BasicalSetEfficiency BasicalSetEfficiency { get; set; }
    }
}