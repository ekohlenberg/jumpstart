import React, { Component } from 'react'
import BudgetService from '../services/budget-service';



class BudgetCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.match.params.id,

                    id: '' ,
                
                    org_id: '' ,
                
                    category_id: '' ,
                
                    amount: '' ,
                
                    start_date: '' ,
                
                    end_date: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeOrgIdHandler = this.changeOrgIdHandler.bind(this);
                                    
                    this.changeCategoryIdHandler = this.changeCategoryIdHandler.bind(this);
                                    
                    this.changeAmountHandler = this.changeAmountHandler.bind(this);
                                    
                    this.changeStartDateHandler = this.changeStartDateHandler.bind(this);
                                    
                    this.changeEndDateHandler = this.changeEndDateHandler.bind(this);
                        this.saveOrUpdateBudget = this.saveOrUpdateBudget.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Budget componentDidMount() ID= " + this.state.id )
            BudgetService.getBudgetById(this.state.id).then( (res) =>{
                let budget = res.data;
                this.setState({

                            id: budget.id ,
                        
                            org_id: budget.org_id ,
                        
                            category_id: budget.category_id ,
                        
                            amount: budget.amount ,
                        
                            start_date: budget.start_date ,
                        
                            end_date: budget.end_date 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateBudget = (e) => {
        e.preventDefault();
        let budget = {

                    id: this.state.id , 
                
                    org_id: this.state.org_id , 
                
                    category_id: this.state.category_id , 
                
                    amount: this.state.amount , 
                
                    start_date: this.state.start_date , 
                
                    end_date: this.state.end_date  
                        };
        console.log('budget => ' + JSON.stringify(budget));

        // step 5
        if(this.state.id === '_add'){
            BudgetService.createBudget(budget).then(res =>{
                this.props.history.push('/budget');
            });
        }else{
            BudgetService.updateBudget(budget, this.state.id).then( res => {
                this.props.history.push('/budget');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeOrgIdHandler= (event) => {
            this.setState({org_id: event.target.value});
        }
        
        changeCategoryIdHandler= (event) => {
            this.setState({category_id: event.target.value});
        }
        
        changeAmountHandler= (event) => {
            this.setState({amount: event.target.value});
        }
        
        changeStartDateHandler= (event) => {
            this.setState({start_date: event.target.value});
        }
        
        changeEndDateHandler= (event) => {
            this.setState({end_date: event.target.value});
        }
            cancel(){
        this.props.history.push('/budget');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Budget</h3>
        }else{
            return <h3 className="text-center">Update Budget</h3>
        }
    }
    render() {
        return (
            <div>
                <br></br>
                   <div className = "container">
                        <div className = "row">
                            <div className = "card col-md-6 offset-md-3 offset-md-3">
                                {
                                    this.getTitle()
                                }
                                <div className = "card-body">
                                    <form>
                                        
                    
                                            <div className = "form-group">
                                            <br/>
                                            <label> Budget ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Organization ID: </label>
                                            <input placeholder="" name="org_id" className="form-control" 
                                                value={this.state.org_id} onChange={this.changeOrgIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Category ID: </label>
                                            <input placeholder="" name="category_id" className="form-control" 
                                                value={this.state.category_id} onChange={this.changeCategoryIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Amount: </label>
                                            <input placeholder="" name="amount" className="form-control" 
                                                value={this.state.amount} onChange={this.changeAmountHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Start Date: </label>
                                            <input placeholder="" name="start_date" className="form-control" 
                                                value={this.state.start_date} onChange={this.changeStartDateHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> End Date: </label>
                                            <input placeholder="" name="end_date" className="form-control" 
                                                value={this.state.end_date} onChange={this.changeEndDateHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateBudget}>Save</button>
                                        <button className="btn btn-danger" onClick={this.cancel.bind(this)} style={{marginLeft: "10px"}}>Cancel</button>
                                    </form>
                                </div>
                            </div>
                        </div>

                   </div>
            </div>
        )
    }
}

export default BudgetCreateComponent;