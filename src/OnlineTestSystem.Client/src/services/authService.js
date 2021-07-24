import { api, setAuthorizationHeader } from "../api/api";
import { getUserFromToken, removeToken, saveToken } from "./tokenService";

let interceptor;

export function authorize(token) {
    saveToken(token);
    setAuthorizationHeader(token);

    setLogoutInterceptor(token);

    const user = getUserFromToken(token);
    return user;
}

export function logout(){
    setAuthorizationHeader('');
    removeToken();
    
    if (interceptor){
        api.interceptors.response.eject(interceptor);
        interceptor = null;
    }
}

function setLogoutInterceptor(token) {
    interceptor = api.interceptors.response.use(res => res, error => {
        if (error.response?.status !== 401 || !token) {
            return Promise.reject(error);
        }

        if (error.response?.status === 401 || error.response?.status === 403) {
            window.location.href = "/account/logout";
        }
    });
}