import React, {useEffect, useState} from 'react';
import Header from "../components/Header";
import Footer from "../components/Footer";
import classes from './Workouts.module.css'
import {getBasicWorkoutsBySection} from "../fetch/FetchData"
import {IBasicalWorkout} from "../interfaces/IBasicalWorkout";
import BasicWorkoutCard from "../components/BasicWorkoutCard";
import {ScrollMenu, VisibilityContext} from "react-horizontal-scrolling-menu";

const Workouts = () => {

    let [firstSection, setFirstSection] = useState<IBasicalWorkout[] | null>([])
    let [secondSection, setSecondSection] = useState<IBasicalWorkout[] | null>([])
    let [thirdSection, setThirdSection] = useState<IBasicalWorkout[] | null>([])

    const visibility = React.useContext(VisibilityContext);

    useEffect( () => {
        const getWorkouts = async () => {
            let first = await getBasicWorkoutsBySection(1);
            setFirstSection(first);
            let second = await getBasicWorkoutsBySection(2);
            setSecondSection(second);
            let third = await getBasicWorkoutsBySection(3);
            setThirdSection(third)
        }
        getWorkouts();
    }, [])


    return (
        <div>
            <Header/>
            <div data-aos="fade-up" style={{position: 'relative', marginBottom: '3%'}}>
                <p className={classes.p}>Here you can see the most popular exercise sets in the sports history.</p>
                <img className={classes.mainImage} src={require("../../public/workouts.jpg")} alt=""/>
            </div>
            <div data-aos="fade-up" className={classes.headerWrapper}>
                <h2 className={classes.h2}>Mass Gaining Workouts</h2>
            </div>
            <div data-aos="fade-up" style={{marginBottom: '30px'}}>
                <ScrollMenu>
                    <div style={{display: 'flex', gap: '5vh', margin: '0 50px'}}>
                        {firstSection == null ? 'null' : firstSection.map((item) => (
                            <BasicWorkoutCard id={item.id} image={item.image} name={item.name} topEfficiency={item.topEfficiency}/>
                        ))}
                    </div>
                </ScrollMenu>
            </div>
            <div data-aos="fade-up" className={classes.headerWrapper}>
                <h2 className={classes.h2}>Fat Loss Workouts</h2>
            </div>
            <div data-aos="fade-up" style={{marginBottom: '30px'}}>
                <ScrollMenu>
                    <div data-aos="fade-up"  style={{display: 'flex', gap: '5vh', margin: '0 50px'}}>
                        {secondSection == null ? 'null' : secondSection.map((item) => (
                            <BasicWorkoutCard id={item.id} image={item.image} name={item.name} topEfficiency={item.topEfficiency}/>
                        ))}
                    </div>
                </ScrollMenu>
            </div>
            <div  data-aos="fade-up" className={classes.headerWrapper}>
                <h2 className={classes.h2}>Workouts From The Best Athletes</h2>
            </div>
            <div data-aos="fade-up" style={{display: 'flex', gap: '5vh', margin: '0 50px'}}>
                {thirdSection == null ? 'null' : thirdSection.map((item) => (
                    <BasicWorkoutCard id={item.id} image={item.image} name={item.name} topEfficiency={item.topEfficiency}/>
                ))}
            </div>
            <Footer/>
        </div>
    );
};

export default Workouts;