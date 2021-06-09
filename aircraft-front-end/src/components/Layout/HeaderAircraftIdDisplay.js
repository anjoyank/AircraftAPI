import classes from './HeaderAircraftIdDisplay.module.css';
import AircraftIdIcon from '../../assets/AircraftIdIcon';

const HeaderAircraftIdDisplay = props => {
    return (
        <button className={classes.button}>
          <span className={classes.icon}>
            <AircraftIdIcon />
          </span>
          <span>Show Entered Repairs For:</span>
          <span className={classes.badge}>AIRCRAFTID #</span>
        </button>
      );
};

export default HeaderAircraftIdDisplay;