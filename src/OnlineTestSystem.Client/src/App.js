import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import { Account } from "./components/Account/Account";
import { PrivateRoute } from "./components/general/PrivateRoute";

function App() {
  return (
    <Router>
      <Switch>
        <Route path="/account">
          <Account />
        </Route>
        <PrivateRoute>
          Not Found!
        </PrivateRoute>
      </Switch>
    </Router>
  );
}

export default App;
