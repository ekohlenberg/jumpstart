import axios from 'axios';

//const INVOICEITEM_API_BASE_URL = "http://localhost:5000/api/invoiceitem";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const INVOICEITEM_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/invoiceitem';


class InvoiceItemService {

    getInvoiceItems(){
        return axios.get(INVOICEITEM_API_BASE_URL);
    }

    createInvoiceItem(invoiceitem){
        return axios.post(INVOICEITEM_API_BASE_URL, invoiceitem);
    }

    getInvoiceItemById(invoiceitemId){
        return axios.get(INVOICEITEM_API_BASE_URL + '/' + invoiceitemId);
    }

    updateInvoiceItem(invoiceitem, invoiceitemId){
        return axios.put(INVOICEITEM_API_BASE_URL + '/' + invoiceitemId, invoiceitem);
    }

    deleteInvoiceItem(invoiceitemId){
        return axios.delete(INVOICEITEM_API_BASE_URL + '/' + invoiceitemId);
    }
}

//const exportedInvoiceItemService =  new InvoiceItemService()
export default new InvoiceItemService()