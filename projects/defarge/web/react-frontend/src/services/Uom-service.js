import axios from 'axios';

//const UOM_API_BASE_URL = "http://localhost:5000/api/uom";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const UOM_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/uom';


class UomService {

    getUoms(){
        return axios.get(UOM_API_BASE_URL);
    }

    createUom(uom){
        return axios.post(UOM_API_BASE_URL, uom);
    }

    getUomById(uomId){
        return axios.get(UOM_API_BASE_URL + '/' + uomId);
    }

    updateUom(uom, uomId){
        return axios.put(UOM_API_BASE_URL + '/' + uomId, uom);
    }

    deleteUom(uomId){
        return axios.delete(UOM_API_BASE_URL + '/' + uomId);
    }
}

//const exportedUomService =  new UomService()
export default new UomService()