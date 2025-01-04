import React, { Component } from 'react'
import TransactionCategoryService from '../services/transaction_category-service';

class TransactionCategoryListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                transactioncategorys: []
        }
        this.addTransactionCategory = this.addTransactionCategory.bind(this);
        this.editTransactionCategory = this.editTransactionCategory.bind(this);
        this.deleteTransactionCategory = this.deleteTransactionCategory.bind(this);
    }

    deleteTransactionCategory(id){
        TransactionCategoryService.deleteTransactionCategory(id).then( res => {
            this.setState({ transactioncategorys: this.state.transactioncategorys.filter(transactioncategory => transactioncategory.id !== id) });
        });
    }
    viewTransactionCategory(id){
        this.props.history.push(`/view-transactioncategory/${id}`);
    }
    editTransactionCategory(id){
        console.log("editing " + id)
        this.props.history.push(`/add-transactioncategory/${id}`);
    }

    componentDidMount(){
        TransactionCategoryService.getTransactionCategorys().then((res) => {
            this.setState({ transactioncategorys: res.data});
        });
    }

    addTransactionCategory(){
        this.props.history.push('/add-transactioncategory/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">TransactionCategory List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addTransactionCategory}> Add TransactionCategory</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Transaction-Category ID</th>
                                    
                                    <th>Transaction ID</th>
                                    
                                    <th>Category ID</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.transactioncategorys.map(
                                        transactioncategory => 
                                        <tr key = { transactioncategory.id }>

                                                <td> { transactioncategory.id } </td>  
                                                
                                                <td> { transactioncategory.transaction_id } </td>  
                                                
                                                <td> { transactioncategory.category_id } </td>  
                                                
                                                <td> { transactioncategory.is_active } </td>  
                                                
                                                <td> { transactioncategory.created_by } </td>  
                                                
                                                <td> { transactioncategory.last_updated } </td>  
                                                
                                                <td> { transactioncategory.last_updated_by } </td>  
                                                
                                                <td> { transactioncategory.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editTransactionCategory(transactioncategory.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteTransactionCategory(transactioncategory.id)} className="btn btn-danger">Delete </button>
                                                
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

export default TransactionCategoryListComponent;