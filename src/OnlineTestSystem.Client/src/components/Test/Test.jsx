import { useState } from "react";
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useParams } from "react-router-dom";
import { testActions } from "../../data/testsActions";
import { TestDetail } from "./TestDetail";
import { TestQuestionViewer } from "./TestQuestionViewer";
import { TestResult } from "./TestResult";

export const Test = () => {
  const { id } = useParams();
  const dispatch = useDispatch();
  const test = useSelector(state => getCurrentTest(state, id))
  const error = useSelector(state => state.tests.error);
  const [isStarted, setStarted] = useState(false);
  const questions = useSelector(state => state.tests.questions);
  const result = useSelector(state => state.tests.result);

  useEffect(() => {
    if (!test) {
      dispatch(testActions.loadTestByIdApi(id));
    }
    dispatch(testActions.clearResult());
  }, [id, test, dispatch]);

  useEffect(() => {
    if (isStarted){
      dispatch(testActions.loadQuestionsApi(id))
    }
  }, [isStarted, id, dispatch]);

  const checkResult = (answers) => {
    dispatch(testActions.checkResultApi(id, answers));
    setStarted(false);
  }

  if (error) {
    return <h3 className="bg-warning text-center text-white p-2">{error}</h3>
  }

  if (result){
    return <TestResult result={result} />;
  }

  if (isStarted){
    return <TestQuestionViewer questions={questions} callback={checkResult}/>
  }

  return (
    test 
      ? <TestDetail test={test} callback={() => setStarted(true)}/>
      : <h3 className="text-center">Loading...</h3>
  );
}

function getCurrentTest(state, id) {
  return state.tests.tests.find(t => t.testId === parseInt(id));
}