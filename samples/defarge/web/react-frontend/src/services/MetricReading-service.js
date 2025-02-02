import axios from 'axios';

//const METRICREADING_API_BASE_URL = "http://localhost:5000/api/metricreading";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const METRICREADING_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/metricreading';


class MetricReadingService {

    getMetricReadings(){
        return axios.get(METRICREADING_API_BASE_URL);
    }

    createMetricReading(metricreading){
        return axios.post(METRICREADING_API_BASE_URL, metricreading);
    }

    getMetricReadingById(metricreadingId){
        return axios.get(METRICREADING_API_BASE_URL + '/' + metricreadingId);
    }

    updateMetricReading(metricreading, metricreadingId){
        return axios.put(METRICREADING_API_BASE_URL + '/' + metricreadingId, metricreading);
    }

    deleteMetricReading(metricreadingId){
        return axios.delete(METRICREADING_API_BASE_URL + '/' + metricreadingId);
    }
}

//const exportedMetricReadingService =  new MetricReadingService()
export default new MetricReadingService()