import { categoryApi } from "../api/categoryApi";
import { testApi } from "../api/testApi";
import { testActionTypes } from "./actionTypes";

function loadCategories(categories) {
  return { type: testActionTypes.LOAD_TEST_CATEGORY, payload: categories };
}

function errorLoadTest(error) {
  return { type: testActionTypes.ERROR_TEST_LOAD, payload: error };
}

function loadTests(tests) {
  return { type: testActionTypes.LOAD_TESTS, payload: tests };
}

function loadCategoriesApi() {
  return dispatch => {
    categoryApi.getAssignedCategories()
      .then(res => {
        if (res.data) {
          dispatch(loadCategories(res.data))
        }
      }).catch(err => {
        dispatch(errorLoadTest("Error"));
      })
  }
}

function loadTestsApi(categoryName) {
  return dispatch => {
    testApi.loadTestByCategory(categoryName)
      .then(res => {
        if (res.data)
          dispatch(loadTests(res.data));
      }).catch(err => {
        dispatch(errorLoadTest("Error"));
      })
  }
}

export const testActions = {
  loadCategories,
  errorLoadTest,
  loadCategoriesApi,
  loadTests,
  loadTestsApi
};