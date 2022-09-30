import React from 'react';
import classes from "./ModalEndTraining.module.css";

const ModalPause = () => {
    return (
        <div>
            <div className={classes.modalActive}>
                <div className={classes.modal__content_pause}>
                    <h2 className={classes.pause}>Pause</h2>
                </div>
            </div>
        </div>
    );
};

export default ModalPause;