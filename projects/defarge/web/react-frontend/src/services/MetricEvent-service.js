import axios from 'axios';

//const METRICEVENT_API_BASE_URL = "http://localhost:5000/api/metricevent";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const METRICEVENT_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/metricevent';


class MetricEventService {

    getMetricEvents(){
        return axios.get(METRICEVENT_API_BASE_URL);
    }

    createMetricEvent(metricevent){
        return axios.post(METRICEVENT_API_BASE_URL, metricevent);
    }

    getMetricEventById(metriceventId){
        return axios.get(METRICEVENT_API_BASE_URL + '/' + metriceventId);
    }

    updateMetricEvent(metricevent, metriceventId){
        return axios.put(METRICEVENT_API_BASE_URL + '/' + metriceventId, metricevent);
    }

    deleteMetricEvent(metriceventId){
        return axios.delete(METRICEVENT_API_BASE_URL + '/' + metriceventId);
    }
}

//const exportedMetricEventService =  new MetricEventService()
export default new MetricEventService()