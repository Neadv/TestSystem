import axios from "axios";

export const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL
});

export function setAuthorizationHeader(token){
    api.defaults.headers = { Authorization: `Bearer ${token}` };
}