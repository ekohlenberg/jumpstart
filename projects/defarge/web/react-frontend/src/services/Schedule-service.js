import axios from 'axios';

//const SCHEDULE_API_BASE_URL = "http://localhost:5000/api/schedule";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const SCHEDULE_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/schedule';


class ScheduleService {

    getSchedules(){
        return axios.get(SCHEDULE_API_BASE_URL);
    }

    createSchedule(schedule){
        return axios.post(SCHEDULE_API_BASE_URL, schedule);
    }

    getScheduleById(scheduleId){
        return axios.get(SCHEDULE_API_BASE_URL + '/' + scheduleId);
    }

    updateSchedule(schedule, scheduleId){
        return axios.put(SCHEDULE_API_BASE_URL + '/' + scheduleId, schedule);
    }

    deleteSchedule(scheduleId){
        return axios.delete(SCHEDULE_API_BASE_URL + '/' + scheduleId);
    }
}

//const exportedScheduleService =  new ScheduleService()
export default new ScheduleService()