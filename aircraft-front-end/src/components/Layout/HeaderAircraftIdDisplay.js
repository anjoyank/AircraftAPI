import classes from './HeaderAircraftIdDisplay.module.css';
import AircraftIdIcon from '../../assets/AircraftIdIcon';

const HeaderAircraftIdDisplay = props => {
    return (
        <button className={classes.button}>
          <span className={classes.icon}>
            <AircraftIdIcon />
          </span>
          <span>Your Cart</span>
          <span className={classes.badge}>3</span>
        </button>
      );
};

export default HeaderAircraftIdDisplay;