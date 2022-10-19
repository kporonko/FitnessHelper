import * as React from 'react';
import './App.css';
import {BrowserRouter, Route, Routes} from "react-router-dom";
import Login from "./src/pages/Login";
import Register from "./src/pages/Register";
import Main from "./src/pages/Main";
import * as AOS from "aos";
import Workouts from "./src/pages/Workouts";
import Exercises from "./src/pages/Exercises";
import MyWorkouts from "./src/pages/MyWorkouts";
import Profile from "./src/pages/Profile";
import ExerciseDesc from "./src/pages/ExerciseDesc";
import WorkoutDesc from "./src/pages/WorkoutDesc";
import MyWorkoutDesc from "./src/pages/MyWorkoutDesc";
import MuscleDesc from "./src/pages/MuscleDesc";
import Training from "./src/pages/Training";

function App() {
    AOS.init();
    return (
    <BrowserRouter>
        <Routes>
            <Route path="/" element={<Login/>}/>
            <Route path="/main" element={<Main />}/>
            <Route path="/register" element={<Register/>}/>
            <Route path="/workouts" element={<Workouts/>}/>
            <Route path="/exercises" element={<Exercises/>}/>
            <Route path="/my-workouts" element={<MyWorkouts/>}/>
            <Route path="/profile" element={<Profile/>}/>
            <Route path="/exercise/:id" element={<ExerciseDesc/>}/>
            <Route path="/workout/:id" element={<WorkoutDesc/>}/>
            <Route path="/my-workout/:id" element={<MyWorkoutDesc/>}/>
            <Route path="/muscle/:id" element={<MuscleDesc/>}/>
            <Route path="/training" element={<Training/>}/>
        </Routes>
    </BrowserRouter>
  );
}

export default App;
