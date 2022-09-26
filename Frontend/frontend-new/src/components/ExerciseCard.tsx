import React from 'react';
import classes from './ExerciseCard.module.css'
import {AiOutlinePlus, AiOutlinePlusCircle} from "react-icons/ai";

const ExerciseCard = (props: {id: number, name: string, image: string, targetMuscle: string}) => {
    return (
        <div className={classes.exWrapper}>
            <img className={classes.exImage} src={props.image} alt="Empty"/>
            <div className={classes.descWrapper}>
                <h3 className={classes.h3}>{props.name}</h3>
                <div style={{display: 'flex', justifyContent: 'space-between'}}>
                    <h5 className={classes.h5}>{props.targetMuscle}</h5>
                    <AiOutlinePlusCircle className={classes.icon} fontSize='28px' cursor='pointer'/>
                </div>
            </div>
        </div>
    );
};

export default ExerciseCard;