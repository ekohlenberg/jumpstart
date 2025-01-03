import axios from 'axios';

//const TRANSACTIONCATEGORY_API_BASE_URL = "http://localhost:5000/api/transactioncategory";
const { apiProtocol } = window['runConfig'];
const { apiHost } = window['runConfig'];
const { apiPort } = window['runConfig'];

const TRANSACTIONCATEGORY_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/transactioncategory';


class TransactionCategoryService {

    getTransactionCategorys(){
        return axios.get(TRANSACTIONCATEGORY_API_BASE_URL);
    }

    createTransactionCategory(transactioncategory){
        return axios.post(TRANSACTIONCATEGORY_API_BASE_URL, transactioncategory);
    }

    getTransactionCategoryById(transactioncategoryId){
        return axios.get(TRANSACTIONCATEGORY_API_BASE_URL + '/' + transactioncategoryId);
    }

    updateTransactionCategory(transactioncategory, transactioncategoryId){
        return axios.put(TRANSACTIONCATEGORY_API_BASE_URL + '/' + transactioncategoryId, transactioncategory);
    }

    deleteTransactionCategory(transactioncategoryId){
        return axios.delete(TRANSACTIONCATEGORY_API_BASE_URL + '/' + transactioncategoryId);
    }
}

export default new TransactionCategoryService()