import React, {FormEvent, useState} from 'react';
import classes from './ModalAddWorkout.module.css'
import {addNewWorkout} from '../fetch/FetchData'

const ModalAddWorkout = (props: {active:boolean, setActive: React.Dispatch<React.SetStateAction<boolean>>}) => {

    const [name, setName] = useState("")

    const handleSubmit = async(e:FormEvent<HTMLFormElement>) => {
        e.preventDefault()
        let id = localStorage.getItem("id");
        if (name !== "" && id !== null){
            await addNewWorkout(+id ,name)
        }
        props.setActive(false)
    }

    return (
        <div className={props.active ? classes.modalActive : classes.modal} onClick={() => props.setActive(false)}>
            <div className={props.active? `${classes.modal__content} ${classes.active}` : classes.modal__content} onClick={e => e.stopPropagation()}>
                <form onSubmit={(e) => handleSubmit(e)} className={classes.form}>
                    <div style={{display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'center'}}>
                        <label className={classes.label}>Enter Workout Name...</label>
                        <input className={classes.input} onChange={(e)=>{setName(e.target.value)}} type="text" placeholder="Workout" value={name}/>
                        <button disabled={name === ""} className={name === "" ? `${classes.buttonSubmit} ${classes.disabled}` :classes.buttonSubmit} type={"submit"}>Create Workout</button>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default ModalAddWorkout;