import { Redirect, Route } from "react-router-dom";
import { useAuth } from "../Account/useAuth";

export const PrivateRoute = ({ children, ...rest }) => {
  const auth = useAuth();
  return (
    <Route {...rest}>
      {auth.user ? children : <Redirect to="/account/login" />}
    </Route>
  );
}