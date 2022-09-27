import React, {useEffect, useState} from 'react';
import Header from "../components/Header";
import Footer from "../components/Footer";
import {getProfile, getUserTrainingsByUserId, getBasicTrainingsByUserId} from '../fetch/FetchData';
import {IProfile} from "../interfaces/IProfile";
import classes from './Profile.module.css'
import {ITraining} from "../interfaces/ITraining";
import TrainingCard from "../components/TrainingCard";

const Profile = () => {

    const [profile, setProfile] = useState<IProfile>()
    const [trainings, setTrainings] = useState<ITraining[]>()
    const [isUserSet, setIsUserSet] = useState(true);

    useEffect(() => {
        const getFullProfile = async () => {
            let userId = localStorage.getItem("id")
            if (userId !== null){
                let profile = await getProfile(+userId)
                setProfile(profile)
                let userTrainings = await getUserTrainingsByUserId(+userId);
                setTrainings(userTrainings)
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