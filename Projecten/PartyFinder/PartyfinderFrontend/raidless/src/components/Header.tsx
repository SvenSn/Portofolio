
import { Link, NavLink } from "react-router-dom";
import logo from '../assets/raidless.png'
import { useAuth } from 'react-oidc-context';

const Header = () => {

    const { isAuthenticated, signinRedirect, signoutRedirect, user } = useAuth();

    const role = user?.profile?.role as string;
    const isAdmin = (role ?? "").toLowerCase() === "admin";

    return (
        <div className="bg-linear-to-r from-blue-950 to-amber-900 text-white py-6 border border-black">
            <div className="flex items-center justify-between px-6">
                <Link to="/" className="flex items-center gap-3">
                    <img className="h-24" src={logo} alt="Raidless Logo" />
                    <h1 className="text-2xl font-bold text-blue-200">Raidless</h1>
                </Link>
                {isAuthenticated && (
                    <p className="ml-6 px-4 py-2 rounded-full bg-linear-to-r from-amber-500 to-blue-700 text-white font-semibold shadow-md">
                        Welcome <span className="font-bold">{user?.profile.preferred_username}</span>!
                    </p>
                )}
                <div className="flex gap-8">
                    <NavLink
                        to="home"
                        className={({ isActive }) =>
                            isActive
                                ? "text-blue-300 font-medium"
                                : "text-amber-100 hover:text-blue-200 transition-colors font-medium"
                        }
                    >
                        Home
                    </NavLink>
                    <NavLink
                        to="about"
                        className={({ isActive }) =>
                            isActive
                                ? "text-blue-300 font-medium"
                                : "text-amber-100 hover:text-blue-200 transition-colors font-medium"
                        }
                    >
                        About
                    </NavLink>

                    {isAuthenticated && isAdmin && (
                        <NavLink
                            to="AdminPage"
                            className={({ isActive }) =>
                                isActive
                                    ? "text-blue-300 font-medium"
                                    : "text-amber-100 hover:text-blue-200 transition-colors font-medium"
                            }
                        >
                            Admin
                        </NavLink>
                    )}
                    <NavLink
                        to="createPreLobby"
                        className={({ isActive }) =>
                            isActive
                                ? "text-blue-300 font-medium"
                                : "text-amber-100 hover:text-blue-200 transition-colors font-medium"
                        }
                    >
                        Create Party
                    </NavLink>
                    <NavLink
                        to="donate"
                        className={({ isActive }) =>
                            isActive
                                ? "text-blue-300 font-medium"
                                : "text-amber-100 hover:text-blue-200 transition-colors font-medium"
                        }
                    >
                        Donate
                    </NavLink>

                    {!isAuthenticated && (
                        <NavLink to="register"
                            className={({ isActive }) =>
                                isActive
                                    ? "text-blue-300 font-medium"
                                    : "text-amber-100 hover:text-blue-200 transition-colors font-medium"
                            }>
                            Register
                        </NavLink>
                    )}
                    <button
                        type='button'
                        onClick={() => (isAuthenticated ? signoutRedirect() : signinRedirect())}
                        className={isAuthenticated ? "text-blue-300 font-medium hover:text-blue-200 transition-colors cursor-pointer" : "text-amber-100 hover:text-blue-200 transition-colors font-medium cursor-pointer"}
                    >
                        {isAuthenticated ? 'Logout' : 'Login'}
                    </button>
                </div>
            </div>
        </div>
    )
}

export default Header