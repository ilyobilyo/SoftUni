import { createContext, useEffect, useState } from "react";
import * as gameService from '../services/gameService'

export const GameContext = createContext();

export const GameProvider = ({ children }) => {
    const [games, setGames] = useState([]);
    const [lastThreeGames, setLastThreeGames] = useState([]);
    
    useEffect(() => {
        gameService.GetAll()
            .then(games => {
                console.log(games);
                setGames(games);
            });
    }, []);

    useEffect(() => {
        gameService.GetLastThreeAddedGames()
        .then(lastThree => {
            setLastThreeGames(lastThree)
        })
    }, [games.length])

   
    const onCreateGame = (game) => {
        setGames(state => [
            ...state,
            game
        ])
    }

    const onEditGame = (game) => {
        setGames(state => [
            state.map(x => x._id == game._id ? game : x)
        ]) 
    }

    const onDeleteGame = (gameId) => {
        setGames(state => 
            state.filter(x => x._id !== gameId)
        )
    }

    return (
        <GameContext.Provider value={{games, onCreateGame, onEditGame, onDeleteGame, lastThreeGames}}>
            {children}
        </GameContext.Provider>
    )
}