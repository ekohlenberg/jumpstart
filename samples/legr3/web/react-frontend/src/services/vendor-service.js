import axios from 'axios';

//const VENDOR_API_BASE_URL = "http://localhost:5000/api/vendor";
const { apiProtocol } = window['runConfig'];
const { apiHost } = window['runConfig'];
const { apiPort } = window['runConfig'];

const VENDOR_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/vendor';


class VendorService {

    getVendors(){
        return axios.get(VENDOR_API_BASE_URL);
    }

    createVendor(vendor){
        return axios.post(VENDOR_API_BASE_URL, vendor);
    }

    getVendorById(vendorId){
        return axios.get(VENDOR_API_BASE_URL + '/' + vendorId);
    }

    updateVendor(vendor, vendorId){
        return axios.put(VENDOR_API_BASE_URL + '/' + vendorId, vendor);
    }

    deleteVendor(vendorId){
        return axios.delete(VENDOR_API_BASE_URL + '/' + vendorId);
    }
}

export default new VendorService()