import axios from 'axios';

//const BILL_API_BASE_URL = "http://localhost:5000/api/bill";
const { apiProtocol } = window['runConfig'];
const { apiHost } = window['runConfig'];
const { apiPort } = window['runConfig'];

const BILL_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/bill';


class BillService {

    getBills(){
        return axios.get(BILL_API_BASE_URL);
    }

    createBill(bill){
        return axios.post(BILL_API_BASE_URL, bill);
    }

    getBillById(billId){
        return axios.get(BILL_API_BASE_URL + '/' + billId);
    }

    updateBill(bill, billId){
        return axios.put(BILL_API_BASE_URL + '/' + billId, bill);
    }

    deleteBill(billId){
        return axios.delete(BILL_API_BASE_URL + '/' + billId);
    }
}

export default new BillService()