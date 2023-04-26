import Message from "../components/message/Message";
function Kezdolap(){
    return (
        <div>
            <Message 
              title="Kedves Versenyző!"
              text="A fenntarthatóság jegyében kerül megrendezésre Környezetvédelem, és Matematika tantárgyból 1. fordulós megyei versenyünk. 
              A környezetvédelmi verseny kitöltésének határideje: 2023.07.21. 
              A matematika verseny kitöltésének határideje: 2023.07.23. 
              Kérlek benneteket, hogy a határidők betartására különösen figyeljetek!
              A honlapunkon történő Regisztráció után lehet részt venni a versenyen, azonban a regisztrációnak 48 órával a kiírt határidő előtt meg kell történnie.
              Reméljük elegendő idő áll majd rendelkezésetekre!
              Ha bármivel kapcsolatban hibát észleltek, vagy probléma adódik, kérünk benneteket, hogy a Kapcsolat menüpontban keressetek minket!
              Sikeres versenyzést kívánunk!
              Tisztelettel: A szerkesztők "
              buttonText="Regisztráció"
              url="/regisztracio"
              btnClass="show"
              />
        </div>
);
}
export default Kezdolap;