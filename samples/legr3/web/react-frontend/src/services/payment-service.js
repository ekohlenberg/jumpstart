import axios from 'axios';

//const PAYMENT_API_BASE_URL = "http://localhost:5000/api/payment";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const PAYMENT_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/payment';


class PaymentService {

    getPayments(){
        return axios.get(PAYMENT_API_BASE_URL);
    }

    createPayment(payment){
        return axios.post(PAYMENT_API_BASE_URL, payment);
    }

    getPaymentById(paymentId){
        return axios.get(PAYMENT_API_BASE_URL + '/' + paymentId);
    }

    updatePayment(payment, paymentId){
        return axios.put(PAYMENT_API_BASE_URL + '/' + paymentId, payment);
    }

    deletePayment(paymentId){
        return axios.delete(PAYMENT_API_BASE_URL + '/' + paymentId);
    }
}

//const exportedPaymentService =  new PaymentService()
export default new PaymentService()