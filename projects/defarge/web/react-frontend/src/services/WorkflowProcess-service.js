import axios from 'axios';

//const WORKFLOWPROCESS_API_BASE_URL = "http://localhost:5000/api/workflowprocess";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const WORKFLOWPROCESS_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/workflowprocess';


class WorkflowProcessService {

    getWorkflowProcesss(){
        return axios.get(WORKFLOWPROCESS_API_BASE_URL);
    }

    createWorkflowProcess(workflowprocess){
        return axios.post(WORKFLOWPROCESS_API_BASE_URL, workflowprocess);
    }

    getWorkflowProcessById(workflowprocessId){
        return axios.get(WORKFLOWPROCESS_API_BASE_URL + '/' + workflowprocessId);
    }

    updateWorkflowProcess(workflowprocess, workflowprocessId){
        return axios.put(WORKFLOWPROCESS_API_BASE_URL + '/' + workflowprocessId, workflowprocess);
    }

    deleteWorkflowProcess(workflowprocessId){
        return axios.delete(WORKFLOWPROCESS_API_BASE_URL + '/' + workflowprocessId);
    }
}

//const exportedWorkflowProcessService =  new WorkflowProcessService()
export default new WorkflowProcessService()