import { setAuthorizationHeader } from "../api/api";
import { getUserFromToken, removeToken, saveToken } from "./tokenService";

export function authorize(token) {
    saveToken(token);
    setAuthorizationHeader(token);

    const user = getUserFromToken(token);
    return user;
}

export function logout(){
    setAuthorizationHeader('');
    removeToken();
}