import React from 'react';
import './bejelentkezes.css';
import { Link } from "react-router-dom";


function Bejelentkezes() {
    return (

        <div className='login template d-flex justify-content-center align-items-center 100-w vh-100 bg-primary'>
            <div className='form-container p-5 rounded bg-white'>
                <form>
                    <h3 className='text-center'>Bejelentkezés</h3>

                    <div className='mb2'>
                        <label htmlFor="email">Email</label>
                        <input type="email" placeholder='enter Email' className='form-control'/>
                    </div>

                    <div className='mb2'>
                        <label htmlFor="password">Jelszó</label>
                        <input type="password" placeholder='enter Password' className='form-control'/>
                    </div>

                    <div className='d-grid mt-2'>
                        <button className='btn btn-primary '>Bejelentkezés</button>
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