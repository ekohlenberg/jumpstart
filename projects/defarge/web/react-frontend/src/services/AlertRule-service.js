import axios from 'axios';

//const ALERTRULE_API_BASE_URL = "http://localhost:5000/api/alertrule";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const ALERTRULE_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/alertrule';


class AlertRuleService {

    getAlertRules(){
        return axios.get(ALERTRULE_API_BASE_URL);
    }

    createAlertRule(alertrule){
        return axios.post(ALERTRULE_API_BASE_URL, alertrule);
    }

    getAlertRuleById(alertruleId){
        return axios.get(ALERTRULE_API_BASE_URL + '/' + alertruleId);
    }

    updateAlertRule(alertrule, alertruleId){
        return axios.put(ALERTRULE_API_BASE_URL + '/' + alertruleId, alertrule);
    }

    deleteAlertRule(alertruleId){
        return axios.delete(ALERTRULE_API_BASE_URL + '/' + alertruleId);
    }
}

//const exportedAlertRuleService =  new AlertRuleService()
export default new AlertRuleService()