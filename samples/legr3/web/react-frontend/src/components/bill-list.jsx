import React, { Component } from 'react'
import BillService from '../services/bill-service';

class BillListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                bills: []
        }
        this.addBill = this.addBill.bind(this);
        this.editBill = this.editBill.bind(this);
        this.deleteBill = this.deleteBill.bind(this);
    }

    deleteBill(id){
        BillService.deleteBill(id).then( res => {
            this.setState({ bills: this.state.bills.filter(bill => bill.id !== id) });
        });
    }
    viewBill(id){
        this.props.history.push(`/view-bill/${id}`);
    }
    editBill(id){
        console.log("editing " + id)
        this.props.history.push(`/add-bill/${id}`);
    }

    componentDidMount(){
        BillService.getBills().then((res) => {
            this.setState({ bills: res.data});
        });
    }

    addBill(){
        this.props.history.push('/add-bill/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Bill List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addBill}> Add Bill</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Bill ID</th>
                                    
                                    <th>Vendor </th>
                                    
                                    <th>Organization</th>
                                    
                                    <th>Number</th>
                                    
                                    <th>Bill Date</th>
                                    
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
                                    this.state.bills.map(
                                        bill => 
                                        <tr key = { bill.id }>

                                                <td> { bill.id } </td>  
                                                
                                                <td> { bill.vendor_id } </td>  
                                                
                                                <td> { bill.org_id } </td>  
                                                
                                                <td> { bill.bill_number } </td>  
                                                
                                                <td> { bill.bill_date } </td>  
                                                
                                                <td> { bill.due_date } </td>  
                                                
                                                <td> { bill.total_amount } </td>  
                                                
                                                <td> { bill.status } </td>  
                                                
                                                <td> { bill.created_date } </td>  
                                                
                                                <td> { bill.is_active } </td>  
                                                
                                                <td> { bill.created_by } </td>  
                                                
                                                <td> { bill.last_updated } </td>  
                                                
                                                <td> { bill.last_updated_by } </td>  
                                                
                                                <td> { bill.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editBill(bill.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteBill(bill.id)} className="btn btn-danger">Delete </button>
                                                
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

export default BillListComponent;