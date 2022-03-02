import React, {useState} from 'react';
import { Box, Grid, Input, TextField } from '@mui/material';
import { useDispatch, useSelector } from "react-redux";

const Company = (props) => {

    const handleChange = (e) => {
        const name = e.target.value;
        if(props.onChange !== undefined){
            props.onChange(e)
        }

    }

    return (
        <Grid container spacing={2}>
            <Grid item md={12}>
                <Box
                    component="form"
                    sx={{
                      m: 1, width:'100%'
                    }
                    }
                    noValidate
                    autoComplete="off"
                >
                    <TextField required id="outlined-required" label="Name" name="name" variant="outlined" fullWidth  onChange={handleChange}/>
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
                    <TextField required id="outlined-basic" label="Phone"  name="phone" variant="outlined" fullWidth onChange={handleChange} />
                </Box>

            </Grid>



        </Grid>)
}

export default Company;