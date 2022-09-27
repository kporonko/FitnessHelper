import React from 'react';
import classes from './TrainingCard.module.css'
import {ITraining} from "../interfaces/ITraining";

const TrainingCard = (props: {training: ITraining}) => {
    return (
        <div className={classes.cardWrapper}>
            <div>
                <h2 className={classes.h2}>{props.training.setName}</h2>
            </div>
            <div>
                <h5 className={classes.h5}>Date: <span className={classes.span}>{props.training.date}</span></h5>
                <h5 className={classes.h5}>Time: <span className={classes.span}>{props.training.time}min</span></h5>
            </div>
        </div>
    );
};

export default TrainingCard;