import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import { Account } from "./components/Account/Account";
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
              <Route path="/test">
                <h1>Test</h1>
              </Route>
              <Route path="/test2">
                <h2>Test2</h2>
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
