import { useDispatch, useSelector } from "react-redux";
import * as userAction from "../../data/userAction";
import { getToken, getUserFromToken } from "../../services/tokenService";
import * as authService from '../../services/authService';

export function useAuth(){
    const userState = useSelector(state => state.user);
    const dispatch = useDispatch();

    if (!userState.user){
        const token = getToken();
        authService.authorize(token);
        const user = getUserFromToken(token);
        dispatch(userAction.userLogin(user));
    }

    const login = (username, password) => {
        dispatch(userAction.userLoginApi(username, password));
    }
    const logout = () => {
        authService.logout();
        dispatch(userAction.userLogout());
    }

    return {
        login,
        logout,
        user: userState.user,
        error: userState.error
    }
}