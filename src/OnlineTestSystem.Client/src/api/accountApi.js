import { api } from "./api";

export function login(username, password){
    return api.post('/account/token', {
        username: username,
        password: password
    });
}