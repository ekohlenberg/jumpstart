import axios from 'axios';

//const EVENTSERVICE_API_BASE_URL = "http://localhost:5000/api/eventservice";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const EVENTSERVICE_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/eventservice';


class EventServiceService {

    getEventServices(){
        return axios.get(EVENTSERVICE_API_BASE_URL);
    }

    createEventService(eventservice){
        return axios.post(EVENTSERVICE_API_BASE_URL, eventservice);
    }

    getEventServiceById(eventserviceId){
        return axios.get(EVENTSERVICE_API_BASE_URL + '/' + eventserviceId);
    }

    updateEventService(eventservice, eventserviceId){
        return axios.put(EVENTSERVICE_API_BASE_URL + '/' + eventserviceId, eventservice);
    }

    deleteEventService(eventserviceId){
        return axios.delete(EVENTSERVICE_API_BASE_URL + '/' + eventserviceId);
    }
}

//const exportedEventServiceService =  new EventServiceService()
export default new EventServiceService()