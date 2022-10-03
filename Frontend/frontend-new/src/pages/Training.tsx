import React, {useEffect, useState} from 'react';
import {useLocation, useNavigate} from "react-router-dom";
import {IExercise} from "../interfaces/IExercise";
import classes from './Training.module.css'
import {
    countTrainingAchievements,
    createAndAddBasicTraining,
    createAndAddUserTraining,
    getCreator, is5Basical,
    is5Own,
    putAchievement, updateUserMuscles
} from "../fetch/FetchData";
import ModalEndTraining from "../components/ModalEndTraining";
import ModalPause from "../components/ModalPause";
import {MuscleId} from "../interfaces/UserMuscles/MuscleId";

const Training = () => {

    const location = useLocation()
    let {workTime, setsCount, rest, exerciseSmallDesc, name, id, isUser} = location.state;
    const count = exerciseSmallDesc.length;
    const [work, setWork] = useState<number>(workTime)
    const [sets, setSets] = useState<number>(setsCount)
    const [exercise, setExercise] = useState<number>(exerciseSmallDesc.length)
    const [nameExercise, setNameExercise] = useState<string>(exerciseSmallDesc[0].name)
    const [image, setImage] = useState<string>(exerciseSmallDesc[0].image)
    const [isRelax, setIsRelax] = useState<boolean>(true)
    const dateNow =  new Date(Date.now()).toISOString();
    const time = workTime * exerciseSmallDesc.length * setsCount / 60;
    const [isActiveModal, setIsActiveModal] = useState(false)
    let [newArr, setNewArr] = useState([...exerciseSmallDesc.slice(1, exerciseSmallDesc.length)]);
    const [isPaused, setIsPaused] = useState<boolean>(false);

    const synergists: number[] = [].concat(...exerciseSmallDesc.map((ex: IExercise) => ex.synergistsId));
    const targetIds: number[] = exerciseSmallDesc.map((ex: IExercise) => ex.targetId);
    console.log('synergists')
    console.log(synergists)
    console.log('targetIds')
    console.log(targetIds)

    useEffect(()=>{
        if (!isPaused){
            let myInterval = setTimeout(() => {
                if (sets > 0){
                    if (work > 0){
                        setWork(work - 1)
                    }
                    else if (work === 0){
                        if (isRelax){
                            setWork(rest);
                            setImage("https://img.freepik.com/premium-photo/faceless-man-relaxing-in-armchair_23-2147800039.jpg?w=2000")
                            setNameExercise("Rest")
                            setIsRelax(false)
                            return;
                        }
                        setWork(workTime)
                        if (exercise === 1){
                            if (sets === 1){
                                if (isUser){
                                    setWork(-1)
                                    const userId = localStorage.getItem("id")
                                    if (userId !== null){
                                        updateUserMuscles({ synergists: synergists, target: targetIds, userId: +userId})
                                    }
                                    return handleUserTraining()
                                }
                                else{
                                    setWork(-1)
                                    const userId = localStorage.getItem("id")
                                    if (userId !== null){
                                        updateUserMuscles({ synergists: synergists, target: targetIds, userId: +userId})
                                    }
                                    handleBasicTraining()
                                }
                                return
                            }
                            else{
                                setNewArr(exerciseSmallDesc.slice(1, exerciseSmallDesc.length))
                                setExercise(exerciseSmallDesc.length)
                                setNameExercise(exerciseSmallDesc[0].name)
                                setImage(exerciseSmallDesc[0].image)
                                setSets(sets - 1)
                                setIsRelax(true)
                            }
                        }
                        else{
                            setNewArr(newArr.slice(1,newArr.length))
                            setExercise(exercise - 1)
                            setNameExercise(newArr[0].name)
                            setImage(newArr[0].image)
                            setIsRelax(true)
                        }
                    }
                }
            }, 1000)
        }
    }, [work]);


    const nav = useNavigate()

    const handleUserTraining = async () => {
        let code = await createAndAddUserTraining(id, Math.ceil(time), dateNow)
        if (code === 201){
            setIsActiveModal(true);
        }
        let userId = localStorage.getItem("id");
        if (userId !== null) {
            let achiev = await is5Own(+userId)
            if (achiev !== null) {
                await putAchievement(5, +userId);
                alert(`Congrats. You got a new achievement: ${achiev.name}`)
            }
            let ach = await countTrainingAchievements(+userId);
            console.log(ach)
            if (ach !== null) {
                await putAchievement(ach.achievmentId, +userId);
                alert(`Congrats. You got a new achievement: ${ach.name}`)
            }
        }
    }
    const handleBasicTraining = async () => {
        let userId = localStorage.getItem("id")
        if (userId !== null){
            let code = await createAndAddBasicTraining(+userId, id, Math.ceil(time), dateNow)
            if (code === 201){
                setIsActiveModal(true);
            }
            let achiev = await is5Basical(+userId)
            if (achiev !== null) {
                await putAchievement(4, +userId);
                alert(`Congrats. You got a new achievement: ${achiev.name}`)
            }

            let ach = await countTrainingAchievements(+userId);
            if (ach !== null) {
                await putAchievement(ach.achievmentId, +userId);
                alert(`Congrats. You got a new achievement: ${ach.name}`)
            }
        }
    }

    const handlePause = () => {
        if (isPaused){
            if (work < 2){
                setWork(work+1);
            }
            else{
                setWork(work - 1)
            }
            // setWork(work-1);
        }
        setIsPaused(!isPaused)
    }

    return (
        <div onClick={() =>{
            handlePause()
        }}>
            <h2 className={classes.header}>{nameExercise}</h2>
            <div style={{display: 'flex', gap: '100px', justifyContent: 'center'}}>
                <h3>{isRelax && `Set ${setsCount - sets + 1}/${setsCount}`}</h3>
                <h3>{isRelax && `Exercise ${exerciseSmallDesc.length - exercise + 1}/${count}`}</h3>
            </div>
            <div className={classes.wrapper}>
                <div className={classes.time}><h2 className={classes.absolute}>{work}</h2></div>
                <div>
                    <img className={classes.image} src={image} alt=""/>
                </div>
            </div>
            {isPaused &&
            <ModalPause/>}
            <ModalEndTraining time={Math.ceil(time)} name={name} active={isActiveModal} setActive={setIsActiveModal}/>
        </div>
    );
};



export default Training;