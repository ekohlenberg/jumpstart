import axios from 'axios';

//const TRANSACTIONCATEGORY_API_BASE_URL = "http://localhost:5000/api/transactioncategory";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

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

//const exportedTransactionCategoryService =  new TransactionCategoryService()
export default new TransactionCategoryService()