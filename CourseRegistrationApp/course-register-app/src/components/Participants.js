import { Box, Button, Grid, TextField, touchRippleClasses } from "@mui/material";
import { createImmutableStateInvariantMiddleware } from "@reduxjs/toolkit";
import React,{useState} from "react";

const Participants = (props) => {

    const handleChange = (e) => {
        const name = e.target.value;
        if(props.onChange !== undefined){
            props.onChange(e)
        }

    }

    const [textFields,setTextFields] = useState([]);
    const [state,setState] = useState();
    let handleAddText = (e) => {
        e.preventDefault()
        setTextFields([...textFields,
            <Grid container spacing={2}>
            <Grid item md={12}>
                <Box
                    component="form"
                    sx={{
                        m: 1, style: { textAlign: 'center' }
                    }
                    }
                    noValidate
                    autoComplete="off"
                >
                    <TextField required id="outlined-required" label="Name" name="participantsName" variant="outlined" fullWidth onChange={handleChange}/>
                </Box>
            </Grid>

            <Grid item md={6}>
                <Box
                    component="form"
                    sx={{
                        m: 1, width: '100%', maxWidth: '100%'
                    }
                    }
                    noValidate
                    autoComplete="off"
                >
                    <TextField required id="outlined-required" label="E-mail"  name="participantsEmail" variant="outlined" fullWidth onChange={handleChange}/>
                </Box>
            </Grid>
            <Grid item md={6}>
                <Box
                    component="form"
                    sx={{
                        m: 1, width: '100%', maxWidth: '100%'
                    }
                    }

                >
                    <TextField required id="outlined-basic" label="Phone"  name="participantsPhone" variant="outlined" fullWidth onChange={handleChange}/>
                </Box></Grid>
            </Grid>
]);
    }

    const removeClick = (i) => {
        let fields = [...textFields];
        fields.splice(i, 1);
        this.setState({ fields });
      }
    return (

        <Grid container spacing={2}>
            <Grid item md={12}>
                <Box
                    component="form"
                    sx={{
                        m: 1, style: { textAlign: 'center' }
                    }
                    }
                    noValidate
                    autoComplete="off"
                >
                    <TextField required id="outlined-required" label="Name" name="participantsName" variant="outlined" fullWidth onChange={handleChange}/>
                </Box>
            </Grid>

            <Grid item md={6}>
                <Box
                    component="form"
                    sx={{
                        m: 1, width: '100%', maxWidth: '100%'
                    }
                    }
                    noValidate
                    autoComplete="off"
                >
                    <TextField required id="outlined-required" label="E-mail"  name="participantsEmail" variant="outlined" fullWidth onChange={handleChange}/>
                </Box>
            </Grid>
            <Grid item md={6}>
                <Box
                    component="form"
                    sx={{
                        m: 1, width: '100%', maxWidth: '100%'
                    }
                    }

                >
                    <TextField required id="outlined-basic" label="Phone"  name="participantsPhone" variant="outlined" fullWidth onChange={handleChange}/>
                </Box></Grid>
                <Grid item md={6}>
                <Box
                    component="form"
                    sx={{
                        m: 1, width: '100%', maxWidth: '100%'
                    }}
                >
                {textFields}
                <Button variant="contained" onClick={handleAddText}>Add Participant</Button>
                
                </Box>
            </Grid>

        </Grid>)
}

export default Participants;