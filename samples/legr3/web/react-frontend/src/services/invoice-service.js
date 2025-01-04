import axios from 'axios';

//const INVOICE_API_BASE_URL = "http://localhost:5000/api/invoice";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const INVOICE_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/invoice';


class InvoiceService {

    getInvoices(){
        return axios.get(INVOICE_API_BASE_URL);
    }

    createInvoice(invoice){
        return axios.post(INVOICE_API_BASE_URL, invoice);
    }

    getInvoiceById(invoiceId){
        return axios.get(INVOICE_API_BASE_URL + '/' + invoiceId);
    }

    updateInvoice(invoice, invoiceId){
        return axios.put(INVOICE_API_BASE_URL + '/' + invoiceId, invoice);
    }

    deleteInvoice(invoiceId){
        return axios.delete(INVOICE_API_BASE_URL + '/' + invoiceId);
    }
}

//const exportedInvoiceService =  new InvoiceService()
export default new InvoiceService()