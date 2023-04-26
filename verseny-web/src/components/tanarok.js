import Message from "../components/message/Message";
function Tanarok(){
return(
  <div>
        <Message 
          title="Kedves Tanárok!"
          text=" Kérünk benneteket, hogy töltsétek le az alábbi alkalmazást, amelyben saját kérdéseiteket feltehetitek, és a diákok eredményeiről itt tudtok majd tájékozódni. Láthatóvá válnak a jó és rossz válaszok, ezeket tanulás céljából bátran felhasználhatjátok!"
          buttonText="Letöltés"
          url="/"
          btnClass="show"
          />
 
    </div>
);
}
export default Tanarok;