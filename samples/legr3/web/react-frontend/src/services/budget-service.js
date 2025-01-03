import axios from 'axios';

//const BUDGET_API_BASE_URL = "http://localhost:5000/api/budget";
const { apiProtocol } = window['runConfig'];
const { apiHost } = window['runConfig'];
const { apiPort } = window['runConfig'];

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

export default new BudgetService()