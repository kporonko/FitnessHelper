import React, {useEffect} from 'react';
import classes from './ModalEndTraining.module.css'
import {useNavigate} from "react-router-dom";

const ModalEndTraining = (props: {time:number, name: string, active: boolean, setActive: React.Dispatch<React.SetStateAction<boolean>>}) => {
    const nav = useNavigate()

    const handleNav = (e: React.MouseEvent<HTMLDivElement>) => {
        e.stopPropagation()
        nav('/profile')
    }

    return (
        <div>
            <div className={props.active ? classes.modalActive : classes.modal} onClick={(e) => handleNav(e)}>
                <div className={props.active? `${classes.modal__content} ${classes.active}` : classes.modal__content}>
                    <h2 className={classes.h2}>Congrats</h2>
                    <div className={classes.div}>Training: {props.name}.</div>
                    <div className={classes.div}>Time: {props.time} minutes.</div>
                    <div style={{display: 'flex', justifyContent: 'center'}}><button className={classes.button} onClick={() => nav('/profile')}>Ok</button></div>
                </div>
            </div>
        </div>
    );
};

export default ModalEndTraining;