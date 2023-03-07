
export const TodoItem = (props) => {
    let rowClasses = 'todo';

    if (props.isCompleted) {
        rowClasses += ' is-completed';
    }

    return (
        <tr className={rowClasses}>
            <td>{props.text}</td>
            <td>{props.isCompleted ? 'Complete' : 'Incomplete'}</td>
            <td className="todo-action">
                {props.isCompleted 
                ? <button onClick={() => props.deleteTodo(props)} className="btn todo-btn">Delete</button> 
                : <button onClick={() => props.updateTodo(props)} className="btn todo-btn">Change status</button>}
            </td>
        </tr>
    )
}