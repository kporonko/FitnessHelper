import {ISynergistsMuscles} from "./ISynergistsMuscles";
import {ITargetMuscle} from "./ITargetMuscle";

export interface IExerciseDesc{
    exerciseId: number,
    name: string,
    description: string,
    urlImage: string,
    urlVideo: string,
    synergistMuscles: ISynergistsMuscles[],
    targetMuscle: ITargetMuscle,
}