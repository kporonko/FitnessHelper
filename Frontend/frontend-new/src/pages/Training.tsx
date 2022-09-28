import React, {useEffect, useState} from 'react';
import {useLocation} from "react-router-dom";
import {IExercise} from "../interfaces/IExercise";
import classes from './Training.module.css'

const Training = () => {

    const location = useLocation()
    const {workTime, setsCount, rest, exerciseSmallDesc, name, id} = location.state;

    const [work, setWork] = useState<number>(workTime)
    const [sets, setSets] = useState<number>(setsCount)
    const [exercise, setExercise] = useState<number>(exerciseSmallDesc.length)
    const [nameExercise, setNameExercise] = useState<string>(exerciseSmallDesc[0].name)
    const [image, setImage] = useState<string>(exerciseSmallDesc[0].image)

    useEffect(()=>{
            let myInterval = setTimeout(() => {
                if (sets > 0){
                    if (work > 0) {
                        setWork(work - 1);
                    }
                    if (work === 0){
                        if (exercise === 0){
                            if (sets - 1 === 0){
                                alert("Congrats")
                                return;
                            }
                            setExercise(exerciseSmallDesc.length)
                            setSets(sets - 1);
                            setWork(workTime)
                            setImage(exerciseSmallDesc[0].image)
                            setNameExercise(exerciseSmallDesc[0].name)
                        }
                        if (sets === 0){
                            console.log("Sets 0")
                        }
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
                <h3>Set {setsCount - sets + 1}/{setsCount}</h3>
                <h3>Exercise {exerciseSmallDesc.length - exercise + 1}/{exerciseSmallDesc.length+1}</h3>
            </div>
            <div className={classes.wrapper}>
                <div className={classes.time}><h2 className={classes.absolute}>{work}</h2></div>
                <div>
                    <img className={classes.image} src={image} alt=""/>
                </div>
            </div>


            {sets}
            {setsCount}
            {rest}
            {name}
            {id}
        </div>
    );
};



export default Training;