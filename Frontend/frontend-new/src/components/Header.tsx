import React from 'react';
import {Link} from "react-router-dom";
import classes from "./Header.module.css"
import logo from '../Assets/logo.jpg'

const Header = (props: {page: string}) => {
    return (
        <div className={classes.wrapper}>
            <img className={classes.logo} src={logo} alt="Fitness Helper"/>
            <div className={classes.linksWrapper}>
                <Link className={props.page === "main" ? classes.linkActive : classes.link} to={'/main'}>HOME</Link>
                <Link className={props.page === "workouts" ? classes.linkActive : classes.link} to={'/workouts'}>WORKOUTS</Link>
                <Link className={props.page === "exercises" ? classes.linkActive : classes.link} to={'/exercises'}>EXERCISES</Link>
                <Link className={props.page === "my-workouts" ? classes.linkActive : classes.link} to={'/my-workouts'}>MY WORKOUTS</Link>
                <Link className={props.page === "profile" ? classes.linkActive : classes.link} to={'/profile'}>PROFILE</Link>
            </div>
        </div>
    );
};

export default Header;