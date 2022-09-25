import React, {useEffect, useState} from 'react';
import Header from "../components/Header";
import Footer from "../components/Footer";
import {useParams} from "react-router-dom";
import {getMuscleById} from '../fetch/FetchData'
import {IMuscle} from "../interfaces/IMuscle";
import classes from "./MuscleDesc.module.css";
const MuscleDesc = () => {

    const {id} = useParams()

    const [muscle, setMuscle] = useState<IMuscle>()

    useEffect(() => {
        const getMuscle = async () => {
            if (id !== undefined){
                let muscle = await getMuscleById(+id);
                if (muscle !== undefined){
                    setMuscle(muscle);
                }
            }
        }
        getMuscle()
    }, [id])
    return (
        <div>
            <Header page=""/>
            <h1 className={classes.h1}>{muscle?.name} muscle</h1>
            <div style={{display: 'flex', gap: '5%', marginBottom: '30px'}}>
                <img className={classes.image} src={muscle?.urlImage} alt=""/>
                <div>
                    <h2 className={classes.h2}>Part Of Body: <span>{muscle?.partOfBody}</span></h2>
                    <h5 className={classes.h5}>{muscle?.description}</h5>
                </div>
            </div>
            <Footer/>
        </div>
    );
};

export default MuscleDesc;