import React, { Component } from 'react'
import PaymentService from '../services/payment-service';



class PaymentCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.match.params.id,

                    id: '' ,
                
                    invoice_id: '' ,
                
                    org_id: '' ,
                
                    payment_date: '' ,
                
                    amount: '' ,
                
                    payment_method: '' ,
                
                    created_date: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeInvoiceIdHandler = this.changeInvoiceIdHandler.bind(this);
                                    
                    this.changeOrgIdHandler = this.changeOrgIdHandler.bind(this);
                                    
                    this.changePaymentDateHandler = this.changePaymentDateHandler.bind(this);
                                    
                    this.changeAmountHandler = this.changeAmountHandler.bind(this);
                                    
                    this.changePaymentMethodHandler = this.changePaymentMethodHandler.bind(this);
                                    
                    this.changeCreatedDateHandler = this.changeCreatedDateHandler.bind(this);
                        this.saveOrUpdatePayment = this.saveOrUpdatePayment.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Payment componentDidMount() ID= " + this.state.id )
            PaymentService.getPaymentById(this.state.id).then( (res) =>{
                let payment = res.data;
                this.setState({

                            id: payment.id ,
                        
                            invoice_id: payment.invoice_id ,
                        
                            org_id: payment.org_id ,
                        
                            payment_date: payment.payment_date ,
                        
                            amount: payment.amount ,
                        
                            payment_method: payment.payment_method ,
                        
                            created_date: payment.created_date 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdatePayment = (e) => {
        e.preventDefault();
        let payment = {

                    id: this.state.id , 
                
                    invoice_id: this.state.invoice_id , 
                
                    org_id: this.state.org_id , 
                
                    payment_date: this.state.payment_date , 
                
                    amount: this.state.amount , 
                
                    payment_method: this.state.payment_method , 
                
                    created_date: this.state.created_date  
                        };
        console.log('payment => ' + JSON.stringify(payment));

        // step 5
        if(this.state.id === '_add'){
            PaymentService.createPayment(payment).then(res =>{
                this.props.history.push('/payment');
            });
        }else{
            PaymentService.updatePayment(payment, this.state.id).then( res => {
                this.props.history.push('/payment');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeInvoiceIdHandler= (event) => {
            this.setState({invoice_id: event.target.value});
        }
        
        changeOrgIdHandler= (event) => {
            this.setState({org_id: event.target.value});
        }
        
        changePaymentDateHandler= (event) => {
            this.setState({payment_date: event.target.value});
        }
        
        changeAmountHandler= (event) => {
            this.setState({amount: event.target.value});
        }
        
        changePaymentMethodHandler= (event) => {
            this.setState({payment_method: event.target.value});
        }
        
        changeCreatedDateHandler= (event) => {
            this.setState({created_date: event.target.value});
        }
            cancel(){
        this.props.history.push('/payment');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Payment</h3>
        }else{
            return <h3 className="text-center">Update Payment</h3>
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
                                            <label> Payment ID: </label>
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
                                            <label> Organization ID: </label>
                                            <input placeholder="" name="org_id" className="form-control" 
                                                value={this.state.org_id} onChange={this.changeOrgIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Payment Date: </label>
                                            <input placeholder="" name="payment_date" className="form-control" 
                                                value={this.state.payment_date} onChange={this.changePaymentDateHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Amount: </label>
                                            <input placeholder="" name="amount" className="form-control" 
                                                value={this.state.amount} onChange={this.changeAmountHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Payment Method: </label>
                                            <input placeholder="" name="payment_method" className="form-control" 
                                                value={this.state.payment_method} onChange={this.changePaymentMethodHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Created Date: </label>
                                            <input placeholder="" name="created_date" className="form-control" 
                                                value={this.state.created_date} onChange={this.changeCreatedDateHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdatePayment}>Save</button>
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

export default PaymentCreateComponent;