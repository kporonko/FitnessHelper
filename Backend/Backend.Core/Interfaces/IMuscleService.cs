using Backend.Core.Models.Muscles;

namespace Backend.Core.Interfaces
{
    public interface IMuscleService
    {
        MuscleFullDesc? GetMuscleById(int id);
    }
}