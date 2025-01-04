import axios from 'axios';

//const BILLITEM_API_BASE_URL = "http://localhost:5000/api/billitem";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const BILLITEM_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/billitem';


class BillItemService {

    getBillItems(){
        return axios.get(BILLITEM_API_BASE_URL);
    }

    createBillItem(billitem){
        return axios.post(BILLITEM_API_BASE_URL, billitem);
    }

    getBillItemById(billitemId){
        return axios.get(BILLITEM_API_BASE_URL + '/' + billitemId);
    }

    updateBillItem(billitem, billitemId){
        return axios.put(BILLITEM_API_BASE_URL + '/' + billitemId, billitem);
    }

    deleteBillItem(billitemId){
        return axios.delete(BILLITEM_API_BASE_URL + '/' + billitemId);
    }
}

//const exportedBillItemService =  new BillItemService()
export default new BillItemService()