import axios from 'axios';

//const ACCOUNT_API_BASE_URL = "http://localhost:5000/api/account";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

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

//const exportedAccountService =  new AccountService()
export default new AccountService()