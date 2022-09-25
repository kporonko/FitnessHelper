import React from 'react';
import classes from './WorkoutExerciseCard.module.css'
import {Link} from "react-router-dom";
const WorkoutExerciseCard = (props: {image:string, name: string, targetMuscle: string, id: number}) => {
    return (
        <Link to={`/exercise/${props.id}`}>
            <div data-aos="fade-up" className={classes.wrapper}>
                <img className={classes.exImage} src={props.image} alt=""/>
                <div>
                    <h2 className={classes.h2}>{props.name}</h2>
                    <h3 className={classes.h3}>Target Muscle: {props.targetMuscle}</h3>
                </div>
            </div>
        </Link>

    );
};

export default WorkoutExerciseCard;