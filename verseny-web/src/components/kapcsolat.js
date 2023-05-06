import { useState } from "react";

function Kapcsolat() {
    const [name, setName] = useState();
    const [email, setEmail] = useState();
    const [subject, setSubject] = useState();
    const [message, setMessage] = useState();

    const send = () => {
        // To be implemented
    }

  return(
      <div className='login template d-flex justify-content-center align-items-center 100-w vh-100 bg-primary'>
            <div className='form-container p-5 rounded bg-white'>
                <form onSubmit={send}>
                    <h3 className='text-center'>Küldj üzenetet nekünk!</h3>

                    <div className='mb2'>
                        <label htmlFor="email">Név</label>
                      <input type="text" placeholder='Név' className='form-control'
                          onChange={e => setName(e.target.value)} required />
                    </div>

                    <div className='mb2'>
                        <label htmlFor="password">Email</label>
                      <input type="email" placeholder='Email' className='form-control'
                          onChange={e => setEmail(e.target.value)} required />
                    </div>

                      <div className='mb2'>
                      <label htmlFor="email">Tárgy</label>
                        <input type="text" placeholder='Tárgy' className='form-control'
                          onChange={e => setSubject(e.target.value)} required />
                    </div>

                      <div className='mb2'>
                        <label htmlFor="email">Üzenet</label>
                      <textarea rows="4" type ="text" placeholder='Üzenet' className='form-control'
                          onChange={e => setMessage(e.target.value)} required />
                    </div>

                    <div className='d-grid mt-2'>
                        <button type="submit" className='btn btn-primary '>Küldés</button>
                    </div>
                </form>
            </div>
        </div>
  )
  }
  export default Kapcsolat;