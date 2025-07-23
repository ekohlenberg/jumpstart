import axios from 'axios';

//const PROCESS_API_BASE_URL = "http://localhost:5000/api/process";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const PROCESS_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/process';


class ProcessService {

    getProcesss(){
        return axios.get(PROCESS_API_BASE_URL);
    }

    createProcess(process){
        return axios.post(PROCESS_API_BASE_URL, process);
    }

    getProcessById(processId){
        return axios.get(PROCESS_API_BASE_URL + '/' + processId);
    }

    updateProcess(process, processId){
        return axios.put(PROCESS_API_BASE_URL + '/' + processId, process);
    }

    deleteProcess(processId){
        return axios.delete(PROCESS_API_BASE_URL + '/' + processId);
    }
}

//const exportedProcessService =  new ProcessService()
export default new ProcessService()