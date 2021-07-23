import { userActionTypes } from "./actionTypes";

const initialState = {
  user: null,
  error: null,
}

export function userReducer(state = initialState, action) {
  switch (action.type) {
    case userActionTypes.USER_LOGIN:
      return {
        user: action.payload,
        error: null
      };
    case userActionTypes.USER_LOGOUT:
      return {
        user: null,
        error: null
      };
    case userActionTypes.USER_LOGIN_ERROR:
      return {
        user: null,
        error: action.payload
      }
    default:
      return state;
  }
}