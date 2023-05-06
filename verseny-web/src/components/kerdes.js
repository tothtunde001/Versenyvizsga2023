function Kerdes(props) {
    const questionNumber = props.questionNumber;
    const questionData = props.question;
    const submitted = props.submitted;

    let answerNumbers = [1, 2, 3, 4];

    const handleAnswerQuestion = (questionId, answerId) => {
        for (let i = 1; i < 5; i++) {
            let button = document.getElementById('answer-button-' + questionId + '-' + i);

            if (i === answerId) {
                button.classList.add("btn-warning");
            }
            else {
                button.classList.remove("btn-warning");
            }
        }

        //Felküldjük a kattintott választ a verseny-formnak
        props.onAnswerChange({ questionId, answerId });
    }

    return (
        <div className="card m-3">
            <div className="card-body">
                <h4 className="card-title">
                    {questionNumber + 1}. kérdés:
                </h4>
                <h5 className="card-title">
                    {questionData.question}
                </h5>

                <div className="container">
                    <div className="row row-cols-2">

                        {
                            answerNumbers.map((answerId) => (
                                <div className="col" key={answerId}>
                                    <button id={'answer-button-' + questionData.id + '-' + answerId}
                                        className={`btn w-100 mb-3 border border-2
                                        ${isCorrectAnswer(submitted, questionData, answerId) ? "btn-success" : ""}
                                        ${isWrongAnswer(submitted, questionData, answerId) ? "btn-danger" : ""}`}
                                        onClick={() => handleAnswerQuestion(questionData.id, answerId) }
                                >
                                        {questionData['answer' + answerId]}
                                </button>
                            </div>
                        ))
                        }

                    </div>
                </div>
            </div>
         </div>
         
    );
}



function isCorrectAnswer(submitted, questionData, currentAnswer) {
    if (submitted &&
        questionData.correctAnswer === currentAnswer) {
        return true;
    }
    return false;
}

function isWrongAnswer(submitted, questionData, currentAnswer) {
    if (submitted &&
        questionData.correctAnswer !== questionData.studentAnswer &&
        questionData.studentAnswer === currentAnswer) {
        return true;
    }
    return false;
}

export default Kerdes;