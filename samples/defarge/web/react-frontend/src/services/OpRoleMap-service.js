import axios from 'axios';

//const OPROLEMAP_API_BASE_URL = "http://localhost:5000/api/oprolemap";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const OPROLEMAP_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/oprolemap';


class OpRoleMapService {

    getOpRoleMaps(){
        return axios.get(OPROLEMAP_API_BASE_URL);
    }

    createOpRoleMap(oprolemap){
        return axios.post(OPROLEMAP_API_BASE_URL, oprolemap);
    }

    getOpRoleMapById(oprolemapId){
        return axios.get(OPROLEMAP_API_BASE_URL + '/' + oprolemapId);
    }

    updateOpRoleMap(oprolemap, oprolemapId){
        return axios.put(OPROLEMAP_API_BASE_URL + '/' + oprolemapId, oprolemap);
    }

    deleteOpRoleMap(oprolemapId){
        return axios.delete(OPROLEMAP_API_BASE_URL + '/' + oprolemapId);
    }
}

//const exportedOpRoleMapService =  new OpRoleMapService()
export default new OpRoleMapService()