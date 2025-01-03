import React, { Component } from 'react'
import CustomerService from '../services/CustomerService';

class CustomerListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                customers: []
        }
        this.addCustomer = this.addCustomer.bind(this);
        this.editCustomer = this.editCustomer.bind(this);
        this.deleteCustomer = this.deleteCustomer.bind(this);
    }

    deleteCustomer(id){
        CustomerService.deleteCustomer(id).then( res => {
            this.setState({customers: this.state.customers.filter(customer => customer.id !== id)});
        });
    }
    viewCustomer(id){
        this.props.history.push(`/view-customer/${id}`);
    }
    editCustomer(id){
        console.log("editing " + id)
        this.props.history.push(`/add-customer/${id}`);
    }

    componentDidMount(){
        CustomerService.getCustomers().then((res) => {
            this.setState({ customers: res.data});
        });
    }

    addCustomer(){
        this.props.history.push('/add-customer/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Customer List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addCustomer}> Add Customer</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Customer ID</th>
                                    
                                    <th>Organization ID</th>
                                    
                                    <th>Name</th>
                                    
                                    <th>First</th>
                                    
                                    <th>Last</th>
                                    
                                    <th>Email</th>
                                    
                                    <th>Phone</th>
                                    
                                    <th>Billing Address</th>
                                    
                                    <th>Shipping Address</th>
                                    
                                    <th>Created</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.customers.map(
                                        customer => 
                                        <tr key = {@(Model.DomainVar).id}>

                                                <td> {customer.id)} </td>  
                                                
                                                <td> {customer.org_id)} </td>  
                                                
                                                <td> {customer.customer_name)} </td>  
                                                
                                                <td> {customer.first_name)} </td>  
                                                
                                                <td> {customer.last_name)} </td>  
                                                
                                                <td> {customer.email)} </td>  
                                                
                                                <td> {customer.phone)} </td>  
                                                
                                                <td> {customer.billing_address)} </td>  
                                                
                                                <td> {customer.shipping_address)} </td>  
                                                
                                                <td> {customer.created_date)} </td>  
                                                
                                                <td> {customer.is_active)} </td>  
                                                
                                                <td> {customer.created_by)} </td>  
                                                
                                                <td> {customer.last_updated)} </td>  
                                                
                                                <td> {customer.last_updated_by)} </td>  
                                                
                                                <td> {customer.version)} </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editCustomer(customer.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteCustomer(customer.id)} className="btn btn-danger">Delete </button>
                                                
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

export default CustomerListComponent;