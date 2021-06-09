import Header from './components/Layout/Header';
import Card from './components/UI/Card';
import { Fragment } from 'react';

const App = () => {
  return (
    <Fragment>
      <Header />
      <Card>
        <input type="text" placeholder="this will let you select which task"/>
        <form>
          <h2>this will let you fill in the task details</h2>
        </form>
      </Card>
      <Card>
        <h2>this will be the returned task?</h2>
      </Card>
    </Fragment>
  );
}

export default App;
