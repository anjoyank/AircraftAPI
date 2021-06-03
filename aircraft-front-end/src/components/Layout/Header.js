import { Fragment } from "react";

import sketchbookImage from '../../assets/aircraftApiPlan.jpg';
import classes from './Header.module.css'
import HeaderAircraftIdDisplay from './HeaderAircraftIdDisplay';

//could make separate component for img but it is simple so we don't
const Header = props => {
    return <Fragment>
        <header className={classes.header}>
            <h1>Aircraft Repair -- Calculate Next Due</h1>
            <HeaderAircraftIdDisplay />
        </header>
        <div className={classes['main-image']}>
            <img src={sketchbookImage} alt="Mockup of App Flow"/>
        </div>
        </ Fragment>
};

export default Header;