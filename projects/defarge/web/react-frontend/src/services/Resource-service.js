import axios from 'axios';

//const RESOURCE_API_BASE_URL = "http://localhost:5000/api/resource";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const RESOURCE_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/resource';


class ResourceService {

    getResources(){
        return axios.get(RESOURCE_API_BASE_URL);
    }

    createResource(resource){
        return axios.post(RESOURCE_API_BASE_URL, resource);
    }

    getResourceById(resourceId){
        return axios.get(RESOURCE_API_BASE_URL + '/' + resourceId);
    }

    updateResource(resource, resourceId){
        return axios.put(RESOURCE_API_BASE_URL + '/' + resourceId, resource);
    }

    deleteResource(resourceId){
        return axios.delete(RESOURCE_API_BASE_URL + '/' + resourceId);
    }
}

//const exportedResourceService =  new ResourceService()
export default new ResourceService()