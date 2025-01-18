import axios from 'axios';

//const ACTION_API_BASE_URL = "http://localhost:5000/api/action";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const ACTION_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/action';


class ActionService {

    getActions(){
        return axios.get(ACTION_API_BASE_URL);
    }

    createAction(action){
        return axios.post(ACTION_API_BASE_URL, action);
    }

    getActionById(actionId){
        return axios.get(ACTION_API_BASE_URL + '/' + actionId);
    }

    updateAction(action, actionId){
        return axios.put(ACTION_API_BASE_URL + '/' + actionId, action);
    }

    deleteAction(actionId){
        return axios.delete(ACTION_API_BASE_URL + '/' + actionId);
    }
}

//const exportedActionService =  new ActionService()
export default new ActionService()