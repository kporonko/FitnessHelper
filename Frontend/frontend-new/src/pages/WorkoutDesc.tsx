import React, {useEffect, useState} from 'react';
import Footer from "../components/Footer";
import Header from "../components/Header";
import {useParams} from "react-router-dom";
import {getBasicalWorkoutFullDesc} from '../fetch/FetchData';
import classes from './WorkoutDesc.module.css';
import {AiFillFire, AiOutlineFire} from "react-icons/ai";
import WorkoutExerciseCard from "../components/WorkoutExerciseCard";

const WorkoutDesc = () => {

    const {id} = useParams();

    const [name, setName] = useState("")
    const [image, setImage] = useState("")
    const [description, setDescription] = useState("")
    const [efficiency, setEfficiency] = useState({
        cardio: 0,
        legs: 0,
        arms: 0,
        back: 0,
        chest: 0,
        abs: 0
    });
    const [exerciseSmallDesc, setExerciseSmallDesc] = useState([{
        name: "",
        image: "",
        id: -1,
        targetMuscle: ""
    }])

    useEffect(() => {
        const getDescWorkout = async () => {
            let desc;
            if (id !== undefined){
                desc = await getBasicalWorkoutFullDesc(+id);
            }
            if (desc !== null && desc !== undefined){
                setImage(desc.image)
                setDescription(desc.description)
                setName(desc.name)
                setEfficiency(desc.efficiency)
                setExerciseSmallDesc(desc.exerciseSmallDescs)
            }
        }

        getDescWorkout()
    }, [id])

    return (
        <div>
            <Header page=""/>
            <h1 className={classes.h1}>{name === "" ? "Error" : name}</h1>
            <div className={classes.descWrapper}>
                <div data-aos="fade-up" style={{display: 'flex', justifyContent: 'center'}}>
                    <img className={classes.mainImg} src={image === "" ? "" : image} alt="Error"/>
                </div>
                <p data-aos="fade"               className={classes.p}>{description === "" ? "Error" : description}</p>
                <div data-aos="fade" className={classes.efficiencyWrapper}>
                    <span className={classes.partBodySpan}>Abs:</span> {Array(efficiency.abs).fill(0).map((x,i) => (
                        <span className={classes.fire}><AiFillFire/></span>
                ))}
                    <span>{Array(5 - efficiency.abs).fill(0).map((x,i) => (
                        <span className={classes.fire}><AiOutlineFire/></span>
                        ))}</span>
                </div>
                <div data-aos="fade" className={classes.efficiencyWrapper}>
                    <span className={classes.partBodySpan}>Cardio:</span> {Array(efficiency.cardio).fill(0).map((x,i) => (
                        <span className={classes.fire}><AiFillFire/></span>
                ))}
                    <span>{Array(5 - efficiency.cardio).fill(0).map((x,i) => (
                        <span className={classes.fire}><AiOutlineFire/></span>
                    ))}</span>
                </div>
                <div data-aos="fade" className={classes.efficiencyWrapper}>
                    <span className={classes.partBodySpan}>Chest:</span> {Array(efficiency.chest).fill(0).map((x,i) => (
                        <span className={classes.fire}><AiFillFire/></span>
                ))}
                    <span>{Array(5 - efficiency.chest).fill(0).map((x,i) => (
                        <span className={classes.fire}><AiOutlineFire/></span>
                    ))}</span>
                </div>
                <div data-aos="fade" className={classes.efficiencyWrapper}>
                    <span className={classes.partBodySpan}>Legs:</span> {Array(efficiency.legs).fill(0).map((x,i) => (
                        <span className={classes.fire}><AiFillFire/></span>
                ))}
                    <span>{Array(5 - efficiency.legs).fill(0).map((x,i) => (
                        <span className={classes.fire}><AiOutlineFire/></span>
                    ))}</span>
                </div>
                <div data-aos="fade" className={classes.efficiencyWrapper}>
                    <span className={classes.partBodySpan}>Back:</span> {Array(efficiency.back).fill(0).map((x,i) => (
                        <span className={classes.fire}><AiFillFire/></span>
                ))}
                    <span>{Array(5 - efficiency.back).fill(0).map((x,i) => (
                        <span className={classes.fire}><AiOutlineFire/></span>
                    ))}</span>
                </div>
                <div data-aos="fade" className={classes.efficiencyWrapper}>
                    <span className={classes.partBodySpan}>Arms:</span> {Array(efficiency.arms).fill(0).map((x,i) => (
                        <span className={classes.fire}><AiFillFire/></span>
                ))}
                    <span>{Array(5 - efficiency.arms).fill(0).map((x,i) => (
                        <span className={classes.fire}><AiOutlineFire/></span>
                    ))}</span>
                </div>
            </div>
            <h1 className={classes.h1}>Exercises</h1>
                {exerciseSmallDesc === undefined ? "" :exerciseSmallDesc.map((item,i) => (
                    <WorkoutExerciseCard key={i} id={item.id} name={item.name} image={item.image} targetMuscle={item.targetMuscle}/>
            ))}
            <button>Soon...</button>
            <Footer/>
        </div>
    );
};

export default WorkoutDesc;