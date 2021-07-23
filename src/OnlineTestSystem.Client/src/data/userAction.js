import * as accountApi from "../api/accountApi";
import * as authService from "../services/authService";
import { userActionTypes } from "./actionTypes"

function userLogin(user) {
  return { type: userActionTypes.USER_LOGIN, payload: user };
}

function userLogout() {
  return { type: userActionTypes.USER_LOGOUT };
}

function userLoginError(error) {
  return { type: userActionTypes.USER_LOGIN_ERROR, payload: error };
}

function userLoginApi(username, password) {
  return dispatch => {
    accountApi.login(username, password)
      .then(res => {
        if (res.data?.token){
          const user = authService.authorize(res.data.token)
          dispatch(userLogin(user));          
        }
      })
      .catch(err => {
        if (err.response?.data?.error){
          dispatch(userLoginError(err.response.data.error));
        }
      })
  }
}

export {
  userLogin,
  userLogout,
  userLoginError,
  userLoginApi
};