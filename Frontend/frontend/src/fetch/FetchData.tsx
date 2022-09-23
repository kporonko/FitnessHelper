import {IUser} from "../interfaces/IUser";
import {IRegisterUserDto} from "../interfaces/IRegisterUserDto";

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