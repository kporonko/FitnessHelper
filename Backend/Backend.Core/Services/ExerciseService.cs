using Backend.Core.Interfaces;
using Backend.Core.Models.Exercises;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services
{
    public class ExerciseService : IExerciseService
    {
        /// <summary>
        /// Entity Framework DbContext.
        /// </summary>
        private readonly ApplicationContext _context;
        public ExerciseService(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all exercises from db.
        /// </summary>
        /// <returns>List of exercises.</returns>
        public List<ExerciseSmallDescription> AllExercises()
        {
            var exercises = _context.Exercises.Include(x => x.ExerciseMuscles).ThenInclude(x => x.Muscle).ToList();
            List<ExerciseSmallDescription> resList = ConvertExercisesIntoDtoList(exercises);
            return resList;
        }

        /// <summary>
        /// Gets all exercises, whose names mathes search string.
        /// </summary>
        /// <param name="search">Search text.</param>
        /// <returns>List of exercises that matches search.</returns>
        public List<ExerciseSmallDescription> ExercisesSearch(string search)
        {
            var exercises = _context.Exercises.Include(x => x.ExerciseMuscles).ThenInclude(x => x.Muscle).Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
            List<ExerciseSmallDescription> resList = ConvertExercisesIntoDtoList(exercises);
            return resList;
        }

        /// <summary>
        /// Gets exercises by part of body.
        /// </summary>
        /// <param name="part">Part of body.</param>
        /// <returns>List of exercises for part of body.</returns>
        public List<ExerciseSmallDescription> ExercisesByPartOfBody(string part)
        {
            var resList = new List<ExerciseSmallDescription>();

            var exercises = _context.Exercises.Include(x => x.ExerciseMuscles).ThenInclude(x => x.Muscle);
            foreach (var exercise in exercises)
            {
                if (exercise.ExerciseMuscles.FirstOrDefault(x => x.IsTarget == true).Muscle.PartOfBody == part)
                    resList.Add(ConvertExerciseIntoDto(exercise));
            }
            return resList;
        }


        /// <summary>
        /// Gets exercises from the user`s set.
        /// </summary>
        /// <param name="setId">Id of user`s set.</param>
        /// <returns>List of set`s exercises small description.</returns>
        public ExercisesUserSet ExercisesByUserSet(int setId)
        {
            var modelRes = new ExercisesUserSet();
            var listExercises = new List<ExerciseSmallDescription>();
            var exercisesUserSet = _context.UserSetExercises.Include(x => x.Exercise).ThenInclude(x => x.ExerciseMuscles).ThenInclude(x => x.Muscle).Where(x => x.UserSetId == setId).ToList();
            foreach (var exUserSet in exercisesUserSet)
            {
                var currExercise = new ExerciseSmallDescription { Id = exUserSet.Exercise.ExerciseId, Image = exUserSet.Exercise.UrlImage, Name = exUserSet.Exercise.Name };
                AddSynergistsToDesc(exUserSet, ref currExercise);
                AddsTargetMuscleToDescByExUserSet(exUserSet, ref currExercise);
                listExercises.Add(currExercise);
            }
            modelRes.exerciseSmallDescription = listExercises;
            modelRes.Name = _context.UserSetOfExercises.FirstOrDefault(x => x.UserSetId == setId)?.Name;
            return modelRes;
        }


        /// <summary>
        /// Adds synergists list to currrent exercise description.
        /// </summary>
        /// <param name="exUserSet">Intermediate table exercise-userSet value.</param>
        /// <param name="currExercise">Current description we must fill with data.</param>
        private void AddSynergistsToDesc(UserSetExercise exUserSet, ref ExerciseSmallDescription currExercise)
        {
            var ex = exUserSet.Exercise;
            var resList = new List<int>();
            foreach (var exMuscle in ex.ExerciseMuscles)
            {
                if (!exMuscle.IsTarget)
                {
                    resList.Add(exMuscle.MuscleId);
                }
            }
            currExercise.SynergistsId = resList;
        }

        /// <summary>
        /// Adds target muscle value to current exercise description.
        /// </summary>
        /// <param name="exUserSet">Intermediate table exercise-userSet value.</param>
        /// <param name="currExercise">Current description we must fill with data.</param>
        private void AddsTargetMuscleToDescByExUserSet(UserSetExercise exUserSet, ref ExerciseSmallDescription currExercise)
        {
            var ex = exUserSet.Exercise;
            foreach (var exMuscle in ex.ExerciseMuscles)
            {
                if (exMuscle.IsTarget)
                {
                    currExercise.TargetMuscle = exMuscle.Muscle.Name;
                    currExercise.TargetId = exMuscle.Muscle.MuscleId;
                }
            }
        }

        /// <summary>
        /// Gets exercise full description by Id.
        /// </summary>
        /// <param name="id">Id of exercise.</param>
        /// <returns>Full description of exercise.</returns>
        public ExerciseFull? ExerciseById(int id)
        {
            var exercise = _context.Exercises.Include(x => x.ExerciseMuscles).ThenInclude(x => x.Muscle).FirstOrDefault(x => x.ExerciseId == id);
            if (exercise == null)
                return null;
            ExerciseFull resExerciseDto = new ExerciseFull();
            resExerciseDto = FillFullExerciseDto(exercise, resExerciseDto);

            return resExerciseDto;
        }

        /// <summary>
        /// Fills resultive Full exercise description Dto from Exercise object. 
        /// </summary>
        /// <param name="exercise">Exercise we want to convert into dto.</param>
        /// <param name="resExerciseDto">Resultive dto object.</param>
        /// <returns>Filled dto.</returns>
        private ExerciseFull FillFullExerciseDto(Exercise exercise, ExerciseFull resExerciseDto)
        {
            resExerciseDto = new ExerciseFull() { ExerciseId = exercise.ExerciseId, Description = exercise.Description, Name = exercise.Name, UrlImage = exercise.UrlImage, UrlVideo = exercise.UrlVideo };

            MuscleSmallDesc targetMuscle = new();
            List<MuscleSmallDesc> synergists = new();
            GetTargetMuscleAndSynergistsDtosFromExercise(exercise, ref targetMuscle, ref synergists);
            FillFullExerciseDtoWithMuscles(resExerciseDto, ref targetMuscle, ref synergists);
            return resExerciseDto;
        }

        /// <summary>
        /// Gets target muscle small desc and all synergists small desc list from exercise.
        /// </summary>
        /// <param name="exercise">Exercise which muscle info we want to get.</param>
        /// <param name="targetMuscle">Resultive targetmuscle dto (Most likely empty, i.e. without target muscle info).</param>
        /// <param name="synergists">Resultive synergists dto list (Most likely empty, i.e. without synergists muscle info).</param>
        private void GetTargetMuscleAndSynergistsDtosFromExercise(Exercise exercise, ref MuscleSmallDesc targetMuscle, ref List<MuscleSmallDesc> synergists)
        {
            foreach (var exerciseMuscles in exercise.ExerciseMuscles)
            {
                FillTargetMuscleOrSynergistDto(exerciseMuscles, ref targetMuscle, ref synergists);
            }
        }

        /// <summary>
        /// Fills target muscle or synergist dto depending on current exerciseMuscle object.
        /// </summary>
        /// <param name="exerciseMuscles"></param>
        /// <param name="targetMuscle"></param>
        /// <param name="synergists"></param>
        private void FillTargetMuscleOrSynergistDto(ExerciseMuscles exerciseMuscles, ref MuscleSmallDesc targetMuscle, ref List<MuscleSmallDesc> synergists)
        {
            var dto = new MuscleSmallDesc() { MuscleId = exerciseMuscles.MuscleId, Name = exerciseMuscles.Muscle.Name };
            if (exerciseMuscles.IsTarget)
                targetMuscle = dto;
            else
                synergists.Add(dto);
        }

        /// <summary>
        /// Adds the muscles dtos to Full Exercise description dto.
        /// </summary>
        /// <param name="resExerciseDto"></param>
        /// <param name="targetMuscle"></param>
        /// <param name="synergists"></param>
        private void FillFullExerciseDtoWithMuscles(ExerciseFull resExerciseDto, ref MuscleSmallDesc targetMuscle, ref List<MuscleSmallDesc> synergists)
        {
            resExerciseDto.SynergistMuscles = synergists;
            resExerciseDto.TargetMuscle = targetMuscle;
        }
        
        /// <summary>
        /// Converts exercises into list of Small desc exercise dto.
        /// </summary>
        /// <param name="exercises">List of exercises to convert.</param>
        /// <returns>List of exercise small desc dtos.</returns>
        private List<ExerciseSmallDescription> ConvertExercisesIntoDtoList(List<Exercise> exercises)
        {
            List<ExerciseSmallDescription> resList = new List<ExerciseSmallDescription>();
            foreach (var exercise in exercises)
            {
                var dto = ConvertExerciseIntoDto(exercise);
                if (dto is not null)
                    resList.Add(dto);
            }

            return resList;
        }

        /// <summary>
        /// Converts one exercise into small desc dto.
        /// </summary>
        /// <param name="exercise">Exercise to convert.</param>
        /// <returns>Exercise small desc dto.</returns>
        private ExerciseSmallDescription? ConvertExerciseIntoDto(Exercise exercise) 
        {
            var targetMuscleName = GetTargetMuscleByExercise(exercise);
            if (targetMuscleName is null)
                return null;

            var dtoExercise = new ExerciseSmallDescription { Id = exercise.ExerciseId, Image = exercise.UrlImage, Name = exercise.Name, TargetMuscle = targetMuscleName };
            return dtoExercise;
        }

        /// <summary>
        /// Gets the exercise`s target muscle.
        /// </summary>
        /// <param name="exercise">Exercise which target muscle we want to find.</param>
        /// <returns>Name of target muscle.</returns>
        private string? GetTargetMuscleByExercise(Exercise exercise)
        {
            return exercise.ExerciseMuscles.FirstOrDefault(x => x.ExerciseId == exercise.ExerciseId && x.IsTarget == true)?.Muscle.Name;
        }
    }
}
