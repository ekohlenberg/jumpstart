import axios from 'axios';

//const EXECUTION_API_BASE_URL = "http://localhost:5000/api/execution";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const EXECUTION_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/execution';


class ExecutionService {

    getExecutions(){
        return axios.get(EXECUTION_API_BASE_URL);
    }

    createExecution(execution){
        return axios.post(EXECUTION_API_BASE_URL, execution);
    }

    getExecutionById(executionId){
        return axios.get(EXECUTION_API_BASE_URL + '/' + executionId);
    }

    updateExecution(execution, executionId){
        return axios.put(EXECUTION_API_BASE_URL + '/' + executionId, execution);
    }

    deleteExecution(executionId){
        return axios.delete(EXECUTION_API_BASE_URL + '/' + executionId);
    }
}

//const exportedExecutionService =  new ExecutionService()
export default new ExecutionService()