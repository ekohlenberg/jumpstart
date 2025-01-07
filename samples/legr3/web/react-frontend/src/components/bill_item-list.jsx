import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import BillItemService from '../services/bill_item-service';

class BillItemListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                billitems: []
        }
        this.addBillItem = this.addBillItem.bind(this);
        this.editBillItem = this.editBillItem.bind(this);
        this.deleteBillItem = this.deleteBillItem.bind(this);
    }

    deleteBillItem(id){
        BillItemService.deleteBillItem(id).then( res => {
            this.setState({ billitems: this.state.billitems.filter(billitem => billitem.id !== id) });
        });
    }
    viewBillItem(id){
        this.props.navigate(`/view-billitem/${id}`);
    }
    editBillItem(id){
        console.log("editing " + id)
        this.props.navigate(`/add-billitem/${id}`);
    }

    componentDidMount(){
        BillItemService.getBillItems().then((res) => {
            this.setState({ billitems: res.data});
        });
    }

    addBillItem(){
        this.props.navigate('/add-billitem/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">BillItem List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addBillItem}> Add BillItem</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Bill Item ID</th>
                                    
                                    <th>Bill ID</th>
                                    
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
                                    this.state.billitems.map(
                                        billitem => 
                                        <tr key = { billitem.id }>

                                                <td> { billitem.id } </td>  
                                                
                                                <td> { billitem.bill_id } </td>  
                                                
                                                <td> { billitem.description } </td>  
                                                
                                                <td> { billitem.quantity } </td>  
                                                
                                                <td> { billitem.unit_price } </td>  
                                                
                                                <td> { billitem.total_amount } </td>  
                                                
                                                <td> { billitem.is_active } </td>  
                                                
                                                <td> { billitem.created_by } </td>  
                                                
                                                <td> { billitem.last_updated } </td>  
                                                
                                                <td> { billitem.last_updated_by } </td>  
                                                
                                                <td> { billitem.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editBillItem(billitem.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteBillItem(billitem.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(BillItemListComponent);