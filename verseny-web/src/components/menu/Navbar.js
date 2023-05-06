import { Component } from "react";
import "./NavbarStyles.css";
import { MenuItems } from "./MenuItems";
import { Link, useNavigate } from "react-router-dom";


function Navbar() {

    const navigate = useNavigate();

    const userId = localStorage.getItem("userId");
    const userName = localStorage.getItem("userName");

    const logout = () => {
        localStorage.removeItem("userId");
        localStorage.removeItem("userName");
        navigate("/");
    }

    let button;
    if (!userId) {
        button = <Link className="login-button" to="/bejelentkezes">Bejelentkezés</Link>
    }
    else {
        button = <button className="login-button" onClick={logout}>Kijelentkezés</button>
        loginMessage = userId;
    }

    let loginMessage = "";
    if (userName) {
        loginMessage = userName;
    }

    return (
        <div>
            <nav className="NavbarItems">
                <h1 className="navbar-logo">Verseny</h1>

                <ul className="nav-menu">
                    {MenuItems.map((item, index) => {
                        return (
                            <li key={index}>
                                <Link className="nav-links" to={item.url}>
                                    <i className={item.icon}></i>{item.title}
                                </Link>
                            </li>
                        )
                    })}

                    {button}
                </ul>
                <div className="logintext mr-2">
                    {loginMessage}
                </div>
            </nav>
            
        </div>
        
    );
}
  
export default Navbar;
