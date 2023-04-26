import "./styles.css";

import { Routes, Route } from "react-router-dom";
import Kezdolap from "./components/kezdolap";
import Verseny from "./components/verseny";
import Diakok from "./components/diakok";
import Tanarok from "./components/tanarok";
import Kapcsolat from "./components/kapcsolat";
import Navbar from "./components/menu/Navbar";
import Regisztracio from "./components/regisztracio";
import Bejelentkezes from "./components/bejelentkezes";
import VersenyForm from "./components/verseny-form";


export default function App() {
  return (
      <div className="App">
      <Navbar />
      <Routes>
        <Route path="/" element={<Kezdolap/>}/>
        <Route path="/verseny" element={<Verseny/>}/>
        <Route path="/diakok" element={<Diakok/>}/>
        <Route path="/tanarok" element={<Tanarok/>}/>
        <Route path="/kapcsolat" element={<Kapcsolat />} />
        <Route path="/bejelentkezes" element={<Bejelentkezes />} />
        <Route path="/regisztracio" element={<Regisztracio />} />
        <Route path="/verseny-form/:versenyId" element={<VersenyForm />} />
      </Routes>

    
      
    </div>
  );
}
