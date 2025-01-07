import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import TransactionService from '../services/transaction-service';

class TransactionListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                transactions: []
        }
        this.addTransaction = this.addTransaction.bind(this);
        this.editTransaction = this.editTransaction.bind(this);
        this.deleteTransaction = this.deleteTransaction.bind(this);
    }

    deleteTransaction(id){
        TransactionService.deleteTransaction(id).then( res => {
            this.setState({ transactions: this.state.transactions.filter(transaction => transaction.id !== id) });
        });
    }
    viewTransaction(id){
        this.props.navigate(`/view-transaction/${id}`);
    }
    editTransaction(id){
        console.log("editing " + id)
        this.props.navigate(`/add-transaction/${id}`);
    }

    componentDidMount(){
        TransactionService.getTransactions().then((res) => {
            this.setState({ transactions: res.data});
        });
    }

    addTransaction(){
        this.props.navigate('/add-transaction/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Transaction List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addTransaction}> Add Transaction</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Transaction ID</th>
                                    
                                    <th>Account ID</th>
                                    
                                    <th>Organization ID</th>
                                    
                                    <th>Transaction Date</th>
                                    
                                    <th>Amount</th>
                                    
                                    <th>Transaction Type</th>
                                    
                                    <th>Description</th>
                                    
                                    <th>Created Date</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.transactions.map(
                                        transaction => 
                                        <tr key = { transaction.id }>

                                                <td> { transaction.id } </td>  
                                                
                                                <td> { transaction.account_id } </td>  
                                                
                                                <td> { transaction.org_id } </td>  
                                                
                                                <td> { transaction.transaction_date } </td>  
                                                
                                                <td> { transaction.amount } </td>  
                                                
                                                <td> { transaction.transaction_type } </td>  
                                                
                                                <td> { transaction.description } </td>  
                                                
                                                <td> { transaction.created_date } </td>  
                                                
                                                <td> { transaction.is_active } </td>  
                                                
                                                <td> { transaction.created_by } </td>  
                                                
                                                <td> { transaction.last_updated } </td>  
                                                
                                                <td> { transaction.last_updated_by } </td>  
                                                
                                                <td> { transaction.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editTransaction(transaction.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteTransaction(transaction.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(TransactionListComponent);