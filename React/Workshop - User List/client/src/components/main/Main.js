import * as userService from '../../services/userService';
import { actions } from '../user-list/ActionConstants';

import { useState, useEffect } from 'react';

import { Search } from '../search/Search';
import { UserList } from '../user-list/UserList';

export const Main = () => {
    const [users, setUsers] = useState([]);

    useEffect(() => {
        userService.getAll()
            .then(users => setUsers(users))
    }, [])

    const onSubmit = (e, closePopup, user) => {
        e.preventDefault();

        const formData = new FormData(e.target);
        const {firstName, lastName, email, imageUrl, phoneNumber, ...address} = Object.fromEntries(formData);

        const body = {firstName, lastName, email, imageUrl, phoneNumber, address};

        if (e.nativeEvent.submitter.textContent == actions.Edit) {

            userService.edit(user._id, body)
            .then(u => {
                let index = users.findIndex(x => x._id == u._id);
                users[index] = u;
                closePopup();
            })
        } else {
            userService.create(body)
            .then(u => {
                setUsers(oldUsers => [...oldUsers, u]);
                closePopup();
            })
        }
    }

    const deleteUser = (userId, closePopup) => {
        userService.del(userId)
        .then(u => {
            setUsers(u => u.filter(x => x._id !== userId));
            closePopup();
        });
    }

    return (
        <main className="main">
            <section className="card users-container">
                <Search />

                <UserList users={users} onSubmit={onSubmit} deleteUser={deleteUser}/>
            </section>
        </main>
    )
}