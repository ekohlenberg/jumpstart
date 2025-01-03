import axios from 'axios';

//const TRANSACTION_API_BASE_URL = "http://localhost:5000/api/transaction";
const { apiProtocol } = window['runConfig'];
const { apiHost } = window['runConfig'];
const { apiPort } = window['runConfig'];

const TRANSACTION_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/transaction';


class TransactionService {

    getTransactions(){
        return axios.get(TRANSACTION_API_BASE_URL);
    }

    createTransaction(transaction){
        return axios.post(TRANSACTION_API_BASE_URL, transaction);
    }

    getTransactionById(transactionId){
        return axios.get(TRANSACTION_API_BASE_URL + '/' + transactionId);
    }

    updateTransaction(transaction, transactionId){
        return axios.put(TRANSACTION_API_BASE_URL + '/' + transactionId, transaction);
    }

    deleteTransaction(transactionId){
        return axios.delete(TRANSACTION_API_BASE_URL + '/' + transactionId);
    }
}

export default new TransactionService()