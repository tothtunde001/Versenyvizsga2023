import Message from "../components/message/Message";
import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import VersenyItem from "../components/verseny-item";

function Verseny() {

    const [versenyek, setVersenyek] = useState([]);

    const navigate = useNavigate();

    // A userId-t a local storage-ból szedjük ki
    const userId = localStorage.getItem("userId");
    // Ha nem vagyunk bejelentkezve, akkor a Bejelentkezé oldalra navigálunk
    if (userId === null) {
        navigate("/bejelentkezes");
    }

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