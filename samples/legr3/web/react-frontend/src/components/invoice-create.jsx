import React, { Component } from 'react'
import InvoiceService from '../services/invoice-service';
import { withNavigation } from './with-navigation';


class InvoiceCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    customer_id: '' ,
                
                    org_id: '' ,
                
                    invoice_number: '' ,
                
                    invoice_date: '' ,
                
                    due_date: '' ,
                
                    total_amount: '' ,
                
                    status: '' ,
                
                    created_date: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeCustomerIdHandler = this.changeCustomerIdHandler.bind(this);
                                    
                    this.changeOrgIdHandler = this.changeOrgIdHandler.bind(this);
                                    
                    this.changeInvoiceNumberHandler = this.changeInvoiceNumberHandler.bind(this);
                                    
                    this.changeInvoiceDateHandler = this.changeInvoiceDateHandler.bind(this);
                                    
                    this.changeDueDateHandler = this.changeDueDateHandler.bind(this);
                                    
                    this.changeTotalAmountHandler = this.changeTotalAmountHandler.bind(this);
                                    
                    this.changeStatusHandler = this.changeStatusHandler.bind(this);
                                    
                    this.changeCreatedDateHandler = this.changeCreatedDateHandler.bind(this);
                        this.saveOrUpdateInvoice = this.saveOrUpdateInvoice.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Invoice componentDidMount() ID= " + this.state.id )
            InvoiceService.getInvoiceById(this.state.id).then( (res) =>{
                let invoice = res.data;
                this.setState({

                            id: invoice.id ,
                        
                            customer_id: invoice.customer_id ,
                        
                            org_id: invoice.org_id ,
                        
                            invoice_number: invoice.invoice_number ,
                        
                            invoice_date: invoice.invoice_date ,
                        
                            due_date: invoice.due_date ,
                        
                            total_amount: invoice.total_amount ,
                        
                            status: invoice.status ,
                        
                            created_date: invoice.created_date 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateInvoice = (e) => {
        e.preventDefault();
        let invoice = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    customer_id: this.state.customer_id , 
                            
                    org_id: this.state.org_id , 
                            
                    invoice_number: this.state.invoice_number , 
                            
                    invoice_date: this.state.invoice_date , 
                            
                    due_date: this.state.due_date , 
                            
                    total_amount: this.state.total_amount , 
                            
                    status: this.state.status , 
                            
                    created_date: this.state.created_date  
                        };
        console.log('invoice => ' + JSON.stringify(invoice));

        // step 5
        if(this.state.id === '_add'){
            InvoiceService.createInvoice(invoice).then(res =>{
                this.props.navigate('/invoice');
            });
        }else{
            InvoiceService.updateInvoice(invoice, this.state.id).then( res => {
                this.props.navigate('/invoice');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeCustomerIdHandler= (event) => {
            this.setState({customer_id: event.target.value});
        }
        
        changeOrgIdHandler= (event) => {
            this.setState({org_id: event.target.value});
        }
        
        changeInvoiceNumberHandler= (event) => {
            this.setState({invoice_number: event.target.value});
        }
        
        changeInvoiceDateHandler= (event) => {
            this.setState({invoice_date: event.target.value});
        }
        
        changeDueDateHandler= (event) => {
            this.setState({due_date: event.target.value});
        }
        
        changeTotalAmountHandler= (event) => {
            this.setState({total_amount: event.target.value});
        }
        
        changeStatusHandler= (event) => {
            this.setState({status: event.target.value});
        }
        
        changeCreatedDateHandler= (event) => {
            this.setState({created_date: event.target.value});
        }
            cancel(){
        this.props.navigate('/invoice');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Invoice</h3>
        }else{
            return <h3 className="text-center">Update Invoice</h3>
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
                                            <label> Invoice ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Customer: </label>
                                            <input placeholder="" name="customer_id" className="form-control" 
                                                value={this.state.customer_id} onChange={this.changeCustomerIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Organization: </label>
                                            <input placeholder="" name="org_id" className="form-control" 
                                                value={this.state.org_id} onChange={this.changeOrgIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Number: </label>
                                            <input placeholder="" name="invoice_number" className="form-control" 
                                                value={this.state.invoice_number} onChange={this.changeInvoiceNumberHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Invoice Date: </label>
                                            <input placeholder="" name="invoice_date" className="form-control" 
                                                value={this.state.invoice_date} onChange={this.changeInvoiceDateHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Due Date: </label>
                                            <input placeholder="" name="due_date" className="form-control" 
                                                value={this.state.due_date} onChange={this.changeDueDateHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Total Amount: </label>
                                            <input placeholder="" name="total_amount" className="form-control" 
                                                value={this.state.total_amount} onChange={this.changeTotalAmountHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Status: </label>
                                            <input placeholder="" name="status" className="form-control" 
                                                value={this.state.status} onChange={this.changeStatusHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Created: </label>
                                            <input placeholder="" name="created_date" className="form-control" 
                                                value={this.state.created_date} onChange={this.changeCreatedDateHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateInvoice}>Save</button>
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

export default withNavigation(InvoiceCreateComponent);