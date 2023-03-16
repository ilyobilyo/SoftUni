import { useContext, useState } from "react"
import { Link, useNavigate } from "react-router-dom"
import { AuthContext } from "../../contexts/AuthContext"

import * as authService from '../../services/authService'

export const Register = () => {
    const navigate = useNavigate();
    const { onLogin } = useContext(AuthContext)
    const [error, setError] = useState({
        email: '',
        password: '',
        confirmPass: ''
    });
    const [formData, setFormData] = useState({
        email: '',
        password: '',
        confirmPassword: ''
    });

    const onSubmit = (e) => {
        e.preventDefault();
        authService.register(formData.email, formData.password)
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

    const validatePassword = () => {
        if (formData.password !== formData.confirmPassword) {
            setError(state => ({
                ...state,
                confirmPass: 'Password and confirm password dont match'
            }))
        } else {
            setError(state => ({
                ...state,
                confirmPass: ''
            }))
        }

        if (formData.password.length < 4) {
            setError(state => ({
                ...state,
                password: 'Password must be at least 4 characters long'
            }))
        } else {
            setError(state => ({
                ...state,
                password: ''
            }))
        }
    }

    const validateEmail = () => {
        if (formData.email.length === 0) {
            setError(state => ({
                ...state,
                email: 'Email is required'
            }))
        } else {
            setError(state => ({
                ...state,
                email: ''
            }))
        }
    }

    return (
        <section id="register-page" className="content auth">
            <form id="register" onSubmit={onSubmit}>
                <div className="container">
                    <div className="brand-logo" />
                    <h1>Register</h1>
                    <label htmlFor="email">Email:</label>
                    <input
                        type="email"
                        id="email"
                        name="email"
                        placeholder="maria@email.com"
                        onChange={onChange}
                        onBlur={validateEmail}
                    />

                    {error.email && <p style={{color: 'red'}}>{error.email}</p>}

                    <label htmlFor="pass">Password:</label>
                    <input type="password" name="password" id="register-password" onChange={onChange} onBlur={validatePassword} />

                    {error.password && <p style={{color: 'red'}}>{error.password}</p>}

                    <label htmlFor="con-pass">Confirm Password:</label>
                    <input type="password" name="confirmPassword" id="confirm-password" onChange={onChange} onBlur={validatePassword} />

                    {error.confirmPass && <p style={{color: 'red'}}>{error.confirmPass}</p>}

                    <input className="btn submit" type="submit" defaultValue="Register" disabled={error.confirmPass || error.email || error.password} />
                    <p className="field">
                        <span>
                            If you already have profile click <Link to="/login">here</Link>
                        </span>
                    </p>
                </div>
            </form>
        </section>
    )
}