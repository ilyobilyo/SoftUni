import { useContext, useState } from "react"
import { useNavigate } from "react-router-dom";
import { GameContext } from "../../contexts/GameContext";

import { validateGameField, validateGameMaxLevel } from "../../utils/validator";

import * as gameService from '../../services/gameService'

export const CreateGame = () => {
    const { onCreateGame } = useContext(GameContext);
    const navigate = useNavigate();

    const [formData, setFormData] = useState({
        title: '',
        category: '',
        maxLevel: '',
        imageUrl: '',
        summary: '',
    });
    const [errors, setErrors] = useState({
        title: '',
        category: '',
        maxLevel: '',
        imageUrl: '',
        summary: '',
    })

    const onSubmit = (e) => {
        e.preventDefault();

        gameService.CreateGame(formData)
        .then(game => {
            onCreateGame(game);
            navigate('/catalog')
        })
        .catch(() => {
            navigate('/');
        })
    }

    const onChange = (e) => {
        setFormData(state => ({
            ...state,
            [e.target.name]: e.target.value
        }))
    }

    const validateFieldsHandler = (e) => {
        setErrors(state => ({
            ...state,
            [e.target.name]: validateGameField(e.target.name, formData[e.target.name])
        }))
    }

    const validateMinLevelHandler = () => {
        setErrors(state => ({
            ...state,
            maxLevel: validateGameMaxLevel(Number(formData.maxLevel))
        }))
    }

    return (
        <section id="create-page" className="auth">
            <form id="create" onSubmit={onSubmit}>
                <div className="container">
                    <h1>Create Game</h1>
                    <label htmlFor="leg-title">Legendary title:</label>
                    <input
                        type="text"
                        id="title"
                        name="title"
                        placeholder="Enter game title..."
                        onChange={onChange}
                        onBlur={validateFieldsHandler}
                    />

                    {errors.title && <p style={{ color: 'red' }}>{errors.title}</p>}

                    <label htmlFor="category">Category:</label>
                    <input
                        type="text"
                        id="category"
                        name="category"
                        placeholder="Enter game category..."
                        onChange={onChange}
                        onBlur={validateFieldsHandler}
                    />

                    {errors.category && <p style={{ color: 'red' }}>{errors.category}</p>}

                    <label htmlFor="levels">MaxLevel:</label>
                    <input
                        type="number"
                        id="maxLevel"
                        name="maxLevel"
                        min={1}
                        placeholder={1}
                        onChange={onChange}
                        onBlur={validateMinLevelHandler}
                    />

                    {errors.maxLevel && <p style={{ color: 'red' }}>{errors.maxLevel}</p>}

                    <label htmlFor="game-img">Image:</label>
                    <input
                        type="text"
                        id="imageUrl"
                        name="imageUrl"
                        placeholder="Upload a photo..."
                        onChange={onChange}
                        onBlur={validateFieldsHandler}
                    />

                    {errors.imageUrl && <p style={{ color: 'red' }}>{errors.imageUrl}</p>}

                    <label htmlFor="summary">Summary:</label>
                    <textarea name="summary" id="summary" onChange={onChange} onBlur={validateFieldsHandler}/>

                    {errors.summary && <p style={{ color: 'red' }}>{errors.summary}</p>}

                    <input
                        className="btn submit"
                        type="submit"
                        value="Create Game"
                        disabled={errors.title || errors.category || errors.maxLevel || errors.imageUrl || errors.summary}
                    />
                </div>
            </form>
        </section>
    )
}