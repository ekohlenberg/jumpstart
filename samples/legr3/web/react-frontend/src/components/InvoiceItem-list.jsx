import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import InvoiceItemService from '../services/invoice_item-service';

class InvoiceItemListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                invoiceitems: []
        }
        this.addInvoiceItem = this.addInvoiceItem.bind(this);
        this.editInvoiceItem = this.editInvoiceItem.bind(this);
        this.deleteInvoiceItem = this.deleteInvoiceItem.bind(this);
    }

    deleteInvoiceItem(id){
        InvoiceItemService.deleteInvoiceItem(id).then( res => {
            this.setState({ invoiceitems: this.state.invoiceitems.filter(invoiceitem => invoiceitem.id !== id) });
        });
    }
    viewInvoiceItem(id){
        this.props.navigate(`/view-invoiceitem/${id}`);
    }
    editInvoiceItem(id){
        console.log("editing " + id)
        this.props.navigate(`/add-invoiceitem/${id}`);
    }

    componentDidMount(){
        InvoiceItemService.getInvoiceItems().then((res) => {
            this.setState({ invoiceitems: res.data});
        });
    }

    addInvoiceItem(){
        this.props.navigate('/add-invoiceitem/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">InvoiceItem List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addInvoiceItem}> Add InvoiceItem</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Invoice Item ID</th>
                                    
                                    <th>Invoice ID</th>
                                    
                                    <th>Description</th>
                                    
                                    <th>Quantity</th>
                                    
                                    <th>Unit Price</th>
                                    
                                    <th>Total Amount</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.invoiceitems.map(
                                        invoiceitem => 
                                        <tr key = { invoiceitem.id }>

                                                <td> { invoiceitem.id } </td>  
                                                
                                                <td> { invoiceitem.invoice_id } </td>  
                                                
                                                <td> { invoiceitem.description } </td>  
                                                
                                                <td> { invoiceitem.quantity } </td>  
                                                
                                                <td> { invoiceitem.unit_price } </td>  
                                                
                                                <td> { invoiceitem.total_amount } </td>  
                                                
                                                <td> { invoiceitem.is_active } </td>  
                                                
                                                <td> { invoiceitem.created_by } </td>  
                                                
                                                <td> { invoiceitem.last_updated } </td>  
                                                
                                                <td> { invoiceitem.last_updated_by } </td>  
                                                
                                                <td> { invoiceitem.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editInvoiceItem(invoiceitem.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteInvoiceItem(invoiceitem.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(InvoiceItemListComponent);