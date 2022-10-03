import {MuscleId} from "./MuscleId";

export interface MuscleForUpdate{
     userId: number,
     synergists: number[],
     target: number[]
}