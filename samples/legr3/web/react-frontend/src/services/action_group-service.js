import axios from 'axios';

//const ACTIONGROUP_API_BASE_URL = "http://localhost:5000/api/actiongroup";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const ACTIONGROUP_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/actiongroup';


class ActionGroupService {

    getActionGroups(){
        return axios.get(ACTIONGROUP_API_BASE_URL);
    }

    createActionGroup(actiongroup){
        return axios.post(ACTIONGROUP_API_BASE_URL, actiongroup);
    }

    getActionGroupById(actiongroupId){
        return axios.get(ACTIONGROUP_API_BASE_URL + '/' + actiongroupId);
    }

    updateActionGroup(actiongroup, actiongroupId){
        return axios.put(ACTIONGROUP_API_BASE_URL + '/' + actiongroupId, actiongroup);
    }

    deleteActionGroup(actiongroupId){
        return axios.delete(ACTIONGROUP_API_BASE_URL + '/' + actiongroupId);
    }
}

//const exportedActionGroupService =  new ActionGroupService()
export default new ActionGroupService()