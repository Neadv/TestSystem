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

function addTest(test) {
  return { type: testActionTypes.ADD_TEST, payload: test };
}

function loadTestByIdApi(id) {
  return dispatch => {
    testApi.loadTestById(id)
      .then(res => {
        if (res.data)
          dispatch(addTest(res.data));
      }).catch(err => {
        dispatch(errorLoadTest("Not found"));
      })
  }
}

function loadQuestions(questions) {
  return { type: testActionTypes.LOAD_QUESTIONS, payload: questions };
}

function loadQuestionsApi(testId) {
  return dispatch => {
    testApi.loadQuestion(testId)
      .then(res => {
        if (res.data) {
          dispatch(loadQuestions(res.data));
        }
      }).catch(err => {
        dispatch(errorLoadTest("Error"));
      });
  }
}

function checkResult(result) {
  return { type: testActionTypes.CHECK_RESULT, payload: result };
}

function checkResultApi(testId, answers) {
  return dispatch => {
    testApi.checkTest(testId, answers)
      .then(res => {
        if (res.data)
          dispatch(checkResult(res.data));
      }).catch(err => {
        dispatch(errorLoadTest("Error"));
      })
  }
}

function clearResult() {
  return { type: testActionTypes.CLEAR_RESULT };
}

export const testActions = {
  loadCategories,
  errorLoadTest,
  loadCategoriesApi,
  loadTests,
  loadTestsApi,
  addTest,
  loadTestByIdApi,
  loadQuestions,
  loadQuestionsApi,
  checkResult,
  checkResultApi,
  clearResult
};