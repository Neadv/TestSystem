import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Link, useParams } from "react-router-dom";
import { testActions } from "../../data/testsActions";
import { Button, Form } from "react-bootstrap";
import { useState } from "react";

export const Test = () => {
  const { id } = useParams();
  const dispatch = useDispatch();
  const test = useSelector(state => getCurrentTest(state, id))
  const error = useSelector(state => state.tests.error);

  const [agreeToStart, setAgree] = useState(false);

  useEffect(() => {
    if (!test) {
      dispatch(testActions.loadTestByIdApi(id));
    }
  }, [id, test, dispatch])

  if (error) {
    return <h3 className="bg-warning text-center text-white p-2">{error}</h3>
  }

  return (
    test ?
      <>
        <h2 className="text-center">{test.title}</h2>
        <div>{test.description}</div>
        <div>Count of questions: <strong>{test.questionCount}</strong></div>

        <Form.Group className="mt-3" controlId="formBasicCheckbox">
          <Form.Check type="checkbox" label="Agree to start" checked={agreeToStart} onChange={(e) => setAgree(e.target.checked)}/>
        </Form.Group>

        <Button variant="primary" className="ml-2" disabled={!agreeToStart}>Proceed</Button>
        <Link to="/" className="btn btn-secondary m-2">Back</Link>
      </>
      : <h3 className="text-center">Loading...</h3>
  );
}

function getCurrentTest(state, id) {
  return state.tests.tests.find(t => t.testId === parseInt(id));
}