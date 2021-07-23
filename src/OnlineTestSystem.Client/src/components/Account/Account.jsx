import { Redirect, Route, Switch } from "react-router-dom";
import { Login } from "./Login";
import './Account.css';
import { useAuth } from "./useAuth";
import { Logout } from "./Logout";

export const Account = () => {
  const auth = useAuth();

  return (
    <div className="account-wrapper">
      <Switch>
        <Route exact path="/account/login">
          <Login login={auth.login} error={auth.error}/>
        </Route>
        <Route exact path="/account/logout">
          <Logout logout={auth.logout}/>
        </Route>
        <Route>
          <Redirect to="/account/login" />
        </Route>
      </Switch>
    </div>
  );
}