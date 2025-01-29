import axios from 'axios';

//const USERPASSWORD_API_BASE_URL = "http://localhost:5000/api/userpassword";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const USERPASSWORD_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/userpassword';


class UserPasswordService {

    getUserPasswords(){
        return axios.get(USERPASSWORD_API_BASE_URL);
    }

    createUserPassword(userpassword){
        return axios.post(USERPASSWORD_API_BASE_URL, userpassword);
    }

    getUserPasswordById(userpasswordId){
        return axios.get(USERPASSWORD_API_BASE_URL + '/' + userpasswordId);
    }

    updateUserPassword(userpassword, userpasswordId){
        return axios.put(USERPASSWORD_API_BASE_URL + '/' + userpasswordId, userpassword);
    }

    deleteUserPassword(userpasswordId){
        return axios.delete(USERPASSWORD_API_BASE_URL + '/' + userpasswordId);
    }
}

//const exportedUserPasswordService =  new UserPasswordService()
export default new UserPasswordService()