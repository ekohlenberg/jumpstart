import axios from 'axios';

//const CATEGORY_API_BASE_URL = "http://localhost:5000/api/category";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

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

//const exportedCategoryService =  new CategoryService()
export default new CategoryService()