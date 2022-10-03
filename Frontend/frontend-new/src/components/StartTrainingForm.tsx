import React, {useState} from 'react';
import {Link} from "react-router-dom";
import classes from './StartTrainingForm.module.css'
import {IExerciseDesc} from "../interfaces/ExerciseById/IExerciseDesc";
import {IExercise} from "../interfaces/IExercise";

const StartTrainingForm = (props: {exerciseSmallDesc: IExercise[], workoutName: string, workoutId: number, isUser: boolean}) => {

    const [workTime, setWorkTime] = useState(10)
    const [setsCount, setSetsCount] = useState(1)
    const [rest, setRest] = useState(10)
    console.log(props.exerciseSmallDesc)
    return (
        <div style={{margin: '50px 20%'}}>
            { props.exerciseSmallDesc.length > 0 ?
                <div>
                    <form style={{display: 'flex', justifyContent: 'space-between'}}>
                        <div className={classes.component}>
                            <h2 className={classes.h2}>Worktime</h2>
                            <input className={classes.input} min={10} value={workTime} onChange={(e) => setWorkTime(+e.target.value)} step={10} type="number"/>
                        </div>
                        <div className={classes.component}>
                            <h2 className={classes.h2}>Sets Count</h2>
                            <input className={classes.input} min={1} value={setsCount} onChange={(e) => setSetsCount(+e.target.value)} step={1} type="number"/>
                        </div>
                        <div className={classes.component}>
                            <h2 className={classes.h2}>Rest</h2>
                            <input className={classes.input} min={10} value={rest} onChange={(e) => setRest(+e.target.value)} step={10} type="number"/>
                        </div>
                    </form>
                    <div style={{display: 'flex', justifyContent: 'center'}}>
                        <Link to={'/training'} state={{workTime: workTime, setsCount: setsCount, rest: rest, exerciseSmallDesc: props.exerciseSmallDesc, name: props.workoutName, id: props.workoutId, isUser: props.isUser}}><button className={classes.button}>StartTraining</button></Link>
                    </div>
                </div>
                :
                <div>No Exercises</div>
            }
        </div>
    );
};

export default StartTrainingForm;