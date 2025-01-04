import React, { Component } from 'react'
import PaymentService from '../services/payment-service';

class PaymentListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                payments: []
        }
        this.addPayment = this.addPayment.bind(this);
        this.editPayment = this.editPayment.bind(this);
        this.deletePayment = this.deletePayment.bind(this);
    }

    deletePayment(id){
        PaymentService.deletePayment(id).then( res => {
            this.setState({ payments: this.state.payments.filter(payment => payment.id !== id) });
        });
    }
    viewPayment(id){
        this.props.history.push(`/view-payment/${id}`);
    }
    editPayment(id){
        console.log("editing " + id)
        this.props.history.push(`/add-payment/${id}`);
    }

    componentDidMount(){
        PaymentService.getPayments().then((res) => {
            this.setState({ payments: res.data});
        });
    }

    addPayment(){
        this.props.history.push('/add-payment/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Payment List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addPayment}> Add Payment</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Payment ID</th>
                                    
                                    <th>Invoice ID</th>
                                    
                                    <th>Organization ID</th>
                                    
                                    <th>Payment Date</th>
                                    
                                    <th>Amount</th>
                                    
                                    <th>Payment Method</th>
                                    
                                    <th>Created Date</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.payments.map(
                                        payment => 
                                        <tr key = { payment.id }>

                                                <td> { payment.id } </td>  
                                                
                                                <td> { payment.invoice_id } </td>  
                                                
                                                <td> { payment.org_id } </td>  
                                                
                                                <td> { payment.payment_date } </td>  
                                                
                                                <td> { payment.amount } </td>  
                                                
                                                <td> { payment.payment_method } </td>  
                                                
                                                <td> { payment.created_date } </td>  
                                                
                                                <td> { payment.is_active } </td>  
                                                
                                                <td> { payment.created_by } </td>  
                                                
                                                <td> { payment.last_updated } </td>  
                                                
                                                <td> { payment.last_updated_by } </td>  
                                                
                                                <td> { payment.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editPayment(payment.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deletePayment(payment.id)} className="btn btn-danger">Delete </button>
                                                
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

export default PaymentListComponent;