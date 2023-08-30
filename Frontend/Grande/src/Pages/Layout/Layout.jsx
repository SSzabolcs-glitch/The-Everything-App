import { useContext } from 'react';
import { Outlet, Link } from "react-router-dom";
import { UserContext } from '../../main.jsx';

import "./Layout.css";

const Layout = () => {
    const context  = useContext(UserContext);

    /*
    const handleLogout = () => {
        context.setUser(null);
    };
    */

    return (
        <div className="Layout">
            <nav>
                <ul>
                    <div className="main-logo">
                    </div>
                    <li className="home">
                        <Link to="/" className="link">THE EVERYTHING</Link>
                    </li>
                    <div className="menu-container">
                        <li className="menu">
                            <Link to="/products" className="link">Products</Link>
                        </li>
                        <li className="menu">
                            <Link to="/delivery" className="link">Delivery</Link>
                        </li>
                        <li className="menu">
                            <Link to="/about_us" className="link">About Us</Link>
                        </li>
                        <li className="menu">
                            <Link to="/feedbacks" className="link">Feedbacks</Link>
                        </li>
                    </div>
                    <div className="button-container">
                        {!context.user && (
                            <>
                            <Link to="/signup">
                                <button type="button">Sign Up</button>
                            </Link>
                            <Link to="/login">
                                <button type="button">Log In</button>
                            </Link>
                            </>
                        )}
                        {context.user && (
                            <>
                            <Link to="/">
                                <button type="button" onClick={context.logout}>Log Out</button>
                            </Link>
                            <Link to="/profile">
                                <button type="button">My Profile</button>
                            </Link>
                            </>
                        )}
                    </div>
                </ul>
            </nav>
        <Outlet />
        </div>
    );
};
export default Layout;
