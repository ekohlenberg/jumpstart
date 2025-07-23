import axios from 'axios';

//const WORKFLOW_API_BASE_URL = "http://localhost:5000/api/workflow";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const WORKFLOW_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/workflow';


class WorkflowService {

    getWorkflows(){
        return axios.get(WORKFLOW_API_BASE_URL);
    }

    createWorkflow(workflow){
        return axios.post(WORKFLOW_API_BASE_URL, workflow);
    }

    getWorkflowById(workflowId){
        return axios.get(WORKFLOW_API_BASE_URL + '/' + workflowId);
    }

    updateWorkflow(workflow, workflowId){
        return axios.put(WORKFLOW_API_BASE_URL + '/' + workflowId, workflow);
    }

    deleteWorkflow(workflowId){
        return axios.delete(WORKFLOW_API_BASE_URL + '/' + workflowId);
    }
}

//const exportedWorkflowService =  new WorkflowService()
export default new WorkflowService()