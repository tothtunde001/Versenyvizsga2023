import React, { useState } from 'react';
import './bejelentkezes.css';
import { Link, useNavigate } from "react-router-dom";


function Bejelentkezes() {
    const [username, setUsername] = useState(null);
    const [password, setPassword] = useState(null);

    const navigate = useNavigate();

    const login = (e) => {
        e.preventDefault();
        fetch('http://127.0.0.1:8000/api/diakok/login', {
            method: "POST",
            headers: { "content-type": "application/json" },
            body: JSON.stringify({
                "username": username,
                "password": password
            })
        })
        .then(response => {
            return response.json();
        })
            .then(response => {
            // Sikeres bejelentkezés esetén eltároljuk a userId-t
            if (response.status === 'OK') {
                localStorage.setItem("userId", response.id);
                localStorage.setItem("userName", username);
                navigate("/verseny");
            }
            else {
                //Hiba esetén kiírjuk a hibaüzenetet
                alert(response.message);
            }
        })
        .catch(error => {
            console.log(error.message);
        })

    }

    return (

        <div className='login template d-flex justify-content-center align-items-center 100-w'>
            <div className='form-container p-5 mt-5 rounded bg-white'>
                <form onSubmit={login}>
                    <h3 className='text-center'>Bejelentkezés</h3>

                    <div className='mb2'>
                        <label htmlFor="email">Felhasználónév</label>
                        <input type="text" placeholder='Felhasználónév' className='form-control'
                            onChange={e => setUsername(e.target.value)} required />
                    </div>

                    <div className='mb2'>
                        <label htmlFor="password">Jelszó</label>
                        <input type="password" placeholder='Jelszó' className='form-control'
                            onChange={e => setPassword(e.target.value)} required />
                    </div>

                    <div className='d-grid mt-2'>
                        <button type="submit" className='btn btn-primary '>Bejelentkezés</button>
                    </div>
                    <p className='text-right mt-2'>
                        Most jársz itt először?
                        <Link to="/regisztracio" className="ms-2">Regisztráció</Link>
                    </p>
                </form>
            </div>
        </div>

);
}
export default Bejelentkezes;