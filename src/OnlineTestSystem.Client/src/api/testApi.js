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

export const testApi = {
    loadTestByCategory,
    loadTestById,
    loadQuestion
};