import React, { Component } from 'react'
import BudgetService from '../services/BudgetService';

class BudgetListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                budgets: []
        }
        this.addBudget = this.addBudget.bind(this);
        this.editBudget = this.editBudget.bind(this);
        this.deleteBudget = this.deleteBudget.bind(this);
    }

    deleteBudget(id){
        BudgetService.deleteBudget(id).then( res => {
            this.setState({budgets: this.state.budgets.filter(budget => budget.id !== id)});
        });
    }
    viewBudget(id){
        this.props.history.push(`/view-budget/${id}`);
    }
    editBudget(id){
        console.log("editing " + id)
        this.props.history.push(`/add-budget/${id}`);
    }

    componentDidMount(){
        BudgetService.getBudgets().then((res) => {
            this.setState({ budgets: res.data});
        });
    }

    addBudget(){
        this.props.history.push('/add-budget/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Budget List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addBudget}> Add Budget</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Budget ID</th>
                                    
                                    <th>Organization ID</th>
                                    
                                    <th>Category ID</th>
                                    
                                    <th>Amount</th>
                                    
                                    <th>Start Date</th>
                                    
                                    <th>End Date</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.budgets.map(
                                        budget => 
                                        <tr key = {@(Model.DomainVar).id}>

                                                <td> {budget.id)} </td>  
                                                
                                                <td> {budget.org_id)} </td>  
                                                
                                                <td> {budget.category_id)} </td>  
                                                
                                                <td> {budget.amount)} </td>  
                                                
                                                <td> {budget.start_date)} </td>  
                                                
                                                <td> {budget.end_date)} </td>  
                                                
                                                <td> {budget.is_active)} </td>  
                                                
                                                <td> {budget.created_by)} </td>  
                                                
                                                <td> {budget.last_updated)} </td>  
                                                
                                                <td> {budget.last_updated_by)} </td>  
                                                
                                                <td> {budget.version)} </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editBudget(budget.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteBudget(budget.id)} className="btn btn-danger">Delete </button>
                                                
                                             </td>
                                        </tr>
                                    )
                                }
                            </tbody>
                        </table>

                 </div>

            </div>
        )
    }
}

export default BudgetListComponent;