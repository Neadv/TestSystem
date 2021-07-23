import { Redirect, Route, Switch } from "react-router-dom";
import { Login } from "./Login";
import './Account.css';
import { useAuth } from "./useAuth";

export const Account = () => {
  const auth = useAuth();
  console.log(auth.user);

  return (
    <div className="account-wrapper">
      <Switch>
        <Route exact path="/account/login">
          <Login login={auth.login} error={auth.error}/>
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