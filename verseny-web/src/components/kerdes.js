function Kerdes(props) {
    const questionNumber = props.questionNumber;
    const question = props.question;

    return (
        <div className="card m-3">
            <div className="card-body">
                <h4 className="card-title">
                    {questionNumber + 1}. kérdés:
                </h4>
                <h5 className="card-title">
                    {question.Question}
                </h5>

                <div class="container">
                    <div class="row row-cols-2">

                        {question.AnswerText.map((answer) => (
                            <div class="col">
                                <button
                                    className="btn w-100 mb-3 border border-2"
                                    onClick={() => handleAnswerResponse(answer.isCorrect)}>
                                    {answer.Answer}
                                </button>
                             </div>
                           
                        ))}

                    </div>
                </div>

                <div>
                    
                 </div>
             </div>
        </div>
         
    );
}

export default Kerdes;