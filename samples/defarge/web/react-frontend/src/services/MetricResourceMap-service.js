import axios from 'axios';

//const METRICRESOURCEMAP_API_BASE_URL = "http://localhost:5000/api/metricresourcemap";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const METRICRESOURCEMAP_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/metricresourcemap';


class MetricResourceMapService {

    getMetricResourceMaps(){
        return axios.get(METRICRESOURCEMAP_API_BASE_URL);
    }

    createMetricResourceMap(metricresourcemap){
        return axios.post(METRICRESOURCEMAP_API_BASE_URL, metricresourcemap);
    }

    getMetricResourceMapById(metricresourcemapId){
        return axios.get(METRICRESOURCEMAP_API_BASE_URL + '/' + metricresourcemapId);
    }

    updateMetricResourceMap(metricresourcemap, metricresourcemapId){
        return axios.put(METRICRESOURCEMAP_API_BASE_URL + '/' + metricresourcemapId, metricresourcemap);
    }

    deleteMetricResourceMap(metricresourcemapId){
        return axios.delete(METRICRESOURCEMAP_API_BASE_URL + '/' + metricresourcemapId);
    }
}

//const exportedMetricResourceMapService =  new MetricResourceMapService()
export default new MetricResourceMapService()