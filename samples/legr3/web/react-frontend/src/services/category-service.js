import axios from 'axios';

//const CATEGORY_API_BASE_URL = "http://localhost:5000/api/category";
const { apiProtocol } = window['runConfig'];
const { apiHost } = window['runConfig'];
const { apiPort } = window['runConfig'];

const CATEGORY_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/category';


class CategoryService {

    getCategorys(){
        return axios.get(CATEGORY_API_BASE_URL);
    }

    createCategory(category){
        return axios.post(CATEGORY_API_BASE_URL, category);
    }

    getCategoryById(categoryId){
        return axios.get(CATEGORY_API_BASE_URL + '/' + categoryId);
    }

    updateCategory(category, categoryId){
        return axios.put(CATEGORY_API_BASE_URL + '/' + categoryId, category);
    }

    deleteCategory(categoryId){
        return axios.delete(CATEGORY_API_BASE_URL + '/' + categoryId);
    }
}

export default new CategoryService()