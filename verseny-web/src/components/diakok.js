import Message from "../components/message/Message";

function Diakok(){
return(
  <div>
 
        <Message 
          title="Kedves Diákok!"
          text=" Kérünk benneteket, hogy a regisztráció során, olyan felhasználó nevet adjatok meg, amit könnyen meg tudtok jegyezni, és mindeképpen készítsétek elő az oktatási azonosítótokat amely 7-es számmal kezdődik és 11 jegyű.
          Az aktuális versenyekről és határidőkről mindenképpen tájékozódjatok a főoldalunkon. Kérlek benneteket, hogy a felhasználó nevetekre, jelszavatokra vigyázzatok, ne adjátok ki senkinek. Mielőtt elkezdenétek a feladatok kitöltését, ellenőrizzétek, hogy stabil internet kapcsolattal rendelkeztek."
          buttonText="Regisztráció"
          url="/regisztracio"
          btnClass="show"
          />

  </div>
);
}
export default Diakok;