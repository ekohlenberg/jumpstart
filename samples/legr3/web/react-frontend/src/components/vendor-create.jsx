import React, { Component } from 'react'
import VendorService from '../services/VendorService';



class VendorCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.match.params.id,

                    id: '' ,
                
                    org_id: '' ,
                
                    vendor_name: '' ,
                
                    first_name: '' ,
                
                    last_name: '' ,
                
                    email: '' ,
                
                    phone: '' ,
                
                    billing_address: '' ,
                
                    created_date: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeOrgIdHandler = this.changeOrgIdHandler.bind(this);
                                    
                    this.changeVendorNameHandler = this.changeVendorNameHandler.bind(this);
                                    
                    this.changeFirstNameHandler = this.changeFirstNameHandler.bind(this);
                                    
                    this.changeLastNameHandler = this.changeLastNameHandler.bind(this);
                                    
                    this.changeEmailHandler = this.changeEmailHandler.bind(this);
                                    
                    this.changePhoneHandler = this.changePhoneHandler.bind(this);
                                    
                    this.changeBillingAddressHandler = this.changeBillingAddressHandler.bind(this);
                                    
                    this.changeCreatedDateHandler = this.changeCreatedDateHandler.bind(this);
                        this.saveOrUpdateVendor = this.saveOrUpdateVendor.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Vendor componentDidMount() ID= " + this.state.id )
            VendorService.getVendorById(this.state.id).then( (res) =>{
                let vendor = res.data;
                this.setState({

                            id: vendor.id ,
                        
                            org_id: vendor.org_id ,
                        
                            vendor_name: vendor.vendor_name ,
                        
                            first_name: vendor.first_name ,
                        
                            last_name: vendor.last_name ,
                        
                            email: vendor.email ,
                        
                            phone: vendor.phone ,
                        
                            billing_address: vendor.billing_address ,
                        
                            created_date: vendor.created_date 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateVendor = (e) => {
        e.preventDefault();
        let vendor = {

                    id: this.state.id , 
                
                    org_id: this.state.org_id , 
                
                    vendor_name: this.state.vendor_name , 
                
                    first_name: this.state.first_name , 
                
                    last_name: this.state.last_name , 
                
                    email: this.state.email , 
                
                    phone: this.state.phone , 
                
                    billing_address: this.state.billing_address , 
                
                    created_date: this.state.created_date  
                        };
        console.log('vendor => ' + JSON.stringify(vendor));

        // step 5
        if(this.state.id === '_add'){
            VendorService.createVendor(vendor).then(res =>{
                this.props.history.push('/vendor');
            });
        }else{
            VendorService.updateVendor(vendor, this.state.id).then( res => {
                this.props.history.push('/vendor');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeOrgIdHandler= (event) => {
            this.setState({org_id: event.target.value});
        }
        
        changeVendorNameHandler= (event) => {
            this.setState({vendor_name: event.target.value});
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
        
        changeCreatedDateHandler= (event) => {
            this.setState({created_date: event.target.value});
        }
            cancel(){
        this.props.history.push('/vendor');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Vendor</h3>
        }else{
            return <h3 className="text-center">Update Vendor</h3>
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
                                            <label> Vendor : </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Organization: </label>
                                            <input placeholder="" name="org_id" className="form-control" 
                                                value={this.state.org_id} onChange={this.changeOrgIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Name: </label>
                                            <input placeholder="" name="vendor_name" className="form-control" 
                                                value={this.state.vendor_name} onChange={this.changeVendorNameHandler}/>
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
                                            <label> Created: </label>
                                            <input placeholder="" name="created_date" className="form-control" 
                                                value={this.state.created_date} onChange={this.changeCreatedDateHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateVendor}>Save</button>
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

export default VendorCreateComponent;