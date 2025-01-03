import React, { Component } from 'react'
import CustomerService from '../services/CustomerService';



class CustomerCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.match.params.id,

                    id: '' ,
                
                    org_id: '' ,
                
                    customer_name: '' ,
                
                    first_name: '' ,
                
                    last_name: '' ,
                
                    email: '' ,
                
                    phone: '' ,
                
                    billing_address: '' ,
                
                    shipping_address: '' ,
                
                    created_date: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeOrgIdHandler = this.changeOrgIdHandler.bind(this);
                                    
                    this.changeCustomerNameHandler = this.changeCustomerNameHandler.bind(this);
                                    
                    this.changeFirstNameHandler = this.changeFirstNameHandler.bind(this);
                                    
                    this.changeLastNameHandler = this.changeLastNameHandler.bind(this);
                                    
                    this.changeEmailHandler = this.changeEmailHandler.bind(this);
                                    
                    this.changePhoneHandler = this.changePhoneHandler.bind(this);
                                    
                    this.changeBillingAddressHandler = this.changeBillingAddressHandler.bind(this);
                                    
                    this.changeShippingAddressHandler = this.changeShippingAddressHandler.bind(this);
                                    
                    this.changeCreatedDateHandler = this.changeCreatedDateHandler.bind(this);
                        this.saveOrUpdateCustomer = this.saveOrUpdateCustomer.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Customer componentDidMount() ID= " + this.state.id )
            CustomerService.getCustomerById(this.state.id).then( (res) =>{
                let customer = res.data;
                this.setState({

                            id: customer.id ,
                        
                            org_id: customer.org_id ,
                        
                            customer_name: customer.customer_name ,
                        
                            first_name: customer.first_name ,
                        
                            last_name: customer.last_name ,
                        
                            email: customer.email ,
                        
                            phone: customer.phone ,
                        
                            billing_address: customer.billing_address ,
                        
                            shipping_address: customer.shipping_address ,
                        
                            created_date: customer.created_date 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateCustomer = (e) => {
        e.preventDefault();
        let customer = {

                    id: this.state.id , 
                
                    org_id: this.state.org_id , 
                
                    customer_name: this.state.customer_name , 
                
                    first_name: this.state.first_name , 
                
                    last_name: this.state.last_name , 
                
                    email: this.state.email , 
                
                    phone: this.state.phone , 
                
                    billing_address: this.state.billing_address , 
                
                    shipping_address: this.state.shipping_address , 
                
                    created_date: this.state.created_date  
                        };
        console.log('customer => ' + JSON.stringify(customer));

        // step 5
        if(this.state.id === '_add'){
            CustomerService.createCustomer(customer).then(res =>{
                this.props.history.push('/customer');
            });
        }else{
            CustomerService.updateCustomer(customer, this.state.id).then( res => {
                this.props.history.push('/customer');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeOrgIdHandler= (event) => {
            this.setState({org_id: event.target.value});
        }
        
        changeCustomerNameHandler= (event) => {
            this.setState({customer_name: event.target.value});
        }
        
        changeFirstNameHandler= (event) => {
            this.setState({first_name: event.target.value});
        }
        
        changeLastNameHandler= (event) => {
            this.setState({last_name: event.target.value});
        }
        
        changeEmailHandler= (event) => {
            this.setState({email: event.target.value});
        }
        
        changePhoneHandler= (event) => {
            this.setState({phone: event.target.value});
        }
        
        changeBillingAddressHandler= (event) => {
            this.setState({billing_address: event.target.value});
        }
        
        changeShippingAddressHandler= (event) => {
            this.setState({shipping_address: event.target.value});
        }
        
        changeCreatedDateHandler= (event) => {
            this.setState({created_date: event.target.value});
        }
            cancel(){
        this.props.history.push('/customer');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Customer</h3>
        }else{
            return <h3 className="text-center">Update Customer</h3>
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
                                            <label> Customer ID: </label>
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
                                            <label> Name: </label>
                                            <input placeholder="" name="customer_name" className="form-control" 
                                                value={this.state.customer_name} onChange={this.changeCustomerNameHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> First: </label>
                                            <input placeholder="" name="first_name" className="form-control" 
                                                value={this.state.first_name} onChange={this.changeFirstNameHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Last: </label>
                                            <input placeholder="" name="last_name" className="form-control" 
                                                value={this.state.last_name} onChange={this.changeLastNameHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Email: </label>
                                            <input placeholder="" name="email" className="form-control" 
                                                value={this.state.email} onChange={this.changeEmailHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Phone: </label>
                                            <input placeholder="" name="phone" className="form-control" 
                                                value={this.state.phone} onChange={this.changePhoneHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Billing Address: </label>
                                            <input placeholder="" name="billing_address" className="form-control" 
                                                value={this.state.billing_address} onChange={this.changeBillingAddressHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Shipping Address: </label>
                                            <input placeholder="" name="shipping_address" className="form-control" 
                                                value={this.state.shipping_address} onChange={this.changeShippingAddressHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Created: </label>
                                            <input placeholder="" name="created_date" className="form-control" 
                                                value={this.state.created_date} onChange={this.changeCreatedDateHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateCustomer}>Save</button>
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

export default CustomerCreateComponent;