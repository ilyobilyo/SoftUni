import { Route, Routes } from 'react-router-dom';
import './App.css';

import { Header } from './components/header/Header';
import { Home } from './components/home/Home';
import { Login } from './components/login/Login';
import { Register } from './components/register/Register';
import { CreateGame } from './components/create-game/CreateGame';
import { Catalog } from './components/catalog/Catalog';
import { Details } from './components/details/Details';

import { AuthProvider } from './contexts/AuthContext';
import { Logout } from './components/logout/Logout';
import { GameProvider } from './contexts/GameContext';
import { EditGame } from './components/edit-game/EditGame';

function App() {
    return (
        <AuthProvider>
            <div className="App">
                <Header />
                <GameProvider>
                    <main id="main-content">
                        <Routes>
                            <Route path='/' element={<Home />} />
                            <Route path='/register' element={<Register />} />
                            <Route path='/login' element={<Login />} />
                            <Route path='/logout' element={<Logout />} />
                            <Route path='/create' element={<CreateGame />} />
                            <Route path='/catalog' element={<Catalog />} />
                            <Route path='/details/:gameId' element={<Details />} />
                            <Route path='/edit/:gameId' element={<EditGame />} />
                        </Routes>
                    </main>
                </GameProvider>
            </div>
        </AuthProvider>
    );
}

export default App;
