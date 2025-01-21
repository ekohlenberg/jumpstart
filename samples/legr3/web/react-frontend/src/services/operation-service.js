import axios from 'axios';

//const OPERATION_API_BASE_URL = "http://localhost:5000/api/operation";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const OPERATION_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/operation';


class OperationService {

    getOperations(){
        return axios.get(OPERATION_API_BASE_URL);
    }

    createOperation(operation){
        return axios.post(OPERATION_API_BASE_URL, operation);
    }

    getOperationById(operationId){
        return axios.get(OPERATION_API_BASE_URL + '/' + operationId);
    }

    updateOperation(operation, operationId){
        return axios.put(OPERATION_API_BASE_URL + '/' + operationId, operation);
    }

    deleteOperation(operationId){
        return axios.delete(OPERATION_API_BASE_URL + '/' + operationId);
    }
}

//const exportedOperationService =  new OperationService()
export default new OperationService()