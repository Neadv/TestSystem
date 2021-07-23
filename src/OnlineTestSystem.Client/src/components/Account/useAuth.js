import { useDispatch, useSelector } from "react-redux";
import * as userAction from "../../data/userAction";
import { getToken } from "../../services/tokenService";
import * as authService from '../../services/authService';

export function useAuth() {
    const userState = useSelector(state => state.user);
    const dispatch = useDispatch();

    let user = userState.user
    if (!user) {
        const token = getToken();
        if (token) {
            user = authService.authorize(token);
            if (user)
                dispatch(userAction.userLogin(user));
        }
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
        user: user,
        error: userState.error
    }
}