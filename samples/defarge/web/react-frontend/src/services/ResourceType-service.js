import axios from 'axios';

//const RESOURCETYPE_API_BASE_URL = "http://localhost:5000/api/resourcetype";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const RESOURCETYPE_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/resourcetype';


class ResourceTypeService {

    getResourceTypes(){
        return axios.get(RESOURCETYPE_API_BASE_URL);
    }

    createResourceType(resourcetype){
        return axios.post(RESOURCETYPE_API_BASE_URL, resourcetype);
    }

    getResourceTypeById(resourcetypeId){
        return axios.get(RESOURCETYPE_API_BASE_URL + '/' + resourcetypeId);
    }

    updateResourceType(resourcetype, resourcetypeId){
        return axios.put(RESOURCETYPE_API_BASE_URL + '/' + resourcetypeId, resourcetype);
    }

    deleteResourceType(resourcetypeId){
        return axios.delete(RESOURCETYPE_API_BASE_URL + '/' + resourcetypeId);
    }
}

//const exportedResourceTypeService =  new ResourceTypeService()
export default new ResourceTypeService()