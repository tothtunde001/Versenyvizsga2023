import { useState } from 'react';
import Kerdes from "./kerdes";
import { useParams, useNavigate } from 'react-router-dom';
import { useEffect } from 'react';


function VersenyForm() {

    const { versenyId } = useParams();
    const [kerdesek, setKerdesek] = useState([]);
    const [verseny, setVerseny] = useState({});
    const [submitted, setSubmitted] = useState(false);

    const navigate = useNavigate();

    // A userId-t a local storage-ból szedjük ki
    const userId = localStorage.getItem("userId");
    // Ha nem vagyunk bejelentkezve, akkor a Bejelentkezé oldalra navigálunk
    if (userId === null) {
        navigate("/bejelentkezes");
    }

    let answersToSubmit = {};

    let submitButton;
    if (!submitted) {
        submitButton = (
            <button onClick={() => submitCompetition(userId, versenyId, answersToSubmit, navigate)}
                className="btn btn-warning m-2">Beküldöm</button>
        );
    }

    let backButton = (
        <button onClick={() => history.back()} className="btn btn-secondary m-2">Vissza</button>
    );

    useEffect(() => {
        fetch('http://127.0.0.1:8000/api/verseny/diak/view/' + userId +'/' + versenyId)
            .then(response => {
                return response.json();
            })
            .then(response => {
                setKerdesek(response.kerdesek);
                setVerseny(response.verseny);
                setSubmitted(response.submitted)
            })
            .catch(error => {
                console.log(error.message);
            })
    }, []);

    let handleAnswerChange = (answerData) => {
        answersToSubmit[answerData.questionId] = answerData.answerId;
    }

    //const [currentQuestion, setCurrentQuestion] = useState(0);
    //const [score, setScore] = useState(0);
    //const [showScore, setShowScore] = useState(false);
    //const handleAnswerResponse = (isCorrect) => {
    //    if (isCorrect) {
    //        setScore(score + 1);
    //    }
    //    const nextQuestion = currentQuestion + 1;
    //    if (nextQuestion < KerdesBank.length) {
    //        setCurrentQuestion(nextQuestion);
    //    }
    //    else
    //        setShowScore(true);
    //}

    return (

        <div>
            <div className="card m-3">
                <div className="card-body">
                    <h2 className="card-title">
                        {verseny.competition_name}
                    </h2>

                    <div>
                        {verseny.description}
                    </div>
                </div>
            </div>

            {
                kerdesek.map((kerdes, index) => (
                    <Kerdes key={kerdes.id}
                        question={kerdes}
                        questionNumber={index}
                        submitted={submitted}
                        onAnswerChange={handleAnswerChange}
                    ></Kerdes>
                ))
            }

            {backButton}
            {submitButton}

        </div>
    );
}

function submitCompetition(userId, versenyId, answersToSubmit, navigate) {
    fetch('http://127.0.0.1:8000/api/verseny/diak/submit', {
        method: "POST",
        headers: { "content-type": "application/json" },
        body: JSON.stringify({
            "studentId": userId,
            "competitionId": versenyId,
            "studentAnswers": answersToSubmit
        })
    })
    .then(response => {
        return response.json();
    })
    .then(response => {
        alert(response.message);
        //Navigáljunk a versenyek oldalra
        navigate("/verseny");
    })
    .catch(error => {
        console.log(error.message);
    })
    
}

export default VersenyForm;