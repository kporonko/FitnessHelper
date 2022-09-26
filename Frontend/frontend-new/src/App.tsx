import React from 'react';
import './App.css';
import {BrowserRouter, Route, Routes} from "react-router-dom";
import Login from "./pages/Login";
import Register from "./pages/Register";
import Main from "./pages/Main";
import AOS from "aos";
import Workouts from "./pages/Workouts";
import Exercises from "./pages/Exercises";
import MyWorkouts from "./pages/MyWorkouts";
import Profile from "./pages/Profile";
import ExerciseDesc from "./pages/ExerciseDesc";
import WorkoutDesc from "./pages/WorkoutDesc";
import MyWorkoutDesc from "./pages/MyWorkoutDesc";
import MuscleDesc from "./pages/MuscleDesc";
import {ReactNotifications} from "react-notifications-component";
import 'react-notifications-component/dist/theme.css'

function App() {
    AOS.init();
    return (
    <BrowserRouter>
        <ReactNotifications/>
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
            <Route path="/training" element={<div>Training</div>}/>
        </Routes>
    </BrowserRouter>
  );
}

export default App;
