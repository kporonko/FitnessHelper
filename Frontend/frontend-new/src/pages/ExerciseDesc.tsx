import React, {useEffect, useState} from 'react';
import Header from "../components/Header";
import Footer from "../components/Footer";
import {Link, useParams} from "react-router-dom";
import {getExerciseDescById} from '../fetch/FetchData'
import {IExerciseDesc} from "../interfaces/ExerciseById/IExerciseDesc";
import classes from "./ExerciseDesc.module.css";
import YouTube from "react-youtube";
import ReactPlayer from "react-player";
import ModalWorkoutsList from "../components/ModalWorkoutsList";


const ExerciseDesc = () => {

    const {id} = useParams()

    const [exercise, setExercise] = useState<IExerciseDesc>()
    const [isActiveModal, setIsActiveModal] = useState(false)
    const opts = {
        height: '600px',
        width: '1000px',
    };

    useEffect(()=>{
        const getExDesc = async () =>{
            if (id !==  undefined){
                let exercise = await getExerciseDescById(+id);
                setExercise(exercise);
            }

            let res = "";
            if (exercise?.urlVideo === undefined){
                return "";
            }
            for (let i = exercise?.urlVideo.length - 1; i > 0; i--){
                if (exercise?.urlVideo[i]==='/'){
                    return res;
                }
                res += exercise?.urlVideo[i]
            }
            setVideoId(res);
        }
        getExDesc()
    }, [])

    const [videoId, setVideoId] = useState("")



    return (
        <div>
            <Header page=""/>
            <h1 className={classes.h1}>{exercise?.name}</h1>
            <div className={classes.imgWrapper}>
                <img className={classes.exImage} src={exercise?.urlImage} alt="Image"/>
            </div>
            <div style={{display:'flex', justifyContent: 'center', marginTop: '30px'}}>
                <button onClick={() => setIsActiveModal(true)} className={classes.buttonAdd}>Add Exercise To Workout Set</button>
            </div>
            <div className={classes.descWrapper}>
                <h2 data-aos="fade-right" className={classes.h2}>{exercise?.name}</h2>
                <h5 data-aos="fade-right" className={classes.h5}>{exercise?.description}</h5>
            </div>
            <div>
                <h3  data-aos="fade-right" className={classes.h3}>Target Muscle</h3>
                <div  data-aos="fade-right" className={classes.targetBarWrapper}>
                    <div className={classes.targetBar}>
                        <Link to={`/muscle/${exercise?.targetMuscle.muscleId}`}>
                            <div className={classes.target}>
                                <h2 className={classes.h2Muscle}>{exercise?.targetMuscle.name}</h2>
                            </div>
                        </Link>
                    </div>
                </div>

                <h3  data-aos="fade-right" className={classes.h3}>Synergists</h3>
                    <div style={{display: 'flex', flexDirection:"column", alignItems: "center"}}>
                        {exercise?.synergistMuscles.map((item, index) => (
                            <div  data-aos="fade-right" className={classes.targetBar}>
                                <Link to={`/muscle/${item.muscleId}`}>
                                    <div className={classes.synergist}>
                                        <h2 key={index} className={classes.h2Muscle}>{item.name}</h2>
                                    </div>
                                </Link>
                            </div>
                        ))}
                    </div>

                <h3 style={{marginBottom: '30px'}} className={classes.h3}>Watch How To Correctly Do This Exercise</h3>
                {exercise?.urlVideo !== undefined &&
                    <div data-aos="fade-right" className={classes.ytWrapper}>
                        <YouTube opts={opts} videoId={exercise.urlVideo.substring(exercise.urlVideo.length - 11)}/>
                    </div>
                }
                </div>
            {id !== undefined && <ModalWorkoutsList exerciseId={+id} active={isActiveModal} setActive={setIsActiveModal}/>}
            <Footer/>
        </div>
    );
};

export default ExerciseDesc;