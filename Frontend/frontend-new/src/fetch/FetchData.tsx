import {IUser} from "../interfaces/IUser";
import {IRegisterUserDto} from "../interfaces/IRegisterUserDto";
import {IBasicalWorkout} from "../interfaces/IBasicalWorkout";
import {IBasicalWorkoutFull} from "../interfaces/IBasicalWorkoutFull";
import {IExerciseDesc} from "../interfaces/ExerciseById/IExerciseDesc";
import {IMuscle} from "../interfaces/IMuscle";

const baseUrl = "https://localhost:7198/";

export const loginUser = async (login: string, password: string) => {
    const response = await fetch(`${baseUrl}Login?login=${login}&password=${password}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        }});
    if (response.status === 204){
        return null;
    }
    const body = await response.json();
    const data = body as IUser;
    return data;
}
export const registerUser = async (user: IRegisterUserDto) => {
    const response = await fetch(`${baseUrl}User`, {
        method: 'Post',
        body: JSON.stringify({
            "login": user.login,
            "password": user.password,
            "lastName": user.lastName,
            "firstName": user.firstName
        }),
        headers: {
            'Content-Type': 'application/json',
        }});
    if (response.status === 409){
        return false;
    }
    if (response.status === 201){
        return true;
    }
}

export const getBasicWorkoutsBySection = async (section: number) => {
    const response = await fetch(`${baseUrl}GetBySection/${section}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        }});
    if (response.status === 404){
        return null;
    }
    const body = await response.json();
    const data = body as IBasicalWorkout[];
    return data;
}

export const getBasicalWorkoutFullDesc = async (id: number) => {
    const response = await fetch(`${baseUrl}GetFullDescById/${id}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        }});
    if (response.status === 404){
        return null;
    }
    const body = await response.json();
    const data = body as IBasicalWorkoutFull;
    return data;
}

export const getExerciseDescById = async (id: number) => {
    console.log(id)
    const response = await fetch(`${baseUrl}ExerciseById/${id}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        }});
    if (response.status === 404){
        return undefined;
    }
    const body = await response.json();
    const data = body as IExerciseDesc;
    return data;
}

export const getMuscleById = async (id: number) => {
    console.log(id)
    const response = await fetch(`${baseUrl}GetMuscleById/${id}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        }});
    if (response.status === 404){
        return undefined;
    }
    const body = await response.json();
    const data = body as IMuscle;
    return data;
}
