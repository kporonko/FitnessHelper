import React from 'react';
import classes from './ExerciseCard.module.css'
import {AiOutlinePlus, AiOutlinePlusCircle} from "react-icons/ai";
import {Link} from "react-router-dom";

const ExerciseCard = (props: {id: number, name: string, image: string, targetMuscle: string, active:boolean, setActive: React.Dispatch<React.SetStateAction<boolean>>, currExerciseToAdd:number, setCurrExerciseToAdd: React.Dispatch<React.SetStateAction<number>>}) => {

    const handleAdd = (e: React.MouseEvent<SVGElement>) => {
        e.preventDefault()
        props.setCurrExerciseToAdd(props.id);
        props.setActive(true)
    }

    return (
        <Link to={`/exercise/${props.id}`}>
            <div className={classes.exWrapper}>
                <img className={classes.exImage} src={props.image} alt="Empty"/>
                <div className={classes.descWrapper}>
                    <h3 className={classes.h3}>{props.name}</h3>
                    <div style={{display: 'flex', justifyContent: 'space-between'}}>
                        <h5 className={classes.h5}>{props.targetMuscle}</h5>
                        <AiOutlinePlusCircle onClick={(e)=>handleAdd(e)} className={classes.icon} fontSize='28px' cursor='pointer'/>
                    </div>
                </div>
            </div>
        </Link>
    );
};

export default ExerciseCard;