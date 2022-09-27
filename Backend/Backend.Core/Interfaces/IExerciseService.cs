using Backend.Core.Models.Exercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Interfaces
{
    public interface IExerciseService
    {
        List<ExerciseSmallDescription> AllExercises();
        List<ExerciseSmallDescription> ExercisesByPartOfBody(string part);
        List<ExerciseSmallDescription> ExercisesSearch(string search);
        List<ExerciseSmallDescription> ExercisesByUserSet(int setId);
        ExerciseFull? ExerciseById(int exerciseId);

    }
}
