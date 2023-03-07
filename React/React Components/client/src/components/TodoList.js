import { useEffect, useState } from "react"
import { Spinner } from "./Spinner";
import { TodoItem } from "./TodoItem";

const url = 'http://localhost:3030/jsonstore/todos';

export const TodoList = () => {
    const [items, setItems] = useState([]);

    useEffect(() => {
        fetch(url)
            .then(res => res.json())
            .then(result => {
                setItems(Object.values(result));
            })
    }, [])

    const todoChangeState = (todo) => {
        async function putData(id){
            const res = await fetch(`${url}/${id}`, {
                method: 'put',
                headers: {'Content-Type': 'application/json'},
                body: JSON.stringify({...todo, isCompleted: !todo.isCompleted})
            });

            const data = await res.json();

            setItems(oldTodos => oldTodos.map(x => x._id == data._id ? data : x))
        }

        putData(todo._id);
    }

    const deleteItem = (todo) => {
        async function delItem(id){
            await fetch(`${url}/${id}`, {
                method: 'delete',
            });

            setItems(oldTodos => oldTodos.filter(x => x._id !== todo._id))
        }

        delItem(todo._id);
    }

    return (
        !items.length
        ? <Spinner /> 
        : 
        <table className="table">
            <thead>
                <tr>
                    <th className="table-header-task">Task</th>
                    <th className="table-header-status">Status</th>
                    <th className="table-header-action">Action</th>
                </tr>
            </thead>
            <tbody>
                {items.map(x => <TodoItem key={x._id} {...x} updateTodo={todoChangeState} deleteTodo={deleteItem}/>)}
            </tbody>
        </table>
    )
}