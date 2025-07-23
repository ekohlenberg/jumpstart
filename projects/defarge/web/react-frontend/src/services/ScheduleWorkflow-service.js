import axios from 'axios';

//const SCHEDULEWORKFLOW_API_BASE_URL = "http://localhost:5000/api/scheduleworkflow";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const SCHEDULEWORKFLOW_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/scheduleworkflow';


class ScheduleWorkflowService {

    getScheduleWorkflows(){
        return axios.get(SCHEDULEWORKFLOW_API_BASE_URL);
    }

    createScheduleWorkflow(scheduleworkflow){
        return axios.post(SCHEDULEWORKFLOW_API_BASE_URL, scheduleworkflow);
    }

    getScheduleWorkflowById(scheduleworkflowId){
        return axios.get(SCHEDULEWORKFLOW_API_BASE_URL + '/' + scheduleworkflowId);
    }

    updateScheduleWorkflow(scheduleworkflow, scheduleworkflowId){
        return axios.put(SCHEDULEWORKFLOW_API_BASE_URL + '/' + scheduleworkflowId, scheduleworkflow);
    }

    deleteScheduleWorkflow(scheduleworkflowId){
        return axios.delete(SCHEDULEWORKFLOW_API_BASE_URL + '/' + scheduleworkflowId);
    }
}

//const exportedScheduleWorkflowService =  new ScheduleWorkflowService()
export default new ScheduleWorkflowService()