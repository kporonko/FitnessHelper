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
    exerciseSmallDesc: {
        id: number,
        name: string,
        image: string,
        targetMuscle: string
    }[]
}