import React, {useEffect, useState} from 'react';
import Header from "../components/Header";
import Footer from "../components/Footer";
import {useNavigate, useParams} from "react-router-dom";
import {getMuscleById, getResearcher, putAchievement} from '../fetch/FetchData'
import {IMuscle} from "../interfaces/IMuscle";
import classes from "./MuscleDesc.module.css";
const MuscleDesc = () => {

    const {id} = useParams()

    const [muscle, setMuscle] = useState<IMuscle>()
    const nav = useNavigate();
    useEffect(()=>{
        if (localStorage.getItem("id") == null){
            nav("/");
        }
    })
    useEffect(() => {
        const checkAchievement = async () => {
            var userId = localStorage.getItem("id");
            if (userId !== null){
                let isResearcher = await getResearcher(+userId)
                if (isResearcher !== null){
                    let code = await putAchievement(7 ,+userId)
                    alert(`Congrats. You got a new achievement: ${isResearcher.name}`)
                }
            }
        }

        const getMuscle = async () => {
            if (id !== undefined){
                let muscle = await getMuscleById(+id);
                if (muscle !== undefined){
                    setMuscle(muscle);
                }
            }
        }
        getMuscle();
        checkAchievement()
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