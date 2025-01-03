import axios from 'axios';

//const INVOICEITEM_API_BASE_URL = "http://localhost:5000/api/invoiceitem";
const { apiProtocol } = window['runConfig'];
const { apiHost } = window['runConfig'];
const { apiPort } = window['runConfig'];

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

export default new InvoiceItemService()