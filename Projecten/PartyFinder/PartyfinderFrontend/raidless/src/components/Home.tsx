import Logo from "../assets/raidless.png";

const Home = () => {
    return (
        <div className="flex justify-center items-center ">
            <div className="shadow-lg rounded-lg p-8 max-w-lg w-full text-center bg-opacity-90 border border-black">
                <img
                    src={Logo}
                    alt="Raidless Logo"
                    className="mx-auto mb-6 w-32 h-32 rounded-full border-2 border-gray-300"
                />
                <h1 className="text-2xl font-bold mb-2 text-amber-300 drop-shadow">Stop Soloing. Start Bossing.</h1>
                <p className="text-amber-200 mb-4">
                    Find bossing partners instantly for Old School RuneScape.
                </p>
                <p className="text-white mb-4">
                    Tired of hopping worlds, spamming chats, or waiting on friends who never log in? <span className="text-amber-400 font-semibold">Raidless</span> is your go-to tool for finding bossing partners—fast.
                </p>
                <p className="text-white mb-4">
                    No commitment. No dead Discords. Just players who want to boss.
                </p>
                <p className="text-amber-100 italic">
                    Get in. Get the kill. Get the loot.
                </p>
            </div>
        </div>
    )
}

export default Home