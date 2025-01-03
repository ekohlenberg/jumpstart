import axios from 'axios';

//const ACCOUNT_API_BASE_URL = "http://localhost:5000/api/account";
const { apiProtocol } = window['runConfig'];
const { apiHost } = window['runConfig'];
const { apiPort } = window['runConfig'];

const ACCOUNT_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/account';


class AccountService {

    getAccounts(){
        return axios.get(ACCOUNT_API_BASE_URL);
    }

    createAccount(account){
        return axios.post(ACCOUNT_API_BASE_URL, account);
    }

    getAccountById(accountId){
        return axios.get(ACCOUNT_API_BASE_URL + '/' + accountId);
    }

    updateAccount(account, accountId){
        return axios.put(ACCOUNT_API_BASE_URL + '/' + accountId, account);
    }

    deleteAccount(accountId){
        return axios.delete(ACCOUNT_API_BASE_URL + '/' + accountId);
    }
}

export default new AccountService()