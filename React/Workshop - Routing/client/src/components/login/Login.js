import { useContext, useState } from "react"
import { Link, useNavigate } from "react-router-dom"
import { validateEmail, validatePssword } from "../../utils/validator";

import { AuthContext } from "../../contexts/AuthContext"

import * as authService from '../../services/authService'

export const Login = () => {
    const { onLogin } = useContext(AuthContext);
    const navigate = useNavigate();

    const [formData, setFormData] = useState({
        email: '',
        password: ''
    });
    const [errors, setErrors] = useState({
        email: '',
        password: ''
    });

    const onSubmit = (e) => {
        e.preventDefault();

        authService.login(formData.email, formData.password)
            .then(user => {
                onLogin(user);
                navigate('/');
            })
            .catch(() => {
                navigate('/')
            })
    }

    const onChange = (e) => {
        setFormData(state => ({
            ...state,
            [e.target.name]: e.target.value
        }))
    }

    const validatePasswordHandler = () => {
        setErrors(state => ({
            ...state,
            password: validatePssword(formData.password)
        }))
    }

    const validateEmailHandler = () => {
        setErrors(state => ({
            ...state,
            email: validateEmail(formData.email)
        }))
    }

    return (
        <section id="login-page" className="auth">
            <form id="login" onSubmit={onSubmit}>
                <div className="container">
                    <div className="brand-logo" />
                    <h1>Login</h1>
                    <label htmlFor="email">Email:</label>
                    <input
                        type="email"
                        id="email"
                        name="email"
                        placeholder="Sokka@gmail.com"
                        onChange={onChange}
                        onBlur={validateEmailHandler}
                    />

                    {errors.email && <p style={{ color: 'red' }}>{errors.email}</p>}

                    <label htmlFor="login-pass">Password:</label>
                    <input type="password" id="login-password" name="password" onChange={onChange} onBlur={validatePasswordHandler} />

                    {errors.password && <p style={{ color: 'red' }}>{errors.password}</p>}

                    <input type="submit" className="btn submit" value="Login" disabled={errors.email || errors.password}/>
                    <p className="field">
                        <span>
                            If you don't have profile click <Link to="/register">here</Link>
                        </span>
                    </p>
                </div>
            </form>
        </section>
    )
}