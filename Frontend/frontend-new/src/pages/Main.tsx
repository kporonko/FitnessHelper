import React, {useEffect} from 'react';
import {useNavigate} from "react-router-dom";
import classes from "./Main.module.css"
import Header from "../components/Header";
import AOS from 'aos';
import 'aos/dist/aos.css'
import Footer from "../components/Footer";

const Main = () => {
    const nav = useNavigate()

    useEffect(()=>{
        console.log(localStorage.getItem("id"))
        if (localStorage.getItem("id") == null){
            nav("/");
        }
    })

    return (
        <div>
            <Header page="main" />
            <div className={classes.main}>
                <img className={classes.mainImg} src={require("../../public/back.jpg")} alt="MainImage"/>
                <div data-aos="fade-up" className={classes.textWrapper}>
                    <h2 className={classes.h2}>The best workouts</h2>
                    <h5 className={classes.h5}>
                        We prepared for you the best workout sets from the whole world for all purposes - starting with muscle mass gaining and ending with fat loss workouts. You can also find the workouts of the best athletes in the history, such as Arnold Schwarzenegger or Kyryl Poronko.
                    </h5>
                </div>
                <div data-aos="fade-up" className={classes.textWrapper}>
                    <h2 className={classes.h2}>The biggest storage of exercises</h2>
                    <h5 className={classes.h5}>
                        With our app you can learn a lot of new effective exercises for any muscle. You can find out all about exercise - starting with it`s description and ending with video how to properly do the exercise.
                    </h5>
                </div>
                <div data-aos="fade-up" className={classes.textWrapper}>
                    <h2 className={classes.h2}>Create your own exercises</h2>
                    <h5 className={classes.h5}>
                        With our app you can create your own exercises sets or simply - workouts. Just add exercises that you think you need in order to improve your health and go for it.
                    </h5>
                </div>
                <div data-aos="fade-up" className={classes.textWrapper}>
                    <h2 className={classes.h2}>Launch trainings and track your progress</h2>
                    <h5 className={classes.h5}>
                        Our app suggests the possibility of launching the training in the browser. We will show you the convenient interface of training - you will see all the exercises, time of training and so on. Also you can check all your training history.
                    </h5>
                </div>
            </div>
            <Footer/>
        </div>
    );
};

export default Main;