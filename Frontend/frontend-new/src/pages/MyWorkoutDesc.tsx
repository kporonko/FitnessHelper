import React, {useEffect, useState} from 'react';
import Header from "../components/Header";
import Footer from "../components/Footer";
import {useParams} from "react-router-dom";
import {IExercise} from "../interfaces/IExercise";
import {getExercisesFromUserWorkout} from "../fetch/FetchData";
import ExerciseCard from "../components/ExerciseCard";
import ModalWorkoutsList from "../components/ModalWorkoutsList";
import classes from './MyWorkoutDesc.module.css'
import {IUsersetSmallDesc} from "../interfaces/IUsersetSmallDesc";
import {IUserSetFullDesc} from "../interfaces/IUserSetFullDesc";
import WorkoutExerciseCard from "../components/WorkoutExerciseCard";
import StartTrainingForm from "../components/StartTrainingForm";

const MyWorkoutDesc = () => {

    const {id} = useParams()

    const [exercises, setExercises] = useState<IUserSetFullDesc>()
    const [currExerciseToAdd, setCurrExerciseToAdd] = useState(0)
    const [isActiveModal, setIsActiveModal] = useState(false)

    useEffect(() => {
        const getExercises = async () => {
            if(id !== undefined){
                let exs = await getExercisesFromUserWorkout(+id);
                setExercises(exs);
            }
        }
        getExercises()
    }, [exercises])

    return (
        <div>
            <Header page=""/>
            <h2 className={classes.h2}>Workout <span style={{fontSize: '60px', color:'rgba(0, 187, 249, 0.8)'}}>{exercises?.name}</span></h2>
            {exercises?.exerciseSmallDescription?.map((val, ind) =>(
                <div>
                    {id !== undefined &&
                        <WorkoutExerciseCard workoutId={+id} isUserWorkout={true} id={val.id} name={val.name} image={val.image} targetMuscle={val.targetMuscle} key={ind}/>}
                </div>
            ))}
            {exercises !== undefined && exercises.exerciseSmallDescription !== undefined && id !== undefined &&
                <StartTrainingForm isUser={true} exerciseSmallDesc={exercises.exerciseSmallDescription} workoutName={exercises.name} workoutId={+id}/>}
            <Footer/>
        </div>
    );
};

export default MyWorkoutDesc;