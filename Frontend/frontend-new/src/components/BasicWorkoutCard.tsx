import React, {useEffect, useState} from 'react';
import {IBasicalWorkout} from "../interfaces/IBasicalWorkout";
import classes from './BasicWorkoutCard.module.css'
import {AiFillFire, AiOutlineFire} from 'react-icons/ai'
import {Link} from "react-router-dom";

const BasicWorkoutCard = (workout: IBasicalWorkout) => {
    const [firstKey, setFirstKey] = useState("")
    const [secondKey, setSecondKey] = useState("")
    const [firstEfficiency, setFirstEfficiency] = useState(0)
    const [secondEfficiency, setSecondEfficiency] = useState(0)

    const [firstArr, setFirstArr] = useState<number[]>([])
    const [secondArr, setSecondArr] = useState<number[]>([])

    useEffect(() => {
        const getEfficiencies = () => {
            let keys = Object.keys(workout.topEfficiency);
            setFirstKey(keys[0])
            setSecondKey(keys[1])
            let values = Object.values(workout.topEfficiency)
            setFirstEfficiency(values[0])
            setSecondEfficiency(values[1])
            setFirstArr(Array(a(values[0])).fill(0));
            setSecondArr(Array(a(values[1])).fill(0));
        }
        getEfficiencies()
    }, [])

    const a = (number: number) => {
        return 5 - number;
    }

    return (
        <div className={classes.wrapper}>
            <Link to={`/workout/${workout.id}`}>
            <img className={classes.img} src={workout.image} alt=""/>
            <div className={classes.workoutName}>{workout.name}</div>
            <div className={classes.efficiencyWrapper}>
                <p className={classes.p}>{firstKey === "" ? "Empty" : firstKey}{firstEfficiency === 0 ? "Empty" :
                    <span style={{paddingLeft: '10px'}}>{Array(firstEfficiency).fill(0).map((x,i) =>
                        <AiFillFire key={i}/>
                    )}</span>}
                    <span>{firstArr.map((x,i) =>
                        <AiOutlineFire key={i}/>
                    )}</span>
                </p>
                <p className={classes.p}>{secondKey === "" ? "Empty" : secondKey}{secondEfficiency === 0 ? "Empty" :
                    <span style={{paddingLeft: '10px'}}>{Array(secondEfficiency).fill(0).map((x,i) =>
                        <AiFillFire key={i}/>
                    )}</span>}
                    <span>{secondArr.map((x,i) =>
                        <AiOutlineFire key={i}/>
                    )}</span>
                </p>
            </div>
            </Link>
        </div>
    );
};

export default BasicWorkoutCard;