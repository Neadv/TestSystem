import { applyMiddleware, combineReducers, createStore } from "redux";
import thunk from "redux-thunk";
import { testsReducer } from "./testReducer";
import { userReducer } from "./userReducer";

const rootReducer = combineReducers({
  user: userReducer,
  tests: testsReducer
});

export const store = createStore(rootReducer, applyMiddleware(thunk));