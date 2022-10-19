import {IExercise} from "./IExercise";

export interface IBasicalWorkoutFull{
    id: number,
    name: string,
    image: string,
    description: string,
    efficiency: {
        cardio: number,
        legs: number,
        arms: number,
        back: number,
        chest: number,
        abs: number
    },
    exerciseSmallDescs: IExercise[]
}