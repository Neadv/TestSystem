import { useEffect } from "react"
import { Redirect } from "react-router-dom";

export const Logout = ({ logout }) => {
    useEffect(() => {
        logout();
    }, [logout])

    return (
        <Redirect to="/account/login" />
    )
}