import {configureStore } from '@reduxjs/toolkit'
import courseSlice, {coursesReducer} from './courseSlice';
import registerSlice from './registerSlice'

export default configureStore({
    reducer:{
       courses: courseSlice,
       registration: registerSlice
    },
})