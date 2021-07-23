import { api } from "./api";

function loadTestByCategory(categoryName){
    return api.get('test/assigned', {
        params: {
            categoryName: categoryName
        }
    });
}

export const testApi = {
    loadTestByCategory
};