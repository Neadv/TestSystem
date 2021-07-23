import { testActionTypes } from "./actionTypes";

const initialState = {
    categories: [],
    test: [],
    error: null
}

export function testsReducer(state = initialState, action){
    switch(action.type){
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
        default:
            return state;
    }
}