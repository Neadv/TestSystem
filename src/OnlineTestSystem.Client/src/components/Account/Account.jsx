import { Redirect, Route, Switch } from "react-router-dom";
import { Login } from "./Login";
import './Account.css';

export const Account = () => {
  return (
    <div className="account-wrapper">
      <Switch>
        <Route exact path="/account/login">
          <Login />
        </Route>
        <Route exact path="/account/logout">
          <h1>Logout</h1>
        </Route>
        <Route>
          <Redirect to="/account/login" />
        </Route>
      </Switch>
    </div>
  );
}