import { useEffect } from "react";
import { ListGroup } from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux"
import { Link } from "react-router-dom";
import { testActions } from "../../data/testsActions";
import './CategoryList.css';

export const CategoryList = () => {
  const dispatch = useDispatch();
  const categories = useSelector(state => state.tests.categories);

  useEffect(() => {
    dispatch(testActions.loadCategoriesApi());
  }, [dispatch]);

  return (
    <>
      <h3>Categories</h3>
      <ListGroup className="mt-3">
        {categories && categories.map(cat =>
          <ListGroup.Item key={cat.name} className="category-item">
            <Link to={`/${cat.name}`}>
              {cat.name}
            </Link>
          </ListGroup.Item>)}
      </ListGroup>
    </>
  )
}