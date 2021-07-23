import { USER_LOGIN, USER_LOGIN_ERROR, USER_LOGOUT } from "./actionTypes";

const initialState = {
  user: null,
  error: null,
}

export function userReducer(state = initialState, action) {
  switch (action.type) {
    case USER_LOGIN:
      return {
        user: action.payload,
        error: null
      };
    case USER_LOGOUT:
      return {
        user: null,
        error: null
      };
    case USER_LOGIN_ERROR:
      return {
        user: null,
        error: action.payload
      }
    default:
      return state;
  }
}