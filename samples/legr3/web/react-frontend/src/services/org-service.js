import axios from 'axios';

//const ORG_API_BASE_URL = "http://localhost:5000/api/org";
const { apiProtocol } = window['runConfig'];
const { apiHost } = window['runConfig'];
const { apiPort } = window['runConfig'];

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

export default new OrgService()