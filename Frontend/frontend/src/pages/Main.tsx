import React, {useEffect} from 'react';
import {useNavigate} from "react-router-dom";
import login from "./Login";
import Header from "../components/Header";

const Main = () => {
    const nav = useNavigate()
    useEffect(()=>{
        console.log(localStorage.getItem("id"))
        if (localStorage.getItem("id") == null){
            nav("/");
        }
    })

    return (
        <div>
            <Header/>

        </div>
    );
};

export default Main;