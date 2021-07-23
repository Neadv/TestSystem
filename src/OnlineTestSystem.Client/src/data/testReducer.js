import { testActionTypes } from "./actionTypes";

const initialState = {
  categories: [],
  tests: [],
  questions: [],
  result: null,
  error: null
}

export function testsReducer(state = initialState, action) {
  switch (action.type) {
    case testActionTypes.LOAD_TEST_CATEGORY:
      return {
        ...state,
        categories: action.payload,
        error: null
      };
    case testActionTypes.ERROR_TEST_LOAD:
      return {
        ...state,
        error: action.payload
      };
    case testActionTypes.LOAD_TESTS:
      return {
        ...state,
        tests: action.payload,
        error: null
      };
    case testActionTypes.ADD_TEST:
      return {
        ...state,
        tests: [...state.tests, action.payload]
      };
    case testActionTypes.LOAD_QUESTIONS:
      return {
        ...state,
        questions: action.payload,
        error: null
      };
      case testActionTypes.CHECK_RESULT:
        return {
          ...state,
          error: null,
          result: action.payload
        }
    default:
      return state;
  }
}