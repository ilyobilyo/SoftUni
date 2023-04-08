import { useContext } from "react"
import { GameContext } from "../../contexts/GameContext"
import { HomeGameItem } from "./home-game-item/HomeGameItem"

export const Home = () => {
    const { lastThreeGames } = useContext(GameContext)

    return (
        <section id="welcome-world">
            <div className="welcome-message">
                <h2>ALL new games are</h2>
                <h3>Only in GamesPlay</h3>
            </div>
            <img src="./images/four_slider_img01.png" alt="hero" />
            <div id="home-page">
                <h1>Latest Games</h1>

                {lastThreeGames.length > 0
                ? lastThreeGames.map(x => <HomeGameItem key={x._id} game={x}/>)
                : <p className="no-articles">No games yet</p>
                }

            </div>
        </section>
    )
}