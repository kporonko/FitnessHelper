import React from 'react';
import {useLocation} from "react-router-dom";
import {IExercise} from "../interfaces/IExercise";

const Training = () => {

    const location = useLocation()
    const {workTime, setsCount, rest, exerciseSmallDesc, name, id} = location.state;

    return (
        <div>
            {workTime}
            {setsCount}
            {rest}
            {name}
            {id}
            {(exerciseSmallDesc as IExercise[]).map((val, ind) => (
                <div>
                    {val.name}
                    {val.image}
                </div>
            ))}
        </div>
    );
};

export default Training;