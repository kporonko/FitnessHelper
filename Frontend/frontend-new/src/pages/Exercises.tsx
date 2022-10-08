import React, {RefObject, useEffect, useRef, useState} from 'react';
import Header from "../components/Header";
import Footer from "../components/Footer";
import classes from './Exercises.module.css'
import {getAllExercises, getExByPartBody, getExBySearch} from '../fetch/FetchData';
import {IExercise} from "../interfaces/IExercise";
import ExerciseCard from "../components/ExerciseCard";
import {Box, Button, Pagination, TextField} from "@mui/material";
import ModalAddWorkout from "../components/ModalAddWorkout";
import ModalWorkoutsList from "../components/ModalWorkoutsList";
import imageExercise from "../Assets/exercises.jpeg"

const Exercises = () => {

    const [exercises, setExercises] = useState<IExercise[]>();
    const [currentPage, setCurrentPage] = useState(1)
    const [currentSearchPage, setCurrentSearchPage] = useState(1)

    const indexOfLastProduct = currentPage * 15;
    const indexOfFirstProduct = indexOfLastProduct - 15;

    const indexOfLastProductSearch = currentSearchPage * 15;
    const indexOfFirstProductSearch = indexOfLastProductSearch - 15;
    const [isActiveModal, setIsActiveModal] = useState(false)
    const [currCategory, setCurrCategory] = useState("")
    const myRef = useRef<HTMLDivElement>(null)
    useEffect(() => {
        const getExercises = async() => {
            let exercises = await getAllExercises();
            setExercises(exercises);
            setCurrCategory("All Exercises")
        }
        getExercises();
    }, [])

    const currentExercises = exercises?.slice(indexOfFirstProduct, indexOfLastProduct);

    const [search, setSearch] = useState("")
    const [currExerciseToAdd, setCurrExerciseToAdd] = useState(0)
    const [searchedExercises, setSearchedExercises] = useState<IExercise[]>()
    const currentSearchedExercises = searchedExercises?.slice(indexOfFirstProductSearch, indexOfLastProductSearch);

    const refListSearch = useRef<HTMLDivElement>(null)

    const paginate = (event: any, value: React.SetStateAction<number>) => {
        setCurrentPage(value);
        if (myRef.current){
            myRef.current.scrollIntoView({behavior: 'smooth'})
        }
    };
    const paginateSearch = (event: any, value: React.SetStateAction<number>) => {
        setCurrentSearchPage(value);
        if (refListSearch.current){
            refListSearch.current.scrollIntoView({behavior: 'smooth'})
        }
    };

    const [tempSearch, setTempSearch] = useState("")
    const handleSearch = async () => {
        setTempSearch(search)
        let searchedEx = await getExBySearch(search);
        setSearchedExercises(searchedEx)
    }

    const categoryHandle = async (part: string) => {
        setCurrentPage(1)
        let exByPart = await getExByPartBody(part);
        setExercises(exByPart)
        setCurrCategory(part + ' Exercises')
    }

    const allExercisesHandle = async () => {
        setCurrentPage(1)
        let exercises = await getAllExercises();
        setExercises(exercises);
        setCurrCategory("All Exercises")
    }

    return (
        <div>
            <Header page="exercises"/>
            <div style={{position: 'relative', marginBottom: '3%'}}>
                <p className={classes.p}>Here you can see the most popular exercises in the sports history for all muscle group.</p>
                <img className={classes.mainImage} src={imageExercise} alt=""/>
            </div>

            <h4 data-aos="fade-right" className={classes.h4}>Search For Exercises</h4>
            <div data-aos="fade-right" style={{display: 'flex', justifyContent: 'center', margin: '40px 30px'}}>
                <Box style={{display: 'inline'}} position="relative" mb="32px">
                    <TextField onChange={(e)=> setSearch(e.target.value)} sx={{input: {fontWeight: '700', border: 'none', borderRadius: '4px'}, width: {lg: '900px', xs: '350px'}, borderRadius:"40px", backgroundColor: '#fff'}} value={search} placeholder='Search for exercises...' type="text"/>
                    <Button className={classes.buttonSearch} onClick={handleSearch}
                        sx={{bgcolor: 'black', color: '#fff', textTransform: 'none', width: {lg: '175px', xs: '12px'}, fontSize:{lg: '20px', xs: '14px'}, height: '56px', position: "absolute", right: '0', }}
                    >
                        Search
                    </Button>
                </Box>
            </div>

            <div ref={refListSearch}>
                <h2 className={classes.h2}>{searchedExercises === undefined ? '' : `${searchedExercises.length} Results On ${tempSearch}`} </h2>
                <div style={{display: 'flex', justifyContent: 'space-between', flexWrap: 'wrap', margin: '30px 7%'}}>
                    {currentSearchedExercises?.map((val, ind) => (
                            <ExerciseCard currExerciseToAdd={currExerciseToAdd} setCurrExerciseToAdd={setCurrExerciseToAdd} active={isActiveModal} setActive={setIsActiveModal} id={val.id} name={val.name} image={val.image} targetMuscle={val.targetMuscle} key={ind}/>
                        ))
                    }
                </div>
            </div>
            {currentSearchedExercises !== undefined && searchedExercises !== undefined &&
                <Box style={{display: 'flex', justifyContent: 'center', marginBottom:'30px'}}>
                    <Pagination
                        defaultPage={1}
                        count={Math.ceil(searchedExercises.length /15)}
                        page={currentSearchPage}
                        onChange={paginateSearch}
                    />
                </Box>}

            <div ref={myRef}  data-aos="fade-right" style={{display: 'flex', justifyContent: 'space-between', flexWrap: "wrap", margin: '100px 7%'}}>
                <h2 onClick={() => allExercisesHandle()} className={classes.h2Category}>All Exercises</h2>
                <h2 onClick={() => categoryHandle("Neck")} className={classes.h2Category}>Neck</h2>
                <h2 onClick={() => categoryHandle("Shoulders")}  className={classes.h2Category}>Shoulders</h2>
                <h2 onClick={() => categoryHandle("Upper Arms")}  className={classes.h2Category}>Upper Arms</h2>
                <h2 onClick={() => categoryHandle("Forearms")}  className={classes.h2Category}>Forearms</h2>
                <h2 onClick={() => categoryHandle("Chest")} className={classes.h2Category}>Chest</h2>
                <h2 onClick={() => categoryHandle("Hips")}  className={classes.h2Category}>Hips</h2>
                <h2 onClick={() => categoryHandle("Thighs")}  className={classes.h2Category}>Thighs</h2>
                <h2 onClick={() => categoryHandle("Back")}  className={classes.h2Category}>Back</h2>
                <h2 onClick={() => categoryHandle("Waist")}  className={classes.h2Category}>Waist</h2>
                <h2 onClick={() => categoryHandle("Calves")}  className={classes.h2Category}>Calves</h2>
            </div>

            {currCategory !== undefined && <h2 style={{margin: '30px', fontSize:'44px', fontWeight: '900'}} className={classes.h2}>{currCategory}</h2>}


            <div data-aos="fade-right" style={{display: 'flex', justifyContent: 'space-between', flexWrap: 'wrap', margin: '30px 7%'}}>
                {currentExercises?.map((item, index) => (
                    <ExerciseCard currExerciseToAdd={currExerciseToAdd} setCurrExerciseToAdd={setCurrExerciseToAdd} active={isActiveModal} setActive={setIsActiveModal} id={item.id} key={index} name={item.name} image={item.image} targetMuscle={item.targetMuscle}/>
                ))}
            </div>

            {exercises !== undefined &&
            <Box style={{display: 'flex', justifyContent: 'center', marginBottom:'30px'}}>
                <Pagination
                    defaultPage={1}
                    count={Math.ceil(exercises.length /15)}
                    page={currentPage}
                    onChange={paginate}
                />
            </Box>}

            <ModalWorkoutsList exerciseId={currExerciseToAdd} active={isActiveModal} setActive={setIsActiveModal}/>
            <Footer/>
        </div>
    );
};

export default Exercises;