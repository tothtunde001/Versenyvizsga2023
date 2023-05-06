import React from 'react';
import { Link } from "react-router-dom";


function Regisztracio() {
    return (
        <div className='singup template d-flex justify-content-center align-items-center 100-w vh-100 bg-primary'>
            <div className='form-container p-5 rounded bg-white'>
                <form>
                    <h3 className='text-center'>Regisztráció</h3>

                    <div className='mb2'>
                        <label htmlFor="name">Teljes név</label>
                        <input type="name" placeholder='enter Name' className='form-control'/>
                    </div>

                    <div className='mb2'>
                        <label htmlFor="schol">Intézmény</label>
                        <input type="schol" placeholder='enter Schol' className='form-control'/>
                    </div>

                    <div className='mb2'>
                        <label htmlFor="password">Jelszó</label>
                        <input type="password" placeholder='enter Password' className='form-control'/>
                    </div>

                    <div className='d-grid mt-2'>
                        <button className='btn btn-primary'>Regisztráció</button>
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