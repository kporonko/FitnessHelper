import React from 'react';
import classes from "./StartImage.module.css";

const StartImage = () => {
    return (
        <img className={classes.loginImage} src="https://images.pexels.com/photos/1229356/pexels-photo-1229356.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2" alt="Man"/>
    );
};

export default StartImage;