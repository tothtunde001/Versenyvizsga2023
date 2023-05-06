function Kerdes(props) {
    const questionNumber = props.questionNumber;
    const questionData = props.question;
    const submitted = props.submitted;

    let answerNumbers = [1, 2, 3, 4];

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
                            answerNumbers.map((num) => (
                                <div className="col" key={num}>
                                <button
                                    className={`btn w-100 mb-3 border border-2
                                        ${isCorrectAnswer(submitted, questionData, num) ? "btn-success" : ""}
                                        ${isWrongAnswer(submitted, questionData, num) ? "btn-danger" : ""}`}
                                >
                                    {questionData['answer'+num]}
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