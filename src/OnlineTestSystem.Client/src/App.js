import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import { Account } from "./components/Account/Account";

function App() {
  return (
    <Router>
      <Switch>
        <Route path="/account">
          <Account />
        </Route>
        <Route>
          Not Found!
        </Route>
      </Switch>
    </Router>
  );
}

export default App;
