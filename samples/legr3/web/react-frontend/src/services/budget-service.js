import axios from 'axios';

//const BUDGET_API_BASE_URL = "http://localhost:5000/api/budget";
const apiProtocol = process.env.REACT_APP_API_PROTOCOL;
const apiHost = process.env.REACT_APP_API_HOST;
const apiPort = process.env.REACT_APP_API_PORT;

console.log(`API Endpoint: ${apiProtocol}://${apiHost}:${apiPort}`);

const BUDGET_API_BASE_URL = apiProtocol + '://' + apiHost +':' +  apiPort + '/api/budget';


class BudgetService {

    getBudgets(){
        return axios.get(BUDGET_API_BASE_URL);
    }

    createBudget(budget){
        return axios.post(BUDGET_API_BASE_URL, budget);
    }

    getBudgetById(budgetId){
        return axios.get(BUDGET_API_BASE_URL + '/' + budgetId);
    }

    updateBudget(budget, budgetId){
        return axios.put(BUDGET_API_BASE_URL + '/' + budgetId, budget);
    }

    deleteBudget(budgetId){
        return axios.delete(BUDGET_API_BASE_URL + '/' + budgetId);
    }
}

//const exportedBudgetService =  new BudgetService()
export default new BudgetService()