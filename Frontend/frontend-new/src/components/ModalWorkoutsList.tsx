import React, {useEffect, useState} from 'react';
import classes from './ModalWorkoutsList.module.css'
import {getMyWorkouts} from "../fetch/FetchData";
import {IUsersetSmallDesc} from "../interfaces/IUsersetSmallDesc";
import {addExerciseToUserSet} from '../fetch/FetchData'
import { Store } from 'react-notifications-component';

const ModalWorkoutsList = (props: {exerciseId:number, active:boolean, setActive: React.Dispatch<React.SetStateAction<boolean>>}) => {

    const [myWorkouts, setMyWorkouts] = useState<IUsersetSmallDesc[]>()

    useEffect(() => {
        const getWorkouts = async () => {
            let id = localStorage.getItem("id");
            if (id){
                let workouts = await getMyWorkouts(+id);
                setMyWorkouts(workouts);
            }
        }
        getWorkouts()
    })


    const handleClick = async (e: React.MouseEvent<HTMLDivElement>, userSetId: number) => {
        e.preventDefault();
        let codeResponse = await addExerciseToUserSet(props.exerciseId, userSetId)
        if (codeResponse === 201){
            Store.addNotification({
                title: "Successfully Added",
                type: "success",
                insert: "top",
                container: "top-right",
                animationIn: ["animate__animated", "animate__fadeIn"],
                animationOut: ["animate__animated", "animate__fadeOut"],
                dismiss: {
                    duration: 3000,
                    onScreen: true
                }
            })
        }
        else{
            Store.addNotification({
                title: "Seems like this workout already has this exercise",
                type: "danger",
                insert: "top",
                container: "top-right",
                animationIn: ["animate__animated", "animate__fadeIn"],
                animationOut: ["animate__animated", "animate__fadeOut"],
                dismiss: {
                    duration: 3000,
                    onScreen: true
                }
            })
        }
    }

    return (
        <div className={props.active ? classes.modalActive : classes.modal} onClick={() => props.setActive(false)}>
            <div className={props.active? `${classes.modal__content} ${classes.active}` : classes.modal__content} onClick={e => e.stopPropagation()}>
                <h2 className={classes.h2}>Choose workout set</h2>
                {myWorkouts?.map((val, ind) => (
                    <div className={classes.cardWrapper} onClick={(e)=>handleClick(e, val.id)}>
                        <div className={classes.imgWrapper}>
                            <img className={classes.image} src={require("../../public/dumbell.jpg")} alt=""/>
                        </div>
                        <h1 className={classes.h1}>{val.name}</h1>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default ModalWorkoutsList;