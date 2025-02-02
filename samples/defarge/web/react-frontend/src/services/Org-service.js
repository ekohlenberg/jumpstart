import axios from 'axios';

//const ORG_API_BASE_URL = "http://localhost:5000/api/org";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const ORG_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/org';


class OrgService {

    getOrgs(){
        return axios.get(ORG_API_BASE_URL);
    }

    createOrg(org){
        return axios.post(ORG_API_BASE_URL, org);
    }

    getOrgById(orgId){
        return axios.get(ORG_API_BASE_URL + '/' + orgId);
    }

    updateOrg(org, orgId){
        return axios.put(ORG_API_BASE_URL + '/' + orgId, org);
    }

    deleteOrg(orgId){
        return axios.delete(ORG_API_BASE_URL + '/' + orgId);
    }
}

//const exportedOrgService =  new OrgService()
export default new OrgService()