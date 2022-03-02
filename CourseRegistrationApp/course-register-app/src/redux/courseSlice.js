import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';

export const getCoursesAsync = createAsyncThunk(
	'courses/getCoursesAsync',
	async () => {
		const resp = await fetch('https://localhost:5001/api/courses');
		if (resp.ok) {
			const courses = await resp.json();
			return { courses };
		}
	}
);

export const getDatesAsync = createAsyncThunk(
	'dates/getDatesAsync',
	async () => {
		const resp = await fetch('https://localhost:5001/api/date');
		if (resp.ok) {
			const dates = await resp.json();
			return { dates };
		}
	}
);

export const courseSlice = createSlice({
	name: 'course',
	initialState: [
		{ id: 1, name: 'course 1', dates: ['2022-03-02T10:45:15.450Z'] },
	],
	reducers: {

	},
    	extraReducers: {
		[getCoursesAsync.fulfilled]: (state, action) => {
			return action.payload.courses;
		},
        [getDatesAsync.fulfilled]: (state, action) => {
			return action.payload.dates;
		}
	},
});

// export const { addTodo, toggleComplete, deleteTodo } = courseSlice.actions;

export default courseSlice.reducer;