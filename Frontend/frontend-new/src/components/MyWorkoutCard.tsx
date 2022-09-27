import React, {useEffect, useState} from 'react';
import classes from './MyWorkoutCard.module.css'
import {AiFillDelete, AiOutlinePlusCircle} from "react-icons/ai";
import {Link, useParams} from "react-router-dom";
import {deleteMyWorkout} from '../fetch/FetchData'
import { confirmAlert } from 'react-confirm-alert'; // Import
import 'react-confirm-alert/src/react-confirm-alert.css'; // Import css
import {getExercisesFromUserWorkout} from '../fetch/FetchData'
import {IExercise} from "../interfaces/IExercise";

const MyWorkoutCard = (props: {id: number, name: string, exercises: string[]}) => {

    const handleDelete = async (e: React.MouseEvent<SVGElement>) => {
        e.preventDefault()
        confirmAlert({
            message:'Are you sure to delete the '+ props.name+ ' Workout Set',
            title: 'Confirm To Delete',
            buttons:[
                {
                    label: 'Yes',
                    onClick: async () => await deleteMyWorkout(props.id)
                },
                {
                    label: 'No',
                }
            ]
        })
    }

    return (
        <Link to={`/my-workout/${props.id}`}>
            <div data-aos="fade-up" className={classes.wrapper}>
                <img className={classes.exImage} src={require("../../public/dumbell.jpg")} alt=""/>
                <div>
                    <h2 className={classes.h2}>{props.name}</h2>
                    <h3 className={classes.h3}>Exercises: {props.exercises.length === 0 ? 'No Exercises' : props.exercises.map((val, ind) => (
                        <span>{val}, </span>
                    ))}</h3>
                </div>
                <AiFillDelete onClick={(e)=>handleDelete(e)} className={classes.icon} fontSize='28px' cursor='pointer'/>
            </div>
        </Link>
    );
};

export default MyWorkoutCard;