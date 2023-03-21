import { useContext, useState } from "react"
import { Link, useNavigate } from "react-router-dom"
import { AuthContext } from "../../contexts/AuthContext"

import * as authService from '../../services/authService'
import { validateConfirmPssword, validateEmail, validatePssword } from "../../utils/validator"

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

    const validateConfirmPasswordHandler = () => {
        setError(state => ({
            ...state,
            confirmPass: validateConfirmPssword(formData.password, formData.confirmPassword)
        }))
    }

    const validatePasswordHandler = () => {
        setError(state => ({
            ...state,
            password: validatePssword(formData.password)
        }))
    }

    const validateEmailHandler = () => {
        setError(state => ({
            ...state,
            email: validateEmail(formData.email)
        }))
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
                        onBlur={validateEmailHandler}
                    />

                    {error.email && <p style={{ color: 'red' }}>{error.email}</p>}

                    <label htmlFor="pass">Password:</label>
                    <input type="password" name="password" id="register-password" onChange={onChange} onBlur={validatePasswordHandler} />

                    {error.password && <p style={{ color: 'red' }}>{error.password}</p>}

                    <label htmlFor="con-pass">Confirm Password:</label>
                    <input type="password" name="confirmPassword" id="confirm-password" onChange={onChange} onBlur={validateConfirmPasswordHandler} />

                    {error.confirmPass && <p style={{ color: 'red' }}>{error.confirmPass}</p>}

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