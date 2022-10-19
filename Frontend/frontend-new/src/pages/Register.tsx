import React, {useState} from 'react';
import classes from "./LoginRegister.module.css"
import StartImage from "../components/StartImage";
import {Link, useNavigate} from "react-router-dom";
import {registerUser} from "../fetch/FetchData";
const Register = () => {

    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");
    const nav = useNavigate();

    const submit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault()
        const isCreated = await registerUser({"lastName": lastName, "firstName": firstName, "login": login, "password":password})
        if (isCreated === true){
            alert("Account created");
            nav("/")
        }
        else{
            alert("Login is already taken")
        }
    }

    return (
        <div className={classes.mainDiv}>
            <StartImage/>
            <p className={classes.p}>
                Change Your Life With Fitness Helper
            </p>
            <div style={{width: "-webkit-fill-available", margin: "80px 40px"}}>
                <form onSubmit={(e)=> submit(e)}>
                    <h1 className={classes.h1}>Create New Account</h1>
                    <div className={classes.flexInputs}>
                        <div className={classes.inputwrapper}>
                            <label className={classes.label} htmlFor="FirstName">First Name</label>
                            <input className={classes.input} type="text" placeholder="Enter First Name..." id="FirstName" value={firstName} onChange={(e)=>{setFirstName(e.target.value)}}/>
                        </div>
                        <div className={classes.inputwrapper}>
                            <label className={classes.label} htmlFor="LastName">Last Name</label>
                            <input className={classes.input} type="text" placeholder="Enter Last Name..." id="LastName" value={lastName} onChange={(e)=>{setLastName(e.target.value)}}/>
                        </div>
                    </div>
                    <div className={classes.inputwrapper}>
                        <label className={classes.label} htmlFor="Login">Login</label>
                        <input className={classes.input} type="text" placeholder="Enter login..." id="Login" value={login} onChange={(e)=>{setLogin(e.target.value)}}/>
                    </div>
                    <div className={classes.inputwrapper}>
                        <label className={classes.label} htmlFor="Password">Password</label>
                        <input className={classes.input} type="password" placeholder="Enter password..." id="Password" value={password} onChange={(e)=>{setPassword(e.target.value)}}/>
                    </div>
                    <button className={classes.smallBtn}>
                        <Link className={classes.textDecNone} to={"/"}>I already have an account</Link>
                    </button>
                    <button type="submit" disabled={login === "" || password === "" || firstName === "" || lastName === "" || password.length < 8 && true} className={login === "" || password === "" || firstName === "" || lastName === "" || password.length < 8 ? classes.loginBtnDisabled : classes.loginBtnActive}>
                        <h5>Create Account</h5>
                    </button>
                </form>
            </div>
        </div>
    );
};

export default Register;