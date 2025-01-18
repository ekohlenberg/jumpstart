import axios from 'axios';

//const USERACTIONGROUP_API_BASE_URL = "http://localhost:5000/api/useractiongroup";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const USERACTIONGROUP_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/useractiongroup';


class UserActionGroupService {

    getUserActionGroups(){
        return axios.get(USERACTIONGROUP_API_BASE_URL);
    }

    createUserActionGroup(useractiongroup){
        return axios.post(USERACTIONGROUP_API_BASE_URL, useractiongroup);
    }

    getUserActionGroupById(useractiongroupId){
        return axios.get(USERACTIONGROUP_API_BASE_URL + '/' + useractiongroupId);
    }

    updateUserActionGroup(useractiongroup, useractiongroupId){
        return axios.put(USERACTIONGROUP_API_BASE_URL + '/' + useractiongroupId, useractiongroup);
    }

    deleteUserActionGroup(useractiongroupId){
        return axios.delete(USERACTIONGROUP_API_BASE_URL + '/' + useractiongroupId);
    }
}

//const exportedUserActionGroupService =  new UserActionGroupService()
export default new UserActionGroupService()