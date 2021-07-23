import * as accountApi from "../api/accountApi";
import { getUserFromToken } from "../services/tokenService";
import { USER_LOGIN, USER_LOGIN_ERROR, USER_LOGOUT } from "./actionTypes"

function userLogin(user) {
  return { type: USER_LOGIN, payload: user };
}

function userLogout() {
  return { type: USER_LOGOUT };
}

function userLoginError(error) {
  return { type: USER_LOGIN_ERROR, payload: error };
}

function userLoginApi(username, password) {
  return dispatch => {
    accountApi.login(username, password)
      .then(res => {
        if (res.data?.token){
          const user = getUserFromToken(res.data.token);
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