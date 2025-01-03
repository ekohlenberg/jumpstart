import React, { Component } from 'react'
import InvoiceItemService from '../services/InvoiceItemService';



class InvoiceItemCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.match.params.id,

                    id: '' ,
                
                    invoice_id: '' ,
                
                    description: '' ,
                
                    quantity: '' ,
                
                    unit_price: '' ,
                
                    total_amount: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeInvoiceIdHandler = this.changeInvoiceIdHandler.bind(this);
                                    
                    this.changeDescriptionHandler = this.changeDescriptionHandler.bind(this);
                                    
                    this.changeQuantityHandler = this.changeQuantityHandler.bind(this);
                                    
                    this.changeUnitPriceHandler = this.changeUnitPriceHandler.bind(this);
                                    
                    this.changeTotalAmountHandler = this.changeTotalAmountHandler.bind(this);
                        this.saveOrUpdateInvoiceItem = this.saveOrUpdateInvoiceItem.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("InvoiceItem componentDidMount() ID= " + this.state.id )
            InvoiceItemService.getInvoiceItemById(this.state.id).then( (res) =>{
                let invoiceitem = res.data;
                this.setState({

                            id: invoiceitem.id ,
                        
                            invoice_id: invoiceitem.invoice_id ,
                        
                            description: invoiceitem.description ,
                        
                            quantity: invoiceitem.quantity ,
                        
                            unit_price: invoiceitem.unit_price ,
                        
                            total_amount: invoiceitem.total_amount 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateInvoiceItem = (e) => {
        e.preventDefault();
        let invoiceitem = {

                    id: this.state.id , 
                
                    invoice_id: this.state.invoice_id , 
                
                    description: this.state.description , 
                
                    quantity: this.state.quantity , 
                
                    unit_price: this.state.unit_price , 
                
                    total_amount: this.state.total_amount  
                        };
        console.log('invoiceitem => ' + JSON.stringify(invoiceitem));

        // step 5
        if(this.state.id === '_add'){
            InvoiceItemService.createInvoiceItem(invoiceitem).then(res =>{
                this.props.history.push('/invoiceitem');
            });
        }else{
            InvoiceItemService.updateInvoiceItem(invoiceitem, this.state.id).then( res => {
                this.props.history.push('/invoiceitem');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeInvoiceIdHandler= (event) => {
            this.setState({invoice_id: event.target.value});
        }
        
        changeDescriptionHandler= (event) => {
            this.setState({description: event.target.value});
        }
        
        changeQuantityHandler= (event) => {
            this.setState({quantity: event.target.value});
        }
        
        changeUnitPriceHandler= (event) => {
            this.setState({unit_price: event.target.value});
        }
        
        changeTotalAmountHandler= (event) => {
            this.setState({total_amount: event.target.value});
        }
            cancel(){
        this.props.history.push('/invoiceitem');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add InvoiceItem</h3>
        }else{
            return <h3 className="text-center">Update InvoiceItem</h3>
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
                                            <label> Invoice Item ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Invoice ID: </label>
                                            <input placeholder="" name="invoice_id" className="form-control" 
                                                value={this.state.invoice_id} onChange={this.changeInvoiceIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Description: </label>
                                            <input placeholder="" name="description" className="form-control" 
                                                value={this.state.description} onChange={this.changeDescriptionHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Quantity: </label>
                                            <input placeholder="" name="quantity" className="form-control" 
                                                value={this.state.quantity} onChange={this.changeQuantityHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Unit Price: </label>
                                            <input placeholder="" name="unit_price" className="form-control" 
                                                value={this.state.unit_price} onChange={this.changeUnitPriceHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Total Amount: </label>
                                            <input placeholder="" name="total_amount" className="form-control" 
                                                value={this.state.total_amount} onChange={this.changeTotalAmountHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateInvoiceItem}>Save</button>
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

export default InvoiceItemCreateComponent;