import { Button, FormControl } from "@mui/material";
import React, { useState } from "react";
import Company from "./Company";
import Course from "./Course";
import Participants from "./Participants";
import { useDispatch, useSelector } from "react-redux";
import { addRegisterAsync } from "../redux/registerSlice";

const Register = () => {
    
  const [company, setCompany] = useState({
    name: "",
    email: "",
    phone: "",
  });
  const [participantsToBePosted, setParticipantsToBePosted] = useState([{
    name: "",
    email: "",
    phone: "",
  },]);
  const [course, setCourse] = useState({
    name: "",
    date: "",
  });


  const dispatch = useDispatch();

  const handleCompanyChange = (event) => {
    let value = event.target.value;
    setCompany({
      ...company,
      [event.target.name]: value,
    });
  };
  const handleParticipantsChange = (index, event) => {
    let n = event.target.name;
    let value = event.target.value;
    console.log(index);
    let participants = [...participantsToBePosted];
    participants[index][n] = value;
    setParticipantsToBePosted(participants);

  };
  console.log(participantsToBePosted);
  const [participants,setParticipants] = useState([<Participants key={0} id={0} onChange={handleParticipantsChange}/>]);

  let handleAddParticipants = (e) => {
    e.preventDefault();

    setParticipants([...participants, <Participants key={participants.length} id={participants.length} onChange={handleParticipantsChange} />])

    setParticipantsToBePosted(participantsToBePosted.push({
      name: "",
      email: "",
      phone: "",
    }));

    console.log(participantsToBePosted);
  }



  const handleCourseChange = (event) => {
    let value = event.target.value;
    setCourse({
      ...course,
      [event.target.name]: value,
    });
  };

  const handleSubmit = (event) => {
    console.log(participantsToBePosted)
    event.preventDefault();
    dispatch(
      addRegisterAsync({
        company: {
          name: company.name,
          email: company.email,
          phone: company.phone,
        },
        course: { name: course.name, date: course.date },
        participant: participantsToBePosted
      })
    );
  };

  return (
    <FormControl>
      <Course onChange={handleCourseChange} />
      <Company onChange={handleCompanyChange} />
      {participants}
      <Button variant="contained" onClick={handleAddParticipants}>Add Participant</Button>
      <Button type="submit" onClick={handleSubmit}>
        Submit
      </Button>
    </FormControl>
  );
};

export default Register;
