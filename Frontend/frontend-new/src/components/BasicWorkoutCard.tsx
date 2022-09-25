import React, {useEffect, useState} from 'react';
import {IBasicalWorkout} from "../interfaces/IBasicalWorkout";
import classes from './BasicWorkoutCard.module.css'

const BasicWorkoutCard = (workout: IBasicalWorkout) => {

    console.log(workout.topEfficiency)
    const [firstKey, setFirstKey] = useState("")
    const [secondKey, setSecondKey] = useState("")
    const [firstEfficiency, setFirstEfficiency] = useState(0)
    const [secondEfficiency, setSecondEfficiency] = useState(0)


    useEffect(() => {
        const getEfficiencies = () => {
            let keys = Object.keys(workout.topEfficiency);
            setFirstKey(keys[0])
            setSecondKey(keys[1])
            let values = Object.values(workout.topEfficiency)
            setFirstEfficiency(values[0])
            setSecondEfficiency(values[1])
        }
        getEfficiencies()
    }, [])


    return (
        <div className={classes.wrapper}>
            <img className={classes.img} src={workout.image} alt=""/>
            <div className={classes.workoutName}>{workout.name}</div>
            <div className={classes.efficiencyWrapper}>
                <p>{firstKey === "" ? "Nol" : firstKey}{firstEfficiency === 0 ? "Nol" : firstEfficiency}</p>
                <p>{secondKey === "" ? "Nol" : secondKey}{secondEfficiency === 0 ? "Nol" : secondEfficiency}</p>
            </div>
        </div>
    );
};

export default BasicWorkoutCard;