import { Link } from "react-router-dom"

export const TestResult = ({ result }) => {
    return (
        <div>
            <h3 className="text-center">Result</h3>
            <div>
                <em>Score: </em>
                <strong>{result.score}</strong>
            </div>
            <div className="d-flex justify-content-center p-2">
                {result.answers && result.answers.map((a, index) =>
                    <span className={`bg-${a ? 'success' : 'danger'} text-white text-center m-1 p-1`} key={index} style={{minWidth: "2em"}}>
                        {index}
                    </span>)}
            </div>
            <Link to="/" className="btn btn-secondary">Back</Link>
        </div>
    )
}