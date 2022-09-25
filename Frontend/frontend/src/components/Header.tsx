import React from 'react';
import {Link} from "react-router-dom";
import classes from "./Header.module.css"

const Header = () => {
    return (
        <div className={classes.wrapper}>
            <img className={classes.logo} src={require("../../public/logo.jpg")} alt="Fitness Helper"/>
            <div className={classes.linksWrapper}>
                <Link className={classes.linkActive} to={'/main'}>HOME</Link>
                <Link className={classes.link} to={'/workouts'}>WORKOUTS</Link>
                <Link className={classes.link} to={'/exercises'}>EXERCISES</Link>
                <Link className={classes.link} to={'/my-workouts'}>MY WORKOUTS</Link>
                <Link className={classes.link} to={'/profile'}>PROFILE</Link>
            </div>
        </div>
    );
};

export default Header;