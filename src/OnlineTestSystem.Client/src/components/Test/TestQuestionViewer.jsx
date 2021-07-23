import { useState } from "react"
import { Button, Card, FormCheck } from "react-bootstrap";

export const TestQuestionViewer = ({ questions = [], callback }) => {
    const [currentNumber, setNumber] = useState(0);
    const [selected, setSelected] = useState(-1);
    const [answers, setAnswers] = useState([]);
    const currentQuestion = questions[currentNumber];
    const count = questions.length;

    const next = () => {
        setSelected(-1);
        setNumber(currentNumber + 1);

        const newAnswers = answers.slice();
        newAnswers.push(selected);
        setAnswers(newAnswers);

        if (currentNumber === count - 1){
            callback(newAnswers);
        }
    };

    return (
        currentQuestion ?
        <div>
            <div className="text-center">{currentNumber + 1}/{count}</div>
            <div className="my-2">{currentQuestion.question}</div>
            <Card>
                <Card.Body>
                    {currentQuestion.options && currentQuestion.options.map((o, index) => (
                        <FormCheck key={index} label={o}
                        onChange={(e) => setSelected(parseInt(e.target.value))}
                        name="answerGroup" value={index} type="radio" 
                        checked={index === selected}/>
                    ))}
                </Card.Body>
            </Card>
            <Button variant="primary" className="my-2" onClick={next} disabled={selected === -1}>Next</Button>
        </div> : <h1>Loading...</h1>
    )
}