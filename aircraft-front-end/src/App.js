import Card from "./components/UI/Card";
import { Fragment, useState } from "react";

const App = () => {
  //-----STATE MGMT FUNCS-----//

  const [repairs, setRepairs] = useState([]);
  const [tasks, setTasks] = useState([]);
  const [aircraftId, setAircraftId] = useState(0);
  const [formIsShown, setFormIsShown] = useState(false);

  //-----------------//

  //-----------------//
  let url = "";
  const setUrl = (id) => {
    url += "http://localhost:5000/aircraft/" + aircraftId + "/duelist";
  };

  //-----------------//

  //----DATA--TASK-ITEMS----//

  const DUMMY_TASKS = [
    {
      "ItemNumber": 1,
      "Description": "Item 1",
      "LogDate": "2018-04-07T00:00:00",
      "LogHours": null,
      "IntervalMonths": null,
      "IntervalHours": null,
    },
    {
      "ItemNumber": 2,
      "Description": "Item 2",
      "LogDate": "2018-04-07T00:00:00",
      "LogHours": 100,
      "IntervalMonths": 12,
      "IntervalHours": 500,
    },
    {
      "ItemNumber": 3,
      "Description": "Item 3",
      "LogDate": "2018-06-01T00:00:00",
      "LogHours": 150,
      "IntervalMonths": null,
      "IntervalHours": 400,
    },
    {
      "ItemNumber": 4,
      "Description": "Item 4",
      "LogDate": "2018-06-01T00:00:00",
      "LogHours": 150,
      "IntervalMonths": 6,
      "IntervalHours": null,
    },
  ];

  //-----------------//

  //-----------------//

  const taskHandler = () => {};
  const repairHandler = () => {};

  const getNextDue = (event) => {
    event.preventDefault();
  };

  //-----------------//

  //-----------------//

  const aircraftIdSubmitHandler = (event) => {
    event.preventDefault();
    let num = event.target.id.value;
    setAircraftId(num);
    setFormIsShown(true);
  };

  //-----------------//

  //-----------------//

  const onCancel = (event) => {
    window.location.reload();
  };

  const onSend = (event) => {
    event.preventDefault();
    postRepairs(aircraftId, DUMMY_TASKS);
  };

  //-----------------//

  

  //-----------------//

  async function postRepairs(id='', taskList=[{}]) {
    setUrl(id);
    const response = await fetch(url, {
      method: "POST",
      mode: 'cors',
      credentials: 'include',
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(taskList),
      redirect: 'follow',
    })
      .then((res) => {
        return res.json();
      })
      .then((data) => {
        const nextDueList = data.results[1].map((listData) => {
          return {
            taskId: listData.ItemNumber,
            description: listData.Description,
            nextDue: listData.NextDue,
          };
        });
        setRepairs(nextDueList);
      });
  }
  //-----MAIN-----//

  return (
    <Fragment>
      {repairs.length > 0 && <div>{repairs}</div>}
      <div>
        {/*--SELECT---AIRCRAFT--ID--FORM*/}
        <form onSubmit={aircraftIdSubmitHandler}>
          <label>
            Please Enter Aircraft Id #
            <input
              type="number"
              name="id"
              min="1"
              max="2"
              step="1"
              defaultValue="1"
            />
          </label>
          <button type="submit">Confirm Aircraft Id #</button>
        </form>
        {/*---FORM END---*/}

        {/*--CONDITIONAL TASK FORM--AIRCRAFTID MUST BE SELECTED--*/}
        {formIsShown && (
          <form onSubmit={getNextDue}>
            <label>
              <input />
            </label>
            <label>
              <input />
            </label>
            <label>
              <input />
            </label>
            <label>
              <input />
            </label>
          </form>
        )}
        {formIsShown && <button onClick={onSend}>Calculate Next Due</button>}
        {formIsShown && <button onClick={onCancel}>Cancel</button>}
      </div>
    </Fragment>
  );
};

export default App;
