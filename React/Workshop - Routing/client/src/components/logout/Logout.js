import { useContext, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { AuthContext } from "../../contexts/AuthContext";

import * as authService from '../../services/authService';

export const Logout = () => {
    const { onLogout } = useContext(AuthContext);
    const navigate = useNavigate();

    useEffect(() => {
        authService.logout()
        .then(() => {
            onLogout();
            navigate('/');
        })
        .catch(() => {
            navigate('/')
        })
    }, [])

    return null;
}