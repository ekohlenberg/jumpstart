import axios from 'axios';

//const ACTIONGROUPMAP_API_BASE_URL = "http://localhost:5000/api/actiongroupmap";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const ACTIONGROUPMAP_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/actiongroupmap';


class ActionGroupMapService {

    getActionGroupMaps(){
        return axios.get(ACTIONGROUPMAP_API_BASE_URL);
    }

    createActionGroupMap(actiongroupmap){
        return axios.post(ACTIONGROUPMAP_API_BASE_URL, actiongroupmap);
    }

    getActionGroupMapById(actiongroupmapId){
        return axios.get(ACTIONGROUPMAP_API_BASE_URL + '/' + actiongroupmapId);
    }

    updateActionGroupMap(actiongroupmap, actiongroupmapId){
        return axios.put(ACTIONGROUPMAP_API_BASE_URL + '/' + actiongroupmapId, actiongroupmap);
    }

    deleteActionGroupMap(actiongroupmapId){
        return axios.delete(ACTIONGROUPMAP_API_BASE_URL + '/' + actiongroupmapId);
    }
}

//const exportedActionGroupMapService =  new ActionGroupMapService()
export default new ActionGroupMapService()