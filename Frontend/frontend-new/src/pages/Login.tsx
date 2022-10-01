import React, {useState} from 'react';
import classes from "./LoginRegister.module.css"
import {Link, useNavigate, useNavigation} from "react-router-dom";
import {loginUser} from "../fetch/FetchData"
import {IUser} from "../interfaces/IUser";
import StartImage from "../components/StartImage";

const Login = () => {

    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");
    const nav = useNavigate();
    const submit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault()
        const status: number = await loginUser();
        if (status === 200){
            nav('/main')
            return;
        }
        else{
            alert("Invalid login or password")
            return;
        }
    }

    return (
        <div className={classes.mainDiv}>
            <StartImage/>
            <p className={classes.p}>
                Change Your Life With Fitness Helper
            </p>
            <div style={{width: "-webkit-fill-available", margin: "150px 40px"}}>
                <form onSubmit={(e)=> submit(e)}>
                    <h1 className={classes.h1}>Sign In To Your Account</h1>
                    <div className={classes.inputwrapper}>
                        <label className={classes.label} htmlFor="Login">Login</label>
                        <input className={classes.input} type="text" placeholder="Enter login..." id="Login" value={login} onChange={(e)=>{setLogin(e.target.value)}}/>
                    </div>
                    <div className={classes.inputwrapper}>
                        <label className={classes.label} htmlFor="Password">Password</label>
                        <input className={classes.input} type="password" placeholder="Enter password..." id="Password" value={password} onChange={(e)=>{setPassword(e.target.value)}}/>
                    </div>
                    <button className={classes.smallBtn}>
                        <Link className={classes.textDecNone} to={"/register"}>I don`t have an account</Link>
                    </button>
                    <button type="submit" disabled={login === "" || password === "" || password.length < 8 && true} className={login === "" || password === "" || password.length < 8 ? classes.loginBtnDisabled : classes.loginBtnActive}>
                        <h5>Login</h5>
                    </button>
                </form>
            </div>
        </div>
    );
};

export default Login;