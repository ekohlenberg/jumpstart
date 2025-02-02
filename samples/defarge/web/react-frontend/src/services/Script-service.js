import axios from 'axios';

//const SCRIPT_API_BASE_URL = "http://localhost:5000/api/script";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const SCRIPT_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/script';


class ScriptService {

    getScripts(){
        return axios.get(SCRIPT_API_BASE_URL);
    }

    createScript(script){
        return axios.post(SCRIPT_API_BASE_URL, script);
    }

    getScriptById(scriptId){
        return axios.get(SCRIPT_API_BASE_URL + '/' + scriptId);
    }

    updateScript(script, scriptId){
        return axios.put(SCRIPT_API_BASE_URL + '/' + scriptId, script);
    }

    deleteScript(scriptId){
        return axios.delete(SCRIPT_API_BASE_URL + '/' + scriptId);
    }
}

//const exportedScriptService =  new ScriptService()
export default new ScriptService()