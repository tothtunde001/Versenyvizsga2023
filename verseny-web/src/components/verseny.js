import Message from "../components/message/Message";
import { Link } from "react-router-dom";

function Verseny(){
return(
  <div>
        <Message 
          title="Kedves Versenyző!"
          text=" Környezetvédelmi verseny
          Általános iskola alsó tagozat számára a verseny indulása: 2023.07.21.
  
          Matematikai verseny
          Gimnáziumi tanulók számára a verseny indulása:2023.07.23."
          buttonText="Környezetvédelem"
          url="/"
          btnClass="show"
  
          buttonText2="Matematika"
          url2="/"
          btnClass2="show"
          />

        Itt kell majd a versenyeket megjeleníteni, amik az API-ból érkeznek

        <div><Link to="/verseny-form/1">Ez egy verseny</Link> </div>
        <div> <Link to="/verseny-form/2">Ez egy verseny</Link> </div>
        <div> <Link to="/verseny-form/3">Ez egy verseny</Link> </div >
        <div> <Link to="/verseny-form/4">Ez egy verseny</Link> </div >
        <div> <Link to="/verseny-form/5">Ez egy verseny</Link> </div >
        <div><Link to="/verseny-form/6">Ez egy verseny</Link> </div >
        <div> <Link to="/verseny-form/7">Ez egy verseny</Link> </div >
        <div> <Link to="/verseny-form/8">Ez egy verseny</Link> </div >

  </div>
);
}
export default Verseny;