import Message from "../components/message/Message";
import { Link } from "react-router-dom";

function Verseny(){
return(
  <div>
        <Message 
          title="Kedves Versenyző!"
          text=" Verseny Kvíz
          Általános iskola alsó tagozat számára a verseny indulása: 2023.07.21.
  
          A verseny indulása:2023.07.23."
          buttonText="VersenyKvíz"
          url="/"
          btnClass="show"
  
          />


  </div>
);
}
export default Verseny;