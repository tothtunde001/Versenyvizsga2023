import Message from "../components/message/Message";
import { useState } from 'react';
import Kerdes from "./kerdes";

function VersenyForm(){
    var KerdesBank = [
        {
            Question: "Takaros nevű város főtere kör alakú, amelyen 10 sétaút keresztezi egymást. A főtér, utakon kívüli részeit füvesítik. Legfeljebb hány részt fedhet fű?",
            AnswerText: [
                { Answer: "52", isCorrect: false },
                { Answer: "46", isCorrect: false },
                { Answer: "56", isCorrect: true },
                { Answer: "egyik sem", isCorrect: false },

            ]
        },
        {
            Question: "Egy háromszög egyik oldala 26 cm, a másik két oldalhoz tartozó súlyvonala 15 cm illetve 36 cm hosszú. Mekkora a háromszög területe?",
            AnswerText: [
                { Answer: "360 cm2", isCorrect: true },
                { Answer: "328 cm2", isCorrect: false },
                { Answer: "371 cm2", isCorrect: false },
                { Answer: "346 cm2", isCorrect: false }
            ]
        },
        {
            Question: "Takaros nevű város főtere kör alakú, amelyen 7 sétaút keresztezi egymást. A főtér utakon kívüli részeit füvesítik. Legfeljebb hány részt fedhet fű?",
            AnswerText: [
                { Answer: "27", isCorrect: false },
                { Answer: "29", isCorrect: true },
                { Answer: "31", isCorrect: false },
                { Answer: "34", isCorrect: false }
            ]
        },
        {
            Question: "Mekkora egy derékszögű háromszög belső szögeinek az összege?",

            AnswerText: [
                { Answer: "160°", isCorrect: false },
                { Answer: "90°", isCorrect: false },
                { Answer: "175°", isCorrect: false },
                { Answer: "180°", isCorrect: true }
            ]
        },
        {
            Question: "Minden négyzet rombusz, de nem minden rombusz négyzet. Igaz vagy hamis ez az állítás?",

            AnswerText: [
                { Answer: "hamis", isCorrect: false },
                { Answer: "igaz", isCorrect: true }
            ]
        },
        {
            Question: "Kettővel azok a számok oszthatók, amelyek utolsó számjegye: 2, 4, 6, 8. Igaz vagy hamis ez az állítás?",

            AnswerText: [
                { Answer: "hamis", isCorrect: false },
                { Answer: "igaz", isCorrect: false },
                { Answer: "részben igaz, mert a 0 számjegy kimaradt", isCorrect: true },
                { Answer: "részben igaz", isCorrect: false },

            ]
        }

    ]
    const [currentQuestion, setCurrentQuestion] = useState(0);
    const [score, setScore] = useState(0);
    const [showScore, setShowScore] = useState(false);
    const handleAnswerResponse = (isCorrect) => {
        if (isCorrect) {
            setScore(score + 1);
        }
        const nextQuestion = currentQuestion + 1;
        if (nextQuestion < KerdesBank.length) {
            setCurrentQuestion(nextQuestion);
        }
        else
            setShowScore(true);
    }

    console.log(KerdesBank)
    return (

        KerdesBank.map((kerdes, index) => (
            <Kerdes question={kerdes} questionNumber={index}></Kerdes>
        ))

    );
}
export default VersenyForm;