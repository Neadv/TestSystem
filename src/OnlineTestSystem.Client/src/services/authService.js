import { setAuthorizationHeader } from "../api/api";
import { getUserFromToken, removeToken, saveToken } from "./tokenService";

export function authorize(token) {
    saveToken(token);
    setAuthorizationHeader(token);
}

export function logout(){
    setAuthorizationHeader('');
    removeToken();
}