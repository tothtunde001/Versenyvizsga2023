import React, { useState } from 'react';
import { Link, useNavigate } from "react-router-dom";


function Regisztracio() {

    const [username, setUsername] = useState(null);
    const [password, setPassword] = useState(null);
    const [email, setEmail] = useState(null);
    const [fullname, setFullname] = useState(null);
    const [school, setSchool] = useState(null);
    const [classs, setClasss] = useState(null);

    const navigate = useNavigate();

    const signUp = (e) => {
        e.preventDefault();
        fetch('http://127.0.0.1:8000/api/diakok/signup', {
            method: "POST",
            headers: { "content-type": "application/json" },
            body: JSON.stringify({
                "username": username,
                "password": password,
                "email": email,
                "fullname": fullname,
                "school": school,
                "class": classs
            })
        })
        .then(response => {
            return response.json();
        })
        .then(response => {
            alert(response.message);
            //Sikeres regisztráció esetén a bejelentkezés oldalra navigálunk
            if (response.status === 'OK') {
                navigate("/bejelentkezes");
            }
        })
        .catch(error => {
            console.log(error.message);
        })
    }

    return (
        <div className='singup template d-flex justify-content-center align-items-center 100-w vh-100'>
            <div className='form-container p-5 mt-5 rounded bg-white'>
                <form onSubmit={signUp}>
                    <h3 className='text-center'>Regisztráció</h3>

                    <div className='mb2'>
                        <label htmlFor="name">Felhasználónév</label>
                        <input type="name" placeholder='Felhasználónév' className='form-control'
                            onChange={e => setUsername(e.target.value)} required />
                    </div>

                    <div className='mb2'>
                        <label htmlFor="password">Jelszó</label>
                        <input type="password" placeholder='Jelszó' className='form-control'
                            onChange={e => setPassword(e.target.value)} required />
                    </div>

                    <div className='mb2'>
                        <label htmlFor="name">Email</label>
                        <input type="email" placeholder='Email' className='form-control'
                            onChange={e => setEmail(e.target.value)} required />
                    </div>

                    <div className='mb2'>
                        <label htmlFor="name">Teljes név</label>
                        <input type="name" placeholder='Teljes név' className='form-control'
                            onChange={e => setFullname(e.target.value)} required />
                    </div>

                    <div className='mb2'>
                        <label htmlFor="schol">Intézmény</label>
                        <input type="schol" placeholder='Intézmény' className='form-control'
                            onChange={e => setSchool(e.target.value)} required />
                    </div>

                    <div className='mb2'>
                        <label htmlFor="schol">Osztály</label>
                        <input type="schol" placeholder='Osztály' className='form-control'
                            onChange={e => setClasss(e.target.value)} required />
                    </div>

                    <div className='d-grid mt-2'>
                        <button type="submit" className='btn btn-primary'>Regisztráció</button>
                    </div>
                    <p className='text-end mt-2'>
                        Már regisztráltál?
                        <Link to="/bejelentkezes" className="ms-2">Bejelentkezés</Link>
                    </p>
                </form>
            </div>
        </div>
    );
}
export default Regisztracio;