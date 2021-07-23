import { api } from "./api";

function getAssignedCategories(){
    return api.get("category");
}

export const categoryApi = {
    getAssignedCategories
};