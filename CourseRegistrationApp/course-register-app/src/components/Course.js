import React, { StrictMode, useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { getCoursesAsync, getDatesAsync } from '../redux/courseSlice';
import { Box, FormControl, Grid, InputLabel, MenuItem, Select, SelectChangeEvent, TextField } from '@mui/material';
import { connect } from "react-redux";
import courseData from '../assets/courses.json'
import { elementAcceptingRef } from '@mui/utils';
import store from '../redux/store'

const Course = (props) => {
	const dispatch = useDispatch();

	const courses = useSelector((state) => state.courses);
    const dates = useSelector((state) => state.courses);

    const [courseState,setCourseState] = useState('');
    const [dateState, setDateState]  = useState(['']);

    const handleCourseChange = (e) => {
        setCourseState(e.target.value);
    }
    const handleDateChange = (e) => {
        setDateState(e.target.value);
    }
    const handleChange = (e) => {

        if(props.onChange !== undefined){
            props.onChange(e)
        }
    }   

	useEffect(() => {
        dispatch(getCoursesAsync())
        // dispatch(getDatesAsync())
	}, [dispatch]);
   
    //   const date = courses.find(item => item[0].courseAndDateRelations.dateId === dates.id)?.dates.map((state) => (
    //      <MenuItem key={state.id} value={state.date}>
    //       {state}
    //     </MenuItem>
    //   ));

	return (
        <>
<Grid container spacing={2}>
    <Grid item md={6}>
        <Box sx={{
            m: 1, width: '100%', maxWidth: '100%'
        }}>

            <FormControl fullWidth>
                <InputLabel id="demo-simple-select-label">Course</InputLabel>
                <Select
                    labelId="demo-simple-select-label"
                    id="demo-simple-select"
                    label="Course"
                    onChange={e => { handleChange(e); handleCourseChange(e);}}
                    name="courseName"
                >
                    {courses.map((course)=><MenuItem key={course.name} value={course.name}>{course.name}</MenuItem>)}
                </Select>
            </FormControl>
        </Box>
    </Grid>
    <Grid item md={6}>
        <Box sx={{
            m: 1, width: '100%', maxWidth: '100%'
        }}>
            <FormControl fullWidth>
                <InputLabel id="demo-simple-select-label">Date</InputLabel>
                <Select
                    labelId="demo-simple-select-label"
                    id="demo-simple-select"
                    label="Date"
                    value={'2020-10-10'}
                    name="courseDate"
                    // onChange={e => { handleChange(); handleDateChange();}}
                >
                    {/* {dates.map((date)=><MenuItem key={date} value={date}>{date}</MenuItem>)} */}
          
                </Select>
            </FormControl>
        </Box>
    </Grid>

</Grid>
</>
	);
};
// const allActions = [
//     getCoursesAsync(),
//     getDatesAsync(),
// ];
// const mapDispatchToProps = dispatch => ({
//     props: () => {
//         allActions.map((action) => dispatch(action));
//     },
//   });
//   export default connect(mapDispatchToProps
//   )(Course);
  
export default Course;
