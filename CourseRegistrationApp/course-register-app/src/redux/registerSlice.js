import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";

export const addRegisterAsync = createAsyncThunk(
  "register/addRegisterAsync",
  async (payload) => {
    const resp = await fetch("https://localhost:5001/api/register", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        cdrForCreationDto: {
          dateForCreationDto: { courseDate: "2022-03-01T14:37:29.543Z" },
          courseForCreationDto: { name: 'coursename1' },
        },

        participantForCreationDto:
          payload.participant
        ,
        companyForCreationDto: {
          name: payload.company.name,
          phone: payload.company.phone,
          email: payload.company.email,
        }
      }),
    });

    if (resp.ok) {
      const registration = await resp.json();
      return { registration };
    }
  }
);

export const registerSlice = createSlice({
  name: "register",
  initialState: [],
  reducers: {
    addRegister: (state, action) => {
      const register = {
        course: {
          name: action.payload.course.name,
          date: action.payload.course.date,
        },
        company: {
          name: action.payload.company.name,
          phone: action.payload.company.phone,
          email: action.payload.company.email,
        },
        participant: action.payload.participant,
      };
      state.push(register);
    },

    extraReducers: {
      [addRegisterAsync.fulfilled]: (state, action) => {
        state.push(action.payload.register);
      },
    },
  },
});

export const { addRegister } = registerSlice.actions;

export default registerSlice.reducer;
