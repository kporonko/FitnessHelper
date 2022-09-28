import React, {useEffect, useState} from 'react';
import {useLocation} from "react-router-dom";
import {IExercise} from "../interfaces/IExercise";
import classes from './Training.module.css'
import {createAndAddBasicTraining, createAndAddUserTraining} from "../fetch/FetchData";

const Training = () => {

    const location = useLocation()
    const {workTime, setsCount, rest, exerciseSmallDesc, name, id, isUser} = location.state;

    const [work, setWork] = useState<number>(workTime)
    const [sets, setSets] = useState<number>(setsCount)
    const [exercise, setExercise] = useState<number>(exerciseSmallDesc.length)
    const [nameExercise, setNameExercise] = useState<string>(exerciseSmallDesc[0].name)
    const [image, setImage] = useState<string>(exerciseSmallDesc[0].image)
    const [isRelax, setIsRelax] = useState<boolean>(true)
    const dateNow =  new Date(Date.now()).toISOString();
    const time = workTime * exerciseSmallDesc.length * setsCount / 60;

    const handleUserTraining = async () => {
        let userId = localStorage.getItem("id")
        if (userId !== null){
            await createAndAddUserTraining(+userId, id, Math.ceil(time), dateNow)
        }
    }
    const handleBasicTraining = async () => {
        let userId = localStorage.getItem("id")
        if (userId !== null){
            await createAndAddBasicTraining(+userId, id, Math.ceil(time), dateNow)
        }
    }

    useEffect(()=>{
        let myInterval = setTimeout(() => {
            if (sets > 0){
                if (work > 0) {
                    setWork(work - 1);
                }
                if (work === 0){
                    if (isRelax){
                        setWork(rest);
                        setImage("https://img.freepik.com/premium-photo/faceless-man-relaxing-in-armchair_23-2147800039.jpg?w=2000")
                        setNameExercise("Rest")
                        setIsRelax(false)
                        return;
                    }
                    if (exercise === 0){
                        if (sets - 1 === 0){
                            if (isUser){
                                handleUserTraining()
                            }
                            else {
                                handleBasicTraining()
                            }
                            return;
                        }
                        setExercise(exerciseSmallDesc.length)
                        setSets(sets - 1);
                        setWork(workTime)
                        setImage(exerciseSmallDesc[0].image)
                        setNameExercise(exerciseSmallDesc[0].name)
                    }
                    setIsRelax(true)
                    setImage(exerciseSmallDesc[10 - exercise].image)
                    setWork(workTime)
                    setNameExercise(exerciseSmallDesc[10 - exercise].name)
                    setExercise(exercise - 1);
                }
            }
        }, 1000)
    }, [work]);

    return (
        <div>
            <h2 className={classes.header}>{nameExercise}</h2>
            <div style={{display: 'flex', gap: '100px', justifyContent: 'center'}}>
                <h3>{isRelax && `Set ${setsCount - sets + 1}/${setsCount}`}</h3>
                <h3>{isRelax && `Exercise ${exerciseSmallDesc.length - exercise + 1}/${exerciseSmallDesc.length+1}`}</h3>
            </div>
            <div className={classes.wrapper}>
                <div className={classes.time}><h2 className={classes.absolute}>{work}</h2></div>
                <div>
                    <img className={classes.image} src={image} alt=""/>
                </div>
            </div>
        </div>
    );
};



export default Training;