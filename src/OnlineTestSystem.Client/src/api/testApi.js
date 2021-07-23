import { api } from "./api";

function loadTestByCategory(categoryName){
    return api.get('test/assigned', {
        params: {
            categoryName: categoryName
        }
    });
}

function loadTestById(id){
    return api.get('test/' + id);
}

function loadQuestion(testId){
    return api.get("test/questions/" + testId);
}

function checkTest(testId, answers){
    return api.post("test/check/" + testId, answers);
}

export const testApi = {
    loadTestByCategory,
    loadTestById,
    loadQuestion,
    checkTest
};