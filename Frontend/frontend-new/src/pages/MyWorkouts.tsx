import React, {useEffect, useState} from 'react';
import Header from "../components/Header";
import Footer from "../components/Footer";
import {IUsersetSmallDesc} from "../interfaces/IUsersetSmallDesc";
import {getMyWorkouts} from '../fetch/FetchData'
import MyWorkoutCard from "../components/MyWorkoutCard";
import classes from "./Workouts.module.css";
import {AiOutlinePlus, AiOutlinePlusCircle} from "react-icons/ai";
import ModalAddWorkout from "../components/ModalAddWorkout";
import {useNavigate} from "react-router-dom";

const MyWorkouts = () => {

    const [myWorkouts, setMyWorkouts] = useState<IUsersetSmallDesc[]>()
    const [modalActive, setModalActive] = useState(false);
    const nav = useNavigate();
    useEffect(()=>{
        if (localStorage.getItem("id") == null){
            nav("/");
        }
    })
    useEffect(()=>{
        const getWorkouts = async() => {
            let id = localStorage.getItem("id");
            let token = localStorage.getItem("token");
            if (id !== null && token){
                let workouts = await getMyWorkouts(+id, token);
                setMyWorkouts(workouts);
            }
        }
        getWorkouts()
    }, [myWorkouts])

    return (
        <div>
            <Header page="my-workouts"/>
            <div data-aos="fade" className={classes.headerWrapper}>
                <h2 className={classes.h2}>My Workouts</h2>
            </div>
            <div style={{display:'flex', justifyContent: 'center', margin: '30px 0'}}>
                <button onClick={() => setModalActive(true)} className={classes.button}>
                    <div style={{display: 'flex', alignItems:'center', gap:'50px'}}>
                        <AiOutlinePlusCircle className={classes.icon}/>
                        <p className={classes.buttonText}>Add New Workout</p>
                    </div>
                </button>
            </div>
            {myWorkouts?.map((val, ind) => (
                <div data-aos="fade-right" >
                    <MyWorkoutCard key={ind} id={val.id} exercises={val.exercises} name={val.name}/>
                </div>
            ))}
            <div style={{marginTop: '20px'}}></div>
            <ModalAddWorkout active={modalActive} setActive={setModalActive}/>
            <Footer/>
        </div>
    );
};

export default MyWorkouts;