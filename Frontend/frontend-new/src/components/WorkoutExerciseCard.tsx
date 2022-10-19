import React from 'react';
import classes from './WorkoutExerciseCard.module.css'
import {Link} from "react-router-dom";
import {AiFillDelete} from "react-icons/ai";
import {confirmAlert} from "react-confirm-alert";
import {deleteExerciseFromWorkout} from "../fetch/FetchData";

const WorkoutExerciseCard = (props: {image:string, name: string, targetMuscle: string, id: number, isUserWorkout: boolean, workoutId: number}) => {

    const handleClickDeleteExercise = async (e: React.MouseEvent<SVGElement>) => {
        e.preventDefault()
        confirmAlert({
            message:'Are you sure to delete the '+ props.name+ ' Exercise',
            title: 'Confirm To Delete',
            buttons:[
                {
                    label: 'Yes',
                    onClick: async () => await deleteExerciseFromWorkout(props.id, props.workoutId)
                },
                {
                    label: 'No',
                }
            ]
        })
    }

    return (
            <div data-aos="fade-up" className={classes.wrapper}>
                <Link style={{width: '100%', display: 'flex', justifyContent: 'space-between', alignItems: 'center'}} to={`/exercise/${props.id}`}>
                <img className={classes.exImage} src={props.image} alt=""/>
                <div>
                    <h2 className={classes.h2}>{props.name}</h2>
                    <h3 className={classes.h3}>Target Muscle: {props.targetMuscle}</h3>
                </div>
                {props.isUserWorkout &&
                <AiFillDelete onClick={(e) => handleClickDeleteExercise(e)} className={classes.icon} fontSize='28px' cursor='pointer'/>}
                </Link>
            </div>

    );
};

export default WorkoutExerciseCard;