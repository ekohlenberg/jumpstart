import React, { Component } from 'react'
import TransactionCategoryService from '../services/TransactionCategoryService';



class TransactionCategoryCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.match.params.id,

                    id: '' ,
                
                    transaction_id: '' ,
                
                    category_id: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeTransactionIdHandler = this.changeTransactionIdHandler.bind(this);
                                    
                    this.changeCategoryIdHandler = this.changeCategoryIdHandler.bind(this);
                        this.saveOrUpdateTransactionCategory = this.saveOrUpdateTransactionCategory.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("TransactionCategory componentDidMount() ID= " + this.state.id )
            TransactionCategoryService.getTransactionCategoryById(this.state.id).then( (res) =>{
                let transactioncategory = res.data;
                this.setState({

                            id: transactioncategory.id ,
                        
                            transaction_id: transactioncategory.transaction_id ,
                        
                            category_id: transactioncategory.category_id 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateTransactionCategory = (e) => {
        e.preventDefault();
        let transactioncategory = {

                    id: this.state.id , 
                
                    transaction_id: this.state.transaction_id , 
                
                    category_id: this.state.category_id  
                        };
        console.log('transactioncategory => ' + JSON.stringify(transactioncategory));

        // step 5
        if(this.state.id === '_add'){
            TransactionCategoryService.createTransactionCategory(transactioncategory).then(res =>{
                this.props.history.push('/transactioncategory');
            });
        }else{
            TransactionCategoryService.updateTransactionCategory(transactioncategory, this.state.id).then( res => {
                this.props.history.push('/transactioncategory');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeTransactionIdHandler= (event) => {
            this.setState({transaction_id: event.target.value});
        }
        
        changeCategoryIdHandler= (event) => {
            this.setState({category_id: event.target.value});
        }
            cancel(){
        this.props.history.push('/transactioncategory');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add TransactionCategory</h3>
        }else{
            return <h3 className="text-center">Update TransactionCategory</h3>
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
                                            <label> Transaction-Category ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Transaction ID: </label>
                                            <input placeholder="" name="transaction_id" className="form-control" 
                                                value={this.state.transaction_id} onChange={this.changeTransactionIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Category ID: </label>
                                            <input placeholder="" name="category_id" className="form-control" 
                                                value={this.state.category_id} onChange={this.changeCategoryIdHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateTransactionCategory}>Save</button>
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

export default TransactionCategoryCreateComponent;