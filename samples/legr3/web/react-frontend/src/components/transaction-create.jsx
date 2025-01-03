import React, { Component } from 'react'
import TransactionService from '../services/TransactionService';



class TransactionCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.match.params.id,

                    id: '' ,
                
                    account_id: '' ,
                
                    org_id: '' ,
                
                    transaction_date: '' ,
                
                    amount: '' ,
                
                    transaction_type: '' ,
                
                    description: '' ,
                
                    created_date: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeAccountIdHandler = this.changeAccountIdHandler.bind(this);
                                    
                    this.changeOrgIdHandler = this.changeOrgIdHandler.bind(this);
                                    
                    this.changeTransactionDateHandler = this.changeTransactionDateHandler.bind(this);
                                    
                    this.changeAmountHandler = this.changeAmountHandler.bind(this);
                                    
                    this.changeTransactionTypeHandler = this.changeTransactionTypeHandler.bind(this);
                                    
                    this.changeDescriptionHandler = this.changeDescriptionHandler.bind(this);
                                    
                    this.changeCreatedDateHandler = this.changeCreatedDateHandler.bind(this);
                        this.saveOrUpdateTransaction = this.saveOrUpdateTransaction.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Transaction componentDidMount() ID= " + this.state.id )
            TransactionService.getTransactionById(this.state.id).then( (res) =>{
                let transaction = res.data;
                this.setState({

                            id: transaction.id ,
                        
                            account_id: transaction.account_id ,
                        
                            org_id: transaction.org_id ,
                        
                            transaction_date: transaction.transaction_date ,
                        
                            amount: transaction.amount ,
                        
                            transaction_type: transaction.transaction_type ,
                        
                            description: transaction.description ,
                        
                            created_date: transaction.created_date 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateTransaction = (e) => {
        e.preventDefault();
        let transaction = {

                    id: this.state.id , 
                
                    account_id: this.state.account_id , 
                
                    org_id: this.state.org_id , 
                
                    transaction_date: this.state.transaction_date , 
                
                    amount: this.state.amount , 
                
                    transaction_type: this.state.transaction_type , 
                
                    description: this.state.description , 
                
                    created_date: this.state.created_date  
                        };
        console.log('transaction => ' + JSON.stringify(transaction));

        // step 5
        if(this.state.id === '_add'){
            TransactionService.createTransaction(transaction).then(res =>{
                this.props.history.push('/transaction');
            });
        }else{
            TransactionService.updateTransaction(transaction, this.state.id).then( res => {
                this.props.history.push('/transaction');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeAccountIdHandler= (event) => {
            this.setState({account_id: event.target.value});
        }
        
        changeOrgIdHandler= (event) => {
            this.setState({org_id: event.target.value});
        }
        
        changeTransactionDateHandler= (event) => {
            this.setState({transaction_date: event.target.value});
        }
        
        changeAmountHandler= (event) => {
            this.setState({amount: event.target.value});
        }
        
        changeTransactionTypeHandler= (event) => {
            this.setState({transaction_type: event.target.value});
        }
        
        changeDescriptionHandler= (event) => {
            this.setState({description: event.target.value});
        }
        
        changeCreatedDateHandler= (event) => {
            this.setState({created_date: event.target.value});
        }
            cancel(){
        this.props.history.push('/transaction');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Transaction</h3>
        }else{
            return <h3 className="text-center">Update Transaction</h3>
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
                                            <label> Transaction ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Account ID: </label>
                                            <input placeholder="" name="account_id" className="form-control" 
                                                value={this.state.account_id} onChange={this.changeAccountIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Organization ID: </label>
                                            <input placeholder="" name="org_id" className="form-control" 
                                                value={this.state.org_id} onChange={this.changeOrgIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Transaction Date: </label>
                                            <input placeholder="" name="transaction_date" className="form-control" 
                                                value={this.state.transaction_date} onChange={this.changeTransactionDateHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Amount: </label>
                                            <input placeholder="" name="amount" className="form-control" 
                                                value={this.state.amount} onChange={this.changeAmountHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Transaction Type: </label>
                                            <input placeholder="" name="transaction_type" className="form-control" 
                                                value={this.state.transaction_type} onChange={this.changeTransactionTypeHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Description: </label>
                                            <input placeholder="" name="description" className="form-control" 
                                                value={this.state.description} onChange={this.changeDescriptionHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Created Date: </label>
                                            <input placeholder="" name="created_date" className="form-control" 
                                                value={this.state.created_date} onChange={this.changeCreatedDateHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateTransaction}>Save</button>
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

export default TransactionCreateComponent;