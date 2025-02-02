import axios from 'axios';

//const MONITOREDRESOURCE_API_BASE_URL = "http://localhost:5000/api/monitoredresource";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const MONITOREDRESOURCE_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/monitoredresource';


class MonitoredResourceService {

    getMonitoredResources(){
        return axios.get(MONITOREDRESOURCE_API_BASE_URL);
    }

    createMonitoredResource(monitoredresource){
        return axios.post(MONITOREDRESOURCE_API_BASE_URL, monitoredresource);
    }

    getMonitoredResourceById(monitoredresourceId){
        return axios.get(MONITOREDRESOURCE_API_BASE_URL + '/' + monitoredresourceId);
    }

    updateMonitoredResource(monitoredresource, monitoredresourceId){
        return axios.put(MONITOREDRESOURCE_API_BASE_URL + '/' + monitoredresourceId, monitoredresource);
    }

    deleteMonitoredResource(monitoredresourceId){
        return axios.delete(MONITOREDRESOURCE_API_BASE_URL + '/' + monitoredresourceId);
    }
}

//const exportedMonitoredResourceService =  new MonitoredResourceService()
export default new MonitoredResourceService()