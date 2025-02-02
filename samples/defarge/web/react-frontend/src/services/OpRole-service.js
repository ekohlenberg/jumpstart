import axios from 'axios';

//const OPROLE_API_BASE_URL = "http://localhost:5000/api/oprole";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const OPROLE_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/oprole';


class OpRoleService {

    getOpRoles(){
        return axios.get(OPROLE_API_BASE_URL);
    }

    createOpRole(oprole){
        return axios.post(OPROLE_API_BASE_URL, oprole);
    }

    getOpRoleById(oproleId){
        return axios.get(OPROLE_API_BASE_URL + '/' + oproleId);
    }

    updateOpRole(oprole, oproleId){
        return axios.put(OPROLE_API_BASE_URL + '/' + oproleId, oprole);
    }

    deleteOpRole(oproleId){
        return axios.delete(OPROLE_API_BASE_URL + '/' + oproleId);
    }
}

//const exportedOpRoleService =  new OpRoleService()
export default new OpRoleService()