import React from 'react'
import logo from "../assets/raidless.png"

const About = () => {
    return (
        <div className="flex justify-center items-center ">
            <div className="shadow-lg rounded-lg p-8 max-w-lg w-full text-center bg-opacity-90 border border-black">
                <img
                    src={logo}
                    alt="Raidless Logo"
                    className="mx-auto mb-6 w-24 h-24 rounded-full border-2 border-gray-300"
                />
                <h1 className="text-2xl font-bold mb-2 text-amber-300 drop-shadow">Hello, I'm Sven Snoeck</h1>
                <p className="text-amber-200 mb-4">
                    A programming student in .NET and React.
                </p>
                <p className="text-white mb-4">
                    This web application helps Old School Runescape players find parties for bosses and raids. Create a lobby solo or with friends, queue up, and get matched based on your chosen boss and party size.
                </p>
                <p className="text-white mb-4">
                    No need for Discord—there’s a real-time chat in every matched lobby!
                </p>
                <p className="text-amber-100 italic">
                    I plan to add more features and improve both the frontend and backend in the future.
                </p>
            </div>
        </div>
    )
}

export default About