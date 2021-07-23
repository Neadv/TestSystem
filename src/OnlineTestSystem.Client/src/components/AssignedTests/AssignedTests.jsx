import { Route, Switch } from "react-router-dom";
import { Category } from "./Category";
import { CategoryList } from "./CategoryList";

export const AssignedTests = () => {
    return (
        <Switch>
            <Route exact path="/">
                <CategoryList />
            </Route>
            <Route exact path="/:category">
                <Category />
            </Route>
        </Switch>
    );
}