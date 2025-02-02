import axios from 'axios';

//const ALERT_API_BASE_URL = "http://localhost:5000/api/alert";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const ALERT_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/alert';


class AlertService {

    getAlerts(){
        return axios.get(ALERT_API_BASE_URL);
    }

    createAlert(alert){
        return axios.post(ALERT_API_BASE_URL, alert);
    }

    getAlertById(alertId){
        return axios.get(ALERT_API_BASE_URL + '/' + alertId);
    }

    updateAlert(alert, alertId){
        return axios.put(ALERT_API_BASE_URL + '/' + alertId, alert);
    }

    deleteAlert(alertId){
        return axios.delete(ALERT_API_BASE_URL + '/' + alertId);
    }
}

//const exportedAlertService =  new AlertService()
export default new AlertService()