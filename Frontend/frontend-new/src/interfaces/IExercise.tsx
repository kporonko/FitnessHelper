export interface IExercise {
    id: number,
    name: string,
    image: string,
    targetMuscle: string,
    targetId: number,
    synergistsId: number[]
}