import axios from 'axios';

//const ONEVENT_API_BASE_URL = "http://localhost:5000/api/onevent";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const ONEVENT_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/onevent';


class OnEventService {

    getOnEvents(){
        return axios.get(ONEVENT_API_BASE_URL);
    }

    createOnEvent(onevent){
        return axios.post(ONEVENT_API_BASE_URL, onevent);
    }

    getOnEventById(oneventId){
        return axios.get(ONEVENT_API_BASE_URL + '/' + oneventId);
    }

    updateOnEvent(onevent, oneventId){
        return axios.put(ONEVENT_API_BASE_URL + '/' + oneventId, onevent);
    }

    deleteOnEvent(oneventId){
        return axios.delete(ONEVENT_API_BASE_URL + '/' + oneventId);
    }
}

//const exportedOnEventService =  new OnEventService()
export default new OnEventService()