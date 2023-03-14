import { useState } from "react";
import { useParams } from "react-router-dom"
import { GameComment } from "./game-comment/GameComment";


export const Details = ({ games, addComment }) => {
    const { gameId } = useParams();
    const [comment, setComment] = useState({
        username: '',
        comment: ''
    });
    const [error, setError] = useState({
        username: '',
        comment: ''
    });

    const game = games.find(x => x._id == gameId);

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

        const result = `${comment.username}: ${comment.comment}`;
        
        addComment(gameId, result);
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

                    {game.comments?.length > 0
                        ? <ul>
                            {game.comments.map(x => <GameComment key={game + 's' + x} comment={x} />)}
                        </ul>
                        : <p className="no-comment">No comments.</p>
                    }

                </div>

                <div className="buttons">
                    <a href="#" className="button">
                        Edit
                    </a>
                    <a href="#" className="button">
                        Delete
                    </a>
                </div>
            </div>
            {/* Bonus */}
            {/* Add Comment ( Only for logged-in users, which is not creators of the current game ) */}
            <article className="create-comment">
                <label>Add new comment:</label>
                <form className="form" onSubmit={createCommentHandler}>
                    <input
                        name="username"
                        type="text"
                        value={comment.username}
                        onBlur={validate}
                        onChange={onChange}
                    />

                    {error.username && <div style={{ color: 'orange' }}>{error.username}</div>}

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
                        disabled={error.comment || error.username}
                    />
                </form>
            </article>
        </section>
    )
}