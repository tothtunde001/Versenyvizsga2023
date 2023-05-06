import React from 'react';
import './login.css';

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

                    <div className='mb2'>
                        <input type="checkbox" className='custom-control custom-checkbox' id='check'/>
                        <label htmlFor="check" className='custom-input-label ms-2'>Emlékezz rám</label>
                    </div>

                    <div className='d-grid'>
                        <button className='btn btn-primary'>Bejelentkezés</button>
                    </div>
                    <p className='text-right'>Elfelejtett<a href="">jelszó?</a><link to href="/singup" className="ms-2">Regisztráció</link></p>
                </form>
            </div>
        </div>

);
}
export default Bejelentkezes;