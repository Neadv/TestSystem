import { api } from "./api";

function login(username, password){
    return api.post('/account/token', {
        username: username,
        password: password
    });
}

export {
    login
};