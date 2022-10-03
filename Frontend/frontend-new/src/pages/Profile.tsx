import React, {useEffect, useState} from 'react';
import Header from "../components/Header";
import Footer from "../components/Footer";
import {getProfile, getUserTrainingsByUserId, getBasicTrainingsByUserId, getAllAchievments, getUserMuscles} from '../fetch/FetchData';
import {IProfile} from "../interfaces/IProfile";
import classes from './Profile.module.css'
import {ITraining} from "../interfaces/ITraining";
import TrainingCard from "../components/TrainingCard";
import {IAchievment} from "../interfaces/IAchievment";
import {IUserMuscle} from "../interfaces/IUserMuscle";
import {Link} from "react-router-dom";
import Dropdown from 'react-dropdown';

const Profile = () => {

    const [profile, setProfile] = useState<IProfile>()
    const [trainings, setTrainings] = useState<ITraining[]>()
    const [isUserSet, setIsUserSet] = useState(true);
    const [achievments, setAchievments] = useState<IAchievment[]>();
    const [userMuscles, setUserMuscles] = useState<IUserMuscle[]>();
    const [isOpenMuscles, setIsOpenMuscles] = useState(false)

    useEffect(() => {
        const getFullProfile = async () => {
            let userId = localStorage.getItem("id")
            if (userId !== null){
                let profile = await getProfile(+userId)
                setProfile(profile)
                let userTrainings = await getUserTrainingsByUserId(+userId);
                setTrainings(userTrainings)
                let achievements = await getAllAchievments(+userId);
                setAchievments(achievements)
                let muscles = await getUserMuscles(+userId)
                setUserMuscles(muscles);
            }
        }
        getFullProfile()
    }, [])

    const handleBasicTrainings = async () => {
        let userId = localStorage.getItem("id")
        if (userId !== null){
            let basicTrainings = await getBasicTrainingsByUserId(+userId);
            setTrainings(basicTrainings)
            setIsUserSet(false)
        }
    }
    const handleUserTrainings = async () => {
        let userId = localStorage.getItem("id")
        if (userId !== null){
            let userTrainings = await getUserTrainingsByUserId(+userId);
            setTrainings(userTrainings)
            setIsUserSet(true)
        }
    }

    return (
        <div>
            <Header page="profile"/>
            <h2 className={classes.h2}>Your Profile</h2>
            <div className={classes.flexDiv}>
                <div className={classes.imgWrapper}>
                    <img src={require("../../public/user.png")} alt=""/>
                </div>
                <div>
                    <h3 className={classes.h3}>{profile?.name}</h3>
                    <h5 className={classes.h5}>Total Trainings: <span className={classes.boldSpan}>{profile?.totalTrainings}</span></h5>
                    <h5 className={classes.h5}>Total Trainings Time: <span className={classes.boldSpan}>{profile?.totalTrainingsTimeInMinutes} min.</span></h5>
                </div>
            </div>
            <div className={classes.achievments}>
                <hr/>
                    <div style={{display: 'flex', justifyContent: 'center', gap:'30px'}}>
                        {achievments?.map((val, ind) => (
                            <div style={{display: 'flex', flexDirection: 'column', justifyContent: 'center', alignItems: 'center'}}>
                                <img className={val.isDone === true ? classes.achievImage: classes.achievImageGray} src={val.image} alt=""/>
                                <h2 className={val.isDone === true ? classes.achievName: classes.achievNameGray}>{val.name}</h2>
                                <h2 className={classes.achievDesc}>{val.description}</h2>
                            </div>
                        ))}
                    </div>
                <hr/>
            </div>

            <div style={{margin: '10px 7%'}}>
                <hr/>
                <div style={{display: 'flex', justifyContent: 'center'}}>
                    <button className={!isOpenMuscles ? classes.button : `${classes.button} ${classes.red}`} onClick={() => setIsOpenMuscles(!isOpenMuscles)}>{isOpenMuscles? 'Close Muscles' : 'Open Muscles'}</button>
                </div>
                <div className={isOpenMuscles ? classes.userMuscles : classes.invisible} style={{display: 'flex', flexDirection: 'column', alignItems: 'center'}}>
                    {userMuscles?.map((val, ind) => (
                        <div key={ind}>
                            <Link className={classes.link} to={`/muscle/${val.id}`}>
                                <h5 className={classes.muscleName}>{val.name}: <span>{val.percentage}</span></h5>
                                <div>
                                    <img style={{top: document.documentElement.clientHeight / 2, right: 20}} className={classes.image} src={val.urlImage} alt=""/>
                                </div>
                            </Link>
                        </div>
                    ))}
                </div>
                <hr/>
            </div>

            <h2 className={classes.h2}>Trainings</h2>
            <div style={{margin: '30px 15%'}}>
                <span onClick={() => handleUserTrainings()} className={isUserSet ? `${classes.categorySpan} ${classes.activeSpan}` : `${classes.categorySpan}`}>Own Trainings</span>
                <span onClick={() => handleBasicTrainings()} className={!isUserSet ? `${classes.categorySpan} ${classes.activeSpan}` : `${classes.categorySpan}`}>Basic Trainings</span>
            </div>
            <div>
                {trainings?.map((val, ind) => (
                    <TrainingCard training={val} key={ind}/>
                ))}
            </div>
            <Footer/>
        </div>
    );
};

export default Profile;