import { useContext, useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom"
import { GameComment } from "./game-comment/GameComment";

import * as gameService from '../../services/gameService'
import { AuthContext } from "../../contexts/AuthContext";
import { GameContext } from "../../contexts/GameContext";

export const Details = () => {
    const navigate = useNavigate();
    const { user } = useContext(AuthContext);
    const { onDeleteGame } = useContext(GameContext);

    const { gameId } = useParams();

    const [game, setGame] = useState({});
    const [gameComments, setGameComments] = useState([]);

    const [comment, setComment] = useState({
        comment: ''
    });
    const [error, setError] = useState({
        comment: ''
    });

    useEffect(() => {
        gameService.GetById(gameId)
            .then(game => setGame(game))
            .catch(() => {
                navigate('/');
            })

        gameService.GetGameComments(gameId)
            .then(com => setGameComments(com))
            .catch(() => { navigate('/') })
    }, [])

    const onChange = (e) => {
        setComment(state => ({
            ...state,
            [e.target.name]: e.target.value
        }))
    }

    const validate = (e) => {
        let value = e.target.value;

        if (value.length < 3 || value.length > 20) {
            setError(state => ({
                ...state,
                [e.target.name]: `${e.target.name} must be between 3 and 20 characters`
            }))
        } else {
            setError(state => ({
                ...state,
                [e.target.name]: ''
            }))
        }
    }

    const createCommentHandler = (e) => {
        e.preventDefault();

        gameService.CreateComment({ gameId: game._id, comment: comment.comment })
            .then(com => setGameComments(state => [...state, com]))
            .catch(() => {
                navigate('/');
            })

        setComment({ comment: '' })
    }

    const deleteGameHandler = (e) => {
        const confirm = window.confirm('Are you sure you want to delete thi game man !')

        if (confirm) {
            gameService.removeGame(gameId)
                .then(() => {
                    onDeleteGame(gameId);
                    navigate('/catalog');
                })
                .catch(() => {
                    navigate('/');
                })
        }
    }

    return (
        <section id="game-details">
            <h1>Game Details</h1>
            <div className="info-section">
                <div className="game-header">
                    <img className="game-img" src={game.imageUrl} alt="game" />
                    <h1>{game.title}</h1>
                    <span className="levels">MaxLevel: {game.maxLevel}</span>
                    <p className="type">{game.category}</p>
                </div>
                <p className="text">{game.summary}</p>

                <div className="details-comments">
                    <h2>Comments:</h2>

                    {gameComments.length > 0
                        ? <ul>
                            {gameComments.map(x => <GameComment key={x._id} comment={x} />)}
                        </ul>
                        : <p className="no-comment">No comments.</p>
                    }

                </div>

                {user._id == game._ownerId &&
                    <div className="buttons">
                        <Link to={`/edit/${gameId}`} className="button">
                            Edit
                        </Link>
                        <button onClick={deleteGameHandler} className="button">
                            Delete
                        </button>
                    </div>
                }

            </div>
            {/* Bonus */}
            {/* Add Comment ( Only for logged-in users, which is not creators of the current game ) */}
            <article className="create-comment">
                <label>Add new comment:</label>
                <form className="form" onSubmit={createCommentHandler}>
                    <textarea
                        name="comment"
                        placeholder="Comment......"
                        value={comment.comment}
                        onBlur={validate}
                        onChange={onChange}
                    />

                    {error.comment && <div style={{ color: 'orange' }}>{error.comment}</div>}

                    <input
                        className="btn submit"
                        type="submit"
                        value="Add Comment"
                        disabled={error.comment}
                    />
                </form>
            </article>
        </section>
    )
}