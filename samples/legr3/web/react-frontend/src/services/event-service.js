import axios from 'axios';

//const EVENT_API_BASE_URL = "http://localhost:5000/api/event";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const EVENT_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/event';


class EventService {

    getEvents(){
        return axios.get(EVENT_API_BASE_URL);
    }

    createEvent(event){
        return axios.post(EVENT_API_BASE_URL, event);
    }

    getEventById(eventId){
        return axios.get(EVENT_API_BASE_URL + '/' + eventId);
    }

    updateEvent(event, eventId){
        return axios.put(EVENT_API_BASE_URL + '/' + eventId, event);
    }

    deleteEvent(eventId){
        return axios.delete(EVENT_API_BASE_URL + '/' + eventId);
    }
}

//const exportedEventService =  new EventService()
export default new EventService()