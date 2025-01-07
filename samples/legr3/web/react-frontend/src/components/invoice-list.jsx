import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import InvoiceService from '../services/invoice-service';

class InvoiceListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                invoices: []
        }
        this.addInvoice = this.addInvoice.bind(this);
        this.editInvoice = this.editInvoice.bind(this);
        this.deleteInvoice = this.deleteInvoice.bind(this);
    }

    deleteInvoice(id){
        InvoiceService.deleteInvoice(id).then( res => {
            this.setState({ invoices: this.state.invoices.filter(invoice => invoice.id !== id) });
        });
    }
    viewInvoice(id){
        this.props.navigate(`/view-invoice/${id}`);
    }
    editInvoice(id){
        console.log("editing " + id)
        this.props.navigate(`/add-invoice/${id}`);
    }

    componentDidMount(){
        InvoiceService.getInvoices().then((res) => {
            this.setState({ invoices: res.data});
        });
    }

    addInvoice(){
        this.props.navigate('/add-invoice/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Invoice List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addInvoice}> Add Invoice</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Invoice ID</th>
                                    
                                    <th>Customer</th>
                                    
                                    <th>Organization</th>
                                    
                                    <th>Number</th>
                                    
                                    <th>Invoice Date</th>
                                    
                                    <th>Due Date</th>
                                    
                                    <th>Total Amount</th>
                                    
                                    <th>Status</th>
                                    
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
                                    this.state.invoices.map(
                                        invoice => 
                                        <tr key = { invoice.id }>

                                                <td> { invoice.id } </td>  
                                                
                                                <td> { invoice.customer_id } </td>  
                                                
                                                <td> { invoice.org_id } </td>  
                                                
                                                <td> { invoice.invoice_number } </td>  
                                                
                                                <td> { invoice.invoice_date } </td>  
                                                
                                                <td> { invoice.due_date } </td>  
                                                
                                                <td> { invoice.total_amount } </td>  
                                                
                                                <td> { invoice.status } </td>  
                                                
                                                <td> { invoice.created_date } </td>  
                                                
                                                <td> { invoice.is_active } </td>  
                                                
                                                <td> { invoice.created_by } </td>  
                                                
                                                <td> { invoice.last_updated } </td>  
                                                
                                                <td> { invoice.last_updated_by } </td>  
                                                
                                                <td> { invoice.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editInvoice(invoice.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteInvoice(invoice.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(InvoiceListComponent);