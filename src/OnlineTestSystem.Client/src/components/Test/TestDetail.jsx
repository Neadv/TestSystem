import { useState } from "react";
import { Button, Form } from "react-bootstrap";
import { Link } from "react-router-dom";

export const TestDetail = ({ test, callback }) => {
    const [agreeToStart, setAgree] = useState(false);

    return (
        <>
            <h2 className="text-center">{test.title}</h2>
            <div>{test.description}</div>
            <div>Count of questions: <strong>{test.questionCount}</strong></div>

            <Form.Group className="mt-3" controlId="formBasicCheckbox">
                <Form.Check type="checkbox" label="Agree to start" checked={agreeToStart} onChange={(e) => setAgree(e.target.checked)} />
            </Form.Group>

            <Button variant="primary" className="ml-2" disabled={!agreeToStart} onClick={callback}>Proceed</Button>
            <Link to="/" className="btn btn-secondary m-2">Back</Link>
        </>
    );
}