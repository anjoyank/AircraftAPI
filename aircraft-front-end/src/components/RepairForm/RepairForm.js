import React, {useState} from 'react';
import classes from './RepairForm.module.css';
import Input from '../UI/Input';

const RepairForm = (props) => {
    const [] = useState('');
    const [] = useState('');
    const [] = useState('');
    const [] = useState('');
    const [] = useState('');
    const [] = useState('');

    return (
        <form className={classes.form}>
          <Input
            label="Amount"
            input={{
              id: "amount",
              type: "number",
              min: "1",
              max: "5",
              step: "1",
              defaultValue: "1",
            }}
          />
          <button>+ Add</button>
        </form>
      );
}

export default RepairForm;