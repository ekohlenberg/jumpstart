import axios from 'axios';

//const USERORG_API_BASE_URL = "http://localhost:5000/api/userorg";
const { apiProtocol } = window['runConfig'];
const { apiHost } = window['runConfig'];
const { apiPort } = window['runConfig'];

const USERORG_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/userorg';


class UserOrgService {

    getUserOrgs(){
        return axios.get(USERORG_API_BASE_URL);
    }

    createUserOrg(userorg){
        return axios.post(USERORG_API_BASE_URL, userorg);
    }

    getUserOrgById(userorgId){
        return axios.get(USERORG_API_BASE_URL + '/' + userorgId);
    }

    updateUserOrg(userorg, userorgId){
        return axios.put(USERORG_API_BASE_URL + '/' + userorgId, userorg);
    }

    deleteUserOrg(userorgId){
        return axios.delete(USERORG_API_BASE_URL + '/' + userorgId);
    }
}

export default new UserOrgService()