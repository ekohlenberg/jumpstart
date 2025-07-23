import axios from 'axios';

//const METRIC_API_BASE_URL = "http://localhost:5000/api/metric";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const METRIC_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/metric';


class MetricService {

    getMetrics(){
        return axios.get(METRIC_API_BASE_URL);
    }

    createMetric(metric){
        return axios.post(METRIC_API_BASE_URL, metric);
    }

    getMetricById(metricId){
        return axios.get(METRIC_API_BASE_URL + '/' + metricId);
    }

    updateMetric(metric, metricId){
        return axios.put(METRIC_API_BASE_URL + '/' + metricId, metric);
    }

    deleteMetric(metricId){
        return axios.delete(METRIC_API_BASE_URL + '/' + metricId);
    }
}

//const exportedMetricService =  new MetricService()
export default new MetricService()