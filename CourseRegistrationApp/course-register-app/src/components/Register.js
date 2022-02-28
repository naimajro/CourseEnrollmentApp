import { Button, FormControl } from "@mui/material";
import React, { useState } from "react";
import Company from "./Company";
import Course from "./Course";
import Participants from "./Participants";
import { useDispatch, useSelector } from "react-redux";
import { addRegisterAsync } from "../redux/registerSlice";

const Register = () => {
    
  const [company, setCompany] = useState({
    companyName: "",
    companyEmail: "",
    companyPhone: "",
  });
  const [participants, setParticipants] = useState({
    participantsName: "",
    participantsEmail: "",
    participantsPhone: "",
  });
  const [course, setCourse] = useState({
    courseName: "",
    courseDate: "",
  });
  const dispatch = useDispatch();

  const handleCompanyChange = (event) => {
    let value = event.target.value;
    setCompany({
      ...company,
      [event.target.name]: value,
    });
  };

  const handleParticipantsChange = (event) => {
    let value = event.target.value;
    setParticipants({
      ...participants,
      [event.target.name]: value,
    });
  };

  const handleCourseChange = (event) => {
    let value = event.target.value;
    setCourse({
      ...course,
      [event.target.name]: value,
    });
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    dispatch(
      addRegisterAsync({
        company: {
          name: company.companyName,
          email: company.companyEmail,
          phone: company.companyPhone,
        },
        course: { name: course.courseName, date: course.courseDate },
        participant: {
          name: participants.participantsName,
          phone: participants.participantsPhone,
          email: participants.participantsEmail,
        },
      })
    );
  };

  return (
    <FormControl>
      <Course onChange={handleCourseChange} />
      <Company onChange={handleCompanyChange} />
      <Participants onChange={handleParticipantsChange} />
      <Button type="submit" onClick={handleSubmit}>
        Submit
      </Button>
    </FormControl>
  );
};

export default Register;
