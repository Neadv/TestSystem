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

export const testApi = {
    loadTestByCategory,
    loadTestById
};