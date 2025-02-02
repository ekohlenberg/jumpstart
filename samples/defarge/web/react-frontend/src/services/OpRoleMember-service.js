import axios from 'axios';

//const OPROLEMEMBER_API_BASE_URL = "http://localhost:5000/api/oprolemember";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const OPROLEMEMBER_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/oprolemember';


class OpRoleMemberService {

    getOpRoleMembers(){
        return axios.get(OPROLEMEMBER_API_BASE_URL);
    }

    createOpRoleMember(oprolemember){
        return axios.post(OPROLEMEMBER_API_BASE_URL, oprolemember);
    }

    getOpRoleMemberById(oprolememberId){
        return axios.get(OPROLEMEMBER_API_BASE_URL + '/' + oprolememberId);
    }

    updateOpRoleMember(oprolemember, oprolememberId){
        return axios.put(OPROLEMEMBER_API_BASE_URL + '/' + oprolememberId, oprolemember);
    }

    deleteOpRoleMember(oprolememberId){
        return axios.delete(OPROLEMEMBER_API_BASE_URL + '/' + oprolememberId);
    }
}

//const exportedOpRoleMemberService =  new OpRoleMemberService()
export default new OpRoleMemberService()