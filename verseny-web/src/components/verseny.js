import Message from "../components/message/Message";
import { useEffect, useState } from 'react';
import VersenyItem from "../components/verseny-item";

function Verseny() {

    const [versenyek, setVersenyek] = useState([]);

    const userId = 2; //TODO: ennek a bejelentkezésből kell jönnie

    useEffect(() => {
        fetch('http://127.0.0.1:8000/api/verseny/diak/list/' + userId)
            .then(response => {
                return response.json();
            })
            .then(response => {
                //console.log(response);
                setVersenyek(response.data);
            })
            .catch(error => {
                console.log(error.message);
            })
    }, []);

return(
  <div>
        <Message 
          title="Kedves Versenyző!"
            text="Az alábbi versenyek közül választhatsz. Minden versenyt csak egyszer tölthetsz ki. Kitöltés után megtekintheted az eredményeidet"
          btnClass="hide"
        />

        <div className="container">
            {
                versenyek.map((verseny) => (
                    <VersenyItem key={verseny.id} verseny={verseny}></VersenyItem>
                ))
            }
        </div>

  </div>
);
}
export default Verseny;