import axios from 'axios';

//const SERVER_API_BASE_URL = "http://localhost:5000/api/server";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const SERVER_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/server';


class ServerService {

    getServers(){
        return axios.get(SERVER_API_BASE_URL);
    }

    createServer(server){
        return axios.post(SERVER_API_BASE_URL, server);
    }

    getServerById(serverId){
        return axios.get(SERVER_API_BASE_URL + '/' + serverId);
    }

    updateServer(server, serverId){
        return axios.put(SERVER_API_BASE_URL + '/' + serverId, server);
    }

    deleteServer(serverId){
        return axios.delete(SERVER_API_BASE_URL + '/' + serverId);
    }
}

//const exportedServerService =  new ServerService()
export default new ServerService()