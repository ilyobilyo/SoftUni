import { Route, Routes } from 'react-router-dom';
import { useEffect, useState } from 'react';
import './App.css';

import * as gameService from './services/gameService'

import { Header } from './components/header/Header';
import { Home } from './components/home/Home';
import { Login } from './components/login/Login';
import { Register } from './components/register/Register';
import { CreateGame } from './components/create-game/CreateGame';
import { Catalog } from './components/catalog/Catalog';
import { Details } from './components/details/Details';

import { AuthContext } from './contexts/AuthContext';
import { useLocalStorage } from './hooks/useLocalStorage';

function App() {
    const [games, setGames] = useState([]);
    const [user, setUser] = useLocalStorage('auth', {});

    const onLogin = (user) =>{
        setUser(user)
    }

    useEffect(() => {
        gameService.GetAll()
            .then(games => {
                console.log(games);
                setGames(games);
            });
    }, []);

    const addComment = (gameId, comment) => {
        setGames(state => {
            const game = games.find(x => x._id == gameId);

            const comments = game.comments || [];
            comments.push(comment);

            return [
                ...state.filter(x => x._id !== gameId),
                { ...game, comments }
            ]
        })
    }

    return (
        <AuthContext.Provider value={{user, onLogin}}>
            <div className="App">
                <Header />
                <main id="main-content">
                    <Routes>
                        <Route path='/' element={<Home games={games} />} />
                        <Route path='/register' element={<Register />} />
                        <Route path='/login' element={<Login />} />
                        <Route path='/create' element={<CreateGame />} />
                        <Route path='/catalog' element={<Catalog games={games} />} />
                        <Route path='/details/:gameId' element={<Details games={games} addComment={addComment} />} />
                    </Routes>
                </main>
            </div>
        </AuthContext.Provider>
    );
}

export default App;
