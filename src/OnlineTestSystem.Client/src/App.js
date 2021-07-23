import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import { Account } from "./components/Account/Account";
import { AssignedTests } from "./components/AssignedTests/AssignedTests";
import { PrivateRoute } from "./components/general/PrivateRoute";
import { Layout } from "./components/Layout/Layout";

function App() {
  return (
    <Router>
      <Switch>
        <Route path="/account">
          <Account />
        </Route>
        <PrivateRoute>
          <Layout>
            <Switch>
              <Route path="/">
                <AssignedTests />
              </Route>
              <Route>
                Not found
              </Route>
            </Switch>
          </Layout>
        </PrivateRoute>
      </Switch>
    </Router>
  );
}

export default App;
