import { Box, Button, Grid, TextField, touchRippleClasses } from "@mui/material";
import { createImmutableStateInvariantMiddleware } from "@reduxjs/toolkit";
import React,{useState} from "react";

const Participants = (props) => {
    
    const handleChange = (e) => {
        //console.log(e.target.value);
        const name = e.target.value;
        if(props.onChange(props.id, e) !== undefined){
            props.onChange(props.id, e)
        }

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
                    <TextField required id="outlined-required" label="Name" name="name" variant="outlined" fullWidth onChange={handleChange}/>
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
                    <TextField required id="outlined-required" label="E-mail"  name="email" variant="outlined" fullWidth onChange={handleChange}/>
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
                    <TextField required id="outlined-basic" label="Phone"  name="phone" variant="outlined" fullWidth onChange={handleChange}/>
                </Box></Grid>
                <Grid item md={6}>
                <Box
                    component="form"
                    sx={{
                        m: 1, width: '100%', maxWidth: '100%'
                    }}
                >
                
                </Box>
            </Grid>

        </Grid>)
}

export default Participants;