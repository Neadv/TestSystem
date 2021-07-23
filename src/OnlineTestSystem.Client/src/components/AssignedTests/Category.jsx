import { useEffect } from "react";
import { Table } from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux";
import { Link, useParams } from "react-router-dom";
import { testActions } from "../../data/testsActions";

export const Category = () => {
  const { category } = useParams();
  const dispatch = useDispatch();
  const tests = useSelector(state => state.tests.tests)

  useEffect(() => {
    dispatch(testActions.loadTestsApi(category));
  }, [category, dispatch])

  return (
    <>
      <h3 className="text-center">{category}</h3>
      <Table striped bordered size="sm">
        <thead>
          <tr>
            <th>Title</th>
            <th>Count of questions</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {tests && tests.map(t => 
            <tr key={t.testId}>
              <td>{t.title}</td>
              <td>{t.questionCount}</td>
              <td>
                <Link to={`/test/${t.testId}`} className="btn btn-sm btn-primary">Start</Link>
              </td>
            </tr>)}
        </tbody>
      </Table>
    </>
  );
}